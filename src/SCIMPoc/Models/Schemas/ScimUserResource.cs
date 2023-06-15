namespace SCIMPoc.Models.Schemas
{
    public class ScimUserResource
    {
        private readonly List<string> _schemas;

        public string Id { get; } = "urn:ietf:params:scim:schemas:core:2.0:User";
        public List<string> Schemas => _schemas;
        public string Name { get; } = "User";
        public string Description { get; } = "User Account";
        public List<ScimResourceAttribute> Attributes { get; } = new()
        {
            new()
            {
                Name = "userName",
                Type = "string",
                Description = "Username",
                Required = true,
                CaseExact = false,
                Mutability = "readWrite",
                Returned = "default",
                Uniqueness = "server"
            }
        };

        public ScimUserResource()
        {
            _schemas = new() { Id };
        }
    }
}
