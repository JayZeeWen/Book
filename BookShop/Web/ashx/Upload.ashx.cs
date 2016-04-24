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
                string dir = "/UploadImage/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/";
                Directory.CreateDirectory(Path.GetDirectoryName(context.Server.MapPath(dir)));//创建文件夹
                string fullDir = dir + Common.WebCommon.GetStreamMD5(file.InputStream) + fileExt;

                using (Image img = Image.FromStream(file.InputStream))
                {
                    file.SaveAs(context.Server.MapPath(fullDir));
                    context.Response.Write(fullDir + ":" + img.Width + ":" + img.Height);
                }                
                //file.SaveAs(context.Server.MapPath("/UploadImage/"+fileName));
                //context.Response.Write("/UploadImage/" + fileName);
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