using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Zero.Data.Projects
{
    /// <summary>用户。存储用户信息</summary>
    public partial interface IUser
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 ID { get; set; }

        /// <summary>密码</summary>
        String Password { get; set; }

        /// <summary>名称</summary>
        String Name { get; set; }

        /// <summary>头像</summary>
        String Avatar { get; set; }

        /// <summary>性别</summary>
        XCode.Membership.SexKinds Sex { get; set; }

        /// <summary>年龄</summary>
        Int32 Age { get; set; }

        /// <summary>出生日期</summary>
        DateTime BirthDay { get; set; }

        /// <summary>手机</summary>
        String Phone { get; set; }

        /// <summary>身高cm</summary>
        Int32 Height { get; set; }

        /// <summary>体重kg</summary>
        Int32 Weight { get; set; }

        /// <summary>新冠感染情况</summary>
        Int32 InfectionID { get; set; }

        /// <summary>服用数量</summary>
        Int32 UsageAmount { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }
        #endregion
    }
}