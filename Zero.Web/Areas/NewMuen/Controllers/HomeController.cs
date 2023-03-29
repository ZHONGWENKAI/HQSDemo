using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Common;
using System.Drawing;
using Zero.Data.Projects;
using Zero.Web.Areas.Projects;
using NewLife.Web;
using NewLife;
using Zero.Data.Common;
using System.Linq;

namespace Zero.Web.Areas.NewMuen.Controllers
{
    [Menu(60, true, Icon = "fa-table")]
    [NewMuenArea]
    public class HomeController : ControllerBaseX
    {

        
        public  ActionResult Index(Pager p)
        {

            //User user = Data.Projects.User.FindByID(2);
            //ViewBag.user = user;
            //ViewData.Model = user;
            return View("Login");
        }
        //登录
        public ActionResult Login(String username, String password)
        {
            User user = Data.Projects.User.FindByName(username);
            if (user != null)
            {
                if (user.Password == password)
                {
                    return (ActionResult)GetUser(user.ID);
                }
            }
            else
            {
                return JsonRefresh("密码或用户名有误，请退回上一步");
                //return this.Content("alert('操作成功');", "application/x-javascript");
                //return this.JavaScript("alter('{0}');", "弹出窗口");

            }

            //ViewBag.user = user;
            //ViewData.Model = user;
            return JsonRefresh("密码或用户名有误，请退回上一步");
        }

        public ActionResult Register(String username,String passeord, String passeord2)
        {
            Console.WriteLine(username);
            Console.WriteLine(passeord);
            User user = Data.Projects.User.FindByName(username);
            if (user == null)
            {
                if (passeord.Equals(passeord2))
                {
                    User newUser = new Data.Projects.User();
                    newUser.SetItem("Name", username);
                    newUser.SetItem("Password", passeord);
                    newUser.Insert();
                    return JsonRefresh("注册成功");
                }
                else
                {
                    return JsonRefresh("两次输入密码不一致，请退回上一步");
                }
            }
            else
            {
                return JsonRefresh("用户名已被占用，请退回上一步");
            }
            //ViewBag.user = user;
            //ViewData.Model = user;
            return JsonRefresh("输入有误，请退回上一步");
        }

        public ActionResult GetCommoncss()
        {
            FileIO fileIO = new FileIO();
            byte[] fileArray = fileIO.readFile("../Views/Home/css/common.css");

            //byte[] fileArray = fileIO.readFile(avatar);
            //fileIO.writeFile("D:/Code/HQSDemo/UserAvatar/2.jpeg", fileArray);
            //参数      图像文件的二进制数组    返回的格式
            return File(fileArray, "text/css");
        }

        public ActionResult GetStylecss()
        {
            FileIO fileIO = new FileIO();
            byte[] fileArray = fileIO.readFile("/Areas/NewMuen/Views/Home/css/style.css");

            //byte[] fileArray = fileIO.readFile(avatar);
            //fileIO.writeFile("D:/Code/HQSDemo/UserAvatar/2.jpeg", fileArray);
            //参数      图像文件的二进制数组    返回的格式
            return File(fileArray, "text/css");
        }

        public ActionResult GetLoginImg()
        {
            FileIO fileIO = new FileIO();
            byte[] fileArray = fileIO.readFile("/Areas/NewMuen/Views/Home//img/login.ico");

            //byte[] fileArray = fileIO.readFile(avatar);
            //fileIO.writeFile("D:/Code/HQSDemo/UserAvatar/2.jpeg", fileArray);
            //参数      图像文件的二进制数组    返回的格式
            return File(fileArray, "image/x-icon");
        }

        public ActionResult GetbgImg()
        {
            FileIO fileIO = new FileIO();
            byte[] fileArray = fileIO.readFile("/Areas/NewMuen/Views/Home/img/bg.png");

            //byte[] fileArray = fileIO.readFile(avatar);
            //fileIO.writeFile("D:/Code/HQSDemo/UserAvatar/2.jpeg", fileArray);
            //参数      图像文件的二进制数组    返回的格式
            return File(fileArray, "image/png");
        }

        public ActionResult GetLoginJS()
        {
            FileIO fileIO = new FileIO();
            byte[] fileArray = fileIO.readFile("/Areas/NewMuen/Views/Home/JS/login.js");

            //byte[] fileArray = fileIO.readFile(avatar);
            //fileIO.writeFile("D:/Code/HQSDemo/UserAvatar/2.jpeg", fileArray);
            //参数      图像文件的二进制数组    返回的格式
            return File(fileArray, "text/javascript");
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
           
            User user = Zero.Data.Projects.User.FindByID(id);
            return View("GetUser",user);
        }

