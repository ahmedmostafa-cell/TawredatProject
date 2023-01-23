

using System;

namespace TawredatProject.Services
{
    public interface ISMSService
    {
         public string Send(String apiKey, String username, String numbers, String message, String sender);
    }
}