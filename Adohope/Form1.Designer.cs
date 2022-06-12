namespace Adohope
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chkBox_Photos = new System.Windows.Forms.CheckBox();
            this.chkBox_VoiceNotes = new System.Windows.Forms.CheckBox();
            this.chkBox_Messages = new System.Windows.Forms.CheckBox();
            this.chkBox_Contacts = new System.Windows.Forms.CheckBox();
            this.chkBox_Notes = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkBox_HEIC = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Backup Folder :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(106, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(425, 23);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(537, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Select";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkBox_Photos
            // 
            this.chkBox_Photos.AutoSize = true;
            this.chkBox_Photos.Location = new System.Drawing.Point(11, 11);
            this.chkBox_Photos.Name = "chkBox_Photos";
            this.chkBox_Photos.Size = new System.Drawing.Size(180, 19);
            this.chkBox_Photos.TabIndex = 3;
            this.chkBox_Photos.Text = "Extract All Photos and Videos";
            this.chkBox_Photos.UseVisualStyleBackColor = true;
            this.chkBox_Photos.CheckedChanged += new System.EventHandler(this.chkBox_Photos_CheckedChanged);
            // 
            // chkBox_VoiceNotes
            // 
            this.chkBox_VoiceNotes.AutoSize = true;
            this.chkBox_VoiceNotes.Location = new System.Drawing.Point(11, 56);
            this.chkBox_VoiceNotes.Name = "chkBox_VoiceNotes";
            this.chkBox_VoiceNotes.Size = new System.Drawing.Size(144, 19);
            this.chkBox_VoiceNotes.TabIndex = 4;
            this.chkBox_VoiceNotes.Text = "Extract All Voice Notes";
            this.chkBox_VoiceNotes.UseVisualStyleBackColor = true;
            // 
            // chkBox_Messages
            // 
            this.chkBox_Messages.AutoSize = true;
            this.chkBox_Messages.Location = new System.Drawing.Point(11, 81);
            this.chkBox_Messages.Name = "chkBox_Messages";
            this.chkBox_Messages.Size = new System.Drawing.Size(133, 19);
            this.chkBox_Messages.TabIndex = 5;
            this.chkBox_Messages.Text = "Extract All Messages";
            this.chkBox_Messages.UseVisualStyleBackColor = true;
            // 
            // chkBox_Contacts
            // 
            this.chkBox_Contacts.AutoSize = true;
            this.chkBox_Contacts.Location = new System.Drawing.Point(11, 106);
            this.chkBox_Contacts.Name = "chkBox_Contacts";
            this.chkBox_Contacts.Size = new System.Drawing.Size(129, 19);
            this.chkBox_Contacts.TabIndex = 6;
            this.chkBox_Contacts.Text = "Extract All Contacts";
            this.chkBox_Contacts.UseVisualStyleBackColor = true;
            // 
            // chkBox_Notes
            // 
            this.chkBox_Notes.AutoSize = true;
            this.chkBox_Notes.Location = new System.Drawing.Point(11, 131);
            this.chkBox_Notes.Name = "chkBox_Notes";
            this.chkBox_Notes.Size = new System.Drawing.Size(113, 19);
            this.chkBox_Notes.TabIndex = 7;
            this.chkBox_Notes.Text = "Extract All Notes";
            this.chkBox_Notes.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(7, 168);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(586, 37);
            this.button2.TabIndex = 8;
            this.button2.Text = "Start Extracting";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkBox_HEIC);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.chkBox_Notes);
            this.panel1.Controls.Add(this.chkBox_Photos);
            this.panel1.Controls.Add(this.chkBox_Contacts);
            this.panel1.Controls.Add(this.chkBox_VoiceNotes);
            this.panel1.Controls.Add(this.chkBox_Messages);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(12, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 215);
            this.panel1.TabIndex = 9;
            // 
            // chkBox_HEIC
            // 
            this.chkBox_HEIC.AutoSize = true;
            this.chkBox_HEIC.Enabled = false;
            this.chkBox_HEIC.Location = new System.Drawing.Point(32, 33);
            this.chkBox_HEIC.Name = "chkBox_HEIC";
            this.chkBox_HEIC.Size = new System.Drawing.Size(133, 19);
            this.chkBox_HEIC.TabIndex = 9;
            this.chkBox_HEIC.Text = "Convert HEIC to JPG";
            this.chkBox_HEIC.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 272);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(624, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsStatus
            // 
            this.tsStatus.Margin = new System.Windows.Forms.Padding(3, 3, 0, 2);
            this.tsStatus.Name = "tsStatus";
            this.tsStatus.Size = new System.Drawing.Size(42, 17);
            this.tsStatus.Text = "Ready.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 294);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Adohope - Tiny Tool";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkBox_Photos;
        private System.Windows.Forms.CheckBox chkBox_VoiceNotes;
        private System.Windows.Forms.CheckBox chkBox_Messages;
        private System.Windows.Forms.CheckBox chkBox_Contacts;
        private System.Windows.Forms.CheckBox chkBox_Notes;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkBox_HEIC;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsStatus;
    }
}

