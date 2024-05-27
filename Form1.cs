using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
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
            // LoadServerVersion();
            DisplayPublicIP();
            DisplayLocalIP();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            loadingBAR.Value = 0;
            loadingBAR.Enabled = true;
            loadingBAR.Visible = true;
            startBTN.Visible = false;
            startBTN.Enabled = false;
            stopBTN.Visible = true;
            stopBTN.Enabled = true;
            restartBTN.Visible = true;
            restartBTN.Enabled = true;

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

                AppendOutput("Server started. Sending initial test command...");
                // Send an initial test command to verify if the server is accepting input
                serverProcess.StandardInput.WriteLine("list");
                serverProcess.StandardInput.Flush(); // Flush the stream to ensure the command is sent
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
            loadingBAR.Value = 0;
            loadingBAR.Enabled = false;
            loadingBAR.Visible = false;
            startBTN.Visible = true;
            startBTN.Enabled = true;
            stopBTN.Visible = false;
            stopBTN.Enabled = false;
            restartBTN.Visible = false;
            restartBTN.Enabled = false;
            if (serverProcess != null && !serverProcess.HasExited)
            {
                try
                {
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
        }

        /* private void LoadServerVersion()
        {
            string serverJarPath = Path.Combine(Application.StartupPath, "server", "server.jar");

            if (File.Exists(serverJarPath))
            {
                try
                {

                    string javaPath = Path.Combine(Application.StartupPath, "jdk", "bin", "java.exe");
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

                    using (Process process = Process.Start(startInfo))
                    {
                        using (StreamReader reader = process.StandardOutput)
                        {
                            string versionInfo = reader.ReadToEnd();
                            AppendOutput($"Server Version: {versionInfo}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving server version: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Server JAR file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
        */

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
            loadingBAR.Value = 0;
            loadingBAR.Enabled = true;
            loadingBAR.Visible = true;
            startBTN.Visible = false;
            startBTN.Enabled = false;
            stopBTN.Visible = true;
            stopBTN.Enabled = true;
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
            label8.Visible = false;
            label7.Visible = false;
            label9.Visible = false;
            label10.Visible = false;

            ramALLmax.Increment = ramALLmax.Value / 2 * 2;
            ramALLmin.Increment = ramALLmin.Value / 2 * 2;
        }
        //Active development
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
                        AppendOutput($"Command sent: {command}");
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

        //End of Active development

    }
}
