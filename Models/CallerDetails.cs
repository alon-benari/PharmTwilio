using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwilioSend.Models
{
    public class CallerDetails
    {

        public int id { get; set; }
        public string callerPhone { get; set; }
        public DateTime callingDate { get; set; }
    }
}
