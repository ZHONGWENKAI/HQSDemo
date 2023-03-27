using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Zero.Data.Projects
{
    /// <summary>用户。存储用户信息</summary>
    public partial class UserModel : IUser
    {
        #region 属性
        /// <summary>编号</summary>
        public Int32 ID { get; set; }

        /// <summary>密码</summary>
        public String Password { get; set; }

        /// <summary>名称</summary>
        public String Name { get; set; }

        /// <summary>头像</summary>
        public String Avatar { get; set; }

        /// <summary>性别</summary>
        public XCode.Membership.SexKinds Sex { get; set; }

        /// <summary>年龄</summary>
        public Int32 Age { get; set; }

        /// <summary>出生日期</summary>
        public DateTime BirthDay { get; set; }

        /// <summary>手机</summary>
        public String Phone { get; set; }

        /// <summary>身高cm</summary>
        public Int32 Height { get; set; }

        /// <summary>体重kg</summary>
        public Int32 Weight { get; set; }

        /// <summary>新冠感染情况</summary>
        public Int32 InfectionID { get; set; }

        /// <summary>服用数量</summary>
        public Int32 UsageAmount { get; set; }

        /// <summary>备注</summary>
        public String Remark { get; set; }
        #endregion

        #region 拷贝
        /// <summary>拷贝模型对象</summary>
        /// <param name="model">模型</param>
        public void Copy(IUser model)
        {
            ID = model.ID;
            Password = model.Password;
            Name = model.Name;
            Avatar = model.Avatar;
            Sex = model.Sex;
            Age = model.Age;
            BirthDay = model.BirthDay;
            Phone = model.Phone;
            Height = model.Height;
            Weight = model.Weight;
            InfectionID = model.InfectionID;
            UsageAmount = model.UsageAmount;
            Remark = model.Remark;
        }
        #endregion
    }
}