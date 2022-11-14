namespace NarodResolutionUtility
{
    partial class welcomeRequirementsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(welcomeRequirementsForm));
            this.welcomePanel = new System.Windows.Forms.Panel();
            this.welcomePanelWelcomeLabel = new System.Windows.Forms.Label();
            this.welcomePanelIntroLabel = new System.Windows.Forms.Label();
            this.welcomePanelCreditsLabel = new System.Windows.Forms.Label();
            this.welcomePanelAboutLabel = new System.Windows.Forms.Label();
            this.welcomePanelExitButton = new System.Windows.Forms.Button();
            this.welcomePanelProceedButton = new System.Windows.Forms.Button();
            this.compatibilityPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.compatibilityPanelExitButton = new System.Windows.Forms.Button();
            this.compatibilityPanelVersionLabel = new System.Windows.Forms.Label();
            this.compatibilityPanelTitleLabel = new System.Windows.Forms.Label();
            this.compatibilityPanelNvidiaLabel = new System.Windows.Forms.Label();
            this.compatibilityPanelMonitorLabel = new System.Windows.Forms.Label();
            this.compatibilityPanelRegLabel = new System.Windows.Forms.Label();
            this.compatibilityPanelWindowsCheck = new System.Windows.Forms.Label();
            this.compatibilityPanelDescriptionLabel = new System.Windows.Forms.Label();
            this.compatibilityPanelMonitorsLabel = new System.Windows.Forms.Label();
            this.welcomePanel.SuspendLayout();
            this.compatibilityPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // welcomePanel
            // 
            this.welcomePanel.Controls.Add(this.welcomePanelProceedButton);
            this.welcomePanel.Controls.Add(this.welcomePanelExitButton);
            this.welcomePanel.Controls.Add(this.welcomePanelAboutLabel);
            this.welcomePanel.Controls.Add(this.welcomePanelCreditsLabel);
            this.welcomePanel.Controls.Add(this.welcomePanelIntroLabel);
            this.welcomePanel.Controls.Add(this.welcomePanelWelcomeLabel);
            this.welcomePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.welcomePanel.Location = new System.Drawing.Point(0, 0);
            this.welcomePanel.Name = "welcomePanel";
            this.welcomePanel.Size = new System.Drawing.Size(624, 441);
            this.welcomePanel.TabIndex = 0;
            // 
            // welcomePanelWelcomeLabel
            // 
            this.welcomePanelWelcomeLabel.AutoSize = true;
            this.welcomePanelWelcomeLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.welcomePanelWelcomeLabel.Location = new System.Drawing.Point(12, 9);
            this.welcomePanelWelcomeLabel.Name = "welcomePanelWelcomeLabel";
            this.welcomePanelWelcomeLabel.Size = new System.Drawing.Size(201, 32);
            this.welcomePanelWelcomeLabel.TabIndex = 0;
            this.welcomePanelWelcomeLabel.Text = "Welcome to NRU";
            // 
            // welcomePanelIntroLabel
            // 
            this.welcomePanelIntroLabel.AutoSize = true;
            this.welcomePanelIntroLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.welcomePanelIntroLabel.Location = new System.Drawing.Point(25, 52);
            this.welcomePanelIntroLabel.Name = "welcomePanelIntroLabel";
            this.welcomePanelIntroLabel.Size = new System.Drawing.Size(546, 119);
            this.welcomePanelIntroLabel.TabIndex = 1;
            this.welcomePanelIntroLabel.Text = resources.GetString("welcomePanelIntroLabel.Text");
            // 
            // welcomePanelCreditsLabel
            // 
            this.welcomePanelCreditsLabel.AutoSize = true;
            this.welcomePanelCreditsLabel.Location = new System.Drawing.Point(25, 227);
            this.welcomePanelCreditsLabel.Name = "welcomePanelCreditsLabel";
            this.welcomePanelCreditsLabel.Size = new System.Drawing.Size(174, 45);
            this.welcomePanelCreditsLabel.TabIndex = 2;
            this.welcomePanelCreditsLabel.Text = "CREDITS:\r\n\r\nNarod / NarodGaming - Author";
            // 
            // welcomePanelAboutLabel
            // 
            this.welcomePanelAboutLabel.AutoSize = true;
            this.welcomePanelAboutLabel.Location = new System.Drawing.Point(480, 227);
            this.welcomePanelAboutLabel.Name = "welcomePanelAboutLabel";
            this.welcomePanelAboutLabel.Size = new System.Drawing.Size(91, 45);
            this.welcomePanelAboutLabel.TabIndex = 3;
            this.welcomePanelAboutLabel.Text = "ABOUT:\r\n\r\nVersion: V1.0.0.0";
            // 
            // welcomePanelExitButton
            // 
            this.welcomePanelExitButton.Location = new System.Drawing.Point(25, 389);
            this.welcomePanelExitButton.Name = "welcomePanelExitButton";
            this.welcomePanelExitButton.Size = new System.Drawing.Size(100, 40);
            this.welcomePanelExitButton.TabIndex = 4;
            this.welcomePanelExitButton.Text = "Exit";
            this.welcomePanelExitButton.UseVisualStyleBackColor = true;
            this.welcomePanelExitButton.Click += new System.EventHandler(this.welcomePanelExitButton_Click);
            // 
            // welcomePanelProceedButton
            // 
            this.welcomePanelProceedButton.Location = new System.Drawing.Point(471, 389);
            this.welcomePanelProceedButton.Name = "welcomePanelProceedButton";
            this.welcomePanelProceedButton.Size = new System.Drawing.Size(141, 40);
            this.welcomePanelProceedButton.TabIndex = 5;
            this.welcomePanelProceedButton.Text = "Proceed";
            this.welcomePanelProceedButton.UseVisualStyleBackColor = true;
            this.welcomePanelProceedButton.Click += new System.EventHandler(this.welcomePanelProceedButton_Click);
            // 
            // compatibilityPanel
            // 
            this.compatibilityPanel.Controls.Add(this.compatibilityPanelMonitorsLabel);
            this.compatibilityPanel.Controls.Add(this.compatibilityPanelDescriptionLabel);
            this.compatibilityPanel.Controls.Add(this.compatibilityPanelWindowsCheck);
            this.compatibilityPanel.Controls.Add(this.compatibilityPanelRegLabel);
            this.compatibilityPanel.Controls.Add(this.compatibilityPanelMonitorLabel);
            this.compatibilityPanel.Controls.Add(this.compatibilityPanelNvidiaLabel);
            this.compatibilityPanel.Controls.Add(this.button1);
            this.compatibilityPanel.Controls.Add(this.compatibilityPanelExitButton);
            this.compatibilityPanel.Controls.Add(this.compatibilityPanelVersionLabel);
            this.compatibilityPanel.Controls.Add(this.compatibilityPanelTitleLabel);
            this.compatibilityPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.compatibilityPanel.Location = new System.Drawing.Point(0, 0);
            this.compatibilityPanel.Name = "compatibilityPanel";
            this.compatibilityPanel.Size = new System.Drawing.Size(624, 441);
            this.compatibilityPanel.TabIndex = 1;
            this.compatibilityPanel.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(471, 389);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 40);
            this.button1.TabIndex = 5;
            this.button1.Text = "Proceed";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // compatibilityPanelExitButton
            // 
            this.compatibilityPanelExitButton.Location = new System.Drawing.Point(25, 389);
            this.compatibilityPanelExitButton.Name = "compatibilityPanelExitButton";
            this.compatibilityPanelExitButton.Size = new System.Drawing.Size(100, 40);
            this.compatibilityPanelExitButton.TabIndex = 4;
            this.compatibilityPanelExitButton.Text = "Exit";
            this.compatibilityPanelExitButton.UseVisualStyleBackColor = true;
            this.compatibilityPanelExitButton.Click += new System.EventHandler(this.compatibilityPanelExitButton_Click);
            // 
            // compatibilityPanelVersionLabel
            // 
            this.compatibilityPanelVersionLabel.AutoSize = true;
            this.compatibilityPanelVersionLabel.Location = new System.Drawing.Point(374, 414);
            this.compatibilityPanelVersionLabel.Name = "compatibilityPanelVersionLabel";
            this.compatibilityPanelVersionLabel.Size = new System.Drawing.Size(91, 15);
            this.compatibilityPanelVersionLabel.TabIndex = 3;
            this.compatibilityPanelVersionLabel.Text = "Version: V1.0.0.0";
            // 
            // compatibilityPanelTitleLabel
            // 
            this.compatibilityPanelTitleLabel.AutoSize = true;
            this.compatibilityPanelTitleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.compatibilityPanelTitleLabel.Location = new System.Drawing.Point(12, 9);
            this.compatibilityPanelTitleLabel.Name = "compatibilityPanelTitleLabel";
            this.compatibilityPanelTitleLabel.Size = new System.Drawing.Size(328, 32);
            this.compatibilityPanelTitleLabel.TabIndex = 0;
            this.compatibilityPanelTitleLabel.Text = "NRU - Compatibility Checker";
            // 
            // compatibilityPanelNvidiaLabel
            // 
            this.compatibilityPanelNvidiaLabel.AutoSize = true;
            this.compatibilityPanelNvidiaLabel.Location = new System.Drawing.Point(25, 67);
            this.compatibilityPanelNvidiaLabel.Name = "compatibilityPanelNvidiaLabel";
            this.compatibilityPanelNvidiaLabel.Size = new System.Drawing.Size(107, 15);
            this.compatibilityPanelNvidiaLabel.TabIndex = 6;
            this.compatibilityPanelNvidiaLabel.Text = "NVIDIA check label";
            // 
            // compatibilityPanelMonitorLabel
            // 
            this.compatibilityPanelMonitorLabel.AutoSize = true;
            this.compatibilityPanelMonitorLabel.Location = new System.Drawing.Point(25, 105);
            this.compatibilityPanelMonitorLabel.Name = "compatibilityPanelMonitorLabel";
            this.compatibilityPanelMonitorLabel.Size = new System.Drawing.Size(122, 15);
            this.compatibilityPanelMonitorLabel.TabIndex = 7;
            this.compatibilityPanelMonitorLabel.Text = "MONITOR check label";
            // 
            // compatibilityPanelRegLabel
            // 
            this.compatibilityPanelRegLabel.AutoSize = true;
            this.compatibilityPanelRegLabel.Location = new System.Drawing.Point(25, 183);
            this.compatibilityPanelRegLabel.Name = "compatibilityPanelRegLabel";
            this.compatibilityPanelRegLabel.Size = new System.Drawing.Size(119, 15);
            this.compatibilityPanelRegLabel.TabIndex = 8;
            this.compatibilityPanelRegLabel.Text = "REGISTRY check label";
            // 
            // compatibilityPanelWindowsCheck
            // 
            this.compatibilityPanelWindowsCheck.AutoSize = true;
            this.compatibilityPanelWindowsCheck.Location = new System.Drawing.Point(25, 221);
            this.compatibilityPanelWindowsCheck.Name = "compatibilityPanelWindowsCheck";
            this.compatibilityPanelWindowsCheck.Size = new System.Drawing.Size(126, 15);
            this.compatibilityPanelWindowsCheck.TabIndex = 9;
            this.compatibilityPanelWindowsCheck.Text = "WINDOWS check label";
            // 
            // compatibilityPanelDescriptionLabel
            // 
            this.compatibilityPanelDescriptionLabel.AutoSize = true;
            this.compatibilityPanelDescriptionLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.compatibilityPanelDescriptionLabel.Location = new System.Drawing.Point(25, 272);
            this.compatibilityPanelDescriptionLabel.Name = "compatibilityPanelDescriptionLabel";
            this.compatibilityPanelDescriptionLabel.Size = new System.Drawing.Size(161, 17);
            this.compatibilityPanelDescriptionLabel.TabIndex = 10;
            this.compatibilityPanelDescriptionLabel.Text = "Full description label here.";
            // 
            // compatibilityPanelMonitorsLabel
            // 
            this.compatibilityPanelMonitorsLabel.AutoSize = true;
            this.compatibilityPanelMonitorsLabel.Location = new System.Drawing.Point(25, 143);
            this.compatibilityPanelMonitorsLabel.Name = "compatibilityPanelMonitorsLabel";
            this.compatibilityPanelMonitorsLabel.Size = new System.Drawing.Size(128, 15);
            this.compatibilityPanelMonitorsLabel.TabIndex = 11;
            this.compatibilityPanelMonitorsLabel.Text = "MONITORS check label";
            // 
            // welcomeRequirementsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.compatibilityPanel);
            this.Controls.Add(this.welcomePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "welcomeRequirementsForm";
            this.ShowIcon = false;
            this.Text = "NRU - Requirements Checker";
            this.welcomePanel.ResumeLayout(false);
            this.welcomePanel.PerformLayout();
            this.compatibilityPanel.ResumeLayout(false);
            this.compatibilityPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel welcomePanel;
        private Label welcomePanelIntroLabel;
        private Label welcomePanelWelcomeLabel;
        private Label welcomePanelCreditsLabel;
        private Label welcomePanelAboutLabel;
        private Button welcomePanelProceedButton;
        private Button welcomePanelExitButton;
        private Panel compatibilityPanel;
        private Button button1;
        private Button compatibilityPanelExitButton;
        private Label compatibilityPanelVersionLabel;
        private Label compatibilityPanelTitleLabel;
        private Label compatibilityPanelNvidiaLabel;
        private Label compatibilityPanelMonitorLabel;
        private Label compatibilityPanelWindowsCheck;
        private Label compatibilityPanelRegLabel;
        private Label compatibilityPanelDescriptionLabel;
        private Label compatibilityPanelMonitorsLabel;
    }
}