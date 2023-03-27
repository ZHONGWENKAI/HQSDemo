using Microsoft.AspNetCore.Mvc;
using Zero.Data.Projects;

namespace HQSDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //我的
        public IActionResult GetUser(Int32 id)
        {
            id = 2;
            User user = Zero.Data.Projects.User.FindByID(id);
            return View("GetUser",user);
        }

        public IActionResult EditUser(Int32 id)
        {
            id = 2;
            User user = Zero.Data.Projects.User.FindByID(id);
            return View("EditUser", user);
        }
        //用户
        public IActionResult GetSearchUser(Int32 id)
        {
            User user = Zero.Data.Projects.User.FindByID(id);
            ViewData["user"] = user;

            List<User> userList = (List<User>)Zero.Data.Projects.User.FindAll();
            return View("SearchUser", userList);
        }

        public IActionResult GetSearchUserDetail(Int32 id)
        {
            User user = Zero.Data.Projects.User.FindByID(id);
            ViewData["user"] = user;

            List<DailyOrSum> dailyOrSumList = (List<DailyOrSum>)DailyOrSum.FindAllByUserID(id);

            return View("SearchUserDetail", dailyOrSumList);
        }

        //积分抽奖
        public IActionResult GetChouJiang(Int32 id)
        {
            User user = Zero.Data.Projects.User.FindByID(id);
            return View("choujiang", user);
        }



        //日常打卡
        public IActionResult GetDaily(Int32 id)
        {
            User user = Zero.Data.Projects.User.FindByID(id);
            ViewData["user"] = user;

            List<DailyOrSum> dailyOrSumList = (List<DailyOrSum>)DailyOrSum.FindAllByType(DailyOrSum.Kind.打卡记录);
            
            return View("GetDaily", dailyOrSumList);
        }
        //打卡

        public IActionResult AddDaily(Int32 id)
        {
            User user = Zero.Data.Projects.User.FindByID(id);
            //ViewData["user"] = user;

            //List<DailyOrSum> dailyOrSumList = (List<DailyOrSum>)DailyOrSum.FindAllByType(DailyOrSum.Kind.打卡记录);

            return View("AddDaily", user);
        }
        public String AddDailyDetail(String EffectText,String[] pictureData,Int32 userid,String Evaluate,String Recording)
        {

            User user = Zero.Data.Projects.User.FindByID(userid);

            Effect effectId = Effect.FindByName(EffectText);

            DailyOrSum dailyOrSum = new DailyOrSum();
            dailyOrSum.SetItem("UserID",userid);
            dailyOrSum.SetItem("EffectID", effectId);
            dailyOrSum.SetItem("Recording",Recording);
            dailyOrSum.SetItem("Evaluate", Evaluate);
            dailyOrSum.SetItem("Type",DailyOrSum.Kind.打卡记录);
            dailyOrSum.Insert();

            List<DailyOrSum> dailyOrSumList = (List<DailyOrSum>)DailyOrSum.FindAllByUserID(userid);
            var dailyId = dailyOrSumList[dailyOrSumList.Count - 1].ID;

            insertPictureList(pictureData, dailyId);


            return "好了";
        }

        public String insertPictureList(String[] pictureData, Int32 dailyOrSumID)
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


        //疗程总结
        public IActionResult GetSum(Int32 id)
        {
            User user = Zero.Data.Projects.User.FindByID(id);
            ViewData["user"] = user;

            List<DailyOrSum> dailyOrSumList = (List<DailyOrSum>)DailyOrSum.FindAllByType(DailyOrSum.Kind.疗程总结);

            return View("GetSum", dailyOrSumList);
        }
    }
}
