namespace RabbitMQManager
{
    /// <summary>
    /// RabbitMQ 配置管理
    /// </summary>
    public class RabbitMQManagerUtils
    {
        public static RabbitMQConfiguration instance = GetRabbitMQConfiguration();

        private static RabbitMQConfiguration GetRabbitMQConfiguration()
        {
            return ConfigurationManager<RabbitMQConfiguration>.GetConfiguration("\\config\\RabbitMQ.config", "RabbitMQ");
        }
    }

}
