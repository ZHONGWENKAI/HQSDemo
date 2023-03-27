using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Zero.Data.Projects
{
    /// <summary>用户疾病。用户疾病对应表</summary>
    public partial interface IUserDisease
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 ID { get; set; }

        /// <summary>用户ID</summary>
        Int32 UserID { get; set; }

        /// <summary>疾病ID</summary>
        Int32 DiseaseID { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }
        #endregion
    }
}