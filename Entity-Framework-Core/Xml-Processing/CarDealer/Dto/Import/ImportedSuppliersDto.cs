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
    public partial class ImportedSuppliersDto
    {

        private SuppliersSupplier[] supplierField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Supplier")]
        public SuppliersSupplier[] Supplier
        {
            get
            {
                return this.supplierField;
            }
            set
            {
                this.supplierField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SuppliersSupplier
    {

        private string nameField;

        private bool isImporterField;

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
        public bool isImporter
        {
            get
            {
                return this.isImporterField;
            }
            set
            {
                this.isImporterField = value;
            }
        }
    }


}
