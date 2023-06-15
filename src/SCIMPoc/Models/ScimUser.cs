using Newtonsoft.Json;

namespace SCIMPoc.Models
{
    public class ScimUser
    {
        public ScimUser(string username, ScimUserName name, List<string>? emails = null)
        {
            Username = username;
            Name = name;
            if (emails != null)
            {
                Emails = emails;
            }
        }

        public List<string> Schemas { get; } = new() { "urn:ietf:params:scim:schemas:core:2.0:User" };

        [JsonProperty("userName")]
        public string Username { get; set; }

        public ScimUserName Name { get; set; }

        public List<string> Emails { get; set; } = new List<string>();
    }
}
