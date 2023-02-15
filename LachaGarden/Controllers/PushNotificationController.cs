using LachaGarden.Models;
using LachaGarden.Services;
using Microsoft.AspNetCore.Mvc;

namespace LachaGarden.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PushNotificationController : ControllerBase
    {
        [HttpPost]
        public async void sendMessage(Notification fcmNotiMessage)
        {
            PushNotification pushNotification = new PushNotification();
            pushNotification.SendSigleMessage(fcmNotiMessage, "dxzO7xy8SpalAp5DQSZpKl:APA91bHS5oOu_VxFk-u1y6lzyvyoQx4tFLT69t4nFkr9X1bk0Uau-fMcTIzxp4nqg-OfmMQz5__AZof-0GHKnlkH9bQ8qBHHjrwdsd4E0y-th9evZDN7bUYJ4B6vMe5EmrarLqD3H1U2");
        }
    }
}
