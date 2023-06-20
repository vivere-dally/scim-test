using System.Net.Mime;

using Microsoft.AspNetCore.Mvc;

using SCIMPoc.Models;

namespace SCIMPoc.Controllers
{
    [ApiController]
    [Route("scim/v2")]
    [Produces(MediaTypeNames.Application.Json)]
    public class ScimController : ControllerBase
    {
        private readonly ILogger<ScimController> logger;
        private static readonly List<ScimUser> _users = new();
        private static readonly Dictionary<string, ScimUser> _usersMap = new();

        public ScimController(ILogger<ScimController> logger)
        {
            this.logger = logger;
        }

        private static int StartIndex(int page, int perPage) => (page - 1) * perPage;

        [HttpGet]
        [Route("Schemas")]
        public ActionResult GetSchemas([FromQuery] int page = 1, [FromQuery] int perPage = 10)
        {
            var userSchema = new
            {
                Schemas = new[] { "urn:ietf:params:scim:schemas:core:2.0:User" },
                Id = "urn:ietf:params:scim:schemas:core:2.0:User",
                Name = "User",
                Description = "User Account",
                Attributes = new object[]
                {
                    new
                    {
                        Name = "username",
                        Type = "string",
                        Description = "Username",
                        Required = true,
                        CaseExact = false,
                        Mutability = "readWrite",
                        Returned = "default",
                        Uniqueness = "server"
                    },
                    new
                    {
                        Name = "active",
                        Type = "boolean",
                        Description = "User status",
                        Required = true,
                        CaseExact = false,
                        Mutability = "readWrite",
                        Returned = "default",
                    }
                }
            };

            var startIndex = StartIndex(page, perPage);
            return Ok(new ScimListResponse(1, perPage, startIndex, new() { userSchema }));
        }

        [HttpGet]
        [Route("Users")]
        public ActionResult GetUsers([FromQuery] int page = 1, [FromQuery] int perPage = 10, [FromQuery] string filter = "")
        {
            var startIndex = StartIndex(page, perPage);
            var results = new List<object>();
            for (int i = Math.Min(_users.Count, startIndex); i < Math.Min(_users.Count, startIndex + perPage); i += 1)
            {
                results.Add(_users[i]);
            }

            return Ok(new ScimListResponse(results.Count, perPage, startIndex, results));
        }

        [HttpGet]
        [Route("Users/{user}")]
        public ActionResult GetUsers(string user)
        {
            if (_usersMap.TryGetValue(user, out var value))
            {
                return Ok(value);
            }

            return NotFound(new ScimError(404, $"user not found with {user}", "user not found", ""));
        }

        [HttpPost]
        [Route("Users")]
        public ActionResult CreateUser([FromBody] ScimUser user)
        {
            if (_usersMap.TryGetValue(user.Username, out var value))
            {
                return new ObjectResult(new ScimError(409, $"user exists with username {user.Username}", "user exists", ""));
            }

            _users.Add(user);
            _usersMap[user.Username] = user;
            return Ok(user);
        }

        [HttpPatch]
        [Route("Users")]
        public ActionResult PatchUsers([FromBody] dynamic payload)
        {
            return Ok();
        }
    }
}
