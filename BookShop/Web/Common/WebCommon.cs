﻿using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace BookShop.Web.Common
{
    public class WebCommon
    {

        /// <summary>
        /// 计算文件的MD5值
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static String GetStreamMD5(Stream stream)
        {
            string strResult = "";
            string strHashData = "";
            byte[] arrbytHashValue;
            System.Security.Cryptography.MD5CryptoServiceProvider oMD5Hasher =
                new System.Security.Cryptography.MD5CryptoServiceProvider();
            arrbytHashValue = oMD5Hasher.ComputeHash(stream); //计算指定Stream 对象的哈希值
            //由以连字符分隔的十六进制对构成的String，其中每一对表示value 中对应的元素；例如“F-2C-4A”
            strHashData = System.BitConverter.ToString(arrbytHashValue);
            //替换-
            strHashData = strHashData.Replace("-", "");
            strResult = strHashData;
            return strResult;
        }

        public static void GotoPage()
        {
            HttpContext.Current.Response.Redirect("/Member/Login.aspx?retureurl="+HttpContext.Current.Request.Url.ToString());
        }

        public static string GetMD5(string str)
        {
            MD5 md = MD5.Create();
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(str);
            byte[] md5Buffer =  md.ComputeHash(buffer);
            StringBuilder sb = new StringBuilder();
            foreach(byte b in md5Buffer)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();

        }


    }
}