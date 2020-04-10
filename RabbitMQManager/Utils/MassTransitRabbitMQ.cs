using MassTransit;
using MassTransit.RabbitMqTransport;
using System;

namespace RabbitMQManager
{
    /// <summary>
    /// MassTransit 消息总线
    /// </summary>
    public class MassTransitRabbitMQ
    {
        public static readonly MassTransitRabbitMQ instance = new MassTransitRabbitMQ();
        private MassTransitRabbitMQ() { }

        /// <summary>
        /// 创建消息总线
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <param name="registrationAction"></param>
        /// <returns></returns>
        public IBusControl CreateBus(Action<IRabbitMqBusFactoryConfigurator, IRabbitMqHost> registrationAction = null)
        {
            var conifg = RabbitMQManagerUtils.instance;
            if (conifg == null) {
                throw new Exception("缺少RabbitMQ配置节");
            }
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri(conifg.Host), h =>
                {
                    h.Username(conifg.Username);
                    h.Password(conifg.Password);

                    h.PublisherConfirmation = true;
                });
                
                cfg.PrefetchCount = 1000;
                registrationAction?.Invoke(cfg, host);
            });
        }
       
    }
}
