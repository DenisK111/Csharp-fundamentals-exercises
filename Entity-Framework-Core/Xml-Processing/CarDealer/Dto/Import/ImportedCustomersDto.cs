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
    public partial class ImportedCustomersDto
    {

        private CustomersCustomer[] customerField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Customer")]
        public CustomersCustomer[] Customer
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CustomersCustomer
    {

        private string nameField;

        private System.DateTime birthDateField;

        private bool isYoungDriverField;

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
        public System.DateTime birthDate
        {
            get
            {
                return this.birthDateField;
            }
            set
            {
                this.birthDateField = value;
            }
        }

        /// <remarks/>
        public bool isYoungDriver
        {
            get
            {
                return this.isYoungDriverField;
            }
            set
            {
                this.isYoungDriverField = value;
            }
        }
    }


}
