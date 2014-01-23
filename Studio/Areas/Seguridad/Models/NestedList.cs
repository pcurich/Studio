using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Studio.Areas.Seguridad.Models
{
    public class NestedList
    {
        public string ol { get; set; }
        public string li { get; set; }
        public string ul { get; set; }
        public List<NestedList> children { get; set; }

        public NestedList()
        {
            children = new List<NestedList>();
        }
    }
}