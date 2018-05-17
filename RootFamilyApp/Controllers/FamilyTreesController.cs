using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RootFamilyApp.Models;
using RootFamilyApp.Services;
using Syncfusion.JavaScript.DataVisualization.DiagramEnums;
using Syncfusion.JavaScript.DataVisualization.Models;
using Syncfusion.JavaScript.DataVisualization.Models.Collections;
using Syncfusion.JavaScript.DataVisualization.Models.Diagram;

namespace RootFamilyApp.Controllers
{
    public class FamilyTreesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FamilyTrees
        public async Task<ActionResult> Index()
        {
            var familyTrees = db.FamilyTrees;
            ViewBag.dataSource = familyTrees;
            return View(await familyTrees.ToListAsync());
        }

        public ActionResult UploadFile(IEnumerable<HttpPostedFileBase> uploadFile)
        {
            foreach (var file in uploadFile)
            {
                var familyTree = GedcomReaderService.Load(file.InputStream);
                var fileName = Path.GetFileName(file.FileName);
                familyTree.Name = fileName;
                db.FamilyTrees.Add(familyTree);
                //var destinationPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);
                //file.SaveAs(destinationPath);
            }
            return Content("");
        }

        public ActionResult RemoveDefault(string[] fileNames)
        {
            //foreach (var fullName in fileNames)
            //{
            //    var fileName = Path.GetFileName(fullName);
            //    var physicalPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);
            //    if (System.IO.File.Exists(physicalPath))
            //    {
            //        System.IO.File.Delete(physicalPath);
            //    }
            //}
            return Content("");
        }

        // GET: FamilyTrees/Details/5
        //public async Task<ActionResult> Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    FamilyTree familyTree = await db.FamilyTrees.FindAsync(id);
        //    if (familyTree == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(familyTree);
        //}

