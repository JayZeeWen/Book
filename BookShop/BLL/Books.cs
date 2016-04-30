using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using BookShop.Model;
using System.Text;
using System.Web;
using System.IO;

namespace BookShop.BLL
{
    /// <summary>
    /// Books
    /// </summary>
    public partial class Books
    {
        private readonly BookShop.DAL.Books dal = new BookShop.DAL.Books();
        public Books()
        { }
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
        public bool Exists(string ISBN, int Id)
        {
            return dal.Exists(ISBN, Id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BookShop.Model.Books model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BookShop.Model.Books model)
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
        public bool Delete(string ISBN, int Id)
        {

            return dal.Delete(ISBN, Id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            return dal.DeleteList(Idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BookShop.Model.Books GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public BookShop.Model.Books GetModelByCache(int Id)
        {

            string CacheKey = "BooksModel-" + Id;
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
                catch { }
            }
            return (BookShop.Model.Books)objModel;
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BookShop.Model.Books> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BookShop.Model.Books> DataTableToList(DataTable dt)
        {
            List<BookShop.Model.Books> modelList = new List<BookShop.Model.Books>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BookShop.Model.Books model;
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
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
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

        public DataSet GetDataSetByPara(BaseParameter para, out int totalCount)
        {
            return   dal.GetDataSetByPara(para, out totalCount);
        }

        /// <summary>
        /// 创建静态html
        /// </summary>
        /// <param name="id"></param>
        public void CreateHtmlPage(int id)
        {
            Model.Books book = dal.GetModel(id);
            if(book != null)
            {
                var data = new { title = book.Title, desc = book.ContentDescription };

                //string html = Common.RenderHtml("BookTemplate.html", data);//使用NVelocity 
                string temp = HttpContext.Current.Server.MapPath("/Template/BookTemplate.html");
                string html = File.ReadAllText(temp);
                html = html.Replace("$title", book.Title).Replace("$desc", book.ContentDescription).Replace
                    ("$bookId", book.Id.ToString());

                //把替换好的内容保存
                string dir = HttpContext.Current.Server.MapPath("/StaticPage/"+ book.PublishDate.Year 
                    + "/"+ book.PublishDate.Month + "/"+book.PublishDate.Day+"/");
                Directory.CreateDirectory(Path.GetDirectoryName(dir));
                File.WriteAllText(dir + book.Id + ".html", html, Encoding.UTF8);

            }
        }

        #endregion  ExtensionMethod
    }
}

