using MassTransit;
using Microsoft.Practices.Unity;
using RabbitMQClient.Consumer;
using MassTransit.RabbitMqTransport;
using RabbitMQManager;
using RabbitMQMessageDefinition;
using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

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


            var bus = MassTransitRabbitMQ.instance.CreateBus(
                                    (cfg, host) =>
                                    {
                                       
                                        cfg.ReceiveEndpoint(host, "myQueue", x =>
                                        {
                                            x.BindDeadLetterQueue("myQueue-Dead-Letter");
                                            x.Consumer<PrintMessageConsumer>();
                                        });

                                        cfg.ReceiveEndpoint(host, "myQueue10", x =>
                                        {
                                            x.BindDeadLetterQueue("myQueue10-Dead-Letter");
                                            x.Consumer<Print10MessageConsumer>();
                                        });
                                    });
            bus.Start();

            //消息总线
            IBusControl _busControl = MassTransitRabbitMQ.instance.CreateBus(
                                    (cfg, host) =>
                                    {

                                        cfg.ReceiveEndpoint(host, "myQueue-Dead-Letter", x =>
                                        {
                                            x.BindMessageExchanges = false;                                     
                                            x.Consumer<PrintMessageConsumer>();
     
                                        });

                                        cfg.ReceiveEndpoint(host, "myQueue10-Dead-Letter", x =>
                                        {
                                            x.BindMessageExchanges = false;
                                            x.Consumer<Print10MessageConsumer>();

                                        });

                                    });
            _busControl.Start();

            bus.Stop();

           

            RabbitMQMessageTransferUtil transferUtil = new RabbitMQMessageTransferUtil();
            container.RegisterInstance(transferUtil, new ContainerControlledLifetimeManager());
            container.RegisterInstance(_busControl, new ContainerControlledLifetimeManager());
            container.RegisterInstance<IBus>(_busControl, new ContainerControlledLifetimeManager());

            IocManager.Initialize(new UnityDependencyResolver(container));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMqClient());
        }

        private static Task PrintMessageReceived(PrintMessage msg, string queueName)
        {
            Console.WriteLine(string.Format("{0} - Message \"{1}\" received on queue \"{2}\".", DateTime.Now.ToString("HH:mm:ss"), msg.content, queueName));
            return Task.FromResult<int>(0);
        }

    }
}
