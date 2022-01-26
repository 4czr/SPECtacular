using System;
using System.Net;
using System.Windows.Forms;

namespace SPECtacular
{
    public partial class SPECtacular : Form
    {
        string externalIpString = new WebClient().DownloadString("http://icanhazip.com").Replace("\\r\\n", "").Replace("\\n", "").Trim();
        public SPECtacular()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblCPU.Text = HardwareInfo.GetCPUName();
            lblCPUDescription.Text = HardwareInfo.GetCPUDescription();
            lblCPUCores.Text = HardwareInfo.GetCPUCores();
            lblCPUThreads.Text = HardwareInfo.GetCPUThreads();
            lblGPU.Text = HardwareInfo.GetGPUName();
            lblDriverVersion.Text = HardwareInfo.GetGPUDriverVersion();
            lblRAMTotal.Text = HardwareInfo.GetPhysicalMemory();
            lblMobo.Text = HardwareInfo.GetMoboMan() + " " + HardwareInfo.GetMoboProd();
            lblOSInfo.Text = HardwareInfo.GetOSInformation();
        }


        
        /// ////////////////// Commented out due to changes to the GUI, but will be adding to the advanced page so not completely removing
        /// 

        
        //private void tmrGPURefresh_Tick(object sender, EventArgs e)
        //{
        //    lblRefresh.Text = HardwareInfo.GetGPURefresh();
        //}

        //private void checkBox1_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox1.Checked)
        //    {
        //        var externalIp = IPAddress.Parse(externalIpString);
        //        lbleIP.Text = externalIp.ToString();
        //     } else
        //    {
        //        lbleIP.Text = "Hidden";
        //    }
        //}

        //private void checkBox2_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox2.Checked)
        //    {
        //        String strHostName = string.Empty;
        //        IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
        //        IPAddress[] addr = ipEntry.AddressList;

        //        for (int i = 0; i < addr.Length; i++)
        //        {
        //            lbllIP.Text = addr[i].ToString();
        //        }
        //    }
        //    else
        //    {
        //        lbllIP.Text = "Hidden";
        //    }
        //}

        //private void label12_Click(object sender, EventArgs e)
        //{

        //}

        //private void checkBox3_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox3.Checked)
        //    {

        //        lblPID.Text = HardwareInfo.GetCPUPID();

        //    } else
        //    {

        //        lblPID.Text = "Hidden";
        //    }
        //}

        private void advancedViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming soon!", "Not ready yet", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void externalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var externalIp = IPAddress.Parse(externalIpString);
            Clipboard.Clear();
            Clipboard.SetText(externalIp.ToString());
            MessageBox.Show("Successfully copied to clipboard!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void internalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strHostName = string.Empty;
            IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress[] addr = ipEntry.AddressList;

            for (int i = 0; i < addr.Length; i++)
            {
                Clipboard.Clear();
                Clipboard.SetText(addr[i].ToString());
                MessageBox.Show("Successfully copied to clipboard!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText("PC Specifications provided by SPECtacular\n\n--- Operating System ---\n" + HardwareInfo.GetOSInformation() + "\n\n--- Motherboard Details ---\n" + HardwareInfo.GetMoboMan() + " " + HardwareInfo.GetMoboProd() + "\n\n--- CPU Details ---\nName: " + HardwareInfo.GetCPUName() + "\nDescription: " + HardwareInfo.GetCPUDescription() + "\nCores: " + HardwareInfo.GetCPUCores() + " | Threads: " + HardwareInfo.GetCPUThreads() + "\n\n--- GPU Details ---\nGPU: " + HardwareInfo.GetGPUName() + "\nDriver Version: " + HardwareInfo.GetGPUDriverVersion() + "\nRefresh Rate: " + HardwareInfo.GetGPURefresh() + "\n\n--- RAM Details ---\n" + HardwareInfo.GetPhysicalMemory() + "\n\nhttps://github.com/4czr/SPECtacular");
            MessageBox.Show("Successfully copied to clipboard!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cPUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText("CPU Details provided by SPECtacular\n\nName: " + HardwareInfo.GetCPUName() + "\nDescription: " + HardwareInfo.GetCPUDescription() + "\nCores: " + HardwareInfo.GetCPUCores() + " | Threads: " + HardwareInfo.GetCPUThreads() + "\nhttps://github.com/4czr/SPECtacular");
            MessageBox.Show("Successfully copied to clipboard!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gPUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText("GPU Details provided by SPECtacular\n\nGPU: " + HardwareInfo.GetGPUName() + "\nDriver Version: " + HardwareInfo.GetGPUDriverVersion() + "\nRefresh Rate: " + HardwareInfo.GetGPURefresh() + "Hz\nhttps://github.com/4czr/SPECtacular");
            MessageBox.Show("Successfully copied to clipboard!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MessageBox.Show("This app was written by 4czr to learn about WMI and interacting with hardware. This project will lead onto others and will itself grow. I plan to maintain this project into the distant future.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A lot of the program was written by reading the microsoft docs, however I did find a resource online called HardwareInfo.cs using WMI which helped me to get started. Whoever originally created that class, thank you :)", "Credits", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}