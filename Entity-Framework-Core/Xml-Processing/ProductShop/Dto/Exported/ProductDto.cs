using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dto.Exported
{


    public class ProductDto
    {
        [XmlElement("Product")]
       public Exported5[] Products { get; set; }
    }
}
