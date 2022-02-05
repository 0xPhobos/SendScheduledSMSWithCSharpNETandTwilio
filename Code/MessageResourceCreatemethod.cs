using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;

string twilioAccountSid = Environment.GetEnvironmentVariable("TwilioAccountSid");
string twilioAuthToken = Environment.GetEnvironmentVariable("TwilioAuthToken");
string twilioMessagingServiceSid = Environment.GetEnvironmentVariable("TwilioMessagingServiceSid");
string toPhoneNumber = Environment.GetEnvironmentVariable("ToPhoneNumber");

TwilioClient.Init(twilioAccountSid, twilioAuthToken);

var message = MessageResource.Create(
    messagingServiceSid: twilioMessagingServiceSid,
    body: "Sending SMS with Twilio and .NET is easy!",
    to: new PhoneNumber(toPhoneNumber),
    sendAt: DateTime.UtcNow.AddMinutes(61),
    scheduleType: MessageResource.ScheduleTypeEnum.Fixed
);

Console.WriteLine($"Message SID: {message.Sid}");