        public IActionResult EditUser(Int32 id)
        {
            Console.WriteLine(id);
            User user = Zero.Data.Projects.User.FindByID(id);
            ViewData["user"] = user;
            return View("EditUser", user);
        }

        public IActionResult quit()
        {
            
            return View("Login");
        }
        public String  EditUserDetail(Int32 Sex,String DiseaseText,String InfectionText,Int32 Age,String Phone,Int32 Height,Int32 Weight,Int32 userid,String Name,String Avatar)
        {
            Console.WriteLine(userid);
            Console.WriteLine(Name);
            Console.WriteLine(Sex);
            Console.WriteLine(Age);
            Console.WriteLine(Phone);
            Console.WriteLine(Height);
            Console.WriteLine(Weight);
            Console.WriteLine(DiseaseText);
            Console.WriteLine(InfectionText);

            Int32 infectionId = 0;
            if (!InfectionText.Contains("新冠感染情况"))
            {
                infectionId = Infection.FindByName(InfectionText).ID;
            }
            
            Console.WriteLine(infectionId);
            User user = Zero.Data.Projects.User.FindByID(userid);
            user.SetItem("Name", Name);
            user.SetItem("Avatar", Avatar);
            user.SetItem("Sex", Sex);
            user.SetItem("Age", Age);
            user.SetItem("Phone", Phone);
            user.SetItem("Height", Height);
            user.SetItem("Weight", Weight);
            user.SetItem("InfectionID", infectionId);
            user.Update();

            

            if (!DiseaseText.IsNullOrWhiteSpace())
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

        public IActionResult SearchDaily(Int32 userid,String EffectText,String InfectionText,String DiseaseText)
        {

            User user = Zero.Data.Projects.User.FindByID(userid);
            ViewData["user"] = user;

            //Int32 effectId = 0;
            //Int32 infectionId = 0;
            //if (!EffectText.Contains("效果评价"))
            //    effectId = Effect.FindByName(EffectText).ID;

            //if (!InfectionText.Contains("新冠感染情况"))
            //    infectionId = Infection.FindByName(InfectionText).ID;

            //Console.WriteLine(effectId);
            //Console.WriteLine(infectionId);

            //List<User> infectionUserList = new List<User>();
            //List<DailyOrSum> effectDailyOrSums = new List<DailyOrSum>();
            //if (infectionId > 0)
            //    infectionUserList = (List<User>)Zero.Data.Projects.User.FindAllByInfectionID(userid);
            //else
            //    infectionUserList = (List<User>)Zero.Data.Projects.User.FindAll();

            //if (effectId > 0)
            //    effectDailyOrSums = (List<DailyOrSum>)DailyOrSum.FindAllByEffectID(effectId);
            //else
            //    effectDailyOrSums = (List<DailyOrSum>)DailyOrSum.FindAll();

            //int[] diseaseIds = {};
            //if (!DiseaseText.IsNullOrWhiteSpace())
            //{
            //    String[] diseaseNames = DiseaseText.Split(",");

            //    for (int i = 0; i < diseaseNames.Length - 1; i++)
            //    {
            //        Console.WriteLine(diseaseNames[i]);
            //        diseaseIds[i] = Disease.FindByName(diseaseNames[i]).ID;
            //    }
            //}
            //List<UserDisease> userDiseases = new List<UserDisease>();
            //for (int i = 0; i < diseaseIds.Length; i++)
            //{
            //    userDiseases.AddRange(UserDisease.FindAllByDiseaseID(diseaseIds[i]));
            //}
            //List<User> userDiseaseList = new List<User>();
            //foreach (var userDisease in userDiseases)
            //{
            //    if (userDiseaseList.Exists(t => t == Zero.Data.Projects.User.FindByID(userDisease.UserID)))
            //    {

            //    }
            //    else
            //    {
            //        userDiseaseList.Add(Zero.Data.Projects.User.FindByID(userDisease.UserID));
            //    }

            //}
            //if (userDiseaseList == null)
            //{
            //    userDiseaseList = (List<User>)Zero.Data.Projects.User.FindAll();
            //}

            ////List<User> UserList = new List<User>();
            ////    IEnumerable<User> UserExceptLs = infectionUserList.Intersect((List<User>)userDiseaseList);
            ////    UserList = UserExceptLs.ToList();      
            //List<DailyOrSum> UserListDailyOrSunList = new List<DailyOrSum>();
            //foreach (var item in UserList)
            //{
            //    UserListDailyOrSunList.AddRange(DailyOrSum.FindAllByUserID(item.ID));
            //}

            //List<DailyOrSum> DailyOrSunList = (List<DailyOrSum>)UserListDailyOrSunList.Intersect(effectDailyOrSums).ToList();




            Int32 effectId = 0;
            Int32 infectionId = 0;

            if (!EffectText.Contains("效果评价"))
            {
                effectId = Effect.FindByName(EffectText).ID;
            }
            if (!InfectionText.Contains("新冠感染情况"))
            {
                infectionId = Infection.FindByName(InfectionText).ID;
            }


            //将疾病类型从String变为int
            List<UserDisease> userDiseases = new List<UserDisease>();
            if (!DiseaseText.IsNullOrWhiteSpace())
            {
                String[] diseaseNames = DiseaseText.Split(",");
                int[] diseaseIds = new int[10];
                for (int i = 0; i < diseaseNames.Length - 1; i++)
                {
                    Console.WriteLine(diseaseNames[i]);
                    diseaseIds[i] = Disease.FindByName(diseaseNames[i]).ID;
                }


                //获取患有相关疾病的user
                
                for (int i = 0; i < diseaseNames.Length - 1; i++)
                {
                    userDiseases.AddRange(UserDisease.FindAllByDiseaseID(diseaseIds[i]));
                }
            }
            else
            {
                userDiseases = (List<UserDisease>)UserDisease.FindAll();
            }
            
            List<User> userList1 = new List<User>();
            foreach (var userDisease in userDiseases)
            {
                if (userList1.Exists(t => t == Zero.Data.Projects.User.FindByID(userDisease.UserID)))
                {

                }
                else
                {
                    userList1.Add(Zero.Data.Projects.User.FindByID(userDisease.UserID));
                }

            }


            //筛选出有新冠感染状态的user
            List<User> userList2 = new List<User>();
            foreach (var user1 in userList1)
            {
                if (user1.InfectionID == infectionId)
                {
                    userList2.Add(user);
                }
            }
            if (userList2 == null)
            {
                userList2 = (List<User>)Zero.Data.Projects.User.FindAll();
            }
            Console.WriteLine(userList2);

            //查询有该评价效果的Daily并且是筛选后的userid发布的
            List<DailyOrSum> DailyOrSunList = new List<DailyOrSum>();
            foreach (var user1 in userList2)
            {
                DailyOrSunList.AddRange((DailyOrSum.SearchDaily(effectId, user.ID)));
            }
            
            return View("GetDaily", DailyOrSunList);
        }

        //动态/疗程总结
        public IActionResult GetSum(Int32 id)
        {
            User user = Zero.Data.Projects.User.FindByID(id);
            ViewData["user"] = user;

            List<DailyOrSum> dailyOrSumList = (List<DailyOrSum>)DailyOrSum.FindAllByType(DailyOrSum.Kind.疗程总结);

            return View("GetSum", dailyOrSumList);
        }

        public IActionResult SearchSum(Int32 userid, String EffectText, String InfectionText, String DiseaseText)
        {

            User user = Zero.Data.Projects.User.FindByID(userid);
            ViewData["user"] = user;

            var effectId = Effect.FindByName(EffectText).ID;
            var infectionId = Infection.FindByName(InfectionText).ID;

            //将疾病类型从String变为int
            String[] diseaseNames = DiseaseText.Split(",");
            foreach (var item in diseaseNames)
            {
                Console.WriteLine(item);
            }
            int[] diseaseIds = new int[10];
            for (int i = 0; i < diseaseNames.Length - 1; i++)
            {
                Console.WriteLine(diseaseNames[i]);
                diseaseIds[i] = Disease.FindByName(diseaseNames[i]).ID;
            }
            //获取患有相关疾病的user
            List<UserDisease> userDiseases = new List<UserDisease>();
            for (int i = 0; i < diseaseNames.Length - 1; i++)
            {
                userDiseases.AddRange(UserDisease.FindAllByDiseaseID(diseaseIds[i]));
            }
            List<User> userList1 = new List<User>();
            foreach (var userDisease in userDiseases)
            {
                if (userList1.Exists(t => t == Zero.Data.Projects.User.FindByID(userDisease.UserID)))
                {

                }
                else
                {
                    userList1.Add(Zero.Data.Projects.User.FindByID(userDisease.UserID));
                }

            }
            //筛选出有新冠感染状态的user
            List<User> userList2 = new List<User>();
            foreach (var user1 in userList1)
            {
                if (user.InfectionID == infectionId)
                {
                    userList2.Add(user);
                }
            }
            //查询有该评价效果的Daily并且是筛选后的userid发布的
            List<DailyOrSum> DailyOrSunList = new List<DailyOrSum>();
            foreach (var user1 in userList2)
            {
                DailyOrSunList.AddRange((DailyOrSum.SearchSum(effectId, user.ID)));
            }

            return View("GetDaily", DailyOrSunList);
        }
    }
}
