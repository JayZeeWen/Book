using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Drawing;

namespace BookShop.Web.ashx
{
    /// <summary>
    /// Upload 的摘要说明
    /// </summary>
    public class Upload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpPostedFile file = context.Request.Files["Filedata"];//接受文件
            string fileName = Path.GetFileName(file.FileName);//获取文件名
            string fileExt = Path.GetExtension(fileName);
            if(fileExt == ".jpg")
            {
                file.SaveAs(context.Server.MapPath("/UploadImage/"+fileName));
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
}