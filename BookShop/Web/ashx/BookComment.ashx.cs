using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Web.ashx
{
    /// <summary>
    /// BookComment 的摘要说明
    /// </summary>
    public class BookComment : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"];
            if(action == "add")
            {
                Model.BookComment entity = new Model.BookComment();
                entity.BookId = Convert.ToInt32(context.Request["bookId"]);
                entity.Msg = context.Request["msg"];
                entity.CreateDateTime = DateTime.Now;
                BLL.BookComment bll = new BLL.BookComment();
                if (bll.Add(entity) > 0)
                {
                    context.Response.Write("ok");
                }
                else
                {
                    context.Response.Write("no");
                }
             }
            else if(action =="load")//加载评论
            {
                int bookId = Convert.ToInt32(context.Request["bookId"]);
                BLL.BookComment bll = new BLL.BookComment();
                List<Model.BookComment> comments = bll.GetModelList(" bookId =" + bookId);
                //进行时间运算
                List<CommentViewModel> viewList = new List<CommentViewModel>();
                foreach(var entity in comments)
                {
                    CommentViewModel view = new CommentViewModel();
                    view.Msg = entity.Msg;
                    view.CreateDateTime = Common.WebCommon.GetTimeSpan(DateTime.Now - entity.CreateDateTime );
                    viewList.Add(view);
                }
                System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                context.Response.Write(js.Serialize(viewList.ToArray()));
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }


    public class CommentViewModel
    {
        public string CreateDateTime { get; set; }

        public string Msg { get; set; }
    }
}