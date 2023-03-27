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
    /// <summary>用户。存储用户信息</summary>
    [Serializable]
    [DataObject]
    [Description("用户。存储用户信息")]
    [BindIndex("IU_User_Name", true, "Name")]
    [BindTable("User", Description = "用户。存储用户信息", ConnName = "Zero", DbType = DatabaseType.None)]
    public partial class User : IUser
    {
        #region 属性
        private Int32 _ID;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("ID", "编号", "")]
        public Int32 ID { get => _ID; set { if (OnPropertyChanging("ID", value)) { _ID = value; OnPropertyChanged("ID"); } } }

        private String _Password;
        /// <summary>密码</summary>
        [DisplayName("密码")]
        [Description("密码")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn("password", "密码", "")]
        public String Password { get => _Password; set { if (OnPropertyChanging("Password", value)) { _Password = value; OnPropertyChanged("Password"); } } }

        private String _Name;
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn("Name", "名称", "", Master = true)]
        public String Name { get => _Name; set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } } }

        private String _Avatar;
        /// <summary>头像</summary>
        [DisplayName("头像")]
        [Description("头像")]
        [DataObjectField(false, false, true, 1000000)]
        [BindColumn("Avatar", "头像", "")]
        public String Avatar { get => _Avatar; set { if (OnPropertyChanging("Avatar", value)) { _Avatar = value; OnPropertyChanged("Avatar"); } } }

        private XCode.Membership.SexKinds _Sex;
        /// <summary>性别</summary>
        [DisplayName("性别")]
        [Description("性别")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Sex", "性别", "")]
        public XCode.Membership.SexKinds Sex { get => _Sex; set { if (OnPropertyChanging("Sex", value)) { _Sex = value; OnPropertyChanged("Sex"); } } }

        private Int32 _Age;
        /// <summary>年龄</summary>
        [DisplayName("年龄")]
        [Description("年龄")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Age", "年龄", "")]
        public Int32 Age { get => _Age; set { if (OnPropertyChanging("Age", value)) { _Age = value; OnPropertyChanged("Age"); } } }

        private DateTime _BirthDay;
        /// <summary>出生日期</summary>
        [DisplayName("出生日期")]
        [Description("出生日期")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("BirthDay", "出生日期", "")]
        public DateTime BirthDay { get => _BirthDay; set { if (OnPropertyChanging("BirthDay", value)) { _BirthDay = value; OnPropertyChanged("BirthDay"); } } }

        private String _Phone;
        /// <summary>手机</summary>
        [DisplayName("手机")]
        [Description("手机")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn("Phone", "手机", "")]
        public String Phone { get => _Phone; set { if (OnPropertyChanging("Phone", value)) { _Phone = value; OnPropertyChanged("Phone"); } } }

        private Int32 _Height;
        /// <summary>身高cm</summary>
        [DisplayName("身高cm")]
        [Description("身高cm")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Height", "身高cm", "")]
        public Int32 Height { get => _Height; set { if (OnPropertyChanging("Height", value)) { _Height = value; OnPropertyChanged("Height"); } } }

        private Int32 _Weight;
        /// <summary>体重kg</summary>
        [DisplayName("体重kg")]
        [Description("体重kg")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Weight", "体重kg", "")]
        public Int32 Weight { get => _Weight; set { if (OnPropertyChanging("Weight", value)) { _Weight = value; OnPropertyChanged("Weight"); } } }

        private Int32 _InfectionID;
        /// <summary>新冠感染情况</summary>
        [DisplayName("新冠感染情况")]
        [Description("新冠感染情况")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("InfectionID", "新冠感染情况", "")]
        public Int32 InfectionID { get => _InfectionID; set { if (OnPropertyChanging("InfectionID", value)) { _InfectionID = value; OnPropertyChanged("InfectionID"); } } }

        private Int32 _UsageAmount;
        /// <summary>服用数量</summary>
        [DisplayName("服用数量")]
        [Description("服用数量")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("UsageAmount", "服用数量", "")]
        public Int32 UsageAmount { get => _UsageAmount; set { if (OnPropertyChanging("UsageAmount", value)) { _UsageAmount = value; OnPropertyChanged("UsageAmount"); } } }

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
                    case "Password": return _Password;
                    case "Name": return _Name;
                    case "Avatar": return _Avatar;
                    case "Sex": return _Sex;
                    case "Age": return _Age;
                    case "BirthDay": return _BirthDay;
                    case "Phone": return _Phone;
                    case "Height": return _Height;
                    case "Weight": return _Weight;
                    case "InfectionID": return _InfectionID;
                    case "UsageAmount": return _UsageAmount;
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
                    case "Password": _Password = Convert.ToString(value); break;
                    case "Name": _Name = Convert.ToString(value); break;
                    case "Avatar": _Avatar = Convert.ToString(value); break;
                    case "Sex": _Sex = (XCode.Membership.SexKinds)value.ToInt(); break;
                    case "Age": _Age = value.ToInt(); break;
                    case "BirthDay": _BirthDay = value.ToDateTime(); break;
                    case "Phone": _Phone = Convert.ToString(value); break;
                    case "Height": _Height = value.ToInt(); break;
                    case "Weight": _Weight = value.ToInt(); break;
                    case "InfectionID": _InfectionID = value.ToInt(); break;
                    case "UsageAmount": _UsageAmount = value.ToInt(); break;
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
        /// <summary>取得用户字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>编号</summary>
            public static readonly Field ID = FindByName("ID");

            /// <summary>密码</summary>
            public static readonly Field Password = FindByName("Password");

            /// <summary>名称</summary>
            public static readonly Field Name = FindByName("Name");

            /// <summary>头像</summary>
            public static readonly Field Avatar = FindByName("Avatar");

            /// <summary>性别</summary>
            public static readonly Field Sex = FindByName("Sex");

            /// <summary>年龄</summary>
            public static readonly Field Age = FindByName("Age");

            /// <summary>出生日期</summary>
            public static readonly Field BirthDay = FindByName("BirthDay");

            /// <summary>手机</summary>
            public static readonly Field Phone = FindByName("Phone");

            /// <summary>身高cm</summary>
            public static readonly Field Height = FindByName("Height");

            /// <summary>体重kg</summary>
            public static readonly Field Weight = FindByName("Weight");

            /// <summary>新冠感染情况</summary>
            public static readonly Field InfectionID = FindByName("InfectionID");

            /// <summary>服用数量</summary>
            public static readonly Field UsageAmount = FindByName("UsageAmount");

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

        /// <summary>取得用户字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>编号</summary>
            public const String ID = "ID";

            /// <summary>密码</summary>
            public const String Password = "Password";

            /// <summary>名称</summary>
            public const String Name = "Name";

            /// <summary>头像</summary>
            public const String Avatar = "Avatar";

            /// <summary>性别</summary>
            public const String Sex = "Sex";

            /// <summary>年龄</summary>
            public const String Age = "Age";

            /// <summary>出生日期</summary>
            public const String BirthDay = "BirthDay";

            /// <summary>手机</summary>
            public const String Phone = "Phone";

            /// <summary>身高cm</summary>
            public const String Height = "Height";

            /// <summary>体重kg</summary>
            public const String Weight = "Weight";

            /// <summary>新冠感染情况</summary>
            public const String InfectionID = "InfectionID";

            /// <summary>服用数量</summary>
            public const String UsageAmount = "UsageAmount";

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