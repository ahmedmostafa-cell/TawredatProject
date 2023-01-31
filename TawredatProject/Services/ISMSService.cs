

using System;
using Twilio.Rest.Api.V2010.Account;

namespace TawredatProject.Services
{
    public interface ISMSService
    {
        MessageResource Send(string mobileNumber, string body);
    }
}