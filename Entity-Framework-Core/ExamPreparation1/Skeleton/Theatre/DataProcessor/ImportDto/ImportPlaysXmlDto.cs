using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Cast")]
    public class ImportPlaysXmlDto
    {
        [XmlElement]
        [StringLength(30, MinimumLength = 4)]
        public string FullName { get; set; }

        [XmlElement]
        public bool IsMainCharacter { get; set; }

        [XmlElement]
        [RegularExpression(@"^\+\d{2}-\d{2}-\d{3}-\d{4}$")]
        public string PhoneNumber { get; set; }

        [XmlElement]
        
        public int PlayId { get; set; }
        /*<Cast>
            <FullName>Van Tyson</FullName>
            <IsMainCharacter>false</IsMainCharacter>
            <PhoneNumber>+44-35-745-2774</PhoneNumber>
            <PlayId>26</PlayId>
          </Cast>
        */
    }
}
