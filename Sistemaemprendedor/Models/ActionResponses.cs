using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistemaemprendedor.Models
{
    public enum ResponseType
    { 
        ERROR, SUCCESS, WARNING
    };
    public class ActionResponses
    {
        public string Messages;
        public ResponseType Type;

        public ActionResponses(ResponseType type,string messages ) {
            Type = type;
            Messages = messages;
        }
    }
}