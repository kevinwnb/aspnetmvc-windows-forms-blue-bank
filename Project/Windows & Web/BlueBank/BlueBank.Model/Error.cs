using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBank.Model
{
    public class Error
    {
        private int code;
        private string description;
        private string type;

        public int Code { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public Error()
        {

        }

        public Error(int code, string description, string type)
        {
            this.Code = code;
            this.Description = description;
            this.Type = type;
        }
    }
}
