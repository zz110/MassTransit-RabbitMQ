using MassTransit;
using Microsoft.Practices.Unity;
using RabbitMQManager;
using RabbitMQMessageDefinition;
using System;
using System.Windows.Forms;

namespace RabbitMQClient
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            var consumerContainer = new UnityContainer();
            foreach (ConsumerParam item in ConsumerManager.instance.ConsumerParams)
            {
                Type t = Type.GetType(item.classname);
                consumerContainer.RegisterType(typeof(IConsumer<>), t, item.Name);
   
            }

            var container = new UnityContainer();
            //消息总线
            IBusControl _busControl = MassTransitRabbitMQ.instance.CreateBus(
                                    (cfg, host) =>
                                    {
                                        cfg.ReceiveEndpoint(host, configure =>
                                        {
                                            configure.LoadFrom(consumerContainer);
                                        });
                                    });
            _busControl.Start();

            RabbitMQMessageTransferUtil transferUtil = new RabbitMQMessageTransferUtil();
            container.RegisterInstance(transferUtil, new ContainerControlledLifetimeManager());
            container.RegisterInstance(_busControl, new ContainerControlledLifetimeManager());
            container.RegisterInstance<IBus>(_busControl, new ContainerControlledLifetimeManager());

            IocManager.Initialize(new UnityDependencyResolver(container));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMqClient());
        }
    }
}
