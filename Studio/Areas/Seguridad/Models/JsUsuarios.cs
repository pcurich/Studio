using System.Collections.Generic;
namespace Studio.Areas.Seguridad.Models
{
    public class JsUsuarios
    {
        public JsUsuariosAttribute attr { get; set; }
        public List<JsUsuarios> children { get; set; }

        public string data { get; set; }
        public int IdServerUse { get; set; }
        public string icons { get; set; }
        public string state { get; set; }

        public JsUsuarios()
        {
            children = new List<JsUsuarios>();
        }
    }

    public class JsUsuariosAttribute
    {
        public string id;
        public bool selected;
    }

    public class G_JSTree
    {
        public G_JsTreeAttribute attr;
        public G_JSTree[] children;
        public string data
        {
            get;
            set;
        }
        public int IdServerUse
        {
            get;
            set;
        }
        public string icons
        {
            get;
            set;
        }
        public string state
        {
            get;
            set;
        }
    }

    public class G_JsTreeAttribute
    {
        public string id;
        public bool selected;
    }
}