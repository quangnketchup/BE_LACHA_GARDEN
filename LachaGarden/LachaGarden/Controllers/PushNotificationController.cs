using LachaGarden.Models;
using LachaGarden.Services;
using Microsoft.AspNetCore.Mvc;

namespace LachaGarden.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PushNotificationController : ControllerBase
    {
        string token = "dppkleBtS6CtMSFGPSQQCg:APA91bFnCKFeiF_T0T5Y90fbqpVK2i_Vj2UcXHDMEGekDWj_OTiZZsaUhhWbEZhytMseKKjWKlWtXuFzxnsfLd-H96OIjW5TD0lHWBZ8wi-Vl9y8JnUIREYVYudJA4j6kpIRWjDATbgz";
        [HttpPost]
        public async void sendMessage(Notification fcmNotiMessage)
        {
            PushNotification pushNotification = new PushNotification();
            pushNotification.SendSigleMessage(fcmNotiMessage, token);

        }
    }
}
