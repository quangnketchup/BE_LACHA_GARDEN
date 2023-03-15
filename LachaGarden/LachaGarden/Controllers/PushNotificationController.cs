using LachaGarden.Models;
using LachaGarden.Services;
using Microsoft.AspNetCore.Mvc;

namespace LachaGarden.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PushNotificationController : ControllerBase
    {
        [HttpPost("{token}")]
        public async void sendMessage(String token, [FromBody] Notification fcmNotiMessage)
        {
            PushNotification pushNotification = new PushNotification();
            pushNotification.SendSigleMessage(fcmNotiMessage, token);
        }
    }
}