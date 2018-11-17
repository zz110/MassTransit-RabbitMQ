using MassTransit;
using RabbitMQManager;
using RabbitMQManager.Log;
using RabbitMQMessageDefinition;
using System.Threading.Tasks;

namespace RabbitMQServer.Consumer
{
    public class CameraMessageConsumer : IConsumer<CameraMessage>
    {
        private Logger logger = new Logger();
        public async Task Consume(ConsumeContext<CameraMessage> context)
        {
            await Handle(context);
        }


        public async Task Handle(ConsumeContext<CameraMessage> context)
        {
            await Task.Factory.StartNew(() =>
            {
                string result = Newtonsoft.Json.JsonConvert.SerializeObject(context.Message);
                IocManager.Resolve<RabbitMQMessageTransferUtil>().broadcast(result);
                logger.Log(typeof(CameraMessageConsumer), "Handle", "CameraMessage",
                    result, "");
            });
        }
    }
}
