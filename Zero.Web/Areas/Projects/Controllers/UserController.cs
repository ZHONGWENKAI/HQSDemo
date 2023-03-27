using Zero.Data.Projects;
using NewLife;
using NewLife.Cube;
using NewLife.Cube.Extensions;
using NewLife.Cube.ViewModels;
using NewLife.Web;

using Zero.Web.Areas.Projects;
using Microsoft.AspNetCore.Mvc;


namespace Zero.Web.Areas.Projects.Controllers
{
    /// <summary>存储用户信息</summary>
    [Menu(60, true, Icon = "fa-table")]
    [ProjectsArea]
    public class UserController : EntityController<User>
    {
        static UserController()
        {
            //LogOnChange = true;

            //ListFields.RemoveField("Id", "Creator");
            ListFields.RemoveCreateField();
            ListFields.RemoveUpdateField();
            ListFields.RemoveRemarkField();
            
            //{
            //    var df = ListFields.GetField("Code") as ListField;
            //    df.Url = "?code={Code}";
            //}
            //{
            //    var df = ListFields.AddListField("devices", null, "Onlines");
            //    df.DisplayName = "查看设备";
            //    df.Url = "Device?groupId={Id}";
            //    df.DataVisible = e => (e as User).Devices > 0;
            //}
            //{
            //    var df = ListFields.GetField("Kind") as ListField;
            //    df.GetValue = e => ((Int32)(e as User).Kind).ToString("X4");
            //}
            //ListFields.TraceUrl("TraceId");
        }

        /// <summary>高级搜索。列表页查询、导出Excel、导出Json、分享页等使用</summary>
        /// <param name="p">分页器。包含分页排序参数，以及Http请求参数</param>
        /// <returns></returns>
        protected override IEnumerable<User> Search(Pager p)
        {
            //var deviceId = p["deviceId"].ToInt(-1);

            var start = p["dtStart"].ToDateTime();
            var end = p["dtEnd"].ToDateTime();

            return Data.Projects.User.Search(start, end, p["Q"], p);
        }

        /// <summary>
        /// 返回默认头像
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDefalutAvatar()
        {
            FileIO fileIO = new FileIO();
            byte[] fileArray = fileIO.readFile("./UserAvatar/0.jpeg");

            //byte[] fileArray = fileIO.readFile(avatar);
            //fileIO.writeFile("D:/Code/HQSDemo/UserAvatar/2.jpeg", fileArray);
            //参数      图像文件的二进制数组    返回的格式
            return File(fileArray, "image/*");
        }

        /// <summary>
        /// 返回头像
        /// </summary>
        /// <returns></returns>
        //public ActionResult UpLoadAvatar(String imagesrc,Int32 id)
        //{
        //    FileIO fileIO = new FileIO();
        //    byte[] fileArray = fileIO.readFile(imagesrc);

        //    fileIO.writeFile("D:/Code/HQSDemo/UserAvatar/"+id+".jpeg", fileArray);
        //    //参数      图像文件的二进制数组    返回的格式
        //    return File(fileArray, "image/jpg");
        //}
    }
}