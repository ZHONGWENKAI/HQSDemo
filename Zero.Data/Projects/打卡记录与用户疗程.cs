using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Zero.Data.Projects
{
    /// <summary>打卡记录与用户疗程。存储用户疗程和打卡记录</summary>
    [Serializable]
    [DataObject]
    [Description("打卡记录与用户疗程。存储用户疗程和打卡记录")]
    [BindIndex("IX_DailyOrSum_UserID", false, "UserID")]
    [BindIndex("IX_DailyOrSum_EffectID", false, "EffectID")]
    [BindTable("DailyOrSum", Description = "打卡记录与用户疗程。存储用户疗程和打卡记录", ConnName = "Zero", DbType = DatabaseType.None)]
    public partial class DailyOrSum : IDailyOrSum
    {
        #region 属性
        private Int32 _ID;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("ID", "编号", "")]
        public Int32 ID { get => _ID; set { if (OnPropertyChanging("ID", value)) { _ID = value; OnPropertyChanged("ID"); } } }

        private Int32 _UserID;
        /// <summary>用户ID</summary>
        [DisplayName("用户ID")]
        [Description("用户ID")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("UserID", "用户ID", "", Master = true)]
        public Int32 UserID { get => _UserID; set { if (OnPropertyChanging("UserID", value)) { _UserID = value; OnPropertyChanged("UserID"); } } }

        private Int32 _EffectID;
        /// <summary>效果ID</summary>
        [DisplayName("效果ID")]
        [Description("效果ID")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("EffectID", "效果ID", "", Master = true)]
        public Int32 EffectID { get => _EffectID; set { if (OnPropertyChanging("EffectID", value)) { _EffectID = value; OnPropertyChanged("EffectID"); } } }

        private DateTime _EvaluateTime;
        /// <summary>评价时间</summary>
        [DisplayName("评价时间")]
        [Description("评价时间")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("EvaluateTime", "评价时间", "")]
        public DateTime EvaluateTime { get => _EvaluateTime; set { if (OnPropertyChanging("EvaluateTime", value)) { _EvaluateTime = value; OnPropertyChanged("EvaluateTime"); } } }

        private String _Evaluate;
        /// <summary>文字评论</summary>
        [DisplayName("文字评论")]
        [Description("文字评论")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Evaluate", "文字评论", "")]
        public String Evaluate { get => _Evaluate; set { if (OnPropertyChanging("Evaluate", value)) { _Evaluate = value; OnPropertyChanged("Evaluate"); } } }

        private String _Recording;
        /// <summary>录音</summary>
        [DisplayName("录音")]
        [Description("录音")]
        [DataObjectField(false, false, true, 1000000)]
        [BindColumn("Recording", "录音", "")]
        public String Recording { get => _Recording; set { if (OnPropertyChanging("Recording", value)) { _Recording = value; OnPropertyChanged("Recording"); } } }

        private Data.Projects.DailyOrSum.Kind _Type;
        /// <summary>类型</summary>
        [DisplayName("类型")]
        [Description("类型")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Type", "类型", "")]
        public Data.Projects.DailyOrSum.Kind Type { get => _Type; set { if (OnPropertyChanging("Type", value)) { _Type = value; OnPropertyChanged("Type"); } } }

        private String _CreateUser;
        /// <summary>创建者</summary>
        [DisplayName("创建者")]
        [Description("创建者")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("CreateUser", "创建者", "")]
        public String CreateUser { get => _CreateUser; set { if (OnPropertyChanging("CreateUser", value)) { _CreateUser = value; OnPropertyChanged("CreateUser"); } } }

        private Int32 _CreateUserID;
        /// <summary>创建人</summary>
        [DisplayName("创建人")]
        [Description("创建人")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("CreateUserID", "创建人", "")]
        public Int32 CreateUserID { get => _CreateUserID; set { if (OnPropertyChanging("CreateUserID", value)) { _CreateUserID = value; OnPropertyChanged("CreateUserID"); } } }

        private String _CreateIP;
        /// <summary>创建地址</summary>
        [DisplayName("创建地址")]
        [Description("创建地址")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("CreateIP", "创建地址", "")]
        public String CreateIP { get => _CreateIP; set { if (OnPropertyChanging("CreateIP", value)) { _CreateIP = value; OnPropertyChanged("CreateIP"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("CreateTime", "创建时间", "")]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private String _UpdateUser;
        /// <summary>更新者</summary>
        [DisplayName("更新者")]
        [Description("更新者")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("UpdateUser", "更新者", "")]
        public String UpdateUser { get => _UpdateUser; set { if (OnPropertyChanging("UpdateUser", value)) { _UpdateUser = value; OnPropertyChanged("UpdateUser"); } } }

        private Int32 _UpdateUserID;
        /// <summary>更新人</summary>
        [DisplayName("更新人")]
        [Description("更新人")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("UpdateUserID", "更新人", "")]
        public Int32 UpdateUserID { get => _UpdateUserID; set { if (OnPropertyChanging("UpdateUserID", value)) { _UpdateUserID = value; OnPropertyChanged("UpdateUserID"); } } }

        private String _UpdateIP;
        /// <summary>更新地址</summary>
        [DisplayName("更新地址")]
        [Description("更新地址")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("UpdateIP", "更新地址", "")]
        public String UpdateIP { get => _UpdateIP; set { if (OnPropertyChanging("UpdateIP", value)) { _UpdateIP = value; OnPropertyChanged("UpdateIP"); } } }

        private DateTime _UpdateTime;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("UpdateTime", "更新时间", "")]
        public DateTime UpdateTime { get => _UpdateTime; set { if (OnPropertyChanging("UpdateTime", value)) { _UpdateTime = value; OnPropertyChanged("UpdateTime"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn("Remark", "备注", "")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } } }
        #endregion

        #region 拷贝
        /// <summary>拷贝模型对象</summary>
        /// <param name="model">模型</param>
        public void Copy(IDailyOrSum model)
        {
            ID = model.ID;
            UserID = model.UserID;
            EffectID = model.EffectID;
            EvaluateTime = model.EvaluateTime;
            Evaluate = model.Evaluate;
            Recording = model.Recording;
            Type = model.Type;
            Remark = model.Remark;
        }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        public override Object this[String name]
        {
            get
            {
                switch (name)
                {
                    case "ID": return _ID;
                    case "UserID": return _UserID;
                    case "EffectID": return _EffectID;
                    case "EvaluateTime": return _EvaluateTime;
                    case "Evaluate": return _Evaluate;
                    case "Recording": return _Recording;
                    case "Type": return _Type;
                    case "CreateUser": return _CreateUser;
                    case "CreateUserID": return _CreateUserID;
                    case "CreateIP": return _CreateIP;
                    case "CreateTime": return _CreateTime;
                    case "UpdateUser": return _UpdateUser;
                    case "UpdateUserID": return _UpdateUserID;
                    case "UpdateIP": return _UpdateIP;
                    case "UpdateTime": return _UpdateTime;
                    case "Remark": return _Remark;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "ID": _ID = value.ToInt(); break;
                    case "UserID": _UserID = value.ToInt(); break;
                    case "EffectID": _EffectID = value.ToInt(); break;
                    case "EvaluateTime": _EvaluateTime = value.ToDateTime(); break;
                    case "Evaluate": _Evaluate = Convert.ToString(value); break;
                    case "Recording": _Recording = Convert.ToString(value); break;
                    case "Type": _Type = (Data.Projects.DailyOrSum.Kind)value.ToInt(); break;
                    case "CreateUser": _CreateUser = Convert.ToString(value); break;
                    case "CreateUserID": _CreateUserID = value.ToInt(); break;
                    case "CreateIP": _CreateIP = Convert.ToString(value); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "UpdateUser": _UpdateUser = Convert.ToString(value); break;
                    case "UpdateUserID": _UpdateUserID = value.ToInt(); break;
                    case "UpdateIP": _UpdateIP = Convert.ToString(value); break;
                    case "UpdateTime": _UpdateTime = value.ToDateTime(); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得打卡记录与用户疗程字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>编号</summary>
            public static readonly Field ID = FindByName("ID");

            /// <summary>用户ID</summary>
            public static readonly Field UserID = FindByName("UserID");

            /// <summary>效果ID</summary>
            public static readonly Field EffectID = FindByName("EffectID");

            /// <summary>评价时间</summary>
            public static readonly Field EvaluateTime = FindByName("EvaluateTime");

            /// <summary>文字评论</summary>
            public static readonly Field Evaluate = FindByName("Evaluate");

            /// <summary>录音</summary>
            public static readonly Field Recording = FindByName("Recording");

            /// <summary>类型</summary>
            public static readonly Field Type = FindByName("Type");

            /// <summary>创建者</summary>
            public static readonly Field CreateUser = FindByName("CreateUser");

            /// <summary>创建人</summary>
            public static readonly Field CreateUserID = FindByName("CreateUserID");

            /// <summary>创建地址</summary>
            public static readonly Field CreateIP = FindByName("CreateIP");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>更新者</summary>
            public static readonly Field UpdateUser = FindByName("UpdateUser");

            /// <summary>更新人</summary>
            public static readonly Field UpdateUserID = FindByName("UpdateUserID");

            /// <summary>更新地址</summary>
            public static readonly Field UpdateIP = FindByName("UpdateIP");

            /// <summary>更新时间</summary>
            public static readonly Field UpdateTime = FindByName("UpdateTime");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得打卡记录与用户疗程字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>编号</summary>
            public const String ID = "ID";

            /// <summary>用户ID</summary>
            public const String UserID = "UserID";

            /// <summary>效果ID</summary>
            public const String EffectID = "EffectID";

            /// <summary>评价时间</summary>
            public const String EvaluateTime = "EvaluateTime";

            /// <summary>文字评论</summary>
            public const String Evaluate = "Evaluate";

            /// <summary>录音</summary>
            public const String Recording = "Recording";

            /// <summary>类型</summary>
            public const String Type = "Type";

            /// <summary>创建者</summary>
            public const String CreateUser = "CreateUser";

            /// <summary>创建人</summary>
            public const String CreateUserID = "CreateUserID";

            /// <summary>创建地址</summary>
            public const String CreateIP = "CreateIP";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>更新者</summary>
            public const String UpdateUser = "UpdateUser";

            /// <summary>更新人</summary>
            public const String UpdateUserID = "UpdateUserID";

            /// <summary>更新地址</summary>
            public const String UpdateIP = "UpdateIP";

            /// <summary>更新时间</summary>
            public const String UpdateTime = "UpdateTime";

            /// <summary>备注</summary>
            public const String Remark = "Remark";
        }
        #endregion
    }
}