using System.Xml.Serialization;

namespace ProductShop.Dto.Exported
{
    public class Exported5
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("price")]
        public decimal Price { get; set; }
        [XmlElement("buyer")]
        public string Buyer { get; set; }
    }
}
