using System;

namespace RabbitMQManager.Log
{
    public interface ILogger
    {
        bool Log(Type classname, string methodName, string title, string message, string userId);
        bool Error(Type classname, string methodName, string title, Exception ex, string userId);
        bool Error(Type classname, string methodName, string title, string message, Exception ex, string userId);
        bool Debug(Type classname, string methodName, string title, string message, string userId);
    }
}
