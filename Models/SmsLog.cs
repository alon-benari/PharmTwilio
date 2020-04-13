using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwilioSend.Models
{
    public class SmsLog
    {
        public int SmsLogId { get; set; }
        public string msgID { get; set; }
        public string to { get; set; }
        public string from { get; set; }
        public String dateCreated { get; set; }
        public string body { get; set; }
        public string direction { get; set; }
        public string status { get; set; }

        public bool wasContacted { get; set; }


    }
}
