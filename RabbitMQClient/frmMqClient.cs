using MassTransit;
using RabbitMQManager;
using RabbitMQMessageDefinition;
using System;
using System.Windows.Forms;

namespace RabbitMQClient
{
    public partial class frmMqClient : Form
    {
        RabbitMQMessageTransferUtil transferUtil = IocManager.Resolve<RabbitMQMessageTransferUtil>();

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

        private void frmMqClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                IocManager.Resolve<IBusControl>().Stop();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
