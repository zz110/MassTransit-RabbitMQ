using MassTransit;
using RabbitMQManager;
using RabbitMQMessageDefinition;
using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace RabbitMQClient
{
    public partial class frmMqClient : Form
    {
        RabbitMQMessageTransferUtil transferUtil = IocManager.Resolve<RabbitMQMessageTransferUtil>();


        private IBusControl busControl = IocManager.Resolve<IBusControl>();

        public frmMqClient()
        {
            InitializeComponent();
            transferUtil.TransferMessageHandler += TransferUtil_TransferMessageHandler;
        }


        private void TransferUtil_TransferMessageHandler(TransferMessageEventArgs eventArgs)
        {
            showLogs(eventArgs.message);
        }

        private delegate void showLosgDelegate(string message);
        /// <summary>
        /// 展示消息
        /// </summary>
        /// <param name="message"></param>
        private void showLogs(string message)
        {

            if (richTxt.InvokeRequired)
            {
                showLosgDelegate d = showLogs;
                richTxt.Invoke(d, message);
            }
            else
            {
                if (richTxt.TextLength > 10000)
                {
                    richTxt.Clear();
                }
                richTxt.AppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}:{message}" + Environment.NewLine);
            }
        }


        private void btnCamera_Click(object sender, EventArgs e)
        {
            IocManager.Resolve<IBusControl>().Publish(new CameraMessage
            {
                number = txtCamera.Text,
                content = txtPrintContent.Text,
                clientId = Guid.NewGuid().ToString()
            });
        }

        private void btnDb_Click(object sender, EventArgs e)
        {
            IocManager.Resolve<IBusControl>().Publish(new TruckScaleMessage
            {
                carno = txtCarno.Text,
                weight = txtWeight.Text,
                clientId = Guid.NewGuid().ToString()
            });
        }

       
        /// <summary>
        /// 测试死信队列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 20; i++) {

                    showLogs($"发送消息{i}");
                    busControl.Publish(new PrintMessage()
                    {
                        carno = $"发送消息{i}:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}",
                        content = "发送消息",
                        clientId = Guid.NewGuid().ToString()
                    }, pc => pc.TimeToLive = TimeSpan.FromSeconds(5));


                    showLogs($"发送消息10-{i}");
                    busControl.Publish(new Print10Message()
                    {
                        carno = $"发送消息10-{i}:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}",
                        content = "发送消息10",
                        clientId = Guid.NewGuid().ToString()
                    }, pc => pc.TimeToLive = TimeSpan.FromSeconds(10));

                    Thread.Sleep(1000);
                }

            });
         

       
        }

        private void frmMqClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            IocManager.Resolve<IBusControl>().Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
