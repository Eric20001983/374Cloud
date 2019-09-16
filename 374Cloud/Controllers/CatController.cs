using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using _374Cloud.Data;
using _374Cloud.Dto;
using _374Cloud.Entities;

namespace _374Cloud.Controllers
{
    [Route("api/cat")]
    [ApiController]
    public class CatController : ControllerBase
    {
        private rst374_cloud12Context _context = new rst374_cloud12Context();

        [HttpPost("add")]
        public IActionResult addcat([FromBody] AddCatDto newCat)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            CatalogRef catalog = new CatalogRef();

//          newCat.parent_id = 0; //root node
            var parent_id =  newCat.parent_id;
            var cat = newCat.cat;
            bool existCat = _context.CatalogRef.Any(c => c.ParentId == parent_id && c.Cat == cat);
            if (existCat)
                return BadRequest("Sorry, this Category exists already!!!");

            catalog.ParentId = parent_id;
            catalog.Cat = cat;

            _context.CatalogRef.Add(catalog);
            _context.SaveChanges();

            return Ok(catalog);
        }

        [HttpPost("del")]
        public IActionResult delcat([FromQuery] int id)
        {
            CatalogRef delcat = new CatalogRef();
            CodeRelations updateItem = new CodeRelations();
            List<CodeRelations> codeRelationsList = new List<CodeRelations>();

            delcat = _context.CatalogRef.Where(c => c.Id == id).FirstOrDefault();
//            updateItem = _context.CodeRelations.Where(cl =>cl.Cat)

            if (delcat != null)
            {
                _context.Remove(delcat);
                _context.SaveChanges();
            }
            return Ok(delcat);
        }

        [HttpPatch("edit")]
        public IActionResult editcat([FromQuery] int id, [FromBody] JsonPatchDocument<UpdateCatDto> patchDoc)
        {
            if (patchDoc == null)
                return BadRequest();

            var catToUpdate = _context.CatalogRef.Where(c => c.Id == id).FirstOrDefault();
            if (catToUpdate == null)
                return NotFound();

            var catToPatch = new UpdateCatDto
            {
                id = catToUpdate.Id,
                parent_id = catToUpdate.ParentId,
                cat = catToUpdate.Cat
            };
            patchDoc.ApplyTo(catToPatch, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            catToUpdate.Cat = catToPatch.cat;
            _context.SaveChanges();

            return NoContent();
        }
    }
}