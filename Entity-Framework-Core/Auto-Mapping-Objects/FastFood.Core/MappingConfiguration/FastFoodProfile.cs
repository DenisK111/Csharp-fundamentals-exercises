namespace FastFood.Core.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Core.ViewModels.Categories;
    using FastFood.Core.ViewModels.Employees;
    using FastFood.Core.ViewModels.Items;
    using FastFood.Core.ViewModels.Orders;
    using FastFood.Models;
    using System;
    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            //Orders

            this.CreateMap<CreateOrderInputModel, Order>()
                .ForMember(x=>x.DateTime,y=>y.MapFrom(s=> DateTime.Now));

            this.CreateMap<CreateOrderViewModel, Order>();
                            
            this.CreateMap<Order, OrderAllViewModel>()
                .ForMember(x=>x.Employee,y=>y.MapFrom(s=>s.Employee.Name))
                .ForMember(x=>x.DateTime,y=>y.MapFrom(s=>s.DateTime.ToString("dd-MM-yyyy hh:mm:ss tt")))
                .ForMember(x=>x.OrderId,y=>y.MapFrom(s=>s.Id));

            //Items

            this.CreateMap<CreateItemInputModel, Item>();
           
                
            this.CreateMap<Category, CreateItemViewModel>()
                .ForMember(x=>x.CategoryId,y=>y.MapFrom(s=>s.Id));
            this.CreateMap<CreateItemViewModel, Item>();
              
            this.CreateMap<Item,ItemsAllViewModels>()
                .ForMember(x=>x.Category,y=>y.MapFrom(s=>s.Category.Name));

            //Employees

            this.CreateMap<RegisterEmployeeInputModel, Employee>();

          //  this.CreateMap<Employee, RegisterEmployeeViewModel>();
                
         

            this.CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(x=>x.PositionId,y=>y.MapFrom(s=>s.Id)
                );
               
            this.CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(x=>x.Position,y=>y.MapFrom(s=>s.Position.Name));
                
       

            //Categories

            this.CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(m=>m.Name,y=>y.MapFrom(y=>y.CategoryName));
            this.CreateMap<Category, CategoryAllViewModel>()
                .ForMember(m=>m.Name,y=>y.MapFrom(s=>s.Name));
        }
    }
}
