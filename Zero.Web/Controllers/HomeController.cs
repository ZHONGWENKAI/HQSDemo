﻿using Microsoft.AspNetCore.Mvc;
using Zero.Data.Projects;
using Zero.Web.Areas.Projects;

namespace HQSDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //我的
        public ActionResult GetDefalutAvatar()
        {
            FileIO fileIO = new FileIO();
            byte[] fileArray = fileIO.readFile("./UserAvatar/0.jpeg");

            //byte[] fileArray = fileIO.readFile(avatar);
            //fileIO.writeFile("D:/Code/HQSDemo/UserAvatar/2.jpeg", fileArray);
            //参数      图像文件的二进制数组    返回的格式
            return File(fileArray, "image/*");
        }
        public IActionResult GetUser(Int32 id)
        {
            id = 2;
            User user = Zero.Data.Projects.User.FindByID(id);
            return View("GetUser",user);
        }

        public IActionResult EditUser(Int32 id)
        {
            User user = Zero.Data.Projects.User.FindByID(2);
            ViewData["user"] = user;
            return View("EditUser", user);
        }

        public String  EditUserDetail(Int32 Sex,String DiseaseText,Int32 Age,String Phone,Int32 Height,Int32 Weight,Int32 userid,String Name,String Avatar)
        {

            User user = Zero.Data.Projects.User.FindByID(userid);
            user.SetItem("Name", Name);
            user.SetItem("Avatar", Avatar);
            user.SetItem("Sex", Sex);
            user.SetItem("Age", Age);
            user.SetItem("Phone", Phone);
            user.SetItem("Height", Height);
            user.SetItem("Weight", Weight);
            user.Update();

            

            if (DiseaseText!="")
            {
                List<UserDisease> DeleteUserDiseaseList = (List<UserDisease>)UserDisease.FindAllByUserID(userid);
                UserDisease.DeteleAllByUserID(DeleteUserDiseaseList);
                String [] fristDiseaseList = DiseaseText.Split(',');
                List<UserDisease> userDiseaseList = new List<UserDisease>();
                for (int i = 0; i < fristDiseaseList.Length-1; i++)
                {
                    UserDisease userDisease = new UserDisease();
                    userDisease.SetItem("UserID", userid);
                    userDisease.SetItem("DiseaseID", Disease.FindByName(fristDiseaseList[i]).ID);
                    //userDisease.Insert();
                    userDiseaseList.Add(userDisease);
                }
                UserDisease.InsertAllByUserID(userDiseaseList);
            }


            //return RedirectToAction("GetUser"); 
            return "保存成功";
        }
        //用户
        public IActionResult GetSearchUser(Int32 id)
        {
            User user = Zero.Data.Projects.User.FindByID(id);
            ViewData["user"] = user;

            List<User> userList = (List<User>)Zero.Data.Projects.User.FindAll();
            return View("SearchUser", userList);
        }

        public IActionResult GetSearchUserByName(Int32 userid ,String name)
        {
            Console.WriteLine(userid);
            Console.WriteLine(name);
            User user = Zero.Data.Projects.User.FindByID(userid);
            ViewData["user"] = user;

            List<User> userList = (List<User>)Zero.Data.Projects.User.FindAllByNameLike(name);
            Console.WriteLine(userList);
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
            var returnWord = "";

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

            returnWord = insertPictureList(pictureData, dailyId);


            return returnWord;
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



        //动态/日常打卡
        public IActionResult GetDaily(Int32 id)
        {
            User user = Zero.Data.Projects.User.FindByID(id);
            ViewData["user"] = user;

            List<DailyOrSum> dailyOrSumList = (List<DailyOrSum>)DailyOrSum.FindAllByType(DailyOrSum.Kind.打卡记录);

            return View("GetDaily", dailyOrSumList);
        }

        public IActionResult SearchDaily(Int32 id)
        {
            User user = Zero.Data.Projects.User.FindByID(id);
            ViewData["user"] = user;

            List<DailyOrSum> dailyOrSumList = (List<DailyOrSum>)DailyOrSum.FindAllByType(DailyOrSum.Kind.打卡记录);

            return View("GetDaily", dailyOrSumList);
        }

        //动态/疗程总结
        public IActionResult GetSum(Int32 id)
        {
            User user = Zero.Data.Projects.User.FindByID(id);
            ViewData["user"] = user;

            List<DailyOrSum> dailyOrSumList = (List<DailyOrSum>)DailyOrSum.FindAllByType(DailyOrSum.Kind.疗程总结);

            return View("GetSum", dailyOrSumList);
        }
    }
}
