using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_Client_Demo
{
    internal class TweetModel
    {
        public int Id { get; set; }


        public string Name { get; set; } = null!;

        public string Tweet { get; set; } = null!;
    }
}
