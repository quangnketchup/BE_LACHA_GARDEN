using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Builder.Extensions;

namespace LachaGarden.Services
{
    public class PushNotification
    {
        public async void SendSigleMessage(Models.Notification noti, string registrationToken)
        {
            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile(@"Auth.json")
            });


            // See documentation on defining a message payload.
            var message = new Message()
            {
                Data = new Dictionary<string, string>()
                {
                    { "score", "850" },
                    { "time", "1:00" },
                },

                Notification = new FirebaseAdmin.Messaging.Notification()
                {

                    Title = noti.Title,
                    Body = noti.Body,
                },
                Token = registrationToken,
            };

            // Send a message to the device corresponding to the provided
            // registration token.
            string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
            // Response is a message ID string.
            Console.WriteLine("Successfully sent message: " + response);
        }
        public async void SendSigleMessage(Models.Notification noti, List<string> registrationTokens)
        {
            var message = new MulticastMessage()
            {
                Data = new Dictionary<string, string>()
                {
                    { "score", "850" },
                    { "time", "1:00" },
                },

                Notification = new FirebaseAdmin.Messaging.Notification()
                {

                    Title = noti.Title,
                    Body = noti.Body,
                },
                Tokens = registrationTokens,
            };

            var response = await FirebaseMessaging.DefaultInstance.SendMulticastAsync(message);
            // See the BatchResponse reference documentation
            // for the contents of response.
            Console.WriteLine($"{response.SuccessCount} messages were sent successfully");
        }
    }
}
