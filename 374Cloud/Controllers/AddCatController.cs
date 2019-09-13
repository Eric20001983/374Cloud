using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _374Cloud.Data;
using _374Cloud.Dto;
using _374Cloud.Entities;

namespace _374Cloud.Controllers
{
    [Route("api/addcat")]
    [ApiController]
    public class AddCatController : ControllerBase
    {
        private rst374_cloud12Context _context = new rst374_cloud12Context();

        [HttpPost()]
        public IActionResult addcat([FromBody] AddCatDto newCat)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            CatalogRef catalog = new CatalogRef();

            var parent_id = newCat.parent_id;
            var cat = newCat.cat;
            bool existCat = _context.CatalogRef.Any(c => c.ParentId == parent_id && c.Cat == cat);
            if (existCat)
                return BadRequest("Sorry, this email exists already!!!");

            return Ok();
        }
    }
}