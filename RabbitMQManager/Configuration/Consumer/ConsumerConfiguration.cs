using System.Configuration;


namespace RabbitMQManager
{
    /// <summary>
    /// 消费者配置
    /// </summary>
    public class ConsumerConfiguration: ConfigurationSection
    {
        [ConfigurationProperty("ConsumerParams", IsDefaultCollection = true)]
        public ConsumerParams ConsumerParams
        {
            get { return (ConsumerParams)this["ConsumerParams"]; }
            set { }
        }
    }

    /// <summary>
    /// 消费者参数集合
    /// </summary>
    [ConfigurationCollection(typeof(ConsumerParam))]
    public class ConsumerParams : ConfigurationElementCollection
    {
      
        protected override ConfigurationElement CreateNewElement()
        {
            return new ConsumerParam();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ConsumerParam)element).Name;
        }
    }

    /// <summary>
    /// 消费者参数
    /// </summary>
    public class ConsumerParam : ConfigurationElement
    {

        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { }
        }

        /// <summary>
        /// 队列名称
        /// </summary>
        [ConfigurationProperty("queue_name")]
        public string QueueName
        {
            get { return (string)this["queue_name"]; }
            set { }
        }

        /// <summary>
        /// 消费者类名称
        /// </summary>
        [ConfigurationProperty("classname", IsKey = true, IsRequired = true)]
        public string classname
        {
            get { return (string)this["classname"]; }
            set { }
        }
        

    }

}
