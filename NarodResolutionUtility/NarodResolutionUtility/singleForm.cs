using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Runtime.InteropServices;
using Windows.Foundation;
using Microsoft.Win32;

namespace NarodResolutionUtility
{
    public partial class singleForm : Form
    {

        [DllImport("user32.dll")]
        static extern IntPtr MonitorFromWindow(IntPtr hwnd, uint dwFlags);

        private List<string> gpuNameFetcher()
        {
            List<string> gpuNameList = new();

            using(var gpusearcher = new ManagementObjectSearcher("select * from Win32_VideoController"))
            {
                foreach (ManagementObject gpusearcherObject in gpusearcher.Get())
                {
                    string gpuName = gpusearcherObject["Description"].ToString().ToLower();
                    gpuNameList.Add(gpuName);
                    Console.WriteLine(gpuName);
                }
            }

            return gpuNameList;
        }

        public singleForm()
        {
            InitializeComponent();

            nvidiaSettingsPanelVersionLabel.Text = $"Version: V{Application.ProductVersion}";
            compatibilityPanelVersionLabel.Text = $"Version: V{Application.ProductVersion}";
            welcomePanelAboutLabel.Text = $"ABOUT{Environment.NewLine}{Environment.NewLine}Version: V{Application.ProductVersion}";
            resolutionPanelVersionLabel.Text = $"Version: V{Application.ProductVersion}";
        }

        private void welcomePanelExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit(); // exit the application if the user chooses to do so
        }

