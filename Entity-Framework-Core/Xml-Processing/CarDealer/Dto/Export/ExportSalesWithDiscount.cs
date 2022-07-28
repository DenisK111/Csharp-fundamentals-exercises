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
    public partial class ExportSalesWithDiscount
    {

        private salesSale[] saleField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("sale")]
        public salesSale[] sale
        {
            get
            {
                return this.saleField;
            }
            set
            {
                this.saleField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
   [XmlType("sale")]
    public partial class salesSale
    {

        private salesSaleCar carField;

        private decimal discountField;

        private string customernameField;

        private decimal priceField;

        private decimal pricewithdiscountField;

        /// <remarks/>
        public salesSaleCar car
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

        /// <remarks/>
        public decimal discount
        {
            get
            {
                return this.discountField;
            }
            set
            {
                this.discountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("customer-name")]
        public string customername
        {
            get
            {
                return this.customernameField;
            }
            set
            {
                this.customernameField = value;
            }
        }

        /// <remarks/>
        public decimal price
        {
            get
            {
                return this.priceField;
            }
            set
            {
                this.priceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("price-with-discount")]
        public decimal pricewithdiscount
        {
            get
            {
                return this.pricewithdiscountField;
            }
            set
            {
                this.pricewithdiscountField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class salesSaleCar
    {

        private string makeField;

        private string modelField;

        private long travelleddistanceField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
        [System.Xml.Serialization.XmlAttributeAttribute("travelled-distance")]
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
