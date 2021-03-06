﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using BookShop.Model;
using Maticsoft.DBUtility;//Please add references

namespace BookShop.DAL
{
	/// <summary>
	/// 数据访问类:Books
	/// </summary>
	public partial class Books
	{
		public Books()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "Books"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ISBN,int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Books");
			strSql.Append(" where ISBN=@ISBN and Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@ISBN", SqlDbType.NVarChar,50),
					new SqlParameter("@Id", SqlDbType.Int,4)			};
			parameters[0].Value = ISBN;
			parameters[1].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(BookShop.Model.Books model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Books(");
			strSql.Append("Title,Author,PublisherId,PublishDate,ISBN,WordsCount,UnitPrice,ContentDescription,AurhorDescription,EditorComment,TOC,CategoryId,Clicks)");
			strSql.Append(" values (");
			strSql.Append("@Title,@Author,@PublisherId,@PublishDate,@ISBN,@WordsCount,@UnitPrice,@ContentDescription,@AurhorDescription,@EditorComment,@TOC,@CategoryId,@Clicks)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@Author", SqlDbType.NVarChar,200),
					new SqlParameter("@PublisherId", SqlDbType.Int,4),
					new SqlParameter("@PublishDate", SqlDbType.DateTime),
					new SqlParameter("@ISBN", SqlDbType.NVarChar,50),
					new SqlParameter("@WordsCount", SqlDbType.Int,4),
					new SqlParameter("@UnitPrice", SqlDbType.Money,8),
					new SqlParameter("@ContentDescription", SqlDbType.NVarChar,-1),
					new SqlParameter("@AurhorDescription", SqlDbType.NVarChar,-1),
					new SqlParameter("@EditorComment", SqlDbType.NVarChar,-1),
					new SqlParameter("@TOC", SqlDbType.NVarChar,-1),
					new SqlParameter("@CategoryId", SqlDbType.Int,4),
					new SqlParameter("@Clicks", SqlDbType.Int,4)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.Author;
			parameters[2].Value = model.PublisherId;
			parameters[3].Value = model.PublishDate;
			parameters[4].Value = model.ISBN;
			parameters[5].Value = model.WordsCount;
			parameters[6].Value = model.UnitPrice;
			parameters[7].Value = model.ContentDescription;
			parameters[8].Value = model.AurhorDescription;
			parameters[9].Value = model.EditorComment;
			parameters[10].Value = model.TOC;
			parameters[11].Value = model.CategoryId;
			parameters[12].Value = model.Clicks;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BookShop.Model.Books model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Books set ");
			strSql.Append("Title=@Title,");
			strSql.Append("Author=@Author,");
			strSql.Append("PublisherId=@PublisherId,");
			strSql.Append("PublishDate=@PublishDate,");
			strSql.Append("WordsCount=@WordsCount,");
			strSql.Append("UnitPrice=@UnitPrice,");
			strSql.Append("ContentDescription=@ContentDescription,");
			strSql.Append("AurhorDescription=@AurhorDescription,");
			strSql.Append("EditorComment=@EditorComment,");
			strSql.Append("TOC=@TOC,");
			strSql.Append("CategoryId=@CategoryId,");
			strSql.Append("Clicks=@Clicks");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@Author", SqlDbType.NVarChar,200),
					new SqlParameter("@PublisherId", SqlDbType.Int,4),
					new SqlParameter("@PublishDate", SqlDbType.DateTime),
					new SqlParameter("@WordsCount", SqlDbType.Int,4),
					new SqlParameter("@UnitPrice", SqlDbType.Money,8),
					new SqlParameter("@ContentDescription", SqlDbType.NVarChar,-1),
					new SqlParameter("@AurhorDescription", SqlDbType.NVarChar,-1),
					new SqlParameter("@EditorComment", SqlDbType.NVarChar,-1),
					new SqlParameter("@TOC", SqlDbType.NVarChar,-1),
					new SqlParameter("@CategoryId", SqlDbType.Int,4),
					new SqlParameter("@Clicks", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@ISBN", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.Author;
			parameters[2].Value = model.PublisherId;
			parameters[3].Value = model.PublishDate;
			parameters[4].Value = model.WordsCount;
			parameters[5].Value = model.UnitPrice;
			parameters[6].Value = model.ContentDescription;
			parameters[7].Value = model.AurhorDescription;
			parameters[8].Value = model.EditorComment;
			parameters[9].Value = model.TOC;
			parameters[10].Value = model.CategoryId;
			parameters[11].Value = model.Clicks;
			parameters[12].Value = model.Id;
			parameters[13].Value = model.ISBN;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Books ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ISBN,int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Books ");
			strSql.Append(" where ISBN=@ISBN and Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@ISBN", SqlDbType.NVarChar,50),
					new SqlParameter("@Id", SqlDbType.Int,4)			};
			parameters[0].Value = ISBN;
			parameters[1].Value = Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Books ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BookShop.Model.Books GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,Title,Author,PublisherId,PublishDate,ISBN,WordsCount,UnitPrice,ContentDescription,AurhorDescription,EditorComment,TOC,CategoryId,Clicks from Books ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			BookShop.Model.Books model=new BookShop.Model.Books();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BookShop.Model.Books DataRowToModel(DataRow row)
		{
			BookShop.Model.Books model=new BookShop.Model.Books();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["Author"]!=null)
				{
					model.Author=row["Author"].ToString();
				}
				if(row["PublisherId"]!=null && row["PublisherId"].ToString()!="")
				{
					model.PublisherId=int.Parse(row["PublisherId"].ToString());
				}
				if(row["PublishDate"]!=null && row["PublishDate"].ToString()!="")
				{
					model.PublishDate=DateTime.Parse(row["PublishDate"].ToString());
				}
				if(row["ISBN"]!=null)
				{
					model.ISBN=row["ISBN"].ToString();
				}
				if(row["WordsCount"]!=null && row["WordsCount"].ToString()!="")
				{
					model.WordsCount=int.Parse(row["WordsCount"].ToString());
				}
				if(row["UnitPrice"]!=null && row["UnitPrice"].ToString()!="")
				{
					model.UnitPrice=decimal.Parse(row["UnitPrice"].ToString());
				}
				if(row["ContentDescription"]!=null)
				{
					model.ContentDescription=row["ContentDescription"].ToString();
				}
				if(row["AurhorDescription"]!=null)
				{
					model.AurhorDescription=row["AurhorDescription"].ToString();
				}
				if(row["EditorComment"]!=null)
				{
					model.EditorComment=row["EditorComment"].ToString();
				}
				if(row["TOC"]!=null)
				{
					model.TOC=row["TOC"].ToString();
				}
				if(row["CategoryId"]!=null && row["CategoryId"].ToString()!="")
				{
					model.CategoryId=int.Parse(row["CategoryId"].ToString());
				}
				if(row["Clicks"]!=null && row["Clicks"].ToString()!="")
				{
					model.Clicks=int.Parse(row["Clicks"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id,Title,Author,PublisherId,PublishDate,ISBN,WordsCount,UnitPrice,ContentDescription,AurhorDescription,EditorComment,TOC,CategoryId,Clicks ");
			strSql.Append(" FROM Books ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Id,Title,Author,PublisherId,PublishDate,ISBN,WordsCount,UnitPrice,ContentDescription,AurhorDescription,EditorComment,TOC,CategoryId,Clicks ");
			strSql.Append(" FROM Books ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Books ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Id desc");
			}
			strSql.Append(")AS Row, T.*  from Books T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		#endregion  BasicMethod
		#region  ExtensionMethod
        public DataSet GetDataSetByPara(BaseParameter para,out int totalCount)
        {
            StringBuilder sb = new StringBuilder();
            if (para.KeyValues != null)
            {
                if (para.KeyValues.ContainsKey("CategoryId"))
                {
                    sb.Append(" AND　CategoryId = " + para.KeyValues["CategoryId"]);
                }
            }
            string sql = string.Format( @" select * from (
	                            select row_number() over ( order by  b.{1}) as rw 
		                            , b.* 
	                            from Books b where 0 = 0 {0}
                            ) t where rw between @p_begin_index and @p_end_inedex

                            select count(1) from Books where 0 = 0 {0}",sb.ToString(),para.OrderKey??"Id");

            DataSet ds = DbHelperSQL.Query(sql.ToString()
                ,new SqlParameter("@p_begin_index",para.PageBeginIndex)
                ,new SqlParameter("@p_end_inedex",para.PageEndIndex));
            totalCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            return ds;

        }
		#endregion  ExtensionMethod
	}
}

