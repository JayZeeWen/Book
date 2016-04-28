using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop.Web.Member
{
    public partial class LoginUser : System.Web.UI.UserControl
    {
        public string msg = string.Empty;
        protected string returnUrl = string.Empty;//回传地址
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                CheckUserInfo();
            }
            else
            {
                if (!string.IsNullOrEmpty(Request.QueryString["retureurl"]))
                {
                    returnUrl = Request.QueryString["retureurl"];
                }
                CheckUserCookie();
            }
        }        

        private void CheckUserInfo()
        {
            string userName = Request.Form["txtUserName"];
            string pwd = Request.Form["txtPwd"];
            BLL.Users bll = new BLL.Users();            
            Model.Users user = null;
            bool b = bll.UserLogin(userName, pwd,out msg,out user);
            if(b)
            {
                Session["userInfo"] = user;
                #region 判断用户是否选择“记住我”
                if(Request.Form["checkMe"]!=null)
                {
                    HttpCookie cookie1 = new HttpCookie("cp1",user.LoginId);
                    HttpCookie cookie2 = new HttpCookie("cp2", MD5Pwd(user.LoginPwd));
                    cookie1.Expires = DateTime.Now.AddDays(3);
                    cookie2.Expires = DateTime.Now.AddDays(3);
                    Response.Cookies.Add(cookie1);
                    Response.Cookies.Add(cookie2);
                }
                #endregion
                GoPage(msg);
            }
        }

        private void CheckUserCookie()
        {
            if(Request.Cookies["cp1"] != null && Request.Cookies["cp2"] != null )
            {
                string userName = Request.Cookies["cp1"].Value;
                string cookiePwd = Request.Cookies["cp2"].Value;
                BLL.Users bll = new BLL.Users();
                Model.Users user = bll.GetModel(userName);
                if(user != null )
                {
                    string dataPass = MD5Pwd(user.LoginPwd);
                    if(cookiePwd == dataPass)
                    {
                        Session["userInfo"] = user;
                        GoPage("登陆成功");
                    }
                    else
                    {
                        Response.Cookies["cp1"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["cp2"].Expires = DateTime.Now.AddDays(-1);
                    }
                }
            }            
        }

        private string MD5Pwd(string pwd)
        {
            return Common.WebCommon.GetMD5(Common.WebCommon.GetMD5(pwd));
        }

        private void GoPage(string msg )
        {
            if (!string.IsNullOrEmpty(Request.QueryString["retureurl"]))
            {
                returnUrl = Request.QueryString["retureurl"];
                Response.Redirect(Request.QueryString["retureurl"]);
            }
            Response.Redirect("/ShowMsg.aspx?msg=" + Server.UrlEncode(msg) + "&txt=" + Server.UrlEncode("首页")
                + "&url=/Default.aspx");
        }
    }
}