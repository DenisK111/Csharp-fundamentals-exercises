using Data;
using Newtonsoft.Json;
using Services.Models.ImportDtos;
using Services.Services;

namespace Importer
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var json = File.ReadAllText("../../../ApartmentsData.json");
            ImportJson(json);
            json = File.ReadAllText("../../../HouseData.json");
            ImportJson(json);

        }

        internal static void ImportJson(string Json)
        {
            var deserialised = JsonConvert.DeserializeObject<PropertyDto[]>(Json);

            using var context = new RealEstateContext();
            var addRangeService = new PropertyService(context);
            addRangeService.AddRange(deserialised!);


        }
    }
}