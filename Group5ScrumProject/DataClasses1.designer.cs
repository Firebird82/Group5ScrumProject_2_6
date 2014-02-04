﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
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
    partial void InserttbRoom(tbRoom instance);
    partial void UpdatetbRoom(tbRoom instance);
    partial void DeletetbRoom(tbRoom instance);
    partial void InserttbUser(tbUser instance);
    partial void UpdatetbUser(tbUser instance);
    partial void DeletetbUser(tbUser instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["ProjectRoomsConnectionString2"].ConnectionString, mappingSource)
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
		
		public System.Data.Linq.Table<tbRoom> tbRooms
		{
			get
			{
				return this.GetTable<tbRoom>();
			}
		}
		
		public System.Data.Linq.Table<tbUser> tbUsers
		{
			get
			{
				return this.GetTable<tbUser>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tbRoom")]
	public partial class tbRoom : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _iRoomId;
		
		private string _sRoomName;
		
		private int _iRoomChairs;
		
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
    #endregion
		
		public tbRoom()
		{
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
		
		private string _sUserRole;
		
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
    partial void OnsUserRoleChanging(string value);
    partial void OnsUserRoleChanged();
    #endregion
		
		public tbUser()
		{
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sUserRole", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string sUserRole
		{
			get
			{
				return this._sUserRole;
			}
			set
			{
				if ((this._sUserRole != value))
				{
					this.OnsUserRoleChanging(value);
					this.SendPropertyChanging();
					this._sUserRole = value;
					this.SendPropertyChanged("sUserRole");
					this.OnsUserRoleChanged();
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
}
#pragma warning restore 1591
