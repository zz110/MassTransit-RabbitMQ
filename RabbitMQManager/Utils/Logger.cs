using log4net;
using log4net.Config;
using System;
using System.IO;
using System.Text;

namespace RabbitMQManager.Log
{
    /// <summary>
    /// 日志记录
    /// </summary>
    public class Logger : ILogger
    {
        public static string GetMapPath(string virtualPath)
        {
           
            if (!string.IsNullOrEmpty(virtualPath) && Directory.Exists(virtualPath))
            {
                return virtualPath;
            }
            return (AppDomain.CurrentDomain.BaseDirectory + "/" + virtualPath).Replace("//", "/").Replace("/", "\\").Replace("\\\\", "\\");
        }

        static Logger()
        {
            XmlConfigurator.Configure(new FileInfo(GetMapPath("/config/log4net.config")));
        }
        public bool Log(Type classname, string methodName, string title, string message, string userId)
        {
            LogManager.GetLogger(classname.ToString()).InfoFormat("\r\n方法名称：{0} \r\n标题：{1}\r\n消息：{2}\r\n用户：{3}\r\n", new object[]
            {
                methodName,
                title,
                message,
                userId
            });
            return true;
        }

        public bool Error(Type classname, string methodName, string title, Exception ex, string userId)
        {
            ILog errorLog = LogManager.GetLogger(classname.ToString());
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("===========================================================");
            stringBuilder.AppendLine("标题：" + title);
            stringBuilder.AppendLine("用户：" + userId);
            stringBuilder.AppendLine("类名称：" + classname);
            stringBuilder.AppendLine("方法名称：" + methodName);
            errorLog.Error(stringBuilder.ToString(), ex);
            return true;
        }

        public bool Error(Type classname, string methodName, string title, string message, Exception ex, string userId)
        {
            ILog errorLog = LogManager.GetLogger(classname.ToString());
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("===========================================================");
            stringBuilder.AppendLine("标题：" + title);
            stringBuilder.AppendLine("用户：" + userId);
            stringBuilder.AppendLine("类名称：" + classname);
            stringBuilder.AppendLine("方法名称：" + methodName);
            stringBuilder.AppendLine("消息内容：" + message);
            errorLog.Error(stringBuilder.ToString(), ex);
            return true;
        }

        public bool Debug(Type classname, string methodName, string title, string message, string userId)
        {
            ILog debugLog = LogManager.GetLogger(classname.ToString());
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("===========================================================");
            stringBuilder.AppendLine("标题：" + title);
            stringBuilder.AppendLine("用户：" + userId);
            stringBuilder.AppendLine("类名称：" + classname);
            stringBuilder.AppendLine("方法名称：" + methodName);
            stringBuilder.AppendLine("消息内容：" + message);
            debugLog.Debug(stringBuilder.ToString());
            return true;
        }
    }
}