        public ActionResult Details()
        {
            DiagramProperties model = new DiagramProperties();
            model.Height = "600px";
            model.Width = "100%";
            model.Create = "create";
            model.SnapSettings.SnapConstraints = SnapConstraints.None;
            OverviewProperties overview = new OverviewProperties();
            overview.Height = "300px";
            overview.Width = "233px";
            overview.SourceID = "Diagram1";
            CreateNode(model.Nodes, 24, 23, 20, "../Content/images/overviewcontrol/cards_05.png");
            CreateNode(model.Nodes, 555, 48, 41, "../Content/images/overviewcontrol/cards_03.png");
            CreateNode(model.Nodes, 461, 174, -64, "../Content/images/overviewcontrol/cards_07.png");
            CreateNode(model.Nodes, 455, 634, 0, "../Content/images/overviewcontrol/cards_09.png");
            CreateNode(model.Nodes, 81, 583, 0, "../Content/images/overviewcontrol/cards_11.png");
            CreateNode(model.Nodes, 861, 449, -24, "../Content/images/overviewcontrol/cards_14.png");
            CreateNode(model.Nodes, 34, 417, 20, "../Content/images/overviewcontrol/cards_16.png");
            CreateNode(model.Nodes, 674, 418, 37, "../Content/images/overviewcontrol/cards_18.png");
            CreateNode(model.Nodes, 1181, 921, -75, "../Content/images/overviewcontrol/cards_23.png");
            CreateNode(model.Nodes, 159, 125, -9, "../Content/images/overviewcontrol/cards_25.png");
            CreateNode(model.Nodes, 776, 249, 0, "../Content/images/overviewcontrol/cards_100.png");
            CreateNode(model.Nodes, 776, 27, 0, "../Content/images/overviewcontrol/cards_101.png");
            CreateNode(model.Nodes, 634, 149, -79, "../Content/images/overviewcontrol/cards_102.png");
            CreateNode(model.Nodes, 287, 159, 0, "../Content/images/overviewcontrol/cards_103.png");
            CreateNode(model.Nodes, 223, 584, -20, "../Content/images/overviewcontrol/cards_104.png");
            CreateNode(model.Nodes, 294, 8, -52, "../Content/images/overviewcontrol/cards_105.png");
            CreateNode(model.Nodes, 388, 296, 59, "../Content/images/overviewcontrol/cards_106.png");
            CreateNode(model.Nodes, 102, 267, 0, "../Content/images/overviewcontrol/cards_107.png");
            CreateNode(model.Nodes, 380, 452, 0, "../Content/images/overviewcontrol/cards_108.png");
            CreateNode(model.Nodes, 683, 550, 31, "../Content/images/overviewcontrol/cards_109.png");
            CreateNode(model.Nodes, 1038, 567, 20, "../Content/images/overviewcontrol/cards_05.png");
            CreateNode(model.Nodes, 849, 115, 41, "../Content/images/overviewcontrol/cards_03.png"); ;
            CreateNode(model.Nodes, 1165, 144, -64, "../Content/images/overviewcontrol/cards_07.png"); ;
            CreateNode(model.Nodes, 497, 815, 0, "../Content/images/overviewcontrol/cards_09.png"); ;

            CreateNode(model.Nodes, 993, 480, 0, "../Content/images/overviewcontrol/cards_100.png");
            CreateNode(model.Nodes, 1240, 582, -38, "../Content/images/overviewcontrol/cards_101.png");
            CreateNode(model.Nodes, 941, 249, 0, "../Content/images/overviewcontrol/cards_102.png");
            CreateNode(model.Nodes, 674, 921, -41, "../Content/images/overviewcontrol/cards_104.png");
            CreateNode(model.Nodes, 296, 816, -20, "../Content/images/overviewcontrol/cards_104.png");
            CreateNode(model.Nodes, 1025, 45, -52, "../Content/images/overviewcontrol/cards_105.png");
            CreateNode(model.Nodes, 962, 943, 59, "../Content/images/overviewcontrol/cards_106.png");

            CreateNode(model.Nodes, 1093, 409, -42, "../Content/images/overviewcontrol/cards_107.png");
            CreateNode(model.Nodes, 445, 939, 33, "../Content/images/overviewcontrol/cards_108.png");
            CreateNode(model.Nodes, 756, 783, 31, "../Content/images/overviewcontrol/cards_109.png");
            CreateNode(model.Nodes, 15, 1047, 0, "../Content/images/overviewcontrol/cards_05.png");
            CreateNode(model.Nodes, 1072, 102, 41, "../Content/images/overviewcontrol/cards_03.png");
            CreateNode(model.Nodes, 417, 1198, -64, "../Content/images/overviewcontrol/cards_07.png");
            CreateNode(model.Nodes, 1148, 815, 0, "../Content/images/overviewcontrol/cards_09.png");
            CreateNode(model.Nodes, 1322, 310, -34, "../Content/images/overviewcontrol/cards_11.png");
            CreateNode(model.Nodes, 833, 1442, -36, "../Content/images/overviewcontrol/cards_14.png");
            CreateNode(model.Nodes, 25, 1441, 31, "../Content/images/overviewcontrol/cards_16.png");
            CreateNode(model.Nodes, 630, 1442, 0, "../Content/images/overviewcontrol/cards_18.png");
            CreateNode(model.Nodes, 1454, 102, 37, "../Content/images/overviewcontrol/cards_20.png");
            CreateNode(model.Nodes, 1253, 1306, -75, "../Content/images/overviewcontrol/cards_23.png");

            CreateNode(model.Nodes, 115, 1148, -9, "../Content/images/overviewcontrol/cards_25.png");
            CreateNode(model.Nodes, 993, 480, 0, "../Content/images/overviewcontrol/cards_11.png");
            CreateNode(model.Nodes, 115, 815, -24, "../Content/images/overviewcontrol/cards_14.png");
            CreateNode(model.Nodes, 913, 676, 31, "../Content/images/overviewcontrol/cards_16.png");
            CreateNode(model.Nodes, 1216, 310, 0, "../Content/images/overviewcontrol/cards_18.png");
            CreateNode(model.Nodes, 590, 614, -16, "../Content/images/overviewcontrol/cards_20.png");
            CreateNode(model.Nodes, 285, 685, -75, "../Content/images/overviewcontrol/cards_23.png");
            CreateNode(model.Nodes, 232, 357, -9, "../Content/images/overviewcontrol/cards_25.png");
            CreateNode(model.Nodes, 733, 1273, 0, "../Content/images/overviewcontrol/cards_100.png");
            CreateNode(model.Nodes, 733, 1051, 0, "../Content/images/overviewcontrol/cards_101.png");
            CreateNode(model.Nodes, 590, 1273, -79, "../Content/images/overviewcontrol/cards_102.png");

            CreateNode(model.Nodes, 244, 1212, 0, "../Content/images/overviewcontrol/cards_103.png");
            CreateNode(model.Nodes, 1547, 9, -20, "../Content/images/overviewcontrol/cards_104.png");
            CreateNode(model.Nodes, 251, 1031, -52, "../Content/images/overviewcontrol/cards_105.png");


            CreateNode(model.Nodes, 344, 1320, 59, "../Content/images/overviewcontrol/cards_106.png");
            CreateNode(model.Nodes, 58, 1291, 0, "../Content/images/overviewcontrol/cards_107.png");
            CreateNode(model.Nodes, 287, 1442, 0, "../Content/images/overviewcontrol/cards_108.png");


            CreateNode(model.Nodes, 1499, 733, 31, "../Content/images/overviewcontrol/cards_109.png");
            CreateNode(model.Nodes, 1566, 726, 20, "../Content/images/overviewcontrol/cards_05.png");
            CreateNode(model.Nodes, 805, 1138, 41, "../Content/images/overviewcontrol/cards_03.png");
            CreateNode(model.Nodes, 1122, 1168, -64, "../   Content/images/overviewcontrol/cards_07.png");


            CreateNode(model.Nodes, 1216, 0, 0, "../Content/images/overviewcontrol/cards_09.png");
            CreateNode(model.Nodes, 1326, 534, 0, "../Content/images/overviewcontrol/cards_11.png");
            CreateNode(model.Nodes, 1514, 930, -24, "../Content/images/overviewcontrol/cards_14.png");
            CreateNode(model.Nodes, 1622, 473, 31, "../Content/images/overviewcontrol/cards_16.png");
            CreateNode(model.Nodes, 1498, 1124, 0, "../Content/images/overviewcontrol/cards_18.png");

            CreateNode(model.Nodes, 1668, 228, 0, "../Content/images/overviewcontrol/cards_20.png");
            model.EnableContextMenu = false;
            ViewData["diagramModel"] = model;
            ViewData["overview"] = overview;
            return View();
        }

