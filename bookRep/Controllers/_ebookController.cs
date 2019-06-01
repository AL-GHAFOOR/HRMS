using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using bookRep.BLL;
using bookRep.Models;
using ServiceReportingSystem.Models;

namespace bookRep.Controllers
{
    public class _ebookController : Controller
    {
        // GET: _ebook
        SelectDropDownListManager _downList=new SelectDropDownListManager();
        public ActionResult Create()
        {
            
            ViewBag.SubjectArea= _downList.GetBookCategory();
            ViewBag.Program = _downList.GetProgramlist();
            ViewBag.EditionList = _downList.GetEdition();

            return View();
        }
        public ActionResult BookList()
        {
            List<ModelBookList> list = new List<ModelBookList>();
            var CategoryList = dbEntities.tbl_SubjectArea.ToList();
            foreach (sp_bookList_Result result in dbEntities.sp_bookList())
            {
                list.Add(new ModelBookList()
                {
                    Id = result.Id,
                    SubectArea_Name = SelectDropDownListManager.MultipleCategory(result.SubjectArea_CategoryId,CategoryList),
                    Author = result.Author,
                    Book_Title = result.Book_Title,
                    Description = result.Description,
                    EditionId = result.EditionId,
                    EditionName = result.EditionName,
                    ProgramId = result.ProgramId,
                    ProgramName = result.ProgramName,
                    SchoolId = result.SchoolId,
                    Published = Convert.ToBoolean(result.Published)
                  
                });
            }
          

            return View(list);
        }

        public int[] GetMultiCategory(string[] cat)
        {
            int[] catIdList = new int[cat.Length-1];
            for (int i = 0; i < cat.Length-1; i++)
            {
                catIdList[i] = Convert.ToInt32(cat[i]);
            }

            return catIdList;
        }
        public ActionResult Edit(int id)
        {
           sp_bookList_Result list = dbEntities.sp_bookList().FirstOrDefault(a=>a.Id==id);
            if (list!=null)
            {
                ViewBag.SubjectArea = _downList.GetBookCategory();
                ViewBag.Program = _downList.GetProgramlist();
                ViewBag.EditionList = _downList.GetEdition();
                ModelBook modelBook = new ModelBook();
                modelBook.Author = list.Author;
                modelBook.Book_Title = list.Book_Title;
                modelBook.Description = list.Description;
                modelBook.EditionId = Convert.ToInt32(list.EditionId);
                modelBook.ProgramId = Convert.ToInt32(list.ProgramId);
                modelBook.SubjectArea_CategoryId = Convert.ToString(list.SubjectArea_CategoryId);
                modelBook.MultiCategegory = GetMultiCategory(list.SubjectArea_CategoryId.Split(','));
                modelBook.UserId = list.Author;
                modelBook.UserType = list.Author;
                modelBook.Id = list.Id;
                modelBook.Published = Convert.ToBoolean(list.Published);
                return View("Create", modelBook);
            }


            return RedirectToAction("Index");
        }
        public FileResult Download(string fileName,int cat)
        {
            try
            {
                string catName = dbEntities.tbl_SubjectArea.FirstOrDefault(a => a.Id == cat).SubectArea_Name;
                var FileVirtualPath = "~/App_Data/" + catName + "/" + fileName+".pdf";
                //Response.AppendHeader("content-disposition", "inline; filename="+ Path.GetFileName(FileVirtualPath));
             
                return File(FileVirtualPath, "application/pdf");

               
            }
            catch (Exception e)
            {
                return null;
            }
           
        }
        private eLibraryDbEntities dbEntities = new eLibraryDbEntities();
        public int UpdateBook(ModelBook modelBook, ModelUser user)
        {
            tbl_Book _book = dbEntities.tbl_Book.FirstOrDefault(a => a.Id == modelBook.Id);
            if (_book!=null)
            {
                _book.Book_Title = modelBook.Book_Title;
                _book.EditionId = modelBook.EditionId;
                _book.ProgramId = modelBook.ProgramId;
                _book.SubjectArea_CategoryId = Convert.ToString(modelBook.SubjectArea_CategoryId);
                _book.Author = modelBook.Author;
                _book.Description = modelBook.Description;
                _book.UserId = user.Id.ToString();
                _book.UserType = user.Type;
                _book.Published = modelBook.Published;
            
                return dbEntities.SaveChanges();
            }
            return 0;
        }
      
        [HttpPost]
        public ActionResult UploadData(ModelBook FileData)
        {

            string FileName = "";
            ModelUser user=(ModelUser)Session["User"];
            if (user==null)
            {
                FileName = "Please login first";
                return Json(FileName, JsonRequestBehavior.AllowGet);
            }
         
            try
            {
                ModelState["Id"].Errors.Clear();
                if (ModelState.IsValid)
                {
                    int  splitsubjectArea = Convert.ToInt32(FileData.SubjectArea_CategoryId.Split(',')[0]);

                    if (FileData.Id > 0)
                    {
                        UpdateBook(FileData, user);

                        FileName = "Successfully updated";

                    }
                    else
                    {
                        if (dbEntities.tbl_Book.Count(a => a.Book_Title == FileData.Book_Title) > 0)
                        {
                            FileName = "Book name is already added.";

                        }
                        else
                        {
                            var maxId = dbEntities.tbl_Book.Max(a=>a.Id);

                            var categoryname = dbEntities.tbl_SubjectArea.FirstOrDefault(a => a.Id == splitsubjectArea);
                            foreach (HttpPostedFileBase file in FileData.BookdocumBase)
                            {

                                string fname;

                             Int64   id = Convert.ToInt64(maxId) + 1;
                                if (file.ContentType.Contains("image"))
                                {
                                    var coverfname = Path.Combine(Server.MapPath("~/Content/assets/img/avatars/cover/"), id + ".png");
                                    file.SaveAs(coverfname);
                                }
                                else
                                {
                                    fname = id + ".pdf";
                                    fname = Path.Combine(Server.MapPath("~/App_Data/" + categoryname.SubectArea_Name), fname);
                                    file.SaveAs(fname);
                                }


                            }


                            tbl_Book _book = new tbl_Book();
                            _book.Book_Title = FileData.Book_Title;
                            _book.EditionId = FileData.EditionId;
                            _book.ProgramId = FileData.ProgramId;
                            _book.SubjectArea_CategoryId = FileData.SubjectArea_CategoryId;
                            _book.Author = FileData.Author;
                            _book.Description = FileData.Description;
                            _book.UserId = user.Id.ToString();
                            _book.UserType = user.Type;
                            _book.Published = FileData.Published;
                            dbEntities.tbl_Book.Add(_book);
                            dbEntities.SaveChanges();
                            FileName = "Success";
                        }
                    }
                }
                else
                {
                    FileName ="Required all input data fill up ";
                }
               
                
               
            }
            catch (Exception e)
            {
                FileName = e.GetBaseException().ToString();
            }
                  
            
            return Json(FileName, JsonRequestBehavior.AllowGet);
            //return View();
        }

    }
}