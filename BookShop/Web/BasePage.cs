using BookShop.Web.Common;
using System;
using System.Collections.Generic;
using System.Web;

namespace BookShop.Web
{
    public class BasePage : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            if (Session["userInfo"] == null)
            {
                WebCommon.GotoPage();
            }
            base.OnPreInit(e);            
        }
    }
}