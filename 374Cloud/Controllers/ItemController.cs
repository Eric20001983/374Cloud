using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _374Cloud.Data;
using _374Cloud.Dto;

namespace _374Cloud.Controllers
{
    [Route("api/item")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly rst374_cloud12Context _context = new rst374_cloud12Context();

        Dictionary<int?, string> array = new Dictionary<int?, string>();//collect category list

        [HttpGet("{id}")]
        public IActionResult finalList(int id)
        {
            ItemListFilterDto filter = new ItemListFilterDto();
//          var currentLevel = _context.CatalogRef.Where(cr => cr.Id == id).FirstOrDefault().LayerLevel;
            Dictionary<int?, string> myCategries = getCategoriesById(id);
            foreach (var category in myCategries)
            {
                if (category.Key == 1)
                    filter.cat = category.Value;
                if (category.Key == 2)
                        filter.scat = category.Value;
                if (category.Key == 3)
                    filter.sscat = category.Value;
            }

            //filter.cat = cat;
            //filter.scat = scat;
            //filter.sscat = sscat;

            List<Item> mylist = getItemList(filter);
            return Ok(mylist);
        }

        public List<Item> getItemList(ItemListFilterDto myFilter)
        {
            var items = _context.CodeRelations
                .Where(cr => myFilter.cat != null ? cr.Cat == myFilter.cat : true)
                .Where(cr => myFilter.scat != null ? cr.SCat == myFilter.scat : true)
                .Where(cr => myFilter.sscat != null ? cr.SsCat == myFilter.sscat : true);

            var mylist = new List<Item>(); 

            foreach(var item in items)
            {
                Item ite = new Item();
                ite.code = item.Code;
                ite.description = item.Name;
                ite.cat = item.Cat;
                ite.scat = item.SCat;
                ite.sscat = item.SsCat;
                ite.price = item.Price1;
                mylist.Add(ite);
            }

            return mylist;
        }

        private Dictionary<int?, string> getCategoriesById(int id)
        {

            var level = _context.Catalog.Where(cr => cr.Id == id).FirstOrDefault().LayerLevel;
            var pid = _context.Catalog.Where(cr => cr.Id == id).FirstOrDefault().ParentId;
            var cat = _context.Catalog.Where(cr => cr.Id == id).FirstOrDefault().Cat;

            if (pid == 0)
            {
                array.Add(level,cat);
                return array;
            }
            else
            {
                array.Add(level, cat);
                getCategoriesById(pid);
            }

            return array;
        }

    }
}