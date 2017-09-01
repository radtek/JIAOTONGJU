using DYApp.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DYApp.WebApi.Msg
{
    public class DTOMessage<T>:DyMessage
    {
        public T Data { get; set; }
    }
}