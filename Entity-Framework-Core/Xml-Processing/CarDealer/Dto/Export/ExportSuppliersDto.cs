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
    public partial class suppliers
    {

        private suppliersSuplier[] suplierField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("suplier")]
        public suppliersSuplier[] suplier
        {
            get
            {
                return this.suplierField;
            }
            set
            {
                this.suplierField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]

    [XmlType("suplier")]
    public partial class suppliersSuplier
    {

        private int idField;

        private string nameField;

        private int partscountField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
        [System.Xml.Serialization.XmlAttributeAttribute("parts-count")]
        public int partscount
        {
            get
            {
                return this.partscountField;
            }
            set
            {
                this.partscountField = value;
            }
        }
    }


}
