﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dto.Export
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ExportedCarsWithDistance
    {

        private carsCar[] carField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("car")]
        public carsCar[] car
        {
            get
            {
                return this.carField;
            }
            set
            {
                this.carField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType("car")]
    public partial class carsCar
    {

        private string makeField;

        private string modelField;

        private long travelleddistanceField;

        /// <remarks/>
        public string make
        {
            get
            {
                return this.makeField;
            }
            set
            {
                this.makeField = value;
            }
        }

        /// <remarks/>
        public string model
        {
            get
            {
                return this.modelField;
            }
            set
            {
                this.modelField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("travelled-distance")]
        public long travelleddistance
        {
            get
            {
                return this.travelleddistanceField;
            }
            set
            {
                this.travelleddistanceField = value;
            }
        }
    }


}