        private void compatibilityPanelExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit(); // exit the application if the user chooses to do so
        }

        private void welcomePanelProceedButton_Click(object sender, EventArgs e)
        {
            compatibilityPanel.Visible = true;
            welcomePanel.Visible = false;
            string textBuilder = "";

            #region GPU Manufacturer Checker
            List<string> gpuNameList = gpuNameFetcher();
            if(gpuNameList.Count == 0)
            {
                compatibilityPanelNvidiaLabel.Text = "Unable to verify GPU vendor. Only NVIDIA GPU's are supported.";
                compatibilityPanelNvidiaLabel.ForeColor = Color.OrangeRed;
                textBuilder += $"Warning: GPU detection failed, only NVIDIA GPU's are supported. (You can still continue){Environment.NewLine}";
            } else
            {
                if(gpuNameList.Count == 1)
                {
                    if (gpuNameList[0].Contains("nvidia"))
                    {
                        compatibilityPanelNvidiaLabel.Text = "NVIDIA GPU detected.";
                        compatibilityPanelNvidiaLabel.ForeColor = Color.Green;
                    } else
                    {
                        compatibilityPanelNvidiaLabel.Text = "Non-NVIDIA GPU detected. Only NVIDIA GPU's are supported.";
                        compatibilityPanelNvidiaLabel.ForeColor = Color.Red;
                        textBuilder += $"Error: GPU detection found a non-NVIDIA GPU. You cannot continue.{Environment.NewLine}";
                    }
                } else
                {
                    bool nvidiaFound = false;
                    foreach (string gpuName in gpuNameList) { 
                        if (gpuName.Contains("nvidia"))
                        {
                            nvidiaFound = true;
                        }
                    }
                    if (nvidiaFound)
                    {
                        compatibilityPanelNvidiaLabel.Text = "Multiple GPUs detected. NVIDIA GPU detected. NRU *may* work.";
                        compatibilityPanelNvidiaLabel.ForeColor = Color.Orange;
                        textBuilder += $"Warning: Multiple GPUs detected. Proceed with caution.{Environment.NewLine}";
                    } else
                    {
                        compatibilityPanelNvidiaLabel.Text = "Multiple GPUs detected. No NVIDIA GPU detected. Only NVIDIA GPU's are supported.";
                        compatibilityPanelNvidiaLabel.ForeColor = Color.Red;
                        textBuilder += $"Error: No NVIDIA GPU detected. You cannot continue.{Environment.NewLine}";
                    }
                }
            }
            #endregion

            #region Monitor Checker
            // to do, implement a good way of checking if a g9 / neo g9 is connected
            compatibilityPanelMonitorLabel.Text = "Monitor check is not currently implemented.";
            textBuilder += $"Advisory: Monitor detection not yet implemented. Neo G9/G9 are supported at the moment.{Environment.NewLine}";
            #endregion

            #region Multiple Monitors Checker
            ManagementObjectSearcher monitorObjSearch = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity where service=\"monitor\"");
            int monitorsCount = monitorObjSearch.Get().Count;

            if(monitorsCount == 1)
            {
                compatibilityPanelMonitorsLabel.Text = "Single monitor detected.";
                compatibilityPanelMonitorsLabel.ForeColor = Color.Green;
            }
            else if (monitorsCount > 1)
            {
                compatibilityPanelMonitorsLabel.Text = "Multiple monitors detected. NRU may intefere with other monitors.";
                compatibilityPanelMonitorsLabel.ForeColor = Color.Orange;
                textBuilder += $"Warning: Multiple monitors detected. Proceed with caution.{Environment.NewLine}";
            } else
            {
                compatibilityPanelMonitorsLabel.Text = "Multiple monitor detection failed. You can still continue.";
                compatibilityPanelMonitorsLabel.ForeColor = Color.Orange;
                textBuilder += $"Warning: Unknown number of monitors. Proceed with caution.{Environment.NewLine}";
            }
            #endregion

            #region Check for Registry Key
            RegistryKey topLevelKey = Registry.LocalMachine;
            topLevelKey = topLevelKey.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Video", false);

            RegistryKey? correctFolderKey = null;

            foreach (string monitorFolderKey in topLevelKey.GetSubKeyNames())
            {
                // at this point, it will need to open up the folders to see which is the monitor
                RegistryKey folderKey = topLevelKey.OpenSubKey(monitorFolderKey);
                foreach (string lowestFolderKey in folderKey.GetSubKeyNames())
                {
                    RegistryKey keyValues = folderKey.OpenSubKey(lowestFolderKey);
                    foreach (string keyName in keyValues.GetValueNames())
                    {
                        if (keyName == "NV_Modes")
                        {
                            correctFolderKey = folderKey;
                            compatibilityPanelRegLabel.Text = "Registry key exists!";
                            compatibilityPanelRegLabel.ForeColor = Color.Green;
                        }
                    }
                }
            }
            if (correctFolderKey == null)
            {
                compatibilityPanelRegLabel.Text = "Registry key could not be located.";
                compatibilityPanelRegLabel.ForeColor = Color.Red;
                textBuilder += $"Error: Could not find resolution registry key. You cannot continue.{Environment.NewLine}";
            }
            #endregion

            #region Windows Check
            int buildNumber = Int32.Parse(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "CurrentBuild", null).ToString());
            
            if (buildNumber >= 22000)
            {
                compatibilityPanelWindowsCheck.Text = "Windows 11 detected.";
                compatibilityPanelWindowsCheck.ForeColor = Color.Green;
            } else if (buildNumber >= 10240)
            {
                compatibilityPanelWindowsCheck.Text = "Windows 10 detected.";
                compatibilityPanelWindowsCheck.ForeColor = Color.Green;
            } else if (buildNumber >= 9200)
            {
                compatibilityPanelWindowsCheck.Text = "Windows 8/8.1 detected. These are not supported.";
                compatibilityPanelWindowsCheck.ForeColor = Color.Red;
                textBuilder += $"Error: Your Windows version (and NVIDIA driver version) are too old. You cannot continue.{Environment.NewLine}";
            } else if (buildNumber >= 7601)
            {
                compatibilityPanelWindowsCheck.Text = "Windows 7 detected. NRU *should* work correctly.";
                compatibilityPanelWindowsCheck.ForeColor = Color.OrangeRed;
                textBuilder += $"Warning: Your Windows version is old. Proceed with caution.{Environment.NewLine}";
            } else
            {
                compatibilityPanelWindowsCheck.Text = "Very old Windows detected (Vista or older?). This is not supported.";
                compatibilityPanelWindowsCheck.ForeColor = Color.Red;
                textBuilder += $"Error: Your Windows version is extremely old. You cannot continue.{Environment.NewLine}";
            }
            #endregion

            if(textBuilder == $"Advisory: Monitor detection not yet implemented. Neo G9/G9 are supported at the moment.{Environment.NewLine}")
            {
                textBuilder += $"{Environment.NewLine}Your system has passed all checks successfully.";
            }

            if(textBuilder.Contains("Error") == false)
            {
                compatibilityPanelProceedButton.Enabled = true;
                textBuilder += $"{Environment.NewLine}The next page will walk you through the pre-requirements.";
            }

            compatibilityPanelDescriptionLabel.Text = textBuilder;
        }

        private void compatibilityPanelProceedButton_Click(object sender, EventArgs e)
        {
            compatibilityPanel.Visible = false;
            nvidiaSettingsPanel.Visible = true;
        }

        private void nvidiaSettingsPanelProceedButton_Click(object sender, EventArgs e)
        {
            nvidiaSettingsPanel.Visible = false;
            resolutionPanel.Visible = true;
        }

        private void resolutionPanelCustomCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (resolutionPanelCustomCheckBox.Checked == true)
            {
                resolutionPanel1440Box.Checked = false;
                resolutionPanel1440Box.Enabled = false;
                resolutionPanel1152SUWBox.Checked = false;
                resolutionPanel1152SUWBox.Enabled = false;
                resolutionPanel1440UWBox.Checked = false;
                resolutionPanel1440UWBox.Enabled = false;
                resolutionPanelCustomBox.ReadOnly = false;
            } else
            {
                resolutionPanel1440Box.Enabled = true;
                resolutionPanel1152SUWBox.Enabled = true;
                resolutionPanel1440UWBox.Enabled = true;
                resolutionPanelCustomBox.ReadOnly = true;
            }
        }

        private void resolutionPanelFinishButton_Click(object sender, EventArgs e)
        {
            if (resolutionPanelCustomCheckBox.Checked == true)
            {
                if (resolutionPanelCustomBox.Text.Length== 0)
                {
                    MessageBox.Show("You need to enter at least a single custom resolution to continue.");
                    return;
                }
                bool hasInvalidLine = false;
                string[] resolutions = resolutionPanelCustomBox.Text.Split(Environment.NewLine);
                foreach (string resolution in resolutions)
                {
                    if (resolution == null || resolution.Length == 0) { continue; }
                    if (resolution.Contains("x") == false)
                    {
                        hasInvalidLine = true;
                        break;
                    }
                }
                if (hasInvalidLine)
                {
                    MessageBox.Show($"One (or more) of your custom resolutions is invalid. They should look like this, as an example.{Environment.NewLine}{Environment.NewLine}1600x900{Environment.NewLine}1280x720");
                    return;
                }
            } else
            {
                if (resolutionPanel1440Box.Checked == false && resolutionPanel1152SUWBox.Checked == false && resolutionPanel1440UWBox.Checked == false)
                {
                    MessageBox.Show("You need to check at least a single resolution to continue.");
                    return;
                }
            }
        }
    }
}
