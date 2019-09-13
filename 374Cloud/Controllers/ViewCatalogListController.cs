using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _374Cloud.Data;

namespace _374Cloud.Controllers
{
    [Route("api/catalogList")]
    [ApiController]
    public class ViewCatalogListController : ControllerBase
    {
        readonly private rst374_cloud12Context _context = new rst374_cloud12Context();

        [HttpGet()]
        public IActionResult catalogList()
        {
            var mylist = _context.CatalogRef.Select(c => new
            {
                id = c.Id, pId = c.ParentId, name = c.Cat
            });
            return Ok(mylist);
        }
    }
}