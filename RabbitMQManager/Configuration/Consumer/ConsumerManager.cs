namespace RabbitMQManager
{
    /// <summary>
    /// 消费者配置管理
    /// </summary>
    public class ConsumerManager
    {
        public static ConsumerConfiguration instance = GetConsumerConfiguration();

        private static ConsumerConfiguration GetConsumerConfiguration() {

            return ConfigurationManager<ConsumerConfiguration>.GetConfiguration("config\\Consumer.config", "Consumer");
        }
    }
}
