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
    public partial class ImportCategoryProductDto
    {

        private CategoryProductsCategoryProduct[] categoryProductField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CategoryProduct")]
        public CategoryProductsCategoryProduct[] CategoryProduct
        {
            get
            {
                return this.categoryProductField;
            }
            set
            {
                this.categoryProductField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CategoryProductsCategoryProduct
    {

        private int categoryIdField;

        private int productIdField;

        /// <remarks/>
        public int CategoryId
        {
            get
            {
                return this.categoryIdField;
            }
            set
            {
                this.categoryIdField = value;
            }
        }

        /// <remarks/>
        public int ProductId
        {
            get
            {
                return this.productIdField;
            }
            set
            {
                this.productIdField = value;
            }
        }
    }


}
