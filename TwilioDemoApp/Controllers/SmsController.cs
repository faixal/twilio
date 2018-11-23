using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using TwilioDemoApp.Models;

namespace TwilioDemoApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Sms")]
    public class SmsController : Controller
    {
        const string accountSid = "ACbc3f40a47db120f60ffb5494037fedff";
        const string authToken = "8cb97ef424c19810ec2f96ab4aa6ab0b";

        public SmsController()
        {
            TwilioClient.Init(accountSid, authToken);
        }
        [HttpPost("SendSms")]
        public MessageResource SendSms(Sms sms)
        {
            if (!sms.Number.StartsWith("+")) sms.Number = "+" + sms.Number;
            var message = MessageResource.Create(
                body: sms.Body,
                from: new Twilio.Types.PhoneNumber("+14785594916"),
                to: new Twilio.Types.PhoneNumber(sms.Number)
                , statusCallback: new System.Uri("https://postb.in/80njXFpR")
            );
            return message;
        }
        [HttpGet("getallsent")]
        public List<MessageResource> GetAllSent()
        {
            var list = MessageResource.Read();
            var toSend = new List<MessageResource>();
            foreach (var item in list)
            {
                toSend.Add(item);
            }
            return toSend;
        }
        [HttpGet("callback")]
        public string CallBack()
        {
            return "Call-Back";
        }
    }
}