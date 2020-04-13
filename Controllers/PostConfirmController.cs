using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TwilioSend.Models;
using TwilioSend.Data;

namespace TwilioSend.Controllers
{
    public class PostConfirmController : Controller
    {
        //public IActionResult Index(string targetPhone)
        [HttpPost]
        public IActionResult Index([FromBody] TargetPhones targetPhone)
        {
            Console.WriteLine(targetPhone.targetPhoneNumber);
            Console.WriteLine("A Twilio message was just sent to that number.");
            // do a try catch 
            var id = Int32.Parse(targetPhone.targetPhoneNumber);
            Console.WriteLine(id);
            using (var db = new PharmTwilioDbContext())
            {
                SmsLog rec = db.SmsLogs.Find(id);
                rec.wasContacted = true;
                db.SaveChanges();
            }
            return View();



        }
    }
}