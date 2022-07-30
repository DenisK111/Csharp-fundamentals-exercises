using Data;
using Services.Contracts;
using Models;
using Microsoft.EntityFrameworkCore;

namespace Services.Services
{
    public class TagService : ITagService
    {

        private readonly RealEstateContext context;

        public TagService(RealEstateContext context)
        {
            this.context = context;
        }
        public void Add(string tagName)
        {
            var tag = new Tag { Name = tagName };
            context.Tags.Add(tag);
            context.SaveChanges();
            tag = context.Tags.First(t => t.Name == tagName);


            var avaragePrice = context.Properties.Where(p=>p.Price.HasValue).Average(p => p.Price);
            var properties = context.Properties.ToList();

          

            switch (tag.Name.ToLower().Trim())
            {
                case "евтин имот": AddCheapPropertyTag(tag, (double)avaragePrice!, properties); break;
                case "скъп имот": AddExpensivePropertyTag(tag, (double)avaragePrice!, properties); break;
                case "нисък етаж имот": AddLowFloorTag(tag, properties); break;
                case "добра гледка": AddNiceViewTag(tag, properties); break;
                case "последен етаж": AddTopFloorTag(tag, properties); break;
                default:break;
            }
                                   
                
            

        }

        private void AddNiceViewTag(Tag tag, List<Property> properties)
        {
            foreach (var property in properties)
            {
                if (property.Floor >= 5)
                {
                    property.Tags.Add(tag);
                }
            }

            Console.WriteLine("Added tag!");

            context.SaveChanges();
        }

        private void AddTopFloorTag(Tag tag, List<Property> properties)
        {
            foreach (var property in properties)
            {
                if (property.Floor == property.TotalFloors)
                {
                    property.Tags.Add(tag);
                }
            }
            Console.WriteLine("Added tag!");
            context.SaveChanges();
        }

        private void AddLowFloorTag(Tag tag, List<Property> properties)
        {
            foreach (var property in properties)
            {
                if (property.Floor < 3)
                {
                    property.Tags.Add(tag);
                }
            }

            context.SaveChanges();
        }

        private void AddCheapPropertyTag(Tag tag, double avaragePrice, List<Property> properties)
        {
            foreach (var property in properties)
            {
                if (property.Price < avaragePrice)
                {
                    property.Tags.Add(tag);
                }
            }
            Console.WriteLine("Added tag!");
            context.SaveChanges();
        }

        private void AddExpensivePropertyTag(Tag tag, double avaragePrice, List<Property> properties)
        {
            foreach (var property in properties)
            {
                if (property.Price >= avaragePrice)
                {
                    property.Tags.Add(tag);
                }
            }
            Console.WriteLine("Added tag!");
            context.SaveChanges();
        }
    }
}
