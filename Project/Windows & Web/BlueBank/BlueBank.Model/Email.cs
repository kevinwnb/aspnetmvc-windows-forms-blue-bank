using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBank.Model
{
    public class Email : Base
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        [EmailAddress]
        public string SenderAddress { get; set; }
        [EmailAddress]
        public string ReceiverAddress { get; set; }
        public string Body { get; set; }
    }
}
