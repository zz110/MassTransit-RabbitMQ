using MassTransit;
using Microsoft.Practices.Unity;
using RabbitMQManager;
using RabbitMQMessageDefinition;
using RabbitMQServer.Consumer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RabbitMQServer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            Dictionary<string, UnityContainer> unityContainer = new Dictionary<string, UnityContainer>();
            List<ConsumerParam> consumerList = new List<ConsumerParam>();
            foreach (ConsumerParam item in ConsumerManager.instance.ConsumerParams)
            {
                consumerList.Add(item);
            }
            //此处没有对消息队列名称进行去重
            var queue_name_list = consumerList.Where(w => !string.IsNullOrEmpty(w.QueueName)).ToList();
            foreach (var q in queue_name_list)
            {
                var result = consumerList.Where(w => w.QueueName.Equals(q.QueueName)).ToList();
                if (result != null)
                {
                    var uc = new UnityContainer();
                    foreach (var item in result)
                    {
                        Type t = Type.GetType(item.classname);
                        uc.RegisterType(typeof(IConsumer<>), t, item.Name);
                    }
                    unityContainer.Add(q.QueueName, uc);
                }
            }

            var container = new UnityContainer();
            //消息总线
            IBusControl _busControl = MassTransitRabbitMQ.instance.CreateBus(
                                    (cfg, host) =>
                                    {
                                        //cfg.ReceiveEndpoint(host, "Camera", configure =>
                                        //{
                                        //    // configure.LoadFrom(item.Value);
                                        //    configure.Consumer<CameraMessageConsumer>();
                                        //});

                                        //cfg.ReceiveEndpoint(host, "TruckScaleData", configure =>
                                        //{
                                        //    // configure.LoadFrom(item.Value);
                                        //    configure.Consumer<TruckScaleDataProvideMessageConsumer>();
                                        //});

                                        //foreach (var item in unityContainer)
                                        //{
                                        //    cfg.ReceiveEndpoint(host, item.Key, configure =>
                                        //    {
                                        //        configure.LoadFrom(item.Value);
                                        //    });
                                        //}

                                        cfg.ReceiveEndpoint("server", config =>
                                        {
                                            config.Consumer<CameraMessageConsumer>();
                                            config.Consumer<PrintFaultMessageConsumer>();
                                            config.Consumer<TruckScaleMessageConsumer>();
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
            Application.Run(new frmMqServer());
        }
    }
}
