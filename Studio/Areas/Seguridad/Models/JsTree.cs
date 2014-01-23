using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Studio.Areas.Seguridad.Models
{
    public class JsTree
    {
        public string id { get; set; }

        public string text { get; set; }

        public string icon { get; set; }

        public State state { get; set; }

        public string[] children { get; set; }

        public JsTree(int i)
        {
            children = new string[i];
        }
    }

    public class State
    {
        public bool opened { get; set; }

        public bool disabled { get; set; }

        public bool selected { get; set; }
    }
}