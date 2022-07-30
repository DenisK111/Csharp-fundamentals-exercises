namespace Services.Models.ImportDtos
{
    public interface IProperty
    {
        string BuildingType { get; set; }
        string District { get; set; }
        byte Floor { get; set; }
        int Price { get; set; }
        int Size { get; set; }
        byte TotalFloors { get; set; }
        string Type { get; set; }
        int YardSize { get; set; }
        int Year { get; set; }
    }
}