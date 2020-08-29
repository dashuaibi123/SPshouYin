using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace shouyin
{
    class Units
    {
        /// <summary>
        /// 指定Post地址使用Get 方式获取全部字符串
        /// </summary>
        /// <param name="url">请求后台地址</param>
        /// <returns></returns>
        public static string Post(string url, Dictionary<string, string> dic)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            #region 添加Post 参数
            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (var item in dic)
            {
                if (i > 0)
                    builder.Append("&");
                builder.AppendFormat("{0}={1}", item.Key, item.Value);
                i++;
            }
            byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            #endregion
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }
        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }


        /// <summary>
        /// md5加密
        /// </summary>
        /// <returns></returns>
        public static String md5Encrypt(string str)
        {
            String done="";//记录加密后数值
            MD5 md5 = new MD5CryptoServiceProvider();//创建MD5对象（MD5类为抽象类不能被实例化）

            byte[] date = System.Text.Encoding.Default.GetBytes(str);//将字符串编码转换为一个字节序列

            byte[] date1 = md5.ComputeHash(date);//计算data字节数组的哈希值（加密）

            md5.Clear();//释放类资源

            for (int i = 0; i < date1.Length - 1; i++)//遍历加密后的数值到变量str2

            {

                done += date1[i].ToString("X");//（X为大写时加密后的数值里的字母为大写，x为小写时加密后的数值里的字母为小写）

            }
            return done;
        }
    }
}
