namespace SCIMPoc.Models
{
    public class ScimUser
    {
        public ScimUser(string username, bool active)
        {
            Username = username;
            Active = active;
        }

        public List<string> Schemas { get; } = new() { "urn:ietf:params:scim:schemas:core:2.0:User" };

        public string Username { get; set; }

        public bool Active { get; set; }
    }
}
