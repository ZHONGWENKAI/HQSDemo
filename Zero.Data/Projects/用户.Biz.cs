using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using NewLife;
using NewLife.Data;
using NewLife.Log;
using NewLife.Model;
using NewLife.Reflection;
using NewLife.Threading;
using NewLife.Web;
using XCode;
using XCode.Cache;
using XCode.Configuration;
using XCode.DataAccessLayer;
using XCode.Membership;
using XCode.Shards;
using Zero.Data.Areas.Projects;

namespace Zero.Data.Projects
{
    public partial class User : Entity<User>
    {
        #region 对象操作
        static User()
        {
            // 累加字段，生成 Update xx Set Count=Count+1234 Where xxx
            //var df = Meta.Factory.AdditionalFields;
            //df.Add(nameof(Sex));

            // 过滤器 UserModule、TimeModule、IPModule
            Meta.Modules.Add<UserModule>();
            Meta.Modules.Add<TimeModule>();
            Meta.Modules.Add<IPModule>();

            // 单对象缓存
            var sc = Meta.SingleCache;
            sc.FindSlaveKeyMethod = k => Find(_.Name == k);
            sc.GetSlaveKeyMethod = e => e.Name;
        }

        /// <summary>验证并修补数据，通过抛出异常的方式提示验证失败。</summary>
        /// <param name="isNew">是否插入</param>
        public override void Valid(Boolean isNew)
        {
            // 如果没有脏数据，则不需要进行任何处理
            if (!HasDirty) return;

            // 这里验证参数范围，建议抛出参数异常，指定参数名，前端用户界面可以捕获参数异常并聚焦到对应的参数输入框
            //if (Name.IsNullOrEmpty()) throw new ArgumentNullException(nameof(Name), "名称不能为空！");

            ////if (Password.IsNullOrEmpty()) throw new ArgumentNullException(nameof(Password), "密码不能为空！");

            //if (!Phone.IsNullOrEmpty())
            //{
            //    Regex regex = new Regex(@"^1[3-9]\d{9}$");
            //    if (!regex.IsMatch(Phone))
            //    {
            //        throw new ArgumentNullException(__.Phone, "请输入正确的电话号码");
            //    }
            //}
            //else
            //{
            //    throw new Exception("电话号码不能为空");
            //}

            
            //if (BirthDay==null) throw new ArgumentNullException(nameof(BirthDay), "出生日期不能为空！");
            //if (Age < 0 || Age > 150) throw new ArgumentNullException(nameof(Age), "请输入正确的年龄(0-150间的数字)！");
            //if (Height < 0 || Height > 300) throw new ArgumentNullException(nameof(Height), "请输入正确的身高(0-300cm之间)！");
            //if (Weight < 0 || Weight > 200) throw new ArgumentNullException(nameof(Weight), "请输入正确体重(0-150kg之间)！");
            //if (InfectionID<0) throw new ArgumentNullException(nameof(InfectionID), "感染症状不能为空！");
            
            // 建议先调用基类方法，基类方法会做一些统一处理
            base.Valid(isNew);

            // 在新插入数据或者修改了指定字段时进行修正
            // 处理当前已登录用户信息，可以由UserModule过滤器代劳
            /*var user = ManageProvider.User;
            if (user != null)
            {
                if (isNew && !Dirtys[nameof(CreateUserID)]) CreateUserID = user.ID;
                if (!Dirtys[nameof(UpdateUserID)]) UpdateUserID = user.ID;
            }*/
            //if (isNew && !Dirtys[nameof(CreateTime)]) CreateTime = DateTime.Now;
            //if (!Dirtys[nameof(UpdateTime)]) UpdateTime = DateTime.Now;
            //if (isNew && !Dirtys[nameof(CreateIP)]) CreateIP = ManageProvider.UserHost;
            //if (!Dirtys[nameof(UpdateIP)]) UpdateIP = ManageProvider.UserHost;

            // 检查唯一索引
            // CheckExist(isNew, nameof(Name));
        }

        ///// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //protected override void InitData()
        //{
        //    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
        //    if (Meta.Session.Count > 0) return;

        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化User[用户]数据……");

        //    var entity = new User();
        //    entity.Name = "abc";
        //    entity.Avatar = "abc";
        //    entity.Sex = 0;
        //    entity.Age = 0;
        //    entity.BirthDay = DateTime.Now;
        //    entity.Phone = "abc";
        //    entity.Height = 0;
        //    entity.Weight = 0;
        //    entity.InfectionID = 0;
        //    entity.UsageAmount = 0;
        //    entity.CreateUser = "abc";
        //    entity.CreateUserID = 0;
        //    entity.CreateIP = "abc";
        //    entity.CreateTime = DateTime.Now;
        //    entity.UpdateUser = "abc";
        //    entity.UpdateUserID = 0;
        //    entity.UpdateIP = "abc";
        //    entity.UpdateTime = DateTime.Now;
        //    entity.Remark = "abc";
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化User[用户]数据！");
        //}

        ///// <summary>已重载。基类先调用Valid(true)验证数据，然后在事务保护内调用OnInsert</summary>
        ///// <returns></returns>
        //public override Int32 Insert()
        //{
        //    return base.Insert();
        //}

        ///// <summary>已重载。在事务保护范围内处理业务，位于Valid之后</summary>
        ///// <returns></returns>
        //protected override Int32 OnDelete()
        //{
        //    return base.OnDelete();
        //}

