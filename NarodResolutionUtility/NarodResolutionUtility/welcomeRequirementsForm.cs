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
    public partial class welcomeRequirementsForm : Form
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

        public welcomeRequirementsForm()
        {
            InitializeComponent();
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

            #region GPU Manufacturer Checker
            List<string> gpuNameList = gpuNameFetcher();
            if(gpuNameList.Count == 0)
            {
                compatibilityPanelNvidiaLabel.Text = "Unable to verify GPU vendor. Only NVIDIA GPU's are supported.";
                compatibilityPanelNvidiaLabel.ForeColor = Color.OrangeRed;
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
                    } else
                    {
                        compatibilityPanelNvidiaLabel.Text = "Multiple GPUs detected. No NVIDIA GPU detected. Only NVIDIA GPU's are supported.";
                        compatibilityPanelNvidiaLabel.ForeColor = Color.Red;
                    }
                }
            }
            #endregion

            #region Monitor Checker
            // to do, implement a good way of checking if a g9 / neo g9 is connected
            compatibilityPanelMonitorLabel.Text = "Monitor check is not currently implemented.";
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
            } else
            {
                compatibilityPanelMonitorsLabel.Text = "Multiple monitor detection failed. You can still continue.";
                compatibilityPanelMonitorsLabel.ForeColor = Color.Orange;
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
            } else if (buildNumber >= 7601)
            {
                compatibilityPanelWindowsCheck.Text = "Windows 7 detected. NRU *should* work correctly.";
                compatibilityPanelWindowsCheck.ForeColor = Color.OrangeRed;
            } else
            {
                compatibilityPanelWindowsCheck.Text = "Very old Windows detected (Vista or older?). This is not supported.";
                compatibilityPanelWindowsCheck.ForeColor = Color.Red;
            }
            #endregion
        }
    }
}