        private void CreateNode(Collection nodes, double offsetx, double offsety, double angle, string src)
        {
            ImageNode node = new ImageNode();
            node.Name = "node" + nodes.Count.ToString();
            node.Width = 102;
            node.Height = 142;
            node.OffsetX = offsetx - 51;
            node.OffsetY = offsety - 71;
            node.BorderColor = "none";
            node.RotateAngle = angle;
            node.Source = src;
            nodes.Add(node);
        }

        //// GET: FamilyTrees/Create
        //public ActionResult Create()
        //{
        //    ViewBag.Id = new SelectList(db.TreeHeaders, "Id", "GedcomId");
        //    return View();
        //}

        //// POST: FamilyTrees/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "Id,Name,ChangeDate,FilePath,FileContents")] FamilyTree familyTree)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        familyTree.Id = Guid.NewGuid();
        //        db.FamilyTrees.Add(familyTree);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.Id = new SelectList(db.TreeHeaders, "Id", "GedcomId", familyTree.Id);
        //    return View(familyTree);
        //}

        //// GET: FamilyTrees/Edit/5
        //public async Task<ActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    FamilyTree familyTree = await db.FamilyTrees.FindAsync(id);
        //    if (familyTree == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.Id = new SelectList(db.TreeHeaders, "Id", "GedcomId", familyTree.Id);
        //    return View(familyTree);
        //}

        //// POST: FamilyTrees/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Id,Name,ChangeDate,FilePath,FileContents")] FamilyTree familyTree)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(familyTree).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.Id = new SelectList(db.TreeHeaders, "Id", "GedcomId", familyTree.Id);
        //    return View(familyTree);
        //}

        //// GET: FamilyTrees/Delete/5
        //public async Task<ActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    FamilyTree familyTree = await db.FamilyTrees.FindAsync(id);
        //    if (familyTree == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(familyTree);
        //}

        //// POST: FamilyTrees/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(Guid id)
        //{
        //    FamilyTree familyTree = await db.FamilyTrees.FindAsync(id);
        //    db.FamilyTrees.Remove(familyTree);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
