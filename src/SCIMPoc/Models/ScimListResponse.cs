namespace SCIMPoc.Models
{
    public class ScimListResponse
    {
        private readonly List<string> _schemas = new() { "urn:ietf:params:scim:api:messages:2.0:ListResponse" };

        public ScimListResponse(int totalResults, int itemsPerPage, int startIndex, List<object> resources)
        {
            TotalResults = totalResults;
            ItemsPerPage = itemsPerPage;
            StartIndex = startIndex;
            Resources = resources;
        }

        public List<string> Schemas => _schemas;

        public int TotalResults { get; set; }

        public int ItemsPerPage { get; set; }

        public int StartIndex { get; set; }

        public List<object> Resources { get; set; }
    }
}
