namespace _8mbfy
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.button3 = new System.Windows.Forms.Button();
            this.jpg_q = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cnv_jpg = new System.Windows.Forms.RadioButton();
            this.resize_only = new System.Windows.Forms.RadioButton();
            this.top_def = new System.Windows.Forms.CheckBox();
            this.auto_copy = new System.Windows.Forms.CheckBox();
            this.auto_delete = new System.Windows.Forms.CheckBox();
            this.auto_exit = new System.Windows.Forms.CheckBox();
            this.auto_start = new System.Windows.Forms.CheckBox();
            this.file_skip = new System.Windows.Forms.CheckBox();
            this.target_size = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.jpg_q)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.target_size)).BeginInit();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(10, 320);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(214, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "OK";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // jpg_q
            // 
            this.jpg_q.Location = new System.Drawing.Point(123, 111);
            this.jpg_q.Name = "jpg_q";
            this.jpg_q.Size = new System.Drawing.Size(60, 23);
            this.jpg_q.TabIndex = 14;
            this.jpg_q.Value = new decimal(new int[] {
            85,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "jpegエンコーダー品質";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cnv_jpg);
            this.groupBox1.Controls.Add(this.resize_only);
            this.groupBox1.Location = new System.Drawing.Point(12, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 78);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "透過付き画像(.png/.bmp)";
            // 
            // cnv_jpg
            // 
            this.cnv_jpg.AutoSize = true;
            this.cnv_jpg.Location = new System.Drawing.Point(14, 47);
            this.cnv_jpg.Name = "cnv_jpg";
            this.cnv_jpg.Size = new System.Drawing.Size(198, 19);
            this.cnv_jpg.TabIndex = 1;
            this.cnv_jpg.Text = "jpegに変換し、必要であればリサイズ";
            this.cnv_jpg.UseVisualStyleBackColor = true;
            // 
            // resize_only
            // 
            this.resize_only.AutoSize = true;
            this.resize_only.Checked = true;
            this.resize_only.Location = new System.Drawing.Point(14, 22);
            this.resize_only.Name = "resize_only";
            this.resize_only.Size = new System.Drawing.Size(111, 19);
            this.resize_only.TabIndex = 0;
            this.resize_only.TabStop = true;
            this.resize_only.Text = "リサイズのみを行う";
            this.resize_only.UseVisualStyleBackColor = true;
            // 
            // top_def
            // 
            this.top_def.AutoSize = true;
            this.top_def.Location = new System.Drawing.Point(12, 140);
            this.top_def.Name = "top_def";
            this.top_def.Size = new System.Drawing.Size(142, 19);
            this.top_def.TabIndex = 17;
            this.top_def.Text = "最前面をデフォルトにする";
            this.top_def.UseVisualStyleBackColor = true;
            // 
            // auto_copy
            // 
            this.auto_copy.AutoSize = true;
            this.auto_copy.Location = new System.Drawing.Point(12, 165);
            this.auto_copy.Name = "auto_copy";
            this.auto_copy.Size = new System.Drawing.Size(141, 19);
            this.auto_copy.TabIndex = 18;
            this.auto_copy.Text = "変換後に自動的にコピー";
            this.auto_copy.UseVisualStyleBackColor = true;
            // 
            // auto_delete
            // 
            this.auto_delete.AutoSize = true;
            this.auto_delete.Location = new System.Drawing.Point(12, 190);
            this.auto_delete.Name = "auto_delete";
            this.auto_delete.Size = new System.Drawing.Size(154, 19);
            this.auto_delete.TabIndex = 19;
            this.auto_delete.Text = "終了時に変換データを削除";
            this.auto_delete.UseVisualStyleBackColor = true;
            // 
            // auto_exit
            // 
            this.auto_exit.AutoSize = true;
            this.auto_exit.Location = new System.Drawing.Point(12, 215);
            this.auto_exit.Name = "auto_exit";
            this.auto_exit.Size = new System.Drawing.Size(130, 19);
            this.auto_exit.TabIndex = 20;
            this.auto_exit.Text = "変換後プログラム終了";
            this.auto_exit.UseVisualStyleBackColor = true;
            // 
            // auto_start
            // 
            this.auto_start.AutoSize = true;
            this.auto_start.Location = new System.Drawing.Point(12, 240);
            this.auto_start.Name = "auto_start";
            this.auto_start.Size = new System.Drawing.Size(181, 34);
            this.auto_start.TabIndex = 21;
            this.auto_start.Text = "クリップボードにデータがあった\r\n場合は自動的に処理を開始する";
            this.auto_start.UseVisualStyleBackColor = true;
            // 
            // file_skip
            // 
            this.file_skip.AutoSize = true;
            this.file_skip.Location = new System.Drawing.Point(12, 280);
            this.file_skip.Name = "file_skip";
            this.file_skip.Size = new System.Drawing.Size(186, 34);
            this.file_skip.TabIndex = 22;
            this.file_skip.Text = "最初から目標サイズ値の場合でも\r\n作業フォルダにコピーする";
            this.file_skip.UseVisualStyleBackColor = true;
            // 
            // target_size
            // 
            this.target_size.DecimalPlaces = 2;
            this.target_size.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.target_size.Location = new System.Drawing.Point(73, 3);
            this.target_size.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.target_size.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.target_size.Name = "target_size";
            this.target_size.Size = new System.Drawing.Size(81, 23);
            this.target_size.TabIndex = 23;
            this.target_size.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.target_size.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 24;
            this.label2.Text = "目標サイズ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 15);
            this.label3.TabIndex = 25;
            this.label3.Text = "MB";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 350);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.target_size);
            this.Controls.Add(this.file_skip);
            this.Controls.Add(this.auto_start);
            this.Controls.Add(this.auto_exit);
            this.Controls.Add(this.auto_delete);
            this.Controls.Add(this.auto_copy);
            this.Controls.Add(this.top_def);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.jpg_q);
            this.Controls.Add(this.button3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.jpg_q)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.target_size)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button button3;
        private NumericUpDown jpg_q;
        private Label label1;
        private GroupBox groupBox1;
        private RadioButton cnv_jpg;
        private RadioButton resize_only;
        private CheckBox top_def;
        private CheckBox auto_copy;
        private CheckBox auto_delete;
        private CheckBox auto_exit;
        private CheckBox auto_start;
        private CheckBox file_skip;
        private NumericUpDown target_size;
        private Label label2;
        private Label label3;
    }
}