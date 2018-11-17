using MassTransit;
using RabbitMQManager;
using RabbitMQMessageDefinition;
using System;
using System.Windows.Forms;

namespace RabbitMQServer
{
    public partial class frmMqServer : Form
    {
        RabbitMQMessageTransferUtil transferUtil = IocManager.Resolve<RabbitMQMessageTransferUtil>();
        public frmMqServer()
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


        private void btnPrint_Click(object sender, EventArgs e)
        {
            IocManager.Resolve<IBusControl>().Publish(new PrintMessage
            {
                carno = txtCarno.Text,
                content = txtPrintContent.Text,
                clientId = Guid.NewGuid().ToString()
            });
        }

        private void btnRoad_Click(object sender, EventArgs e)
        {
            IocManager.Resolve<IBusControl>().Publish(new RoadGateMessage
            {
                number = txtRoadgate.Text,
                content = txtPrintContent.Text,
                clientId = Guid.NewGuid().ToString()
            });
        }

        private void frmMqServer_FormClosed(object sender, FormClosedEventArgs e)
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
