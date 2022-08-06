using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using Theatre.Data.Models.Enums;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class ImportPlaysRealXmlDto
    {
        [XmlElement]
        [StringLength(50, MinimumLength = 4)]
        public string Title { get; set; }
        [XmlElement]
       
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "c")]
        public string Duration { get; set; }
        [XmlElement]
        public float Rating { get; set; }
        [XmlElement]
        
        public string Genre { get; set; }

        [XmlElement]
        [MaxLength(700)]
        public string Description { get; set; }

        [XmlElement]
        [StringLength(30, MinimumLength = 4)]
        public string Screenwriter { get; set; }
        /*<Title>The Hsdfoming</Title>
    <Duration>03:40:00</Duration>
    <Rating>8.2</Rating>
    <Genre>Action</Genre>
    <Description>A guyat Pinter turns into a debatable conundrum as oth ordinary and menacing. Much of this has to do with the fabled "Pinter Pause," which simply mirrors the way we often respond to each other in conversation, tossing in remainders of thoughts on one subject well after having moved on to another.</Description>
    <Screenwriter>Roger Nciotti</Screenwriter>
*/
    }
}
