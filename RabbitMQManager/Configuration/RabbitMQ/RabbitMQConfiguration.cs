using System.Configuration;

namespace RabbitMQManager
{
    /// <summary>
    /// RabbitMQ配置
    /// </summary>
    public class RabbitMQConfiguration : ConfigurationSection
    {

        [ConfigurationProperty("Host", DefaultValue = "rabbitmq://localhost/")]
        public string Host
        {
            get
            {
                return (string)this["Host"];
            }
            set
            {
                this["Host"] = value;
            }
        }

        [ConfigurationProperty("Username",  DefaultValue = "")]
        public string Username
        {
            get { return (string)this["Username"]; }
            set { this["Username"] = value; }
        }


        [ConfigurationProperty("Password",  DefaultValue = "")]
        public string Password
        {
            get { return (string)this["Password"]; }
            set { this["Password"] = value; }
        }
    }
}
