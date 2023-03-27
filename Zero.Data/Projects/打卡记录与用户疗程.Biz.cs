using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using NewLife;
using NewLife.Data;
using XCode;
using XCode.Membership;


namespace Zero.Data.Projects
{
    public partial class DailyOrSum : Entity<DailyOrSum>
    {
        #region 对象操作
        static DailyOrSum()
        {
            // 累加字段，生成 Update xx Set Count=Count+1234 Where xxx
            //var df = Meta.Factory.AdditionalFields;
            //df.Add(nameof(UserID));

            // 过滤器 UserModule、TimeModule、IPModule
            Meta.Modules.Add<UserModule>();
            Meta.Modules.Add<TimeModule>();
            Meta.Modules.Add<IPModule>();
        }

        /// <summary>验证并修补数据，通过抛出异常的方式提示验证失败。</summary>
        /// <param name="isNew">是否插入</param>
        public override void Valid(Boolean isNew)
        {
            // 如果没有脏数据，则不需要进行任何处理
            if (!HasDirty) return;
            if(UserID<0) throw new ArgumentNullException(nameof(UserID),"用户编号不能为空");
            if (EffectID < 0) throw new ArgumentNullException(nameof(EffectID), "用户编号不能为空");
            if(EvaluateTime==DateTime.MinValue)EvaluateTime=DateTime.Now;
            if(Type < 0) throw new ArgumentNullException(nameof(Type), "记录类型不能为空");
           
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
        }

        ///// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //protected override void InitData()
        //{
        //    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
        //    if (Meta.Session.Count > 0) return;

        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化DailyOrSum[打卡记录与用户疗程]数据……");

        //    var entity = new DailyOrSum();
        //    entity.UserID = 0;
        //    entity.EffectID = 0;
        //    entity.EvaluateTime = DateTime.Now;
        //    entity.Evaluate = "abc";
        //    entity.Recording = "abc";
        //    entity.Picture = "abc";
        //    entity.Type = 0;
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

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化DailyOrSum[打卡记录与用户疗程]数据！");
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

  

        /// <summary>根据用户ID删除所有记录</summary>
        /// <param name="dailyOrSumList">疾病ID</param>
        /// <returns>实体列表</returns>
        public static Boolean DeteleAllByUserID(List<DailyOrSum> dailyOrSumList)
        {
            bool b = false;

            if (dailyOrSumList != null)
            {
                dailyOrSumList.Delete();
                b = true;
            }


            return b;
        }

        public override int Delete()
        {          
            Picture.DeteleAllByDailyOrSum(ID);
            return base.Delete();
        }
        #endregion

        #region 扩展属性
        /// <summary>用户ID</summary>
        [XmlIgnore, IgnoreDataMember]
        //[ScriptIgnore]
        public User User => Extends.Get(nameof(User), k => User.FindByID(UserID));

        /// <summary>用户ID</summary>
        [Map(nameof(UserID), typeof(User), "ID")]
        public String UserName => User?.Name;

        /// <summary>效果ID</summary>
        [XmlIgnore, IgnoreDataMember]
        //[ScriptIgnore]
        public Effect Effect => Extends.Get(nameof(Effect), k => Effect.FindByID(EffectID));

        /// <summary>效果ID</summary>
        [Map(nameof(EffectID), typeof(Effect), "ID")]
        public String EffectName => Effect?.Name;

        /// <summary>类型枚举</summary>
        public enum Kind
        {
            打卡记录,
            疗程总结
        }
        #endregion

        #region 扩展查询
        /// <summary>根据编号查找</summary>
        /// <param name="id">编号</param>
        /// <returns>实体对象</returns>
        public static DailyOrSum FindByID(Int32 id)
        {
            if (id <= 0) return null;

            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.ID == id);

            // 单对象缓存
            return Meta.SingleCache[id];

            //return Find(_.ID == id);
        }

