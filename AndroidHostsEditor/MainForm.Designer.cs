namespace AndroidHostsEditor
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.adbList = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.bRefreshDevices = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.LADBPath = new System.Windows.Forms.Label();
            this.LCurrentDevice = new System.Windows.Forms.Label();
            this.bRunOpenHosts = new System.Windows.Forms.Button();
            this.LSystemBlock = new System.Windows.Forms.Label();
            this.LReMount = new System.Windows.Forms.Label();
            this.LChangePermission = new System.Windows.Forms.Label();
            this.LPullFiles = new System.Windows.Forms.Label();
            this.LPushFiles = new System.Windows.Forms.Label();
            this.bSaveHostsFromPC = new System.Windows.Forms.Button();
            this.bOpenHostsFromAndroid = new System.Windows.Forms.Button();
            this.debugText = new System.Windows.Forms.TextBox();
            this.bSelectADBPath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // adbList
            // 
            this.adbList.Location = new System.Drawing.Point(12, 54);
            this.adbList.Name = "adbList";
            this.adbList.Size = new System.Drawing.Size(200, 354);
            this.adbList.TabIndex = 0;
            this.adbList.UseCompatibleStateImageBehavior = false;
            this.adbList.SelectedIndexChanged += new System.EventHandler(this.adbList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "ADB List";
            // 
            // bRefreshDevices
            // 
            this.bRefreshDevices.Location = new System.Drawing.Point(12, 28);
            this.bRefreshDevices.Name = "bRefreshDevices";
            this.bRefreshDevices.Size = new System.Drawing.Size(102, 20);
            this.bRefreshDevices.TabIndex = 2;
            this.bRefreshDevices.Text = "Refresh Devices";
            this.bRefreshDevices.UseVisualStyleBackColor = true;
            this.bRefreshDevices.Click += new System.EventHandler(this.bRefreshDevices_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "ADB PATH : ";
            // 
            // LADBPath
            // 
            this.LADBPath.AutoSize = true;
            this.LADBPath.Location = new System.Drawing.Point(168, 8);
            this.LADBPath.Name = "LADBPath";
            this.LADBPath.Size = new System.Drawing.Size(0, 12);
            this.LADBPath.TabIndex = 4;
            // 
            // LCurrentDevice
            // 
            this.LCurrentDevice.AutoSize = true;
            this.LCurrentDevice.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.LCurrentDevice.Location = new System.Drawing.Point(217, 32);
            this.LCurrentDevice.Name = "LCurrentDevice";
            this.LCurrentDevice.Size = new System.Drawing.Size(78, 12);
            this.LCurrentDevice.TabIndex = 6;
            this.LCurrentDevice.Text = "CurrentDevice";
            // 
            // bRunOpenHosts
            // 
            this.bRunOpenHosts.Location = new System.Drawing.Point(219, 76);
            this.bRunOpenHosts.Name = "bRunOpenHosts";
            this.bRunOpenHosts.Size = new System.Drawing.Size(109, 23);
            this.bRunOpenHosts.TabIndex = 7;
            this.bRunOpenHosts.Text = "Run";
            this.bRunOpenHosts.UseVisualStyleBackColor = true;
            this.bRunOpenHosts.Click += new System.EventHandler(this.bRunOpenHosts_Click);
            // 
            // LSystemBlock
            // 
            this.LSystemBlock.AutoSize = true;
            this.LSystemBlock.Location = new System.Drawing.Point(219, 115);
            this.LSystemBlock.Name = "LSystemBlock";
            this.LSystemBlock.Size = new System.Drawing.Size(90, 12);
            this.LSystemBlock.TabIndex = 8;
            this.LSystemBlock.Text = "SYSTEM_BLOCK";
            // 
            // LReMount
            // 
            this.LReMount.AutoSize = true;
            this.LReMount.Location = new System.Drawing.Point(218, 143);
            this.LReMount.Name = "LReMount";
            this.LReMount.Size = new System.Drawing.Size(60, 12);
            this.LReMount.TabIndex = 10;
            this.LReMount.Text = "REMOUNT";
            // 
            // LChangePermission
            // 
            this.LChangePermission.AutoSize = true;
            this.LChangePermission.Location = new System.Drawing.Point(218, 172);
            this.LChangePermission.Name = "LChangePermission";
            this.LChangePermission.Size = new System.Drawing.Size(72, 12);
            this.LChangePermission.TabIndex = 12;
            this.LChangePermission.Text = "PERMISSION";
            // 
            // LPullFiles
            // 
            this.LPullFiles.AutoSize = true;
            this.LPullFiles.Location = new System.Drawing.Point(218, 200);
            this.LPullFiles.Name = "LPullFiles";
            this.LPullFiles.Size = new System.Drawing.Size(32, 12);
            this.LPullFiles.TabIndex = 14;
            this.LPullFiles.Text = "PULL";
            // 
            // LPushFiles
            // 
            this.LPushFiles.AutoSize = true;
            this.LPushFiles.Location = new System.Drawing.Point(334, 235);
            this.LPushFiles.Name = "LPushFiles";
            this.LPushFiles.Size = new System.Drawing.Size(35, 12);
            this.LPushFiles.TabIndex = 16;
            this.LPushFiles.Text = "PUSH";
            // 
            // bSaveHostsFromPC
            // 
            this.bSaveHostsFromPC.Location = new System.Drawing.Point(219, 230);
            this.bSaveHostsFromPC.Name = "bSaveHostsFromPC";
            this.bSaveHostsFromPC.Size = new System.Drawing.Size(109, 23);
            this.bSaveHostsFromPC.TabIndex = 15;
            this.bSaveHostsFromPC.Text = "Save File";
            this.bSaveHostsFromPC.UseVisualStyleBackColor = true;
            this.bSaveHostsFromPC.Click += new System.EventHandler(this.bSaveHostsFromPC_Click);
            // 
            // bOpenHostsFromAndroid
            // 
            this.bOpenHostsFromAndroid.ForeColor = System.Drawing.Color.Black;
            this.bOpenHostsFromAndroid.Location = new System.Drawing.Point(219, 259);
            this.bOpenHostsFromAndroid.Name = "bOpenHostsFromAndroid";
            this.bOpenHostsFromAndroid.Size = new System.Drawing.Size(109, 23);
            this.bOpenHostsFromAndroid.TabIndex = 17;
            this.bOpenHostsFromAndroid.Text = "Open File";
            this.bOpenHostsFromAndroid.UseVisualStyleBackColor = true;
            this.bOpenHostsFromAndroid.Click += new System.EventHandler(this.bOpenHostsFromAndroid_Click);
            // 
            // debugText
            // 
            this.debugText.Location = new System.Drawing.Point(219, 289);
            this.debugText.Multiline = true;
            this.debugText.Name = "debugText";
            this.debugText.Size = new System.Drawing.Size(553, 108);
            this.debugText.TabIndex = 18;
            // 
            // bSelectADBPath
            // 
            this.bSelectADBPath.Location = new System.Drawing.Point(12, 3);
            this.bSelectADBPath.Name = "bSelectADBPath";
            this.bSelectADBPath.Size = new System.Drawing.Size(75, 23);
            this.bSelectADBPath.TabIndex = 19;
            this.bSelectADBPath.Text = "adb Path";
            this.bSelectADBPath.UseVisualStyleBackColor = true;
            this.bSelectADBPath.Click += new System.EventHandler(this.bSelectADBPath_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 420);
            this.Controls.Add(this.bRunOpenHosts);
            this.Controls.Add(this.LSystemBlock);
            this.Controls.Add(this.debugText);
            this.Controls.Add(this.bSelectADBPath);
            this.Controls.Add(this.LReMount);
            this.Controls.Add(this.LCurrentDevice);
            this.Controls.Add(this.bOpenHostsFromAndroid);
            this.Controls.Add(this.LADBPath);
            this.Controls.Add(this.LChangePermission);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LPushFiles);
            this.Controls.Add(this.bRefreshDevices);
            this.Controls.Add(this.LPullFiles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bSaveHostsFromPC);
            this.Controls.Add(this.adbList);
            this.Name = "Form1";
            this.Text = "AndroidHostsEditor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView adbList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bRefreshDevices;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LADBPath;
        private System.Windows.Forms.Label LCurrentDevice;
        private System.Windows.Forms.Button bRunOpenHosts;
        private System.Windows.Forms.Label LSystemBlock;
        private System.Windows.Forms.Label LReMount;
        private System.Windows.Forms.Label LChangePermission;
        private System.Windows.Forms.Label LPullFiles;
        private System.Windows.Forms.Label LPushFiles;
        private System.Windows.Forms.Button bSaveHostsFromPC;
        private System.Windows.Forms.Button bOpenHostsFromAndroid;
        private System.Windows.Forms.TextBox debugText;
        private System.Windows.Forms.Button bSelectADBPath;
    }
}

