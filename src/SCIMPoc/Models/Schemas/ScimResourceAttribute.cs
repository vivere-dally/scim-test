namespace SCIMPoc.Models.Schemas
{
    public class ScimResourceAttribute
    {
        public string? Name { get; set; }

        public string? Type { get; set; }

        public string? Description { get; set; }

        public bool? Required { get; set; }

        public bool? CaseExact { get; set; }

        public string? Mutability { get; set; }

        public string? Returned { get; set; }

        public string? Uniqueness { get; set; }
    }
}
