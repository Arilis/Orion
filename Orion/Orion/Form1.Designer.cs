namespace Orion
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SavedScripts = new System.Windows.Forms.ListBox();
            this.ExecuteButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.HookButton = new System.Windows.Forms.Button();
            this.ExitLabel = new System.Windows.Forms.Label();
            this.OrionLabel = new System.Windows.Forms.Label();
            this.MinimizeLabel = new System.Windows.Forms.Label();
            this.RefreshScriptBox = new System.Windows.Forms.Button();
            this.OpenFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(5, 25);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(494, 273);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Visible = false;
            // 
            // SavedScripts
            // 
            this.SavedScripts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.SavedScripts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SavedScripts.ForeColor = System.Drawing.Color.White;
            this.SavedScripts.FormattingEnabled = true;
            this.SavedScripts.Location = new System.Drawing.Point(505, 25);
            this.SavedScripts.Name = "SavedScripts";
            this.SavedScripts.Size = new System.Drawing.Size(103, 273);
            this.SavedScripts.TabIndex = 1;
            this.SavedScripts.SelectedIndexChanged += new System.EventHandler(this.SavedScripts_SelectedIndexChanged);
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ExecuteButton.FlatAppearance.BorderSize = 0;
            this.ExecuteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExecuteButton.Location = new System.Drawing.Point(5, 304);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(80, 31);
            this.ExecuteButton.TabIndex = 2;
            this.ExecuteButton.Text = "Execute";
            this.ExecuteButton.UseVisualStyleBackColor = false;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClearButton.FlatAppearance.BorderSize = 0;
            this.ClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearButton.Location = new System.Drawing.Point(91, 304);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(80, 31);
            this.ClearButton.TabIndex = 3;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // HookButton
            // 
            this.HookButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.HookButton.FlatAppearance.BorderSize = 0;
            this.HookButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HookButton.Location = new System.Drawing.Point(419, 304);
            this.HookButton.Name = "HookButton";
            this.HookButton.Size = new System.Drawing.Size(80, 31);
            this.HookButton.TabIndex = 4;
            this.HookButton.Text = "Hook";
            this.HookButton.UseVisualStyleBackColor = false;
            this.HookButton.Click += new System.EventHandler(this.HookButton_Click);
            // 
            // ExitLabel
            // 
            this.ExitLabel.AutoSize = true;
            this.ExitLabel.Location = new System.Drawing.Point(594, 9);
            this.ExitLabel.Name = "ExitLabel";
            this.ExitLabel.Size = new System.Drawing.Size(14, 13);
            this.ExitLabel.TabIndex = 5;
            this.ExitLabel.Text = "X";
            this.ExitLabel.Click += new System.EventHandler(this.ExitLabel_Click);
            // 
            // OrionLabel
            // 
            this.OrionLabel.AutoSize = true;
            this.OrionLabel.Location = new System.Drawing.Point(2, 9);
            this.OrionLabel.Name = "OrionLabel";
            this.OrionLabel.Size = new System.Drawing.Size(179, 13);
            this.OrionLabel.TabIndex = 6;
            this.OrionLabel.Text = "Orion | Open-Sourced Roblox Exploit";
            this.OrionLabel.Click += new System.EventHandler(this.OrionLabel_Click);
            // 
            // MinimizeLabel
            // 
            this.MinimizeLabel.AutoSize = true;
            this.MinimizeLabel.Location = new System.Drawing.Point(582, 9);
            this.MinimizeLabel.Name = "MinimizeLabel";
            this.MinimizeLabel.Size = new System.Drawing.Size(10, 13);
            this.MinimizeLabel.TabIndex = 7;
            this.MinimizeLabel.Text = "-";
            this.MinimizeLabel.Click += new System.EventHandler(this.MinimizeLabel_Click);
            // 
            // RefreshScriptBox
            // 
            this.RefreshScriptBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.RefreshScriptBox.FlatAppearance.BorderSize = 0;
            this.RefreshScriptBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshScriptBox.Location = new System.Drawing.Point(505, 304);
            this.RefreshScriptBox.Name = "RefreshScriptBox";
            this.RefreshScriptBox.Size = new System.Drawing.Size(103, 31);
            this.RefreshScriptBox.TabIndex = 8;
            this.RefreshScriptBox.Text = "Refresh";
            this.RefreshScriptBox.UseVisualStyleBackColor = false;
            this.RefreshScriptBox.Click += new System.EventHandler(this.RefreshScriptBox_Click);
            // 
            // OpenFile
            // 
            this.OpenFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.OpenFile.FlatAppearance.BorderSize = 0;
            this.OpenFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenFile.Location = new System.Drawing.Point(177, 304);
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(80, 31);
            this.OpenFile.TabIndex = 9;
            this.OpenFile.Text = "Open";
            this.OpenFile.UseVisualStyleBackColor = false;
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(613, 340);
            this.ControlBox = false;
            this.Controls.Add(this.OpenFile);
            this.Controls.Add(this.RefreshScriptBox);
            this.Controls.Add(this.MinimizeLabel);
            this.Controls.Add(this.OrionLabel);
            this.Controls.Add(this.ExitLabel);
            this.Controls.Add(this.HookButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.ExecuteButton);
            this.Controls.Add(this.SavedScripts);
            this.Controls.Add(this.webBrowser1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orion";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ListBox SavedScripts;
        private System.Windows.Forms.Button ExecuteButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button HookButton;
        private System.Windows.Forms.Label ExitLabel;
        private System.Windows.Forms.Label OrionLabel;
        private System.Windows.Forms.Label MinimizeLabel;
        private System.Windows.Forms.Button RefreshScriptBox;
        private System.Windows.Forms.Button OpenFile;
    }
}

