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

        int loopCount = 1;
        bool jumpOut = false;

        [HttpGet()]
        public IActionResult catalogList()
        {
            var mylist = _context.CatalogRef.Select(c => new
            {
                id = c.Id,
                pId = c.ParentId,
                name = c.Cat
            });
            return Ok(mylist);
        }

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
            var level = getLevel(parent_id, jumpOut);
//          if(jumpOut)
                catalog.LayerLevel = loopCount;
            loopCount = 1;
            jumpOut = false;

            _context.CatalogRef.Add(catalog);
            _context.SaveChanges();

            return Ok(catalog);
        }

        [HttpPost("del")]
        public IActionResult delcat([FromQuery] int id)
        {
            CatalogRef delcat = new CatalogRef();
            CodeRelations updateItem = new CodeRelations();
            List<CodeRelations> affectedItems = new List<CodeRelations>();

            delcat = _context.CatalogRef.Where(c => c.Id == id).FirstOrDefault();
            var affectedCatLevel = delcat.LayerLevel;

            //update categories for affected items
            if (affectedCatLevel == 1)
            {
                affectedItems = _context.CodeRelations.Where(cl => cl.Cat == delcat.Cat).ToList();
                foreach (var item in affectedItems)
                {
                    item.Cat = "";
                }
            }
            else if (affectedCatLevel == 2)
            {
                affectedItems = _context.CodeRelations.Where(cl => cl.SCat == delcat.Cat).ToList();
                foreach (var item in affectedItems)
                {
                    item.SCat = "";
                }
            }
            else if (affectedCatLevel == 3)
            {
                affectedItems = _context.CodeRelations.Where(cl => cl.SsCat == delcat.Cat).ToList();
                foreach (var item in affectedItems)
                {
                    item.SsCat = "";
                }
            }

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

  


            ///update categories for affected items
            List<CodeRelations> affectedItems = new List<CodeRelations>();
            var affectedCatLevel = catToUpdate.LayerLevel;
            //update categories for affected items
            if (affectedCatLevel == 1)
            {
                affectedItems = _context.CodeRelations.Where(cl => cl.Cat == catToUpdate.Cat).ToList();
                foreach (var item in affectedItems)
                {
                    item.Cat = catToPatch.cat;
                }
            }
            else if (affectedCatLevel == 2)
            {
                affectedItems = _context.CodeRelations.Where(cl => cl.SCat == catToUpdate.Cat).ToList();
                foreach (var item in affectedItems)
                {
                    item.SCat = catToPatch.cat;
                }
            }
            else if (affectedCatLevel == 3)
            {
                affectedItems = _context.CodeRelations.Where(cl => cl.SsCat == catToUpdate.Cat).ToList();
                foreach (var item in affectedItems)
                {
                    item.SsCat = catToPatch.cat;
                }
            }
            ///
            catToUpdate.Cat = catToPatch.cat;

            _context.SaveChanges();

            return NoContent();
        }

        //Recursive get LayerLevel
        private int getLevel(int pid, bool bGetLevel)
        {
            var upperLevelPid = _context.CatalogRef.Where(cr => cr.Id == pid).FirstOrDefault().ParentId;

            if (pid == 0)
            {
                bGetLevel = true;
                return loopCount;

            }
            else if (upperLevelPid == 0)
            {
                bGetLevel = true;
                loopCount ++ ;
                return loopCount;
            }
            else
            {
                loopCount ++;
                getLevel(upperLevelPid, bGetLevel);
            }
            return loopCount;
        }
    }
}