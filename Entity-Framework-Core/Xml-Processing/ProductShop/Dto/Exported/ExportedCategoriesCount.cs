using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dto.Exported
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ExportedCategoriesCount
    {

        private CategoriesCategory[] categoryField;

      

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Category")]
        public CategoriesCategory[] Category
        {
            get
            {
                return this.categoryField;
            }
            set
            {
                this.categoryField = value;
            }
        }

        /// <remarks/>
     
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType("Category")]
    public partial class CategoriesCategory
    {

        private string nameField;

        private int countField;

        private decimal averagePriceField;

        private decimal totalRevenueField;

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
        public int count
        {
            get
            {
                return this.countField;
            }
            set
            {
                this.countField = value;
            }
        }

        /// <remarks/>
        public decimal averagePrice
        {
            get
            {
                return this.averagePriceField;
            }
            set
            {
                this.averagePriceField = value;
            }
        }

        /// <remarks/>
        public decimal totalRevenue
        {
            get
            {
                return this.totalRevenueField;
            }
            set
            {
                this.totalRevenueField = value;
            }
        }
    }


}
