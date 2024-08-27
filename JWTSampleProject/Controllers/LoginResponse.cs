namespace JWTSampleProject.Controllers
{
    internal class LoginResponse
    {
        public LoginResponse()
        {
        }

        public string Access_Token { get; set; }
        public object UserName { get; set; }
    }
}