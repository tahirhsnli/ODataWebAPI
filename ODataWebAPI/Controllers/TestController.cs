using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace ODataWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Top)]
    public class TestController(AppDbContext context) : ControllerBase
    {
        [HttpGet("get-all-categories")]
        public IQueryable<Category> GetCategories()
        {
            IQueryable<Category> categories = context.Categories.AsQueryable();
            return(categories);
        }
    }
}
