namespace Piwnica
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
            oApkBtn = new Button();
            ExtBtn = new Button();
            label1 = new Label();
            label2 = new Label();
            Contener_LBx = new ListBox();
            label3 = new Label();
            Shelfs_LBx = new ListBox();
            label4 = new Label();
            Stuff_LBx = new ListBox();
            ContenerAdd_Btn = new Button();
            ContenerRemove_Btn = new Button();
            ShelfAdd_Btn = new Button();
            ShelfRemove_Btn = new Button();
            StuffRemove_Btn = new Button();
            StuffAdd_Btn = new Button();
            ContenerMod_Btn = new Button();
            ShelfsMod_Btn = new Button();
            StuffMod_Btn = new Button();
            SuspendLayout();
            // 
            // oApkBtn
            // 
            oApkBtn.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            oApkBtn.Location = new Point(804, 387);
            oApkBtn.Name = "oApkBtn";
            oApkBtn.Size = new Size(108, 32);
            oApkBtn.TabIndex = 1;
            oApkBtn.Text = "O Aplikacji";
            oApkBtn.UseVisualStyleBackColor = true;
            oApkBtn.Click += oApkBtn_Click;
            // 
            // ExtBtn
            // 
            ExtBtn.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            ExtBtn.Location = new Point(818, 425);
            ExtBtn.Name = "ExtBtn";
            ExtBtn.Size = new Size(94, 32);
            ExtBtn.TabIndex = 2;
            ExtBtn.Text = "Wyjdź";
            ExtBtn.UseVisualStyleBackColor = true;
            ExtBtn.Click += ExtBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(211, 40);
            label1.TabIndex = 3;
            label1.Text = "Naciśnij na interesujący Cię\r\nelement, aby wybrać go z listy.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 105);
            label2.Name = "label2";
            label2.Size = new Size(213, 20);
            label2.TabIndex = 4;
            label2.Text = "Obecne \"kontenery\" w piwnicy:";
            // 
            // Contener_LBx
            // 
            Contener_LBx.FormattingEnabled = true;
            Contener_LBx.Location = new Point(12, 128);
            Contener_LBx.Name = "Contener_LBx";
            Contener_LBx.Size = new Size(213, 224);
            Contener_LBx.TabIndex = 5;
            Contener_LBx.SelectedIndexChanged += Contener_LBx_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(281, 29);
            label3.Name = "label3";
            label3.Size = new Size(94, 20);
            label3.TabIndex = 6;
            label3.Text = "Podzbiorniki:";
            // 
            // Shelfs_LBx
            // 
            Shelfs_LBx.FormattingEnabled = true;
            Shelfs_LBx.Location = new Point(281, 52);
            Shelfs_LBx.Name = "Shelfs_LBx";
            Shelfs_LBx.Size = new Size(160, 304);
            Shelfs_LBx.TabIndex = 7;
            Shelfs_LBx.SelectedIndexChanged += Shelfs_LBx_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(486, 29);
            label4.Name = "label4";
            label4.Size = new Size(239, 20);
            label4.TabIndex = 8;
            label4.Text = "Przedmioty w wybranym zbiorniku:";
            // 
            // Stuff_LBx
            // 
            Stuff_LBx.FormattingEnabled = true;
            Stuff_LBx.Location = new Point(486, 52);
            Stuff_LBx.Name = "Stuff_LBx";
            Stuff_LBx.Size = new Size(407, 304);
            Stuff_LBx.TabIndex = 9;
            // 
            // ContenerAdd_Btn
            // 
            ContenerAdd_Btn.Location = new Point(65, 358);
            ContenerAdd_Btn.Name = "ContenerAdd_Btn";
            ContenerAdd_Btn.Size = new Size(94, 29);
            ContenerAdd_Btn.TabIndex = 10;
            ContenerAdd_Btn.Text = "Dodaj";
            ContenerAdd_Btn.UseVisualStyleBackColor = true;
            ContenerAdd_Btn.Click += ContenerAdd_Btn_Click;
            // 
            // ContenerRemove_Btn
            // 
            ContenerRemove_Btn.Location = new Point(65, 425);
            ContenerRemove_Btn.Name = "ContenerRemove_Btn";
            ContenerRemove_Btn.Size = new Size(94, 29);
            ContenerRemove_Btn.TabIndex = 11;
            ContenerRemove_Btn.Text = "Usuń";
            ContenerRemove_Btn.UseVisualStyleBackColor = true;
            // 
            // ShelfAdd_Btn
            // 
            ShelfAdd_Btn.Location = new Point(309, 358);
            ShelfAdd_Btn.Name = "ShelfAdd_Btn";
            ShelfAdd_Btn.Size = new Size(94, 29);
            ShelfAdd_Btn.TabIndex = 12;
            ShelfAdd_Btn.Text = "Dodaj";
            ShelfAdd_Btn.UseVisualStyleBackColor = true;
            ShelfAdd_Btn.Click += ShelfAdd_Btn_Click;
            // 
            // ShelfRemove_Btn
            // 
            ShelfRemove_Btn.Location = new Point(309, 425);
            ShelfRemove_Btn.Name = "ShelfRemove_Btn";
            ShelfRemove_Btn.Size = new Size(94, 29);
            ShelfRemove_Btn.TabIndex = 13;
            ShelfRemove_Btn.Text = "Usuń";
            ShelfRemove_Btn.UseVisualStyleBackColor = true;
            // 
            // StuffRemove_Btn
            // 
            StuffRemove_Btn.Location = new Point(648, 425);
            StuffRemove_Btn.Name = "StuffRemove_Btn";
            StuffRemove_Btn.Size = new Size(94, 29);
            StuffRemove_Btn.TabIndex = 15;
            StuffRemove_Btn.Text = "Usuń";
            StuffRemove_Btn.UseVisualStyleBackColor = true;
            // 
            // StuffAdd_Btn
            // 
            StuffAdd_Btn.Location = new Point(648, 358);
            StuffAdd_Btn.Name = "StuffAdd_Btn";
            StuffAdd_Btn.Size = new Size(94, 29);
            StuffAdd_Btn.TabIndex = 14;
            StuffAdd_Btn.Text = "Dodaj";
            StuffAdd_Btn.UseVisualStyleBackColor = true;
            StuffAdd_Btn.Click += StuffAdd_Btn_Click;
            // 
            // ContenerMod_Btn
            // 
            ContenerMod_Btn.Location = new Point(65, 393);
            ContenerMod_Btn.Name = "ContenerMod_Btn";
            ContenerMod_Btn.Size = new Size(94, 29);
            ContenerMod_Btn.TabIndex = 16;
            ContenerMod_Btn.Text = "Modyfikuj";
            ContenerMod_Btn.UseVisualStyleBackColor = true;
            // 
            // ShelfsMod_Btn
            // 
            ShelfsMod_Btn.Location = new Point(309, 393);
            ShelfsMod_Btn.Name = "ShelfsMod_Btn";
            ShelfsMod_Btn.Size = new Size(94, 29);
            ShelfsMod_Btn.TabIndex = 17;
            ShelfsMod_Btn.Text = "Modyfikuj";
            ShelfsMod_Btn.UseVisualStyleBackColor = true;
            // 
            // StuffMod_Btn
            // 
            StuffMod_Btn.Location = new Point(648, 393);
            StuffMod_Btn.Name = "StuffMod_Btn";
            StuffMod_Btn.Size = new Size(94, 29);
            StuffMod_Btn.TabIndex = 18;
            StuffMod_Btn.Text = "Modyfikuj";
            StuffMod_Btn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(924, 469);
            Controls.Add(StuffMod_Btn);
            Controls.Add(ShelfsMod_Btn);
            Controls.Add(ContenerMod_Btn);
            Controls.Add(StuffRemove_Btn);
            Controls.Add(StuffAdd_Btn);
            Controls.Add(ShelfRemove_Btn);
            Controls.Add(ShelfAdd_Btn);
            Controls.Add(ContenerRemove_Btn);
            Controls.Add(ContenerAdd_Btn);
            Controls.Add(Stuff_LBx);
            Controls.Add(label4);
            Controls.Add(Shelfs_LBx);
            Controls.Add(label3);
            Controls.Add(Contener_LBx);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ExtBtn);
            Controls.Add(oApkBtn);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "Piwnica";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button oApkBtn;
        private Button ExtBtn;
        private Label label1;
        private Label label2;
        private ListBox Contener_LBx;
        private Label label3;
        private ListBox Shelfs_LBx;
        private Label label4;
        private ListBox Stuff_LBx;
        private Button ContenerAdd_Btn;
        private Button ContenerRemove_Btn;
        private Button ShelfAdd_Btn;
        private Button ShelfRemove_Btn;
        private Button StuffRemove_Btn;
        private Button StuffAdd_Btn;
        private Button ContenerMod_Btn;
        private Button ShelfsMod_Btn;
        private Button StuffMod_Btn;
    }
}
