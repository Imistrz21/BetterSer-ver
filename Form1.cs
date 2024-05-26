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
            LoadServerVersion();
            DisplayPublicIP();
            DisplayLocalIP();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button1.Enabled = false;
            button2.Visible = true;
            button2.Enabled = true;
            button3.Visible = true;
            button3.Enabled = true;
            // Ścieżka do JDK i pliku serwera Minecraft
            string javaPath = Path.Combine(Application.StartupPath, "jdk", "bin", "java.exe");
            string serverJarPath = Path.Combine(Application.StartupPath, "server", "server.jar");

            // Sprawdzenie, czy pliki istnieją
            if (!File.Exists(javaPath) || !File.Exists(serverJarPath))
            {
                MessageBox.Show("Can't find java or minecraft.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Komenda do uruchomienia serwera
            string startArgs = $"-Xmx2024M -Xms2024M -jar \"{serverJarPath}\" nogui";

            // Konfiguracja procesu
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = javaPath,
                Arguments = startArgs,
                WorkingDirectory = Path.GetDirectoryName(serverJarPath),
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            try
            {
                // Uruchomienie procesu
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
            }
            catch (Exception ex)
            {
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
            button1.Visible = true;
            button1.Enabled = true;
            button2.Visible = false;
            button2.Enabled = false;
            button3.Visible = false;
            button3.Enabled = false;
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

        private void LoadServerVersion()
        {
            string serverJarPath = Path.Combine(Application.StartupPath, "server", "server.jar");

            if (File.Exists(serverJarPath))
            {
                try
                {
                    // Command to get the version info
                    string javaPath = Path.Combine(Application.StartupPath, "jdk", "bin", "java.exe");
                    string startArgs = $"-jar \"{serverJarPath}\" --version";
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = javaPath,
                        Arguments = startArgs,
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
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
            button1.Visible = false;
            button1.Enabled = false;
            button2.Visible = true;
            button2.Enabled = true;
            string javaPath = Path.Combine(Application.StartupPath, "jdk", "bin", "java.exe");
            string serverJarPath = Path.Combine(Application.StartupPath, "server", "server.jar");
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
            // Sprawdzenie, czy pliki istnieją
            if (!File.Exists(javaPath) || !File.Exists(serverJarPath))
            {
                MessageBox.Show("Can't find java or minecraft.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Komenda do uruchomienia serwera
            string startArgs = $"-Xmx2024M -Xms2024M -jar \"{serverJarPath}\" nogui";

            // Konfiguracja procesu
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = javaPath,
                Arguments = startArgs,
                WorkingDirectory = Path.GetDirectoryName(serverJarPath),
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            try
            {
                // Uruchomienie procesu
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting server: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