        ///// <summary>已重载。基类先调用Valid(true)验证数据，然后在事务保护内调用OnInsert</summary>
        ///// <returns></returns>
        public override int Insert()
        {
            //XCode.Membership.User  menberUser=  new XCode.Membership.User();
            //menberUser.Name = Name;
            //menberUser.Password = Password;
            return base.Insert();
        }
        public override int Delete()
        {
            //using (var Usertran = User.Meta.CreateTrans())
            using (var UserDiseasetran = UserDisease.Meta.CreateTrans())
            using (var DailyOrSumtran = UserDisease.Meta.CreateTrans())
            {
                //todo
                //WhereExpression exp = new WhereExpression();
                //if (ID > 0) exp &= _.ID == this.ID;
                //User.Delete(exp);

                List<UserDisease> userDiseaseList = (List<UserDisease>)UserDisease.FindAllByUserID(this.ID);
                UserDisease.DeteleAllByUserID(userDiseaseList);

                List<DailyOrSum> dailyOrSumList = (List<DailyOrSum>)DailyOrSum.FindAllByUserID(this.ID);
                DailyOrSum.DeteleAllByUserID(dailyOrSumList);

                //Usertran.Commit();
                UserDiseasetran.Commit();
                DailyOrSumtran.Commit();
            }
            return base.Delete();
        }

        #endregion

        #region 扩展属性
        /// <summary>新冠感染情况</summary>
        [XmlIgnore, IgnoreDataMember]
        //[ScriptIgnore]
        public Infection Infection => Extends.Get(nameof(Infection), k => Infection.FindByID(InfectionID));

        /// <summary>新冠感染情况</summary>
        [Map(nameof(InfectionID), typeof(Infection), "ID")]
        public String InfectionName => Infection?.Name;

        #endregion

        #region 扩展查询
        /// <summary>根据编号查找</summary>
        /// <param name="id">编号</param>
        /// <returns>实体对象</returns>
        public static User FindByID(Int32 id)
        {
            if (id <= 0) return null;

            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.ID == id);

            // 单对象缓存
            return Meta.SingleCache[id];

            //return Find(_.ID == id);
        }

        /// <summary>根据名称查找</summary>
        /// <param name="name">名称</param>
        /// <returns>实体对象</returns>
        public static User FindByName(String name)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.Name.EqualIgnoreCase(name));

            // 单对象缓存
            //return Meta.SingleCache.GetItemWithSlaveKey(name) as User;

            return Find(_.Name == name);
        }

        /// <summary>根据新冠感染情况ID查找</summary>
        /// <param name="userId">用户ID</param>
        /// <returns>实体列表</returns>
        public static IList<User> FindAllByInfectionID(Int32 infectionId)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e => e.InfectionID == infectionId);

            return FindAll(_.InfectionID == infectionId);
        }

        public static IList<User> FindAllByNameLike(String name)
        {
            WhereExpression exp = new WhereExpression();
            if (name != "")
            {
                
                exp &= "name like '%" + name + "%' ";
            }
            
            return FindAll(exp);
        }

        public static IList<User> FindAllUserByDiseases(String DiseaseName)
        {

            List<User> users = new List<User>();

            if (DiseaseName != "" && DiseaseName != null)
            {
                String[] diseaseNames1 = DiseaseName.Split(",");
                String[] diseaseNames = diseaseNames1;
                for (int i = 0; i < diseaseNames1.Length - 1; i++)
                {
                    diseaseNames[i] = diseaseNames1[i];
                }
                int[] diseaseIds = { };
                for (int i = 0; i < diseaseNames.Length; i++)
                {
                    diseaseIds[i] = Disease.FindByName(diseaseNames[i]).ID;
                }
                List<UserDisease> userDiseases = new List<UserDisease>();
                for (int i = 0; i < diseaseIds.Length; i++)
                {
                    userDiseases.AddRange(UserDisease.FindAllByDiseaseID(diseaseIds[i]));
                }

                for (int i = 0; i < userDiseases.Count; i++)
                {
                    users.Add(User.FindByID(userDiseases[i].UserID));
                }

            }
            return users;
        }

        #endregion

        #region 高级查询
        /// <summary>高级查询</summary>
        /// <param name="name">名称</param>
        /// <param name="start">更新时间开始</param>
        /// <param name="end">更新时间结束</param>
        /// <param name="key">关键字</param>
        /// <param name="page">分页参数信息。可携带统计和数据权限扩展查询等信息</param>
        /// <returns>实体列表</returns>
        public static IList<User> Search(String name, DateTime start, DateTime end, String key, PageParameter page)
        {
            var exp = new WhereExpression();

            if (!name.IsNullOrEmpty()) exp &= _.Name == name;
            exp &= _.UpdateTime.Between(start, end);
            if (!key.IsNullOrEmpty()) exp &= _.Name.Contains(key) | _.Avatar.Contains(key) | _.Phone.Contains(key) | _.CreateUser.Contains(key) | _.CreateIP.Contains(key) | _.UpdateUser.Contains(key) | _.UpdateIP.Contains(key) | _.Remark.Contains(key);

            return FindAll(exp, page);
        }



        // Select Count(ID) as ID,Category From User Where CreateTime>'2020-01-24 00:00:00' Group By Category Order By ID Desc limit 20
        //static readonly FieldCache<User> _CategoryCache = new FieldCache<User>(nameof(Category))
        //{
        //Where = _.CreateTime > DateTime.Today.AddDays(-30) & Expression.Empty
        //};

        ///// <summary>获取类别列表，字段缓存10分钟，分组统计数据最多的前20种，用于魔方前台下拉选择</summary>
        ///// <returns></returns>
        //public static IDictionary<String, String> GetCategoryList() => _CategoryCache.FindAllName();
        #endregion

        #region 业务操作
        #endregion
    }
}