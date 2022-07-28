using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Dto.Import
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ImportedSalesDto
    {

        private SalesSale[] saleField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Sale")]
        public SalesSale[] Sale
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SalesSale
    {

        private int carIdField;

        private int customerIdField;

        private decimal discountField;

        /// <remarks/>
        public int carId
        {
            get
            {
                return this.carIdField;
            }
            set
            {
                this.carIdField = value;
            }
        }

        /// <remarks/>
        public int customerId
        {
            get
            {
                return this.customerIdField;
            }
            set
            {
                this.customerIdField = value;
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
    }


}
