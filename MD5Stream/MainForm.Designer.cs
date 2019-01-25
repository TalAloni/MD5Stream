namespace MD5Stream
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabCorrect = new System.Windows.Forms.TabPage();
            this.listCorrect = new System.Windows.Forms.ListBox();
            this.tabIncorrect = new System.Windows.Forms.TabPage();
            this.listIncorrect = new System.Windows.Forms.ListBox();
            this.tabAdded = new System.Windows.Forms.TabPage();
            this.listAdded = new System.Windows.Forms.ListBox();
            this.tabUpdated = new System.Windows.Forms.TabPage();
            this.listUpdated = new System.Windows.Forms.ListBox();
            this.tabInvalid = new System.Windows.Forms.TabPage();
            this.listInvalid = new System.Windows.Forms.ListBox();
            this.tabInaccessible = new System.Windows.Forms.TabPage();
            this.listInaccessible = new System.Windows.Forms.ListBox();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusBarLabelProgress = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabCorrect.SuspendLayout();
            this.tabIncorrect.SuspendLayout();
            this.tabAdded.SuspendLayout();
            this.tabUpdated.SuspendLayout();
            this.tabInvalid.SuspendLayout();
            this.tabInaccessible.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabCorrect);
            this.tabControl.Controls.Add(this.tabIncorrect);
            this.tabControl.Controls.Add(this.tabAdded);
            this.tabControl.Controls.Add(this.tabUpdated);
            this.tabControl.Controls.Add(this.tabInvalid);
            this.tabControl.Controls.Add(this.tabInaccessible);
            this.tabControl.Location = new System.Drawing.Point(12, 43);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(528, 225);
            this.tabControl.TabIndex = 0;
            this.tabControl.Resize += new System.EventHandler(this.tabControl_Resize);
            // 
            // tabCorrect
            // 
            this.tabCorrect.Controls.Add(this.listCorrect);
            this.tabCorrect.Location = new System.Drawing.Point(4, 22);
            this.tabCorrect.Name = "tabCorrect";
            this.tabCorrect.Padding = new System.Windows.Forms.Padding(3);
            this.tabCorrect.Size = new System.Drawing.Size(520, 199);
            this.tabCorrect.TabIndex = 0;
            this.tabCorrect.Text = "Correct (0)";
            this.tabCorrect.UseVisualStyleBackColor = true;
            // 
            // listCorrect
            // 
            this.listCorrect.FormattingEnabled = true;
            this.listCorrect.Location = new System.Drawing.Point(6, 6);
            this.listCorrect.Name = "listCorrect";
            this.listCorrect.Size = new System.Drawing.Size(508, 186);
            this.listCorrect.TabIndex = 0;
            // 
            // tabIncorrect
            // 
            this.tabIncorrect.Controls.Add(this.listIncorrect);
            this.tabIncorrect.Location = new System.Drawing.Point(4, 22);
            this.tabIncorrect.Name = "tabIncorrect";
            this.tabIncorrect.Padding = new System.Windows.Forms.Padding(3);
            this.tabIncorrect.Size = new System.Drawing.Size(520, 199);
            this.tabIncorrect.TabIndex = 1;
            this.tabIncorrect.Text = "Incorrect (0)";
            this.tabIncorrect.UseVisualStyleBackColor = true;
            // 
            // listIncorrect
            // 
            this.listIncorrect.FormattingEnabled = true;
            this.listIncorrect.Location = new System.Drawing.Point(6, 6);
            this.listIncorrect.Name = "listIncorrect";
            this.listIncorrect.Size = new System.Drawing.Size(508, 186);
            this.listIncorrect.TabIndex = 1;
            // 
            // tabAdded
            // 
            this.tabAdded.Controls.Add(this.listAdded);
            this.tabAdded.Location = new System.Drawing.Point(4, 22);
            this.tabAdded.Name = "tabAdded";
            this.tabAdded.Size = new System.Drawing.Size(520, 199);
            this.tabAdded.TabIndex = 2;
            this.tabAdded.Text = "Added (0)";
            this.tabAdded.UseVisualStyleBackColor = true;
            // 
            // listAdded
            // 
            this.listAdded.FormattingEnabled = true;
            this.listAdded.Location = new System.Drawing.Point(6, 6);
            this.listAdded.Name = "listAdded";
            this.listAdded.Size = new System.Drawing.Size(508, 186);
            this.listAdded.TabIndex = 1;
            // 
            // tabUpdated
            // 
            this.tabUpdated.Controls.Add(this.listUpdated);
            this.tabUpdated.Location = new System.Drawing.Point(4, 22);
            this.tabUpdated.Name = "tabUpdated";
            this.tabUpdated.Size = new System.Drawing.Size(520, 199);
            this.tabUpdated.TabIndex = 3;
            this.tabUpdated.Text = "Updated (0)";
            this.tabUpdated.UseVisualStyleBackColor = true;
            // 
            // listUpdated
            // 
            this.listUpdated.FormattingEnabled = true;
            this.listUpdated.Location = new System.Drawing.Point(6, 6);
            this.listUpdated.Name = "listUpdated";
            this.listUpdated.Size = new System.Drawing.Size(508, 186);
            this.listUpdated.TabIndex = 1;
            // 
            // tabInvalid
            // 
            this.tabInvalid.Controls.Add(this.listInvalid);
            this.tabInvalid.Location = new System.Drawing.Point(4, 22);
            this.tabInvalid.Name = "tabInvalid";
            this.tabInvalid.Size = new System.Drawing.Size(520, 199);
            this.tabInvalid.TabIndex = 4;
            this.tabInvalid.Text = "Invalid (0)";
            this.tabInvalid.UseVisualStyleBackColor = true;
            // 
            // listInvalid
            // 
            this.listInvalid.FormattingEnabled = true;
            this.listInvalid.Location = new System.Drawing.Point(6, 6);
            this.listInvalid.Name = "listInvalid";
            this.listInvalid.Size = new System.Drawing.Size(508, 186);
            this.listInvalid.TabIndex = 1;
            // 
            // tabInaccessible
            // 
            this.tabInaccessible.Controls.Add(this.listInaccessible);
            this.tabInaccessible.Location = new System.Drawing.Point(4, 22);
            this.tabInaccessible.Name = "tabInaccessible";
            this.tabInaccessible.Size = new System.Drawing.Size(520, 199);
            this.tabInaccessible.TabIndex = 5;
            this.tabInaccessible.Text = "Inaccessible (0)";
            this.tabInaccessible.UseVisualStyleBackColor = true;
            // 
            // listInaccessible
            // 
            this.listInaccessible.FormattingEnabled = true;
            this.listInaccessible.Location = new System.Drawing.Point(6, 6);
            this.listInaccessible.Name = "listInaccessible";
            this.listInaccessible.Size = new System.Drawing.Size(508, 186);
            this.listInaccessible.TabIndex = 2;
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarLabelProgress});
            this.statusBar.Location = new System.Drawing.Point(0, 271);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(552, 22);
            this.statusBar.SizingGrip = false;
            this.statusBar.TabIndex = 1;
            this.statusBar.Text = "statusStrip1";
            // 
            // statusBarLabelProgress
            // 
            this.statusBarLabelProgress.Name = "statusBarLabelProgress";
            this.statusBarLabelProgress.Size = new System.Drawing.Size(0, 17);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Path:";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(47, 6);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(330, 20);
            this.txtPath.TabIndex = 3;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(383, 4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(465, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 293);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(560, 320);
            this.Name = "MainForm";
            this.Text = "MD5Stream";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.tabControl.ResumeLayout(false);
            this.tabCorrect.ResumeLayout(false);
            this.tabIncorrect.ResumeLayout(false);
            this.tabAdded.ResumeLayout(false);
            this.tabUpdated.ResumeLayout(false);
            this.tabInvalid.ResumeLayout(false);
            this.tabInaccessible.ResumeLayout(false);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabCorrect;
        private System.Windows.Forms.TabPage tabIncorrect;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TabPage tabAdded;
        private System.Windows.Forms.TabPage tabUpdated;
        private System.Windows.Forms.TabPage tabInvalid;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ToolStripStatusLabel statusBarLabelProgress;
        private System.Windows.Forms.ListBox listCorrect;
        private System.Windows.Forms.ListBox listIncorrect;
        private System.Windows.Forms.ListBox listAdded;
        private System.Windows.Forms.ListBox listUpdated;
        private System.Windows.Forms.ListBox listInvalid;
        private System.Windows.Forms.TabPage tabInaccessible;
        private System.Windows.Forms.ListBox listInaccessible;
    }
}