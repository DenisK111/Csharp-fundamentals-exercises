﻿using SIS.HTTP.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFramework.Attributes
{
    public class HttpPostAttribute : BaseAttribute
    {
        public HttpPostAttribute()
        {

        }

        public HttpPostAttribute(string url)
        {
            this.Url=url;
        }
        public override HttpRequestMethod Method => HttpRequestMethod.Post;
    }
}
