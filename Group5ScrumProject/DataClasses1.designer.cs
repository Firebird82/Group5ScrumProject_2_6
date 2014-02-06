﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Group5ScrumProject
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="ProjectRooms")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InserttbBooking(tbBooking instance);
    partial void UpdatetbBooking(tbBooking instance);
    partial void DeletetbBooking(tbBooking instance);
    partial void InserttbUser(tbUser instance);
    partial void UpdatetbUser(tbUser instance);
    partial void DeletetbUser(tbUser instance);
    partial void InserttbRole(tbRole instance);
    partial void UpdatetbRole(tbRole instance);
    partial void DeletetbRole(tbRole instance);
    partial void InserttbRoom(tbRoom instance);
    partial void UpdatetbRoom(tbRoom instance);
    partial void DeletetbRoom(tbRoom instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["ProjectRoomsConnectionString3"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<tbBooking> tbBookings
		{
			get
			{
				return this.GetTable<tbBooking>();
			}
		}
		
		public System.Data.Linq.Table<tbUser> tbUsers
		{
			get
			{
				return this.GetTable<tbUser>();
			}
		}
		
		public System.Data.Linq.Table<tbRole> tbRoles
		{
			get
			{
				return this.GetTable<tbRole>();
			}
		}
		
		public System.Data.Linq.Table<tbRoom> tbRooms
		{
			get
			{
				return this.GetTable<tbRoom>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tbBooking")]
	public partial class tbBooking : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _iBookingID;
		
		private int _iUserId;
		
		private int _iRumId;
		
		private System.DateTime _dtDateDay;
		
		private System.TimeSpan _dtTimeStart;
		
		private System.TimeSpan _dtTimeEnd;
		
		private EntityRef<tbUser> _tbUser;
		
		private EntityRef<tbRoom> _tbRoom;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OniBookingIDChanging(int value);
    partial void OniBookingIDChanged();
    partial void OniUserIdChanging(int value);
    partial void OniUserIdChanged();
    partial void OniRumIdChanging(int value);
    partial void OniRumIdChanged();
    partial void OndtDateDayChanging(System.DateTime value);
    partial void OndtDateDayChanged();
    partial void OndtTimeStartChanging(System.TimeSpan value);
    partial void OndtTimeStartChanged();
    partial void OndtTimeEndChanging(System.TimeSpan value);
    partial void OndtTimeEndChanged();
    #endregion
		
		public tbBooking()
		{
			this._tbUser = default(EntityRef<tbUser>);
			this._tbRoom = default(EntityRef<tbRoom>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_iBookingID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int iBookingID
		{
			get
			{
				return this._iBookingID;
			}
			set
			{
				if ((this._iBookingID != value))
				{
					this.OniBookingIDChanging(value);
					this.SendPropertyChanging();
					this._iBookingID = value;
					this.SendPropertyChanged("iBookingID");
					this.OniBookingIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_iUserId", DbType="Int NOT NULL")]
		public int iUserId
		{
			get
			{
				return this._iUserId;
			}
			set
			{
				if ((this._iUserId != value))
				{
					if (this._tbUser.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OniUserIdChanging(value);
					this.SendPropertyChanging();
					this._iUserId = value;
					this.SendPropertyChanged("iUserId");
					this.OniUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_iRumId", DbType="Int NOT NULL")]
		public int iRumId
		{
			get
			{
				return this._iRumId;
			}
			set
			{
				if ((this._iRumId != value))
				{
					if (this._tbRoom.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OniRumIdChanging(value);
					this.SendPropertyChanging();
					this._iRumId = value;
					this.SendPropertyChanged("iRumId");
					this.OniRumIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_dtDateDay", DbType="Date NOT NULL")]
		public System.DateTime dtDateDay
		{
			get
			{
				return this._dtDateDay;
			}
			set
			{
				if ((this._dtDateDay != value))
				{
					this.OndtDateDayChanging(value);
					this.SendPropertyChanging();
					this._dtDateDay = value;
					this.SendPropertyChanged("dtDateDay");
					this.OndtDateDayChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_dtTimeStart", DbType="Time NOT NULL")]
		public System.TimeSpan dtTimeStart
		{
			get
			{
				return this._dtTimeStart;
			}
			set
			{
				if ((this._dtTimeStart != value))
				{
					this.OndtTimeStartChanging(value);
					this.SendPropertyChanging();
					this._dtTimeStart = value;
					this.SendPropertyChanged("dtTimeStart");
					this.OndtTimeStartChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_dtTimeEnd", DbType="Time NOT NULL")]
		public System.TimeSpan dtTimeEnd
		{
			get
			{
				return this._dtTimeEnd;
			}
			set
			{
				if ((this._dtTimeEnd != value))
				{
					this.OndtTimeEndChanging(value);
					this.SendPropertyChanging();
					this._dtTimeEnd = value;
					this.SendPropertyChanged("dtTimeEnd");
					this.OndtTimeEndChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tbUser_tbBooking", Storage="_tbUser", ThisKey="iUserId", OtherKey="iUserId", IsForeignKey=true)]
		public tbUser tbUser
		{
			get
			{
				return this._tbUser.Entity;
			}
			set
			{
				tbUser previousValue = this._tbUser.Entity;
				if (((previousValue != value) 
							|| (this._tbUser.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._tbUser.Entity = null;
						previousValue.tbBookings.Remove(this);
					}
					this._tbUser.Entity = value;
					if ((value != null))
					{
						value.tbBookings.Add(this);
						this._iUserId = value.iUserId;
					}
					else
					{
						this._iUserId = default(int);
					}
					this.SendPropertyChanged("tbUser");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tbRoom_tbBooking", Storage="_tbRoom", ThisKey="iRumId", OtherKey="iRoomId", IsForeignKey=true)]
		public tbRoom tbRoom
		{
			get
			{
				return this._tbRoom.Entity;
			}
			set
			{
				tbRoom previousValue = this._tbRoom.Entity;
				if (((previousValue != value) 
							|| (this._tbRoom.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._tbRoom.Entity = null;
						previousValue.tbBookings.Remove(this);
					}
					this._tbRoom.Entity = value;
					if ((value != null))
					{
						value.tbBookings.Add(this);
						this._iRumId = value.iRoomId;
					}
					else
					{
						this._iRumId = default(int);
					}
					this.SendPropertyChanged("tbRoom");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tbUser")]
	public partial class tbUser : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _iUserId;
		
		private string _sUserName;
		
		private string _sUserLoginName;
		
		private string _sUserPassword;
		
		private System.Nullable<int> _iUserRole;
		
		private System.Nullable<int> _iBlocked;
		
		private System.Nullable<int> _iActivBooking;
		
		private string _sClass;
		
		private EntitySet<tbBooking> _tbBookings;
		
		private EntityRef<tbRole> _tbRole;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OniUserIdChanging(int value);
    partial void OniUserIdChanged();
    partial void OnsUserNameChanging(string value);
    partial void OnsUserNameChanged();
    partial void OnsUserLoginNameChanging(string value);
    partial void OnsUserLoginNameChanged();
    partial void OnsUserPasswordChanging(string value);
    partial void OnsUserPasswordChanged();
    partial void OniUserRoleChanging(System.Nullable<int> value);
    partial void OniUserRoleChanged();
    partial void OniBlockedChanging(System.Nullable<int> value);
    partial void OniBlockedChanged();
    partial void OniActivBookingChanging(System.Nullable<int> value);
    partial void OniActivBookingChanged();
    partial void OnsClassChanging(string value);
    partial void OnsClassChanged();
    #endregion
		
		public tbUser()
		{
			this._tbBookings = new EntitySet<tbBooking>(new Action<tbBooking>(this.attach_tbBookings), new Action<tbBooking>(this.detach_tbBookings));
			this._tbRole = default(EntityRef<tbRole>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_iUserId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int iUserId
		{
			get
			{
				return this._iUserId;
			}
			set
			{
				if ((this._iUserId != value))
				{
					this.OniUserIdChanging(value);
					this.SendPropertyChanging();
					this._iUserId = value;
					this.SendPropertyChanged("iUserId");
					this.OniUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sUserName", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string sUserName
		{
			get
			{
				return this._sUserName;
			}
			set
			{
				if ((this._sUserName != value))
				{
					this.OnsUserNameChanging(value);
					this.SendPropertyChanging();
					this._sUserName = value;
					this.SendPropertyChanged("sUserName");
					this.OnsUserNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sUserLoginName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string sUserLoginName
		{
			get
			{
				return this._sUserLoginName;
			}
			set
			{
				if ((this._sUserLoginName != value))
				{
					this.OnsUserLoginNameChanging(value);
					this.SendPropertyChanging();
					this._sUserLoginName = value;
					this.SendPropertyChanged("sUserLoginName");
					this.OnsUserLoginNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sUserPassword", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string sUserPassword
		{
			get
			{
				return this._sUserPassword;
			}
			set
			{
				if ((this._sUserPassword != value))
				{
					this.OnsUserPasswordChanging(value);
					this.SendPropertyChanging();
					this._sUserPassword = value;
					this.SendPropertyChanged("sUserPassword");
					this.OnsUserPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_iUserRole", DbType="Int")]
		public System.Nullable<int> iUserRole
		{
			get
			{
				return this._iUserRole;
			}
			set
			{
				if ((this._iUserRole != value))
				{
					if (this._tbRole.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OniUserRoleChanging(value);
					this.SendPropertyChanging();
					this._iUserRole = value;
					this.SendPropertyChanged("iUserRole");
					this.OniUserRoleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_iBlocked", DbType="Int")]
		public System.Nullable<int> iBlocked
		{
			get
			{
				return this._iBlocked;
			}
			set
			{
				if ((this._iBlocked != value))
				{
					this.OniBlockedChanging(value);
					this.SendPropertyChanging();
					this._iBlocked = value;
					this.SendPropertyChanged("iBlocked");
					this.OniBlockedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_iActivBooking", DbType="Int")]
		public System.Nullable<int> iActivBooking
		{
			get
			{
				return this._iActivBooking;
			}
			set
			{
				if ((this._iActivBooking != value))
				{
					this.OniActivBookingChanging(value);
					this.SendPropertyChanging();
					this._iActivBooking = value;
					this.SendPropertyChanged("iActivBooking");
					this.OniActivBookingChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sClass", DbType="NVarChar(50)")]
		public string sClass
		{
			get
			{
				return this._sClass;
			}
			set
			{
				if ((this._sClass != value))
				{
					this.OnsClassChanging(value);
					this.SendPropertyChanging();
					this._sClass = value;
					this.SendPropertyChanged("sClass");
					this.OnsClassChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tbUser_tbBooking", Storage="_tbBookings", ThisKey="iUserId", OtherKey="iUserId")]
		public EntitySet<tbBooking> tbBookings
		{
			get
			{
				return this._tbBookings;
			}
			set
			{
				this._tbBookings.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tbRole_tbUser", Storage="_tbRole", ThisKey="iUserRole", OtherKey="iRoleID", IsForeignKey=true)]
		public tbRole tbRole
		{
			get
			{
				return this._tbRole.Entity;
			}
			set
			{
				tbRole previousValue = this._tbRole.Entity;
				if (((previousValue != value) 
							|| (this._tbRole.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._tbRole.Entity = null;
						previousValue.tbUsers.Remove(this);
					}
					this._tbRole.Entity = value;
					if ((value != null))
					{
						value.tbUsers.Add(this);
						this._iUserRole = value.iRoleID;
					}
					else
					{
						this._iUserRole = default(Nullable<int>);
					}
					this.SendPropertyChanged("tbRole");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_tbBookings(tbBooking entity)
		{
			this.SendPropertyChanging();
			entity.tbUser = this;
		}
		
		private void detach_tbBookings(tbBooking entity)
		{
			this.SendPropertyChanging();
			entity.tbUser = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tbRole")]
	public partial class tbRole : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _iRoleID;
		
		private string _sRoleType;
		
		private EntitySet<tbUser> _tbUsers;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OniRoleIDChanging(int value);
    partial void OniRoleIDChanged();
    partial void OnsRoleTypeChanging(string value);
    partial void OnsRoleTypeChanged();
    #endregion
		
		public tbRole()
		{
			this._tbUsers = new EntitySet<tbUser>(new Action<tbUser>(this.attach_tbUsers), new Action<tbUser>(this.detach_tbUsers));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_iRoleID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int iRoleID
		{
			get
			{
				return this._iRoleID;
			}
			set
			{
				if ((this._iRoleID != value))
				{
					this.OniRoleIDChanging(value);
					this.SendPropertyChanging();
					this._iRoleID = value;
					this.SendPropertyChanged("iRoleID");
					this.OniRoleIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sRoleType", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string sRoleType
		{
			get
			{
				return this._sRoleType;
			}
			set
			{
				if ((this._sRoleType != value))
				{
					this.OnsRoleTypeChanging(value);
					this.SendPropertyChanging();
					this._sRoleType = value;
					this.SendPropertyChanged("sRoleType");
					this.OnsRoleTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tbRole_tbUser", Storage="_tbUsers", ThisKey="iRoleID", OtherKey="iUserRole")]
		public EntitySet<tbUser> tbUsers
		{
			get
			{
				return this._tbUsers;
			}
			set
			{
				this._tbUsers.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_tbUsers(tbUser entity)
		{
			this.SendPropertyChanging();
			entity.tbRole = this;
		}
		
		private void detach_tbUsers(tbUser entity)
		{
			this.SendPropertyChanging();
			entity.tbRole = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tbRoom")]
	public partial class tbRoom : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _iRoomId;
		
		private string _sRoomName;
		
		private int _iRoomChairs;
		
		private string _sRoomDesc;
		
		private EntitySet<tbBooking> _tbBookings;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OniRoomIdChanging(int value);
    partial void OniRoomIdChanged();
    partial void OnsRoomNameChanging(string value);
    partial void OnsRoomNameChanged();
    partial void OniRoomChairsChanging(int value);
    partial void OniRoomChairsChanged();
    partial void OnsRoomDescChanging(string value);
    partial void OnsRoomDescChanged();
    #endregion
		
		public tbRoom()
		{
			this._tbBookings = new EntitySet<tbBooking>(new Action<tbBooking>(this.attach_tbBookings), new Action<tbBooking>(this.detach_tbBookings));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_iRoomId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int iRoomId
		{
			get
			{
				return this._iRoomId;
			}
			set
			{
				if ((this._iRoomId != value))
				{
					this.OniRoomIdChanging(value);
					this.SendPropertyChanging();
					this._iRoomId = value;
					this.SendPropertyChanged("iRoomId");
					this.OniRoomIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sRoomName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string sRoomName
		{
			get
			{
				return this._sRoomName;
			}
			set
			{
				if ((this._sRoomName != value))
				{
					this.OnsRoomNameChanging(value);
					this.SendPropertyChanging();
					this._sRoomName = value;
					this.SendPropertyChanged("sRoomName");
					this.OnsRoomNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_iRoomChairs", DbType="Int NOT NULL")]
		public int iRoomChairs
		{
			get
			{
				return this._iRoomChairs;
			}
			set
			{
				if ((this._iRoomChairs != value))
				{
					this.OniRoomChairsChanging(value);
					this.SendPropertyChanging();
					this._iRoomChairs = value;
					this.SendPropertyChanged("iRoomChairs");
					this.OniRoomChairsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sRoomDesc", DbType="NVarChar(150)")]
		public string sRoomDesc
		{
			get
			{
				return this._sRoomDesc;
			}
			set
			{
				if ((this._sRoomDesc != value))
				{
					this.OnsRoomDescChanging(value);
					this.SendPropertyChanging();
					this._sRoomDesc = value;
					this.SendPropertyChanged("sRoomDesc");
					this.OnsRoomDescChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tbRoom_tbBooking", Storage="_tbBookings", ThisKey="iRoomId", OtherKey="iRumId")]
		public EntitySet<tbBooking> tbBookings
		{
			get
			{
				return this._tbBookings;
			}
			set
			{
				this._tbBookings.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_tbBookings(tbBooking entity)
		{
			this.SendPropertyChanging();
			entity.tbRoom = this;
		}
		
		private void detach_tbBookings(tbBooking entity)
		{
			this.SendPropertyChanging();
			entity.tbRoom = null;
		}
	}
}
#pragma warning restore 1591
