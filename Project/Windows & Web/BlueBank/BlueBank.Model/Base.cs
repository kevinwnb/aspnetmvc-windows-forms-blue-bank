using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBank.Model
{
    public abstract class Base
    {
        private List<Error> errors;

        public List<Error> Errors { get; set; } = new List<Error>();

        public List<Error> GetErrors()
        {
            return Errors;
        }

        public void AddError(Error error)
        {
            Errors.Add(error);
        }
    }
}
