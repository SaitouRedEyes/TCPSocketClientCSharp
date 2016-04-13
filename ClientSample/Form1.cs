using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.IO;

namespace ClientSample
{
    public partial class Client : Form
    {
        delegate void SetTextCallback(string text);

        private Thread thread;
        private NetworkStream socketStream;
        private BinaryWriter write;
        private BinaryReader read;
        private string message = "";

        public Client()
        {
            InitializeComponent();

            thread = new Thread(new ThreadStart(RunClient));
            thread.Start();
        }

        public void RunClient()
        {
            TcpClient client;

            try
            {
                client = new TcpClient();
                client.Connect("localhost", 9000);

                socketStream = client.GetStream();
                write = new BinaryWriter(socketStream);
                read = new BinaryReader(socketStream);

                while (client.Connected)
                {
                    message = read.ReadString();
                    this.SetText(message);
                }

                write.Close();
                read.Close();
                socketStream.Close();
                client.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Server Disconnected: " + error.ToString());
                System.Environment.Exit(System.Environment.ExitCode);
            }
        }

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.show.InvokeRequired)
            {
                //Chamando o componente de interface ajustando o problema das thread diferentes  
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                //Quando estão ns mesma thread, o acesso é permitido.
                this.show.Text += text + "\r\n";
            }
        }

        private void send_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if(!send.Text.Equals("FIM"))
                    {
                        write.Write(send.Text);
                        send.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Client Desconnected!!");
                        System.Environment.Exit(System.Environment.ExitCode);
                    }
                }
            }
            catch (SocketException)
            {
                this.SetText("Atenção! Erro...");
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
        }
    }
}