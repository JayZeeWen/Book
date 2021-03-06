﻿using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using BookShop.Model;
namespace BookShop.BLL
{
	/// <summary>
	/// 1
	/// </summary>
	public partial class Users
	{
		private readonly BookShop.DAL.Users dal=new BookShop.DAL.Users();
		public Users()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string LoginId,string Mail,int Id)
		{
			return dal.Exists(LoginId,Mail,Id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(BookShop.Model.Users model,out string msg)
		{
            //判断用户是否存在
            if (!CheckUserName(model.LoginId))
            {
                msg = "注册成功";
                return dal.Add(model);
            }
            else
            {
                msg = " 此用户存在";
                return -1;
            }
			
		}

        /// <summary>
        /// 校验登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool UserLogin(string userName, string pwd, out string msg,out Model.Users model)
        {
            model = dal.GetModel(userName);
            if(model == null)
            {
                msg = "该用户名不存在";
                return false;
            }
            else
            {
                if(model.UserStateId.Name=="正常")
                {
                    if(model.LoginPwd == pwd)
                    {
                        msg = "登录成功";
                        return true;
                    }
                    else
                    {
                        msg = "密码错误";
                        return false;   
                    }
                }
                else
                {
                    msg = "用户未激活";
                    return false;
                }
            }
        }

        
        public bool CheckUserName(string userName)
        {
            return dal.CheckUserName(userName);
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BookShop.Model.Users model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id)
		{
			
			return dal.Delete(Id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string LoginId,string Mail,int Id)
		{
			
			return dal.Delete(LoginId,Mail,Id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			return dal.DeleteList(Idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BookShop.Model.Users GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public BookShop.Model.Users GetModelByCache(int Id)
		{
			
			string CacheKey = "UsersModel-" + Id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (BookShop.Model.Users)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BookShop.Model.Users> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BookShop.Model.Users> DataTableToList(DataTable dt)
		{
			List<BookShop.Model.Users> modelList = new List<BookShop.Model.Users>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BookShop.Model.Users model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

        public Model.Users GetModel(string userName)
        {
            return dal.GetModel(userName);
        }

		#endregion  ExtensionMethod
	}
}

