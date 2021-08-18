/*
 * (C)JimmyL.   2021~Now
 * All Rights Reserved.
 * 
 * The First Ver:   1.0.2.555 [Beta]
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Net;

namespace SrrWF
{

    public partial class Form1 : Form
    {
        static public double fileNumBeforeScan = 0;
        static public string version = "1.7.10.2";
        static public double numAfterScan = 0;
        static public long miss = 0, clean = 0;
        static public string filePath;
        static public double less, a;
        static public double all;
        static public string result;
        static public string updateDomain ="https://blog-static.cnblogs.com/files/jimmyl-blog/SrrWF.js";

        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>        
        /// 下载文件        
        /// </summary>        
        /// <param name="URL">下载文件地址</param>       
        /// 
        /// <param name="Filename">下载后的存放地址</param>        
        /// <param name="Prog">用于显示的进度条</param>        
        /// 
        public void DownloadFile(
            string URL, string filename)
        {
            try
            {
                System.Net.HttpWebRequest Myrq = (System.Net.HttpWebRequest)

                System.Net.HttpWebRequest.Create(URL);
                System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse();
                long totalBytes = myrp.ContentLength;
                if (myrp.ContentLength != 0)
                {
                    // MessageBox.Show("文件存在");
                    System.IO.Stream st = myrp.GetResponseStream();
                    System.IO.Stream so = new System.IO.FileStream(filename,

                    System.IO.FileMode.Create);
                    long totalDownloadedByte = 0;
                    byte[] by = new byte[1024];
                    int osize = st.Read(by, 0, (int)by.Length);
                    while (osize > 0)
                    {
                        totalDownloadedByte = osize + totalDownloadedByte;
                        so.Write(by, 0, osize);
                        osize = st.Read(by, 0, (int)by.Length);
                    }
                    so.Close();
                    st.Close();
                    //return "success";
                }
                else
                {
                    
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show("检查更新或更新失败！", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //准备检查更新
            DownloadFile(updateDomain, AppDomain.CurrentDomain.BaseDirectory + @"temp\other\ver.");
            if(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"temp\other\ver.") != version)
            {
                if (MessageBox.Show("程序已发布新版本，请问是否半自动更新？", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Update.
                    DownloadFile("https://files.cnblogs.com/files/jimmyl-blog/NewVersion.zip", AppDomain.CurrentDomain.BaseDirectory + @"NewVersion.zip");
                    MessageBox.Show("最新版本的程序压缩包已下载至程序根目录下，解压后覆盖现在程序即可完成更新！", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Environment.Exit(0);
                }
                else
                {
                    MessageBox.Show("程序的最新版本会修复问题和增加新功能，请尽快更新！", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"temp\other\ver.");
                }
            }
            File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"temp\other\ver.");
            tabCrlDecoder.TabPages[tabCrlDecoder.SelectedIndex].Focus();
            button2.Enabled = false;
            button3.Enabled = false;

            DirectoryInfo directoryInfo3 = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + @"temp\del");
            FileInfo[] fileInfos3 = directoryInfo3.GetFiles("*.*", SearchOption.TopDirectoryOnly);
            foreach (FileInfo NextFile3 in fileInfos3)
                File.Delete(NextFile3.FullName);
            DirectoryInfo directoryInfo4 = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + @"temp\clean");
            FileInfo[] fileInfos4 = directoryInfo4.GetFiles("*.*", SearchOption.TopDirectoryOnly);
            foreach (FileInfo NextFile4 in fileInfos4)
                File.Delete(NextFile4.FullName);
            DirectoryInfo directoryInfo5 = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + @"temp\miss");
            FileInfo[] fileInfos5 = directoryInfo5.GetFiles("*.*", SearchOption.TopDirectoryOnly);
            foreach (FileInfo NextFile5 in fileInfos5)
                File.Delete(NextFile5.FullName);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabCrlDecoder_SelectedIndexChanged(object sender, EventArgs e)
        {
            //System.Drawing.Color bgcolor = Color.;

            tabCrlDecoder.TabPages[tabCrlDecoder.SelectedIndex].Focus();

            //tabCrlDecoder.TabPages[tabCrlDecoder.SelectedIndex].BackColor = bgcolor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fileNumBeforeScan = 0;
            less = 0;
            all = 0;
            miss = 0;
            if (aname.Text == "" || path.Text == "")
            {
                MessageBox.Show("路径或杀软名称不得为空。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                string filePath;
                //MessageBox.Show(path.Text);
                if (Directory.Exists(path.Text) == true)
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(path.Text);
                    FileInfo[] fileInfos = directoryInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly);
                    foreach (FileInfo NextFile in fileInfos)
                    {
                        //MessageBox.Show("AAA");
                        fileNumBeforeScan++;
                        if (File.ReadAllText(NextFile.FullName) == "")
                        {
                            File.Delete(NextFile.FullName);
                            MessageBox.Show("发现空文件——" + NextFile.Name + "\n，已将其删除。", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            filePath = AppDomain.CurrentDomain.BaseDirectory + @"temp\" + NextFile.Name + ".tmp";//在当前程序路径创建
                            File.WriteAllText(filePath, GetFileMD5(NextFile.FullName));
                        }
                    }
                    MessageBox.Show("完成，您现在可以使用杀软扫描了。", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button2.Enabled = true;
                }
                else
                {
                    MessageBox.Show("路径不存在。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //BACK
                }
            }
        }
        #region MD5
        public static string GetFileMD5(string filepath)
        {
            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read);
            int bufferSize = 1048576;
            byte[] buff = new byte[bufferSize];
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.Initialize();
            long offset = 0;
            while (offset < fs.Length)
            {
                long readSize = bufferSize;
                if (offset + readSize > fs.Length)
                    readSize = fs.Length - offset;
                fs.Read(buff, 0, Convert.ToInt32(readSize));
                if (offset + readSize < fs.Length)
                    md5.TransformBlock(buff, 0, Convert.ToInt32(readSize), buff, 0);
                else
                    md5.TransformFinalBlock(buff, 0, Convert.ToInt32(readSize));
                offset += bufferSize;
            }
            if (offset >= fs.Length)
            {
                fs.Close();
                byte[] result = md5.Hash;
                md5.Clear();
                StringBuilder sb = new StringBuilder(32);
                for (int i = 0; i < result.Length; i++)
                    sb.Append(result[i].ToString("X2"));
                return sb.ToString().Substring(1, sb.ToString().Length - 1);
            }
            else
            {
                fs.Close();
                return null;
            }
        }
        #endregion MD5

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DirectoryInfo directoryInfo3 = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + @"temp\del");
            FileInfo[] fileInfos3 = directoryInfo3.GetFiles("*.*", SearchOption.TopDirectoryOnly);
            foreach (FileInfo NextFile3 in fileInfos3)
                File.Delete(NextFile3.FullName);
            DirectoryInfo directoryInfo4 = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + @"temp\clean");
            FileInfo[] fileInfos4 = directoryInfo4.GetFiles("*.*", SearchOption.TopDirectoryOnly);
            foreach (FileInfo NextFile4 in fileInfos4)
                File.Delete(NextFile4.FullName);
            DirectoryInfo directoryInfo5 = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + @"temp\miss");
            FileInfo[] fileInfos5 = directoryInfo5.GetFiles("*.*", SearchOption.TopDirectoryOnly);
            foreach (FileInfo NextFile5 in fileInfos5)
                File.Delete(NextFile5.FullName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //path.Enabled = false;
            //aname.Enabled = false;

            DirectoryInfo directoryInfo = new DirectoryInfo(path.Text);
            FileInfo[] fileInfos = directoryInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly);
            if (Directory.GetDirectories(path.Text).Length > 0 || Directory.GetFiles(path.Text).Length > 0)
            {
                foreach (FileInfo NextFile in fileInfos)
                {
                    filePath = AppDomain.CurrentDomain.BaseDirectory + @"temp\" + NextFile.Name + ".tmp";//在当前程序路径创建
                    if (File.ReadAllText(filePath).Trim().Length != 31)
                    {
                        //MessageBox.Show(File.ReadAllText(filePath).Trim().Length.ToString());
                        MessageBox.Show("扫描前的数据损坏。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        button2.Enabled = false;
                        break;
                    }
                    else
                    {
                        DirectoryInfo directoryInfo3 = new DirectoryInfo(path.Text);
                        FileInfo[] fileInfos3 = directoryInfo3.GetFiles("*.*", SearchOption.TopDirectoryOnly);
                       
                        foreach (FileInfo NextFile3 in fileInfos3)
                        {
                            ///*MessageBox.Show(AppDomain.CurrentDomain.BaseDirectory + @"temp*/\del\" + NextFile3.Name);
                            numAfterScan++;
                            string ass = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"temp\" + NextFile3.Name+ ".tmp");
                            //MessageBox.Show(AppDomain.CurrentDomain.BaseDirectory + @"temp\" + NextFile3.Name + ".tmp");
                            if (GetFileMD5(NextFile3.FullName) != ass)
                            {
                                //MessageBox.Show(GetFileMD5(NextFile3.FullName));
                                //MessageBox.Show(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"temp\" + NextFile.Name + ".tmp"));
                                File.Move(AppDomain.CurrentDomain.BaseDirectory + @"temp\"+ NextFile3.Name + ".tmp", AppDomain.CurrentDomain.BaseDirectory + @"temp\clean\" + NextFile3.Name + ".tmp");
                                clean++;
                            }
                            else
                            {
                                File.Move(AppDomain.CurrentDomain.BaseDirectory + @"temp\" + NextFile3.Name + ".tmp", AppDomain.CurrentDomain.BaseDirectory + @"temp\miss\" + NextFile3.Name + ".tmp");
                                //MessageBox.Show(AppDomain.CurrentDomain.BaseDirectory + @"temp\miss\" + NextFile3.Name);
                                miss++;
                            }
                        }
                        DirectoryInfo directoryInfo4 = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + @"temp\");
                        FileInfo[] fileInfos4 = directoryInfo4.GetFiles("*.*", SearchOption.TopDirectoryOnly);
                        foreach (FileInfo NextFile4 in fileInfos4)
                        {
                            File.Move(AppDomain.CurrentDomain.BaseDirectory + @"temp\" + NextFile4.Name, AppDomain.CurrentDomain.BaseDirectory + @"temp\del\" + NextFile4.Name);
                        }
                        less = fileNumBeforeScan - numAfterScan;
                        all = clean + less;

                        double percent = Convert.ToDouble(all) / Convert.ToDouble(fileNumBeforeScan);
                        result = percent.ToString("p");//可以到的5.88%
                        Output.AppendText("Srr " + version + Environment.NewLine + "杀软名称：" + aname.Text + Environment.NewLine + "文件总个数：" + fileNumBeforeScan + Environment.NewLine + "删除：" + less.ToString() + Environment.NewLine + "清除：" + clean + Environment.NewLine + "未检测到：" + miss + Environment.NewLine + "共检测出：" + all + Environment.NewLine + "查杀率：" + result + Environment.NewLine + Environment.NewLine);

                        MessageBox.Show("完成，请去输出栏查看结果。", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        numAfterScan = 0;
                        a = fileNumBeforeScan;

                        //aa = 0;
                        button2.Enabled = false;
                        path.Enabled = true;
                        aname.Enabled = true;
                        button3.Enabled = true;
                        break;
                    }
                }
                
            }
            else
            {
                Output.Text = "";
                Output.AppendText("Srr " + version + Environment.NewLine + "杀软名称：" + aname.Text + Environment.NewLine + "文件总个数：" + fileNumBeforeScan + Environment.NewLine + "删除：" + fileNumBeforeScan + Environment.NewLine + "清除：" + 0 + Environment.NewLine + "未检测到：" + 0 + Environment.NewLine + "共检测出：" + fileNumBeforeScan + Environment.NewLine + "查杀率：100%" + Environment.NewLine + Environment.NewLine);
                MessageBox.Show("完成，请去输出栏查看结果。", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button2.Enabled = false;
                path.Enabled = true;
                aname.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (a != 0)
            {
                string p = AppDomain.CurrentDomain.BaseDirectory + @"log\" + aname.Text + "'s Log.txt";
                File.WriteAllText(p, "杀软名称：" + aname.Text + Environment.NewLine + "文件总个数：" + fileNumBeforeScan + Environment.NewLine + "删除：" + less.ToString() + Environment.NewLine + "清除：" + clean + Environment.NewLine + "未检测到：" + miss + Environment.NewLine + "共检测出：" + all + Environment.NewLine + "查杀率：" + result + Environment.NewLine + Environment.NewLine);
                File.AppendAllText(p, "详细信息：" + Environment.NewLine + Environment.NewLine);
                DirectoryInfo directoryInfo5 = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + @"temp\del");
                FileInfo[] fileInfos5 = directoryInfo5.GetFiles("*.*", SearchOption.TopDirectoryOnly);
                string filenamenow;
                //MessageBox.Show("A");
                foreach (FileInfo NextFile5 in fileInfos5)
                {
                    //MessageBox.Show("A");
                    filenamenow = NextFile5.Name.Substring(0, NextFile5.Name.Length - 4);
                    File.AppendAllText(p, filenamenow + "  -  " + "已删除。" + Environment.NewLine);
                }
                File.AppendAllText(p, Environment.NewLine);
                DirectoryInfo directoryInfo6 = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + @"temp\clean");
                FileInfo[] fileInfos6 = directoryInfo6.GetFiles("*.*", SearchOption.TopDirectoryOnly);
                foreach (FileInfo NextFile6 in fileInfos6)
                {
                    filenamenow = NextFile6.Name.Substring(0, NextFile6.Name.Length - 4);
                    File.AppendAllText(p, filenamenow + "  -  " + "已清除。" + Environment.NewLine);
                }
                File.AppendAllText(p, Environment.NewLine);
                DirectoryInfo directoryInfo7 = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + @"temp\miss");
                FileInfo[] fileInfos7 = directoryInfo7.GetFiles("*.*", SearchOption.TopDirectoryOnly);
                foreach (FileInfo NextFile7 in fileInfos7)
                {
                    //MessageBox.Show(NextFile7.Name);
                    filenamenow = NextFile7.Name.Substring(0, NextFile7.Name.Length - 4);
                    File.AppendAllText(p, filenamenow + "  -  " + "未能检测到。" + Environment.NewLine);
                }

                File.AppendAllText(p, Environment.NewLine);
                File.AppendAllText(p, Environment.NewLine);
                File.AppendAllText(p, "由Srr  " + version + "生成。");
                MessageBox.Show("完成，已写到Log文件夹下。", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button3.Enabled = false;
            }
            else
            {
                MessageBox.Show(fileNumBeforeScan+"无日志。", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
