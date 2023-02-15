using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Mvc;

namespace LachaGarden.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        private static string API_KEY = "AIzaSyAp7q2T07VOPchctK0RVVFfdNU9KAjo1Uc";
        private static string Bucket = "lachagarden.appspot.com";
        private static string AuthEmail = "123@gmail.com";
        private static string AuthPassword = "123";

        [HttpPost]
        public async Task<ActionResult> UploadImageFirebase(IFormFile image)
        {
            string link = "";
            using (var stream = new MemoryStream())
            {
                await image.CopyToAsync(stream);
                stream.Position = 0;

                var auth = new FirebaseAuthProvider(new FirebaseConfig(API_KEY));
                var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);

                var cancellation = new CancellationTokenSource();

                var task = new FirebaseStorage(Bucket, new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    ThrowOnCancel = true
                })
                    .Child(image.FileName)
                    .PutAsync(stream, cancellation.Token);

                try
                {
                    link = await task;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return Ok(link);
        }
    }
}
