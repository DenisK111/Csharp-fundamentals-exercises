using System;
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
    public partial class ExportTotalSalesDto
    {

        private customersCustomer[] customerField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("customer")]
        public customersCustomer[] customer
        {
            get
            {
                return this.customerField;
            }
            set
            {
                this.customerField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    
    [XmlType("customer")]
    public partial class customersCustomer
    {

        private string fullnameField;

        private int boughtcarsField;

        private decimal spentmoneyField;

      
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("full-name")]
        public string fullname
        {
            get
            {
                return this.fullnameField;
            }
            set
            {
                this.fullnameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("bought-cars")]
        public int boughtcars
        {
            get
            {
                return this.boughtcarsField;
            }
            set
            {
                this.boughtcarsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("spent-money")]
        public decimal spentmoney
        {
            get
            {
                return this.spentmoneyField;
            }
            set
            {
                this.spentmoneyField = value;
            }
        }
    }


}
