using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace BookShop.Web
{
    public partial class BookList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindBookList();
            }
        }

        private void BindBookList()
        {
            
            Model.BaseParameter para = new Model.BaseParameter();
            int pageIndex = 1;
            if (!string.IsNullOrEmpty(Request.QueryString["pi"]))
            {
                pageIndex = Convert.ToInt32(Request.QueryString["pi"]);
            }
            para.PageIndex = pageIndex;
            para.PageSize = 10;
            para.OrderKey = "UnitPrice";
            

            #region 参数
            if (!string.IsNullOrEmpty(Request.QueryString["cid"]))
            {
                para.KeyValues.Add("CategoryId", Request.QueryString["cid"]);
            }
            #endregion

            BLL.Books bll = new BLL.Books();
            int total = 0;
            rptBook.DataSource = bll.GetDataSetByPara(para,out total).Tables[0] ;
            double pageCount = Math.Ceiling(total / (double)para.PageSize);
            this.PageBar1.CurrentPageIndex = pageIndex;
            this.PageBar1.CurrentPageCount = (int)pageCount;
            rptBook.DataBind();
        }

        protected string CutString(string str, int length)
        {
            if(str.Length > length)
            {
                return str.Substring(0, length) + "............";
            }
            return str; 
        }

        protected string GetDir(object id)
        {
            BLL.Books bll = new BLL.Books();
            Model.Books book = bll.GetModel(Convert.ToInt32(id));
            string str = book.PublishDate.Year + "/" + book.PublishDate.Month + "/" + book.PublishDate.Day + "/"
                + book.Id + ".html";
            return str;
        }
        
    }
}