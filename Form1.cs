using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobloxLauncher
{
    public partial class Form1 : Form
    {
        private Process serverProcess;
        private const int serverPort = 25565; // Default Minecraft server port

        public Form1()
        {
            InitializeComponent();
            DisplayPublicIP();
            DisplayLocalIP();
            this.ResizeRedraw = true;
            this.DoubleBuffered = true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);


            Color color1 = Color.Green;
            Color color2 = Color.DarkGreen;


            Rectangle rectangle = new Rectangle(0, 0, this.Width, this.Height);


            using (LinearGradientBrush brush = new LinearGradientBrush(rectangle, color1, color2, 45F)) // 45F is the angle of the gradient
            {

                e.Graphics.FillRectangle(brush, rectangle);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showS();

            loadingBAR.Value = 10;
            string javaPath = Path.Combine(Application.StartupPath, "jdk", "bin", "java.exe");
            loadingBAR.Value = 15;
            string serverJarPath = Path.Combine(Application.StartupPath, "server", "server.jar");
            loadingBAR.Value = 20;

            if (!File.Exists(javaPath) || !File.Exists(serverJarPath))
            {
                MessageBox.Show("Can't find java or minecraft.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string startArgs = $"-Xmx{ramALLmin.Value}M -Xms{ramALLmax.Value}M -jar \"{serverJarPath}\" nogui nojiline";
            loadingBAR.Value = 30;

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = javaPath,
                Arguments = startArgs,
                WorkingDirectory = Path.GetDirectoryName(serverJarPath),
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            loadingBAR.Value = 50;
            try
            {
                serverProcess = new Process
                {
                    StartInfo = startInfo,
                    EnableRaisingEvents = true
                };

                serverProcess.OutputDataReceived += (s, ea) => AppendOutput(ea.Data);
                serverProcess.ErrorDataReceived += (s, ea) => AppendOutput(ea.Data);
                serverProcess.Exited += (s, ea) => AppendOutput("Server has stopped.");
                loadingBAR.Value = 90;
                serverProcess.Start();
                serverProcess.BeginOutputReadLine();
                serverProcess.BeginErrorReadLine();
                loadingBAR.Value = 100;
            }
            catch (Exception ex)
            {
                loadingBAR.Visible = false;
                loadingBAR.Enabled = false;
                MessageBox.Show($"Error starting server: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AppendOutput(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AppendOutput), text);
                return;
            }
            if (!string.IsNullOrEmpty(text))
            {
                txtOutput.AppendText(text + Environment.NewLine);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            startServer();
        }
        private void startServer()
        {
            hideS();
                if (serverProcess != null && !serverProcess.HasExited)
                {
                    try
                    {
                    serverProcess.StandardInput.WriteLine("/title @a title {\"text\":\"Server will be stoping...\",\"color\":\"dark_red\"}");
                    serverProcess.StandardInput.Flush();
                    //
                    serverProcess.StandardInput.WriteLine("/title @a title {\"text\":\"Server will be stoping...\",\"color\":\"dark_red\"}");
                    serverProcess.StandardInput.Flush();
                    //
                    serverProcess.StandardInput.WriteLine("/title @a title {\"text\":\"Server will be stoping...\",\"color\":\"dark_red\"}");
                    serverProcess.StandardInput.Flush();
                    //
                    serverProcess.StandardInput.WriteLine("/title @a title {\"text\":\"Server will be stoping...\",\"color\":\"dark_red\"}");
                    serverProcess.StandardInput.Flush();
                    //
                    serverProcess.StandardInput.WriteLine("/title @a title {\"text\":\"Server will be stoping...\",\"color\":\"dark_red\"}");
                    serverProcess.StandardInput.Flush();
                    //
                    serverProcess.StandardInput.WriteLine("/title @a title {\"text\":\"Server will be stoping...\",\"color\":\"dark_red\"}");
                    serverProcess.StandardInput.Flush();
                    //
                    serverProcess.StandardInput.WriteLine("/title @a title {\"text\":\"Server will be stoping...\",\"color\":\"dark_red\"}");
                    serverProcess.StandardInput.Flush();
                    //
                    serverProcess.StandardInput.WriteLine("/title @a title {\"text\":\"Server will be stoping...\",\"color\":\"dark_red\"}");
                    serverProcess.StandardInput.Flush();
                    //
                    serverProcess.StandardInput.WriteLine("/title @a title {\"text\":\"Server will be stoping...\",\"color\":\"dark_red\"}");
                    serverProcess.StandardInput.Flush();
                    //
                    serverProcess.StandardInput.WriteLine("/title @a title {\"text\":\"Server will be stoping...\",\"color\":\"dark_red\"}");
                    serverProcess.StandardInput.Flush();
                    //
                    serverProcess.StandardInput.WriteLine("/title @a title {\"text\":\"Server will be stoping...\",\"color\":\"dark_red\"}");
                    serverProcess.StandardInput.Flush();
                    //
                    serverProcess.StandardInput.WriteLine("/title @a title {\"text\":\"Server will be stoping...\",\"color\":\"dark_red\"}");
                    serverProcess.StandardInput.Flush();
                    //
                    serverProcess.StandardInput.WriteLine("/title @a title {\"text\":\"NOW!!...\",\"color\":\"dark_red\"}");
                    serverProcess.StandardInput.Flush();
                    //
                    serverProcess.StandardInput.WriteLine("/title @a title {\"text\":\"NOW!!...\",\"color\":\"dark_red\"}");
                    serverProcess.StandardInput.Flush();
                    //
                    serverProcess.StandardInput.WriteLine("/title @a title {\"text\":\"NOW!!...\",\"color\":\"dark_red\"}");
                    serverProcess.StandardInput.Flush();
                    //
                    serverProcess.StandardInput.WriteLine("stop");
                    serverProcess.StandardInput.Flush();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error while shutting down: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Server is not running.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

          private void hideS()
        {
            //after stop
            ProcessAllocation.Show();
            cpuALL.Visible = true;
            ramALLmax.Visible = true;
            ramALLmin.Visible = true;
            label4.Visible = true;
            label3.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            webBrowser1.Visible = true;
            label8.Visible = false;
            label7.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            richTextBox1.Visible = true;
            loadingBAR.Value = 0;
            loadingBAR.Enabled = false;
            loadingBAR.Visible = false;
            startBTN.Visible = true;
            startBTN.Enabled = true;
            stopBTN.Visible = false;
            stopBTN.Enabled = false;
            restartBTN.Visible = false;
            restartBTN.Enabled = false;


        }
        private void showS()
        {
            //after start
            ProcessAllocation.Hide();
            cpuALL.Visible = false;
            ramALLmax.Visible = false;
            ramALLmin.Visible = false;
            label4.Visible = false;
            label3.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            webBrowser1.Visible = false;
            label8.Visible = true;
            label7.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
            richTextBox1.Visible = false;
            loadingBAR.Value = 0;
            loadingBAR.Enabled = true;
            loadingBAR.Visible = true;
            startBTN.Visible = false;
            startBTN.Enabled = false;
            stopBTN.Visible = true;
            stopBTN.Enabled = true;
            restartBTN.Visible = true;
            restartBTN.Enabled = true;

        }
        private void DisplayPublicIP()
        {
            try
            {
                string publicIP = new WebClient().DownloadString("http://icanhazip.com").Trim();
                AppendOutput($"Public IP: {publicIP}:{serverPort}");
                label2.Text = $"Public IP: {publicIP}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving public IP: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayLocalIP()
        {
            try
            {
                string localIP = GetLocalIPAddress();
                AppendOutput($"Local IP: {localIP}:{serverPort}");
                label1.Text = $"Local IP: {localIP}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving local IP: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hideS();
            string javaPath = Path.Combine(Application.StartupPath, "jdk", "bin", "java.exe");
            string serverJarPath = Path.Combine(Application.StartupPath, "server", "server.jar");
            if (serverProcess != null && !serverProcess.HasExited)
            {
                try
                {
                    loadingBAR.Value = 50;
                    serverProcess.Kill();
                    AppendOutput("Server was stopped.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error while shutting down: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Server is not running.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (!File.Exists(javaPath) || !File.Exists(serverJarPath))
            {
                MessageBox.Show("Can't find java or minecraft.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string startArgs = $"-Xmx{ramALLmin.Value}M -Xms{ramALLmax.Value}M -jar \"{serverJarPath}\" nogui nojiline";

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = javaPath,
                Arguments = startArgs,
                WorkingDirectory = Path.GetDirectoryName(serverJarPath),
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            try
            {

                serverProcess = new Process
                {
                    StartInfo = startInfo,
                    EnableRaisingEvents = true
                };

                serverProcess.OutputDataReceived += (s, ea) => AppendOutput(ea.Data);
                serverProcess.ErrorDataReceived += (s, ea) => AppendOutput(ea.Data);
                serverProcess.Exited += (s, ea) => AppendOutput("Server has stopped.");

                serverProcess.Start();
                serverProcess.BeginOutputReadLine();
                serverProcess.BeginErrorReadLine();
                loadingBAR.Value = 100;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting server: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ProcessAllocation.Show();
            string  notURI= Application.StartupPath;
            webBrowser1.Url = new Uri($"file:///{notURI}");
            label8.Visible = false;
            label7.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label13.Visible = false;
            ramALLmax.Increment = ramALLmax.Value / 2 * 2;
            ramALLmin.Increment = ramALLmin.Value / 2 * 2;
            timer1.Start();
        }

        private void comBTN_Click(object sender, EventArgs e)
        {
            if (serverProcess != null && !serverProcess.HasExited)
            {
                string command = txtInput.Text;
                if (!string.IsNullOrWhiteSpace(command))
                {
                    try
                    {
                        serverProcess.StandardInput.WriteLine(command);
                        serverProcess.StandardInput.Flush();
                        AppendOutput($"=================================");
                        AppendOutput($"Console command: {command}");
                        AppendOutput($"=================================");
                        txtInput.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error sending command: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a command.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Server is not running.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtOutput_TextChanged(object sender, EventArgs e)
        {

        }

        private void ramALLmin_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void ramALLmax_ValueChanged(object sender, EventArgs e)
        {

        }

        private void serverDownload()
        {
            string serverjarUrl = "https://piston-data.mojang.com/v1/objects/8dd1a28015f51b1803213892b50b7b4fc76e594d/server.jar";
            string serverVersion = "1.20.4";
            string downloadDir = "server";

            Directory.CreateDirectory(downloadDir);

            using (WebClient client = new WebClient())
            {
                client.DownloadFile(serverjarUrl, Path.Combine(downloadDir, "server.jar"));
            }
            MessageBox.Show("Server downloaded successfully.");
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            serverDownload();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string zipFilePath = "jdk.zip";
            string extractPath = "jdk"; 

            
                try
                {
                    if (File.Exists(zipFilePath))
                    {

                        if (!Directory.Exists(extractPath))
                        {
                            Directory.CreateDirectory(extractPath);
                        }

                        ZipFile.ExtractToDirectory(zipFilePath, extractPath);
                       
                        MessageBox.Show("Java installed successfully.");
                    }
                    else
                    {
                        MessageBox.Show("The specified zip file does not exist.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
