using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TwilioSend.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace TwilioSend.Controllers
{
    public class TwilioApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string  TwilioPost( string callerPhone)
        {
            const string accountSid = "";
            const string accountToken = "";
            const string twilioNumber = "";
            TwilioClient.Init(accountSid, accountToken);

            var message = MessageResource.Create(
               body: "Welcome To ASP.NET ",
               from: new Twilio.Types.PhoneNumber(twilioNumber),
               to: new Twilio.Types.PhoneNumber("+1"+callerPhone)
           );

            Console.WriteLine(callerPhone);
            return callerPhone;   
        }
            


    }
}