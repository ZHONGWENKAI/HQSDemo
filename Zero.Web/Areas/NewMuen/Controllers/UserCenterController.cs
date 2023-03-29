using Zero.Data.Projects;
using NewLife;
using NewLife.Cube;
using NewLife.Cube.Extensions;
using NewLife.Cube.ViewModels;
using NewLife.Web;

using Zero.Web.Areas.Projects;
using Microsoft.AspNetCore.Mvc;


namespace Zero.Web.Areas.NewMuen.Controllers
{
    /// <summary>存储用户信息</summary>
    [Menu(60, true, Icon = "fa-table")]
    [NewMuenArea]
    public class UserCenterController : EntityController<User>
    {


        public override ActionResult Index(Pager p)
        {

            User user = Data.Projects.User.FindByID(2);
            //ViewBag.user = user;
            //ViewData.Model = user;
            return View("GetUser2", user);
        }

        public ActionResult GetCommoncss()
        {
            FileIO fileIO = new FileIO();
            byte[] fileArray = fileIO.readFile("./css/common.css");

            //byte[] fileArray = fileIO.readFile(avatar);
            //fileIO.writeFile("D:/Code/HQSDemo/UserAvatar/2.jpeg", fileArray);
            //参数      图像文件的二进制数组    返回的格式
            return File(fileArray, "text/css");
        }

        public ActionResult GetStylecss()
        {
            FileIO fileIO = new FileIO();
            byte[] fileArray = fileIO.readFile("./css/style.css");

            //byte[] fileArray = fileIO.readFile(avatar);
            //fileIO.writeFile("D:/Code/HQSDemo/UserAvatar/2.jpeg", fileArray);
            //参数      图像文件的二进制数组    返回的格式
            return File(fileArray, "text/css");
        }

        public ActionResult GetLoginImg()
        {
            FileIO fileIO = new FileIO();
            byte[] fileArray = fileIO.readFile("./img/login.ico");

            //byte[] fileArray = fileIO.readFile(avatar);
            //fileIO.writeFile("D:/Code/HQSDemo/UserAvatar/2.jpeg", fileArray);
            //参数      图像文件的二进制数组    返回的格式
            return File(fileArray, "image/x-icon");
        }

        public ActionResult GetbgImg()
        {
            FileIO fileIO = new FileIO();
            byte[] fileArray = fileIO.readFile("./img/bg.png");

            //byte[] fileArray = fileIO.readFile(avatar);
            //fileIO.writeFile("D:/Code/HQSDemo/UserAvatar/2.jpeg", fileArray);
            //参数      图像文件的二进制数组    返回的格式
            return File(fileArray, "image/png");
        }

        public ActionResult GetLoginJS()
        {
            FileIO fileIO = new FileIO();
            byte[] fileArray = fileIO.readFile("./JS/login.js");

            //byte[] fileArray = fileIO.readFile(avatar);
            //fileIO.writeFile("D:/Code/HQSDemo/UserAvatar/2.jpeg", fileArray);
            //参数      图像文件的二进制数组    返回的格式
            return File(fileArray, "text/javascript");
        }

        //protected override IEnumerable<User> Search(Pager p)
        //{
        //    var deviceId = p["deviceId"].ToInt(-1);

        //    var start = p["dtStart"].ToDateTime();
        //    var end = p["dtEnd"].ToDateTime();

        //    return Data.Projects.User.Search(start, end, p["Q"], p);
        //}
    }
}
