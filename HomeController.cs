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
        //用户
        public IActionResult GetSearchUser(Int32 id)
        {
            User user = Zero.Data.Projects.User.FindByID(id);
            ViewData["user"] = user;

            List<User> userList = (List<User>)Zero.Data.Projects.User.FindAll();
            return View("SearchUser", userList);
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
            ViewData["user"] = user;
            
            return View("AddDaily", user);
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
