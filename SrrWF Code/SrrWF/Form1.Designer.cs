namespace SrrWF
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabCrlDecoder = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.aname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.path = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.ss = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.Output = new System.Windows.Forms.TextBox();
            this.tabCrlDecoder.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.ss.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCrlDecoder
            // 
            this.tabCrlDecoder.Controls.Add(this.tabPage2);
            this.tabCrlDecoder.Controls.Add(this.TabPage1);
            this.tabCrlDecoder.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabCrlDecoder.Location = new System.Drawing.Point(-4, 0);
            this.tabCrlDecoder.Name = "tabCrlDecoder";
            this.tabCrlDecoder.SelectedIndex = 0;
            this.tabCrlDecoder.Size = new System.Drawing.Size(732, 482);
            this.tabCrlDecoder.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabCrlDecoder.TabIndex = 0;
            this.tabCrlDecoder.SelectedIndexChanged += new System.EventHandler(this.tabCrlDecoder_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.aname);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.path);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 37);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(724, 441);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "准备";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(166, 191);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(407, 124);
            this.button1.TabIndex = 4;
            this.button1.Text = "Ready!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // aname
            // 
            this.aname.Location = new System.Drawing.Point(135, 100);
            this.aname.Name = "aname";
            this.aname.Size = new System.Drawing.Size(320, 35);
            this.aname.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "杀软名称：";
            // 
            // path
            // 
            this.path.Location = new System.Drawing.Point(93, 32);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(558, 35);
            this.path.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "路径：";
            // 
            // TabPage1
            // 
            this.TabPage1.BackColor = System.Drawing.Color.White;
            this.TabPage1.Controls.Add(this.ss);
            this.TabPage1.Location = new System.Drawing.Point(4, 37);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(724, 441);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "统计";
            // 
            // ss
            // 
            this.ss.Controls.Add(this.tabPage3);
            this.ss.Controls.Add(this.tabPage4);
            this.ss.Location = new System.Drawing.Point(0, 0);
            this.ss.Name = "ss";
            this.ss.SelectedIndex = 0;
            this.ss.Size = new System.Drawing.Size(710, 392);
            this.ss.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.ss.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Location = new System.Drawing.Point(4, 37);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(702, 351);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "开始统计";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(71, 56);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(556, 245);
            this.button2.TabIndex = 0;
            this.button2.Text = "Check!";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button3);
            this.tabPage4.Controls.Add(this.Output);
            this.tabPage4.Location = new System.Drawing.Point(4, 37);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(702, 351);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "输出";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(277, 295);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(147, 45);
            this.button3.TabIndex = 4;
            this.button3.Text = "输出日志";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Output
            // 
            this.Output.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Output.Location = new System.Drawing.Point(6, 0);
            this.Output.Multiline = true;
            this.Output.Name = "Output";
            this.Output.ReadOnly = true;
            this.Output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Output.Size = new System.Drawing.Size(696, 286);
            this.Output.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 426);
            this.Controls.Add(this.tabCrlDecoder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(732, 482);
            this.MinimumSize = new System.Drawing.Size(732, 482);
            this.Name = "Form1";
            this.Opacity = 0.95D;
            this.Text = "Srr.  WinForm Edition.    By   JimmyL. ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabCrlDecoder.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.TabPage1.ResumeLayout(false);
            this.ss.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCrlDecoder;
        private System.Windows.Forms.TabPage TabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox path;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox aname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl ss;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox Output;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

