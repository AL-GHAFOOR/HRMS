using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookRep.BLL
{
    public class SelectDropDownListManager
    {
        private eLibraryDbEntities db;
        public SelectDropDownListManager()
        {
            db = new eLibraryDbEntities();
        }
        public IEnumerable<SelectListItem> GetEdition()
        {
            var dbedition = db.tbl_edition.ToList();
            List<SelectListItem> programList = new List<SelectListItem>();
            foreach (tbl_edition edition in dbedition)
            {
                programList.Add(new SelectListItem() { Text = edition.EditionName, Value = edition.Id.ToString() });
            }
            programList.Insert(0, new SelectListItem() { Text = "Select Edition", Value = "" });
            
            return programList;
        }
        
        public static string MultipleCategory(string categoryId,List<tbl_SubjectArea> categList)
        {

            string bindcategoryName = "";
            string[] split = categoryId.Split(',');
            for (int i = 0; i < split.Length-1; i++)
            {
                var IsExistCategoryInlist = categList.FirstOrDefault(a => a.Id == Convert.ToInt32(split[i]));
                if (IsExistCategoryInlist!=null)
                {
                    bindcategoryName += IsExistCategoryInlist.SubectArea_Name + ",";
                }
            }

            return bindcategoryName;

        }
        public static string MultipleCategory(string categoryId)
        {

        
            string[] split = categoryId.Split(',');
            

            return split[0];

        }
        public IEnumerable<SelectListItem> GetBookCategory()
        {
            var dbcateList = db.tbl_SubjectArea.ToList();
            List<SelectListItem> catList = new List<SelectListItem>();
            foreach (tbl_SubjectArea catArea in dbcateList)
            {
                catList.Add(new SelectListItem() { Text = catArea.SubectArea_Name, Value = catArea.Id.ToString() });
            }
            catList.Insert(0, new SelectListItem() { Text = "Select Subject Area", Value = "" });

            return catList;
        }

        public IEnumerable<SelectListItem> GetProgramlist()
        {



            var dbProgram = db.tbl_Program.OrderBy(a=>a.SortOrder).ToList();
            List<SelectListItem> programList = new List<SelectListItem>();
            foreach (tbl_Program tblProgram in dbProgram)
            {
                programList.Add(new SelectListItem() {Text = tblProgram.ProgramName, Value = tblProgram.Id.ToString()});
            }

            programList.Insert(0, new SelectListItem() {Text = "Select Program", Value = ""});


            return programList;
        }
        public IEnumerable<SelectListItem> GetSchool()
        {

            var dbProgram = db.tbl_School.OrderBy(a=>a.SortOrder).ToList();
            List<SelectListItem> valueList = new List<SelectListItem>();
            foreach (tbl_School value in dbProgram)
            {
                valueList.Add(new SelectListItem() { Text = value.SchoolName, Value = value.Id.ToString() });
            }

            valueList.Insert(0, new SelectListItem() { Text = "Select School", Value = "" });


            return valueList;
        }
        public IEnumerable<SelectListItem> GetDepartment()
        {

            var dbProgram = db.tbl_department.OrderBy(a=>a.SortOrder).ToList();
            List<SelectListItem> valueList = new List<SelectListItem>();
            foreach (tbl_department value in dbProgram)
            {
                valueList.Add(new SelectListItem() { Text = value.DepartmentName, Value = value.Id.ToString() });
            }

            valueList.Insert(0, new SelectListItem() { Text = "Select Department", Value = "" });


            return valueList;
        }
      
        public IEnumerable<SelectListItem> GetFacDesignationList()
        {



            var dbProgram = db.tbl_designation.ToList();
            List<SelectListItem> programList = new List<SelectListItem>();
            foreach (tbl_designation tblProgram in dbProgram)
            {
                programList.Add(new SelectListItem() {Text = tblProgram.Designation, Value = tblProgram.Id.ToString()});
            }

            programList.Insert(0, new SelectListItem() {Text = "Select Designation", Value = ""});


            return programList;
        }
    }
}