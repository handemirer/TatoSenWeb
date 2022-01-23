using TatoSen.Model;

namespace TatoSen.Models
{
    public class AuthenticateResponse
    {
        public int user_id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            user_id = user.user_id;
            username = user.username;
            email = user.email;
            Token = token;
        }
    }
}