        /// <summary>根据用户ID查找</summary>
        /// <param name="userId">用户ID</param>
        /// <returns>实体列表</returns>
        public static IList<DailyOrSum> FindAllByUserID(Int32 userId)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e => e.UserID == userId);

            return FindAll(_.UserID == userId);
        }

        /// <summary>根据效果ID查找</summary>
        /// <param name="effectId">效果ID</param>
        /// <returns>实体列表</returns>
        public static IList<DailyOrSum> FindAllByEffectID(Int32 effectId)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e => e.EffectID == effectId);

            return FindAll(_.EffectID == effectId);
        }

        /// <summary>根据Type查找</summary>
        /// <param name="type">效果ID</param>
        /// <returns>实体列表</returns>
        public static IList<DailyOrSum> FindAllByType(Kind type)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e => e.Type == type);

            return FindAll(_.Type == type);
        }

        #endregion

        #region 高级查询
        /// <summary>高级查询</summary>
        /// <param name="userId">用户ID</param>
        /// <param name="effectId">效果ID</param>
        /// <param name="start">更新时间开始</param>
        /// <param name="end">更新时间结束</param>
        /// <param name="key">关键字</param>
        /// <param name="page">分页参数信息。可携带统计和数据权限扩展查询等信息</param>
        /// <returns>实体列表</returns>
        public static IList<DailyOrSum> Search(Int32 userId, Int32 effectId, DateTime start, DateTime end, String key, PageParameter page)
        {
            var exp = new WhereExpression();

            if (userId >= 0) exp &= _.UserID == userId;
            if (effectId >= 0) exp &= _.EffectID == effectId;
            exp &= _.UpdateTime.Between(start, end);
            if (!key.IsNullOrEmpty()) exp &= _.Evaluate.Contains(key) | _.Recording.Contains(key) | _.CreateUser.Contains(key) | _.CreateIP.Contains(key) | _.UpdateUser.Contains(key) | _.UpdateIP.Contains(key) | _.Remark.Contains(key);

            return FindAll(exp, page);
        }


        public static IList<DailyOrSum> SearchDailyByConditions(String effectName, String infectionName, String diseaseName)
        {
            List<User> userList = new List<User>();
            if(infectionName != "" && infectionName != null)
            {
                userList.AddRange(User.FindAllByInfectionID(Infection.FindByName(infectionName).ID));
            }
            if (diseaseName != "" && diseaseName != null)
            {
                userList.AddRange(User.FindAllUserByDiseases(diseaseName));
            }
            var exp = new WhereExpression();

                //模糊查询所有满足条件的Kind加入KindList
                
                String userIds = "";
                
                //Kind.ID循环放入字符串kindIds中
                if (userList != null)
                {
                    for (int i = userList.Count - 1; i >= 0; i--)
                    {
                        if (i == 0) userIds += userList[i].ID.ToString();
                        else
                        userIds += userList[i].ID.ToString() + ",";

                    }

                }
            if (!userIds.IsNullOrEmpty()) exp &= DailyOrSum._.UserID + " in(" + userIds + ")";
            if (!userIds.IsNullOrEmpty()) exp &= DailyOrSum._.EffectID == Effect.FindByName(effectName).ID;
            //List<DailyOrSum> dailyOrSumList = DailyOrSum.FindAllByEffectID(Effect.FindByName(effectName));

            //for(int i = 0; i < userList.Count; i++)
            //{
            //    dailyOrSumList.AddRange(DailyOrSum.FindAllByUserID(userList[i]));
            //}
            exp &= DailyOrSum._.Type == Kind.打卡记录;


            return FindAll(exp);
        }

        // Select Count(ID) as ID,Category From DailyOrSum Where CreateTime>'2020-01-24 00:00:00' Group By Category Order By ID Desc limit 20
        //static readonly FieldCache<DailyOrSum> _CategoryCache = new FieldCache<DailyOrSum>(nameof(Category))
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