using Microsoft.AspNetCore.Mvc;
using System;
using Twilio;
using Twilio.AspNet.Mvc;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML;
using TwilioDemoApp.Models;

namespace TwilioDemoApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Phone")]
    public class PhoneController : Controller
    {
        [HttpPost("MakeCall")]
        public CallResource MakeCall(Sms sms)
        {
            const string accountSid = "ACbc3f40a47db120f60ffb5494037fedff";
            const string authToken = "8cb97ef424c19810ec2f96ab4aa6ab0b";

            TwilioClient.Init(accountSid, authToken);
            if (!sms.Number.StartsWith("+")) sms.Number = "+" + sms.Number;
            var call = CallResource.Create(
                from: new Twilio.Types.PhoneNumber("+14785594916"),
                to: new Twilio.Types.PhoneNumber(sms.Number),
                url: new Uri("http://demo.twilio.com/docs/voice.xml")
            );
            return call;
        }

        [HttpPost("ReceiveCall")]
        public TwiMLResult ReceiveCall()
        {
            var response = new VoiceResponse();
            response.Say("Hello from your twilio dev Faisal. Have fun!");
            return new TwiMLResult(response);
            //return response;
        }
    }
}