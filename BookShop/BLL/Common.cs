using System;
using System.Collections.Generic;
using System.Text;
using NVelocity;
using NVelocity.App;
using NVelocity.Runtime;

namespace BookShop.BLL
{
    class Common
    {
        /// <summary>
        /// 用data数据填充templates模板，渲染生成html返回
        /// </summary>
        /// <param name="templatesName"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string RenderHtml(string templatesName, object data)
        {
            VelocityEngine vltEngine = new VelocityEngine();
            vltEngine.SetProperty(RuntimeConstants.RESOURCE_LOADER, "file");
            vltEngine.SetProperty(RuntimeConstants.FILE_RESOURCE_LOADER_PATH, System.Web.Hosting.HostingEnvironment.MapPath("~/Template"));//模板文件所在的文件夹
            vltEngine.Init();

            VelocityContext vltContext = new VelocityContext();
            vltContext.Put("Model", data);//设置参数，在模板中可以通过$Model来引用
            Template vltTemplate = vltEngine.GetTemplate(templatesName);
            System.IO.StringWriter vltWriter = new System.IO.StringWriter();
            vltTemplate.Merge(vltContext, vltWriter);

            string html = vltWriter.GetStringBuilder().ToString();
            return html;
        }
    }
}
