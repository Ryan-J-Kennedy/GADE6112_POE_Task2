namespace GADE6112_POE
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
            this.components = new System.ComponentModel.Container();
            this.lblRound = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.GameTick = new System.Windows.Forms.Timer(this.components);
            this.btnPause = new System.Windows.Forms.Button();
            this.gbMap = new System.Windows.Forms.GroupBox();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblRound
            // 
            this.lblRound.AutoSize = true;
            this.lblRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRound.Location = new System.Drawing.Point(1288, 60);
            this.lblRound.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(132, 33);
            this.lblRound.TabIndex = 0;
            this.lblRound.Text = "Round: 1";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 1177);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(148, 67);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(1218, 844);
            this.txtOutput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(434, 398);
            this.txtOutput.TabIndex = 3;
            this.txtOutput.Text = "";
            // 
            // GameTick
            // 
            this.GameTick.Interval = 1000;
            this.GameTick.Tick += new System.EventHandler(this.GameTick_Tick);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(168, 1177);
            this.btnPause.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(148, 67);
            this.btnPause.TabIndex = 4;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // gbMap
            // 
            this.gbMap.Location = new System.Drawing.Point(4, 2);
            this.gbMap.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbMap.Name = "gbMap";
            this.gbMap.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbMap.Size = new System.Drawing.Size(1204, 1163);
            this.gbMap.TabIndex = 5;
            this.gbMap.TabStop = false;
            this.gbMap.Text = "Map";
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(1060, 1175);
            this.btnRead.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(148, 67);
            this.btnRead.TabIndex = 6;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(904, 1175);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(148, 67);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1662, 1252);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.gbMap);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblRound);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "RTS Simulation";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRound;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.Timer GameTick;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.GroupBox gbMap;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnSave;
    }
}

