using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoetryBook.Classes
{
    public class JsonProcess
    {
        
            public JsonProcess(bool _success, string _text)
            {
                success = _success;
                text = _text;
            }
            public bool success { get; set; }
            public string text { get; set; }
        
    }
}