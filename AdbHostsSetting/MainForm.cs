using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AdbHostsSetting
{
    public partial class MainForm : Form
    {
        public static string TAG_CURRENT_DEVICE = "DEVICE : ";
        public static string ER_DEVICE_NOT_FOUND = "device not found.";

        public MainForm()
        {
            InitializeComponent();
            InitializeListView();
            LCurrentDevice.Text = TAG_CURRENT_DEVICE;
            runTimer();
        }

        /******** Initialie Method ********/

        public void InitializeListView()
        {
            adbList.View = View.Details;
            adbList.FullRowSelect = true;

            ColumnHeader hDevices = new ColumnHeader();
            hDevices.Text = "devices";
            hDevices.TextAlign = HorizontalAlignment.Center;
            ColumnHeader hAttached = new ColumnHeader();
            hAttached.Text = "attached";
            hAttached.TextAlign = HorizontalAlignment.Center;
            ColumnHeader[] columnHeader = { hDevices, hAttached };
            adbList.Columns.AddRange(columnHeader);
            adbList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        /******** My Method ********/

        private void runTimer()
        {
            //new System.Threading.Timer(new TimerCallback(TimerRefreshDeviceList), null, 0, 1000);
        }

        /// <summary>
        /// Timer Method - auto command 'adb devices'
        /// </summary>
        private void TimerRefreshDeviceList(object o)
        {
            List<ListViewItem> l = new List<ListViewItem>();
            foreach (string name in ADB_SETTING.getSingleton(this).getDevices())
            {
                string[] items = name.Split('\t');
                l.Add(new ListViewItem(new string[] { items[0], items[1] }));
            }
            Invoke(new TimerDelegateAddList(addList), l);
        }


        /// <summary>
        /// Timer -Delegate Add List
        /// </summary>
        /// <param name="items"></param>
        delegate void TimerDelegateAddList(List<ListViewItem> items);
        private void addList(List<ListViewItem> items)
        {
            ADB_SETTING.getSingleton(this).init();
            adbList.Items.Clear();
            foreach(ListViewItem item in items){
                adbList.Items.Add(item);
            }
            adbList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        /******** Event Listener ********/

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            LADBPath.Text = ADB_SETTING.getSingleton(this).PATH;
        }

        private void adbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection _ = this.adbList.SelectedItems;
            if (1 > _.Count) return;
            ListViewItem item = _[0];
            if (item == null) return;
            LCurrentDevice.Text = TAG_CURRENT_DEVICE + item.SubItems[0].Text;
            ADB_SETTING.getSingleton(this).DEVICE_NAME = item.SubItems[0].Text;
        }

        private void bRunOpenHosts_Click(object sender, EventArgs e)
        {
            ADB_SETTING adbSetting = ADB_SETTING.getSingleton(this);

            LSystemBlock.Text = adbSetting.getSystemDirBlock();

            string ret = adbSetting.setRemount();
            if (ret.Contains("Operation"))
            {
                MessageBox.Show(ret, "REMOUNT FAILED");
                LReMount.Text = "REMOUNT FAILED";
                return;
            }
            else
            {
                LReMount.Text = "REMOUNT SUCCESS";
            }

            ret = adbSetting.changePermission();
            LChangePermission.Text = ret.Equals("") ? "CHMOD OK" : ret;

            ret = adbSetting.getHostsFile();
            LPullFiles.Text = ret.Equals("") ? "PULL OK":ret;
        }

        private void bSaveHostsFromPC_Click(object sender, EventArgs e)
        {
            ADB_SETTING adbSetting = ADB_SETTING.getSingleton(this);
            string ret = adbSetting.pushHostsfile();
            LPushFiles.Text = ret.Equals("")?"PUSH OK":ret;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ADB_SETTING.getSingleton(this).deleteLocalHostsFile();
        }

        private void bOpenHostsFromAndroid_Click(object sender, EventArgs e)
        {
            debugText.Text = ADB_SETTING.getSingleton(this).catHostsFile();
        }

        private void bSelectADBPath_Click(object sender, EventArgs e)
        {
            LADBPath.Text = ADB_SETTING.getSingleton(this).openFile();
        }

        private void bRefreshDevices_Click(object sender, EventArgs e)
        {
            List<ListViewItem> l = new List<ListViewItem>();
            foreach (string name in ADB_SETTING.getSingleton(this).getDevices())
            {
                string[] items = name.Split('\t');
                l.Add(new ListViewItem(new string[] { items[0], items[1] }));
            }

            ADB_SETTING.getSingleton(this).init();
            adbList.Items.Clear();
            foreach (ListViewItem item in l)
            {
                adbList.Items.Add(item);
            }
            adbList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

    }


    class ADB_SETTING
    {
        private string DEFAULT_ADB_PATH = "F:\\android-sdk\\sdk\\platform-tools\\adb.exe";
        private string SYSTEM_DIR = "/system";
        private string EXECUTABLE_DIR = Application.StartupPath;
        static ADB_SETTING instance = new ADB_SETTING();
        public string PATH { get;private set; }
        public string DEVICE_NAME { get; set; }
        public string SYSTEM_PATH { get; private set; }
        private ADB_SETTING()
        {
            this.PATH = DEFAULT_ADB_PATH;
            init();
        }
        public void init()
        {
            this.DEVICE_NAME = "";
            this.SYSTEM_PATH = "";
        }
        public static ADB_SETTING getSingleton(Form context)
        {
            return instance;
        }
        public bool isPathSeted()
        {
            return !PATH.Equals("");
        }
        public List<string> getDevices()
        {
            List<string> ret = this.runCommand("devices").Split(new String[]{Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries).ToList();
            ret.RemoveAt(0);
            return ret;
        }
        public string getSystemDirBlock()
        {
            List<string> ret = runDeviceCommand("shell mount", true);
            string block = "";
            foreach (string val in ret)
            {
                if (val.IndexOf(this.SYSTEM_DIR) > 0)
                {
                    block = val;
                    break;
                }
            }
            if (!block.Equals(""))
            {
                this.SYSTEM_PATH = block.Split(' ')[0];
            }
            else
            {
                this.SYSTEM_PATH = "";
            }
            return this.SYSTEM_PATH;
        }

        public string setRemount()
        {
            string ret = 
                this.runDeviceCommand("shell mount -o rw,remount " + this.SYSTEM_PATH + " " + this.SYSTEM_DIR)
                    .Replace(Environment.NewLine, "");
            return ret;
        }

        public string changePermission()
        {
            string ret =
                this.runDeviceCommand("shell chmod 666 " + this.SYSTEM_DIR + "/etc/hosts");
            return ret;
        }

        public string getHostsFile()
        {
            string ret =
                this.runDeviceCommand("pull " + this.SYSTEM_DIR + "/etc/hosts " + this.EXECUTABLE_DIR);
            if (File.Exists(this.EXECUTABLE_DIR +"/hosts"))
            {
                Process.Start(this.EXECUTABLE_DIR + "/hosts");
                return "";
            }
            else
            {
                return ret.Equals("")?"PULL FAILED":ret;
            }
        }

        public string pushHostsfile()
        {
            //if (!this.F_CHANGE_PERMISSION) return "not change permission";
            
            if (File.Exists(this.EXECUTABLE_DIR + "/hosts"))
            {
                return this.runDeviceCommand("push " + this.EXECUTABLE_DIR + "/hosts " + this.SYSTEM_DIR + "/etc/hosts");
            }
            else
            {
                return "file not exists...\n" + this.EXECUTABLE_DIR + "/hosts";
            }
        
        }
        public string catHostsFile()
        {
            return this.runDeviceCommand("shell cat " + this.SYSTEM_DIR + "/etc/hosts");
        }

        private string runCommand(string command)
        {
            if (this.PATH == null || this.PATH.Equals(""))
            {
                throw new FileNotFoundException("not set path <adb.exe>");
            }
            Process p = new Process();
            p.StartInfo.FileName = this.PATH;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.Arguments = command;

            p.Start();
            string results = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            p.Close();
            return results;
        }
        private List<string> runCommand(string command, bool emptyRemove)
        {
            if (this.PATH == null || this.PATH.Equals(""))
            {
                throw new FileNotFoundException("not set path <adb.exe>");
            }
            Process p = new Process();
            p.StartInfo.FileName = this.PATH;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.Arguments = command;

            p.Start();
            string results = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            p.Close();

            return results.Split(new string[] { Environment.NewLine },
                emptyRemove?StringSplitOptions.RemoveEmptyEntries:StringSplitOptions.None).ToList();
        }

        private string runDeviceCommand(string command)
        {
            if (this.DEVICE_NAME == null || this.DEVICE_NAME.Equals("")) return MainForm.ER_DEVICE_NOT_FOUND;
            return runCommand("-s " + this.DEVICE_NAME + " " + command);
        }

        private List<string> runDeviceCommand(string command, bool emptyRemove)
        {
            if (this.DEVICE_NAME == null || this.DEVICE_NAME.Equals("")) return new List<string>();
            return runCommand("-s " + this.DEVICE_NAME + " " + command, emptyRemove);
        }

        public string openFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = @"C:\";
            dialog.Filter = "ExeFile(*.exe)|*.exe";
            dialog.Title = "Select adb.exe";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.PATH = dialog.FileName;
                return dialog.FileName;
            }
            else
            {
                return this.DEFAULT_ADB_PATH;
            }
        }
        public void deleteLocalHostsFile()
        {
            if (File.Exists(this.EXECUTABLE_DIR + "/hosts"))
            {
                File.Delete(this.EXECUTABLE_DIR + "/hosts");
            }
        }
    }
}
