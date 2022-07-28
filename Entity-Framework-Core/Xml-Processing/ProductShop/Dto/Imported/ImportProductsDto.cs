using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.Dto.Imported
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ImportProductsDto
    {

        private ProductsProduct[] productField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Product")]
        public ProductsProduct[] Product
        {
            get
            {
                return this.productField;
            }
            set
            {
                this.productField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ProductsProduct
    {

        private string nameField;

        private decimal priceField;

        private int sellerIdField;

        private int? buyerIdField;

        private bool buyerIdFieldSpecified;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
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
        public int sellerId
        {
            get
            {
                return this.sellerIdField;
            }
            set
            {
                this.sellerIdField = value;
            }
        }

        /// <remarks/>
        public int? buyerId
        {
            get
            {
                return this.buyerIdField;
            }
            set
            {
                this.buyerIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool buyerIdSpecified
        {
            get
            {
                return this.buyerIdFieldSpecified;
            }
            set
            {
                this.buyerIdFieldSpecified = value;
            }
        }
    }


}
