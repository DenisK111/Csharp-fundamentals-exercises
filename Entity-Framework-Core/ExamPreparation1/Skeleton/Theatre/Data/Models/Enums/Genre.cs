using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace Theatre.Data.Models.Enums
{
    [Serializable]
    public enum Genre
    {

        Drama,
        Comedy,
        Romance,
        Musical
    }
}
