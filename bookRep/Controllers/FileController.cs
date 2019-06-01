using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookRep.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BookFileManager()
        {
            return View();
        }
        [ValidateInput(false)]
        public ActionResult FileManagerPartial()
        {
            return PartialView("_FileManagerPartial", FileControllerFileManagerSettings.Model);
        }

        public FileStreamResult FileManagerPartialDownload()
        {
            return FileManagerExtension.DownloadFiles(FileControllerFileManagerSettings.DownloadSettings, FileControllerFileManagerSettings.Model);
        }

        [ValidateInput(false)]
        public ActionResult BookFilePartial()
        {
            return PartialView("_BookFilePartial", FileControllerBookFileSettings.Model);
        }

        public FileStreamResult BookFilePartialDownload()
        {
            return FileManagerExtension.DownloadFiles(FileControllerBookFileSettings.DownloadSettings, FileControllerBookFileSettings.Model);
        }
    }
    public class FileControllerBookFileSettings
    {
        public const string RootFolder = @"~\App_Data";

        public static string Model { get { return RootFolder; } }
        public static DevExpress.Web.Mvc.FileManagerSettings DownloadSettings
        {
            get
            {
                var settings = new DevExpress.Web.Mvc.FileManagerSettings { Name = "BookFile" };
                settings.SettingsEditing.AllowDownload = true;
                return settings;
            }
        }
    }

    public class FileControllerFileManagerSettings
    {
        public const string RootFolder = @"~/content\assets\img\avatars\cover\";
        public static string Model { get { return RootFolder; } }
        public static DevExpress.Web.Mvc.FileManagerSettings DownloadSettings
        {
            get
            {
                var settings = new DevExpress.Web.Mvc.FileManagerSettings { Name = "FileManager" };
                settings.SettingsEditing.AllowDownload = true;
                return settings;
            }
        }
    }

}