using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskBoardDemo.Models;

namespace TaskBoardDemo.Controllers
{
    public class TaskBoardController : Controller
    {
        MVCTutorialEntities db = new MVCTutorialEntities();
        public ActionResult Index()
        {
            var item = db.Posts.ToList();
            var item2 = item.OrderBy(x => x.RowNo);
            return View(item2.ToList());
        }

        public ActionResult UpdateItem(string itemIds)
        {
            int count = 1;
            List<int> itemIdList = new List<int>();
            itemIdList = itemIds.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            foreach (var itemId in itemIdList)
            {
                try
                {
                    Post item = db.Posts.Where(x=>x.Id==itemId).FirstOrDefault();
                    item.RowNo = count;
                    db.Posts.AddOrUpdate(item);
                    db.SaveChanges();
                }
                catch(Exception){
                    continue;
                }
                count++;
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}