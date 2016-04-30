using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop.Web.test
{
    public partial class CreagePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                BLL.Books bll = new BLL.Books();
                List<Model.Books> list = bll.GetModelList("");
                foreach(Model.Books model in list)
                {
                    bll.CreateHtmlPage(model.Id);
                }
                
            }
        }
    }
}