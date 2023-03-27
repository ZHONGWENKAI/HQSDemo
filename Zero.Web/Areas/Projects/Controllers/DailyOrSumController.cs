using Zero.Data.Projects;
using NewLife;
using NewLife.Cube;
using NewLife.Cube.Extensions;
using NewLife.Cube.ViewModels;
using NewLife.Web;
using XCode.Membership;

using Microsoft.AspNetCore.Mvc;
using System.Drawing;


namespace Zero.Web.Areas.Projects.Controllers
{
    /// <summary>存储用户疗程和打卡记录信息</summary>
    [Menu(90, true, Icon = "fa-table")]
    [ProjectsArea]
    public class DailyOrSumController : EntityController<DailyOrSum>
    {
        static DailyOrSumController()
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
            //    df.DataVisible = e => (e as DailyOrSum).Devices > 0;
            //}
            //{
            //    var df = ListFields.GetField("Kind") as ListField;
            //    df.GetValue = e => ((Int32)(e as DailyOrSum).Kind).ToString("X4");
            //}
            //ListFields.TraceUrl("TraceId");
        }

        /// <summary>高级搜索。列表页查询、导出Excel、导出Json、分享页等使用</summary>
        /// <param name="p">分页器。包含分页排序参数，以及Http请求参数</param>
        /// <returns></returns>
        protected override IEnumerable<DailyOrSum> Search(Pager p)
        {
            //var deviceId = p["deviceId"].ToInt(-1);

            var start = p["dtStart"].ToDateTime();
            var end = p["dtEnd"].ToDateTime();

            return DailyOrSum.Search(start, end, p["Q"], p);
        }

        /// <summary>
        /// 返回头像
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAvatar()
        {
            FileIO fileIO = new FileIO();
            byte[] fileArray = fileIO.readFile("D:/Code/HQSDemo/UserAvatar/1.jpeg");

            fileIO.writeFile("D:/Code/HQSDemo/UserAvatar/2.jpeg", fileArray);
            //参数      图像文件的二进制数组    返回的格式
            return File(fileArray,              "image/jpg");
        }

        /// <summary>
        /// 返回图像
        /// </summary>
        /// <returns></returns>
        public ActionResult GetImg()
        {
            FileIO fileIO = new FileIO();
            byte[] fileArray = fileIO.readFile("D:/Code/HQSDemo/UserAvatar/1.jpeg");

            fileIO.writeFile("D:/Code/HQSDemo/UserAvatar/2.jpeg", fileArray);
            //参数      图像文件的二进制数组    返回的格式
            return File(fileArray, "image/*");
        }

        /// <summary>
        /// 返回音频
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAudio()
        {
            FileIO fileIO = new FileIO();
            byte[] fileArray = fileIO.readFile("C:/Users/Administrator/Desktop/小星星.wav");
            //DailyOrSum obj = new DailyOrSum();
            //obj.SetItem("Recording", fileArray);
            //obj.Insert();
            //fileIO.writeFile("D:/Code/HQSDemo/UserAudio/2.mp3", fileArray);
            //参数      图像文件的二进制数组    返回的格式
            return File(fileArray, "audio/*");
        }

        /// <summary>
        /// 上传头像
        /// </summary>
        /// <returns></returns>
        public ActionResult UpLoadAvatar(byte[] arr)
        {
            FileIO fileIO = new FileIO();
            //byte[] fileArray = fileIO.readFile("D:/Code/HQSDemo/UserAudio/1.mp3");

            fileIO.writeFile("D:/Code/HQSDemo/UserAudio/2.mp3", arr);
            //参数      图像文件的二进制数组    返回的格式
            return File(arr, "image/*");
        }

        public String insertPictureList(String[] pictureData,Int32 dailyOrSumID)
        {
            var returnWord = "";
            if (Picture.DeteleAllByDailyOrSum(dailyOrSumID) == false)
            {
                returnWord = "上传失败请重试";
            }
            else
            {
                var pictureList = pictureData;
                //String [] pictures = pictureList.Split(",");
                Console.WriteLine(dailyOrSumID);
                foreach (String pictureItem in pictureList)
                {
                    Picture picture = new Picture();
                    picture.SetItem("Content", pictureItem);
                    picture.SetItem("DailyOrSumID", dailyOrSumID);
                    picture.Insert();
                }
                returnWord = "上传成功";
            }

            return returnWord;
        }
    }
}