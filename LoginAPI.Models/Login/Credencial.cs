using System.ComponentModel;


namespace LoginAPI.Models.Login
{
    public class Credencial
    {
        [DefaultValue("username")]
        public string? Username { get; set; }

        [DefaultValue("password")]
        public string? Password { get; set; }
    }
}
