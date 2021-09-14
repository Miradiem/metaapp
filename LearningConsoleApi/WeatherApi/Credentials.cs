using Newtonsoft.Json.Linq;

namespace LearningConsoleApi
{
    public class Credentials
    {
        private readonly string _username;
        private readonly string _password;
        
        public Credentials(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public JObject ToJObject()
        {
            return new JObject(
                new JProperty("username", _username),
                new JProperty("password", _password));
        }
    }
}
