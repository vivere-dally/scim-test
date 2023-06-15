namespace SCIMPoc.Models
{
    public class ScimError
    {
        public ScimError(int statusCode, string detail, string title, string trace)
        {
            Status = statusCode;
            Detail = detail;
            Title = title;
            Trace = trace;
        }

        public List<string> Schemas { get; } = new() { "urn:ietf:params:scim:api:messages:2.0:Error" };

        public int Status { get; set; }

        public string Detail { get; set; }

        public string Title { get; set; }

        public string Trace { get; set; }
    }
}
