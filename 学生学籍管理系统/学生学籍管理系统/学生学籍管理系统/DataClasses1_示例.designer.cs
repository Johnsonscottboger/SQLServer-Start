﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.34209
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace 学生学籍管理系统
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Student_Course")]
	public partial class DataClasses1_示例DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 可扩展性方法定义
    partial void OnCreated();
    partial void InsertCourse(Course instance);
    partial void UpdateCourse(Course instance);
    partial void DeleteCourse(Course instance);
    partial void InsertStudent(Student instance);
    partial void UpdateStudent(Student instance);
    partial void DeleteStudent(Student instance);
    #endregion
		
		public DataClasses1_示例DataContext() : 
				base(global::学生学籍管理系统.Properties.Settings.Default.Student_CourseConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1_示例DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1_示例DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1_示例DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1_示例DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Course> Course
		{
			get
			{
				return this.GetTable<Course>();
			}
		}
		
		public System.Data.Linq.Table<SC> SC
		{
			get
			{
				return this.GetTable<SC>();
			}
		}
		
		public System.Data.Linq.Table<Student> Student
		{
			get
			{
				return this.GetTable<Student>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Course")]
	public partial class Course : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Cno;
		
		private string _Cname;
		
		private string _Cpno;
		
		private System.Nullable<short> _Ccredit;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCnoChanging(string value);
    partial void OnCnoChanged();
    partial void OnCnameChanging(string value);
    partial void OnCnameChanged();
    partial void OnCpnoChanging(string value);
    partial void OnCpnoChanged();
    partial void OnCcreditChanging(System.Nullable<short> value);
    partial void OnCcreditChanged();
    #endregion
		
		public Course()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cno", DbType="VarChar(15) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Cno
		{
			get
			{
				return this._Cno;
			}
			set
			{
				if ((this._Cno != value))
				{
					this.OnCnoChanging(value);
					this.SendPropertyChanging();
					this._Cno = value;
					this.SendPropertyChanged("Cno");
					this.OnCnoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cname", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string Cname
		{
			get
			{
				return this._Cname;
			}
			set
			{
				if ((this._Cname != value))
				{
					this.OnCnameChanging(value);
					this.SendPropertyChanging();
					this._Cname = value;
					this.SendPropertyChanged("Cname");
					this.OnCnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cpno", DbType="VarChar(10)")]
		public string Cpno
		{
			get
			{
				return this._Cpno;
			}
			set
			{
				if ((this._Cpno != value))
				{
					this.OnCpnoChanging(value);
					this.SendPropertyChanging();
					this._Cpno = value;
					this.SendPropertyChanged("Cpno");
					this.OnCpnoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ccredit", DbType="SmallInt")]
		public System.Nullable<short> Ccredit
		{
			get
			{
				return this._Ccredit;
			}
			set
			{
				if ((this._Ccredit != value))
				{
					this.OnCcreditChanging(value);
					this.SendPropertyChanging();
					this._Ccredit = value;
					this.SendPropertyChanged("Ccredit");
					this.OnCcreditChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.SC")]
	public partial class SC
	{
		
		private string _Sno;
		
		private string _Cno;
		
		private System.Nullable<int> _Grade;
		
		public SC()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sno", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Sno
		{
			get
			{
				return this._Sno;
			}
			set
			{
				if ((this._Sno != value))
				{
					this._Sno = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cno", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Cno
		{
			get
			{
				return this._Cno;
			}
			set
			{
				if ((this._Cno != value))
				{
					this._Cno = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Grade", DbType="Int")]
		public System.Nullable<int> Grade
		{
			get
			{
				return this._Grade;
			}
			set
			{
				if ((this._Grade != value))
				{
					this._Grade = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Student")]
	public partial class Student : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Sno;
		
		private string _Sname;
		
		private string _Ssex;
		
		private int _Sage;
		
		private string _Sdept;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnSnoChanging(string value);
    partial void OnSnoChanged();
    partial void OnSnameChanging(string value);
    partial void OnSnameChanged();
    partial void OnSsexChanging(string value);
    partial void OnSsexChanged();
    partial void OnSageChanging(int value);
    partial void OnSageChanged();
    partial void OnSdeptChanging(string value);
    partial void OnSdeptChanged();
    #endregion
		
		public Student()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sno", DbType="VarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Sno
		{
			get
			{
				return this._Sno;
			}
			set
			{
				if ((this._Sno != value))
				{
					this.OnSnoChanging(value);
					this.SendPropertyChanging();
					this._Sno = value;
					this.SendPropertyChanged("Sno");
					this.OnSnoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sname", DbType="Char(10) NOT NULL", CanBeNull=false)]
		public string Sname
		{
			get
			{
				return this._Sname;
			}
			set
			{
				if ((this._Sname != value))
				{
					this.OnSnameChanging(value);
					this.SendPropertyChanging();
					this._Sname = value;
					this.SendPropertyChanged("Sname");
					this.OnSnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ssex", DbType="VarChar(2) NOT NULL", CanBeNull=false)]
		public string Ssex
		{
			get
			{
				return this._Ssex;
			}
			set
			{
				if ((this._Ssex != value))
				{
					this.OnSsexChanging(value);
					this.SendPropertyChanging();
					this._Ssex = value;
					this.SendPropertyChanged("Ssex");
					this.OnSsexChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sage", DbType="Int NOT NULL")]
		public int Sage
		{
			get
			{
				return this._Sage;
			}
			set
			{
				if ((this._Sage != value))
				{
					this.OnSageChanging(value);
					this.SendPropertyChanging();
					this._Sage = value;
					this.SendPropertyChanged("Sage");
					this.OnSageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sdept", DbType="NChar(10) NOT NULL", CanBeNull=false)]
		public string Sdept
		{
			get
			{
				return this._Sdept;
			}
			set
			{
				if ((this._Sdept != value))
				{
					this.OnSdeptChanging(value);
					this.SendPropertyChanging();
					this._Sdept = value;
					this.SendPropertyChanged("Sdept");
					this.OnSdeptChanged();
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
