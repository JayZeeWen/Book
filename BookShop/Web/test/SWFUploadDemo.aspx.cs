using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop.Web.test
{
    public partial class SWFUploadDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(SWFUploadDemo));
            if(IsPostBack)
            {

            }
        }

        #region AjaxMethod
        [AjaxPro.AjaxMethod]
        public string CutImage(int x,int y,int width,int height,string path)
        {
            using (Bitmap map = new Bitmap(width, height))//创建画布
            {
                using (Graphics g = Graphics.FromImage(map))//为画布创建画笔
                {
                    using (System.Drawing.Image img = System.Drawing.Image.FromFile(Server.MapPath(path)))
                    {
                        //将图片画到画布上
                        g.DrawImage(img
                            , new Rectangle(0, 0, width, height)
                            , new Rectangle(x, y, width, height)
                            , GraphicsUnit.Pixel);
                        string newfile = "/UploadImage/ " + Guid.NewGuid().ToString().Substring(0, 8) + ".jpg";
                        map.Save(Server.MapPath(newfile));
                        return newfile;
                    }
                }
            }

            

        }
        #endregion
    }
}