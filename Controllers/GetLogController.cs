using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using TwilioSend.Models;
using TwilioSend.Data;

namespace TwilioSend.Controllers
{
    public class GetLogController : Controller
    {
        [HttpGet]
        public IEnumerable<SmsLog> Index()
        {
            Console.WriteLine("HttpGet");
            
            const string accountSid = "";
            const string authToken = "";
            

            TwilioClient.Init(accountSid, authToken);


            var messages = MessageResource.Read(
                //dateSentAfter: new DateTime(2020, 4, 4, 0, 0, 0),
                dateSentAfter: DateTime.Now.AddMinutes(-10),
                //dateSentBefore: new DateTime(2019, 3, 1, 0, 0, 0),
                limit: 20
            );
            List<SmsLog> smsLog = new List<SmsLog>();
            Console.WriteLine(messages);
            using (var db = new PharmTwilioDbContext())
            {
                //pack into a dataset.
                foreach (var record in messages)
                {
                    var log = new SmsLog();
                    //
                    Console.Write(record.Sid.ToString());
                    log.msgID = record.Sid.ToString();
                    log.to = record.To.ToString();
                    log.from = record.From.ToString();
                    log.dateCreated = record.DateCreated.ToString();
                    log.body = record.Body.ToString();
                    log.status = record.Status.ToString();
                    log.direction = record.Direction.ToString();
                    log.wasContacted = false;
                    db.Add(log);
                    db.SaveChanges();
                    //smsLog.Add(log);
                    //logSms.Add(JsonSerializer.Serialize<SmsLog>(log));
                  
                }
            
            }
            Console.WriteLine("Fetched record");
            using (var db = new PharmTwilioDbContext())
            {
                 smsLog = db.SmsLogs.Where(e => e.from != "").Where(e=>e.wasContacted == false).ToList();
            }
            return smsLog;
        }
    }
}