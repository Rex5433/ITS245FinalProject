namespace ITS245FinalProject
{
    partial class AllergyHistory
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.bAlgHist = new System.Windows.Forms.ComboBox();
            this.tAllergyDescription = new System.Windows.Forms.TextBox();
            this.lAllergyDescription = new System.Windows.Forms.Label();
            this.tAllergyEndDate = new System.Windows.Forms.TextBox();
            this.lAllergyEndDate = new System.Windows.Forms.Label();
            this.tAllergyStartDate = new System.Windows.Forms.TextBox();
            this.lAllergyStartDate = new System.Windows.Forms.Label();
            this.tAllergen = new System.Windows.Forms.TextBox();
            this.lAllergen = new System.Windows.Forms.Label();
            this.tAlgPatientID = new System.Windows.Forms.TextBox();
            this.lAlgPatientID = new System.Windows.Forms.Label();
            this.tAllergyID = new System.Windows.Forms.TextBox();
            this.lAllergyID = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bAlgDelete = new System.Windows.Forms.Button();
            this.bAlgUndo = new System.Windows.Forms.Button();
            this.bAlgSave = new System.Windows.Forms.Button();
            this.bAlgModify = new System.Windows.Forms.Button();
            this.bAlgAdd = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnPatDemos = new System.Windows.Forms.Button();
            this.lNavigation = new System.Windows.Forms.Label();
            this.btnGenHist = new System.Windows.Forms.Button();
            this.BtnAlgHist = new System.Windows.Forms.Button();
            this.btnFamHist = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lSelectedPatient2 = new System.Windows.Forms.Label();
            this.lSelectedPatient = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.bAlgHist);
            this.panel1.Controls.Add(this.tAllergyDescription);
            this.panel1.Controls.Add(this.lAllergyDescription);
            this.panel1.Controls.Add(this.tAllergyEndDate);
            this.panel1.Controls.Add(this.lAllergyEndDate);
            this.panel1.Controls.Add(this.tAllergyStartDate);
            this.panel1.Controls.Add(this.lAllergyStartDate);
            this.panel1.Controls.Add(this.tAllergen);
            this.panel1.Controls.Add(this.lAllergen);
            this.panel1.Controls.Add(this.tAlgPatientID);
            this.panel1.Controls.Add(this.lAlgPatientID);
            this.panel1.Controls.Add(this.tAllergyID);
            this.panel1.Controls.Add(this.lAllergyID);
            this.panel1.Font = new System.Drawing.Font("Nirmala UI", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 906);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 37);
            this.label1.TabIndex = 13;
            this.label1.Text = "Select Allergy Record:";
            // 
            // bAlgHist
            // 
            this.bAlgHist.FormattingEnabled = true;
            this.bAlgHist.Location = new System.Drawing.Point(332, 35);
            this.bAlgHist.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.bAlgHist.Name = "bAlgHist";
            this.bAlgHist.Size = new System.Drawing.Size(288, 38);
            this.bAlgHist.TabIndex = 12;
            this.bAlgHist.SelectedIndexChanged += new System.EventHandler(this.bAlgHist_SelectedIndexChanged);
            // 
            // tAllergyDescription
            // 
            this.tAllergyDescription.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tAllergyDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tAllergyDescription.Location = new System.Drawing.Point(332, 398);
            this.tAllergyDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tAllergyDescription.Name = "tAllergyDescription";
            this.tAllergyDescription.ReadOnly = true;
            this.tAllergyDescription.Size = new System.Drawing.Size(288, 38);
            this.tAllergyDescription.TabIndex = 11;
            this.tAllergyDescription.Visible = false;
            // 
            // lAllergyDescription
            // 
            this.lAllergyDescription.AutoSize = true;
            this.lAllergyDescription.Font = new System.Drawing.Font("Nirmala UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAllergyDescription.Location = new System.Drawing.Point(10, 406);
            this.lAllergyDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lAllergyDescription.Name = "lAllergyDescription";
            this.lAllergyDescription.Size = new System.Drawing.Size(248, 37);
            this.lAllergyDescription.TabIndex = 10;
            this.lAllergyDescription.Text = "Allergy Description:";
            this.lAllergyDescription.Visible = false;
            // 
            // tAllergyEndDate
            // 
            this.tAllergyEndDate.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tAllergyEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tAllergyEndDate.Location = new System.Drawing.Point(332, 340);
            this.tAllergyEndDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tAllergyEndDate.Name = "tAllergyEndDate";
            this.tAllergyEndDate.ReadOnly = true;
            this.tAllergyEndDate.Size = new System.Drawing.Size(288, 38);
            this.tAllergyEndDate.TabIndex = 9;
            this.tAllergyEndDate.Visible = false;
            // 
            // lAllergyEndDate
            // 
            this.lAllergyEndDate.AutoSize = true;
            this.lAllergyEndDate.Font = new System.Drawing.Font("Nirmala UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAllergyEndDate.Location = new System.Drawing.Point(10, 346);
            this.lAllergyEndDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lAllergyEndDate.Name = "lAllergyEndDate";
            this.lAllergyEndDate.Size = new System.Drawing.Size(221, 37);
            this.lAllergyEndDate.TabIndex = 8;
            this.lAllergyEndDate.Text = "Allergy End Date:";
            this.lAllergyEndDate.Visible = false;
            // 
            // tAllergyStartDate
            // 
            this.tAllergyStartDate.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tAllergyStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tAllergyStartDate.Location = new System.Drawing.Point(332, 279);
            this.tAllergyStartDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tAllergyStartDate.Name = "tAllergyStartDate";
            this.tAllergyStartDate.ReadOnly = true;
            this.tAllergyStartDate.Size = new System.Drawing.Size(288, 38);
            this.tAllergyStartDate.TabIndex = 7;
            this.tAllergyStartDate.Visible = false;
            // 
            // lAllergyStartDate
            // 
            this.lAllergyStartDate.AutoSize = true;
            this.lAllergyStartDate.Font = new System.Drawing.Font("Nirmala UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAllergyStartDate.Location = new System.Drawing.Point(10, 287);
            this.lAllergyStartDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lAllergyStartDate.Name = "lAllergyStartDate";
            this.lAllergyStartDate.Size = new System.Drawing.Size(231, 37);
            this.lAllergyStartDate.TabIndex = 6;
            this.lAllergyStartDate.Text = "Allergy Start Date:";
            this.lAllergyStartDate.Visible = false;
            // 
            // tAllergen
            // 
            this.tAllergen.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tAllergen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tAllergen.Location = new System.Drawing.Point(332, 223);
            this.tAllergen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tAllergen.Name = "tAllergen";
            this.tAllergen.ReadOnly = true;
            this.tAllergen.Size = new System.Drawing.Size(288, 38);
            this.tAllergen.TabIndex = 5;
            this.tAllergen.Visible = false;
            // 
            // lAllergen
            // 
            this.lAllergen.AutoSize = true;
            this.lAllergen.Font = new System.Drawing.Font("Nirmala UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAllergen.Location = new System.Drawing.Point(10, 231);
            this.lAllergen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lAllergen.Name = "lAllergen";
            this.lAllergen.Size = new System.Drawing.Size(129, 37);
            this.lAllergen.TabIndex = 4;
            this.lAllergen.Text = "Allergen: ";
            this.lAllergen.Visible = false;
            // 
            // tAlgPatientID
            // 
            this.tAlgPatientID.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tAlgPatientID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tAlgPatientID.Location = new System.Drawing.Point(332, 167);
            this.tAlgPatientID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tAlgPatientID.Name = "tAlgPatientID";
            this.tAlgPatientID.ReadOnly = true;
            this.tAlgPatientID.Size = new System.Drawing.Size(288, 38);
            this.tAlgPatientID.TabIndex = 3;
            this.tAlgPatientID.Visible = false;
            // 
            // lAlgPatientID
            // 
            this.lAlgPatientID.AutoSize = true;
            this.lAlgPatientID.Font = new System.Drawing.Font("Nirmala UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAlgPatientID.Location = new System.Drawing.Point(10, 175);
            this.lAlgPatientID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lAlgPatientID.Name = "lAlgPatientID";
            this.lAlgPatientID.Size = new System.Drawing.Size(138, 37);
            this.lAlgPatientID.TabIndex = 2;
            this.lAlgPatientID.Text = "Patient ID:";
            this.lAlgPatientID.Visible = false;
            // 
            // tAllergyID
            // 
            this.tAllergyID.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tAllergyID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tAllergyID.Location = new System.Drawing.Point(332, 106);
            this.tAllergyID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tAllergyID.Name = "tAllergyID";
            this.tAllergyID.ReadOnly = true;
            this.tAllergyID.Size = new System.Drawing.Size(288, 38);
            this.tAllergyID.TabIndex = 1;
            this.tAllergyID.Visible = false;
            // 
            // lAllergyID
            // 
            this.lAllergyID.AutoSize = true;
            this.lAllergyID.Font = new System.Drawing.Font("Nirmala UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAllergyID.Location = new System.Drawing.Point(10, 112);
            this.lAllergyID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lAllergyID.Name = "lAllergyID";
            this.lAllergyID.Size = new System.Drawing.Size(139, 37);
            this.lAllergyID.TabIndex = 0;
            this.lAllergyID.Text = "Allergy ID:";
            this.lAllergyID.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel3.Controls.Add(this.bAlgDelete);
            this.panel3.Controls.Add(this.bAlgUndo);
            this.panel3.Controls.Add(this.bAlgSave);
            this.panel3.Controls.Add(this.bAlgModify);
            this.panel3.Controls.Add(this.bAlgAdd);
            this.panel3.Location = new System.Drawing.Point(1616, 742);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(344, 175);
            this.panel3.TabIndex = 5;
            // 
            // bAlgDelete
            // 
            this.bAlgDelete.Location = new System.Drawing.Point(232, 96);
            this.bAlgDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bAlgDelete.Name = "bAlgDelete";
            this.bAlgDelete.Size = new System.Drawing.Size(102, 44);
            this.bAlgDelete.TabIndex = 4;
            this.bAlgDelete.Text = "Delete";
            this.bAlgDelete.UseVisualStyleBackColor = true;
            this.bAlgDelete.Click += new System.EventHandler(this.bAlgDelete_Click);
            // 
            // bAlgUndo
            // 
            this.bAlgUndo.Location = new System.Drawing.Point(124, 96);
            this.bAlgUndo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bAlgUndo.Name = "bAlgUndo";
            this.bAlgUndo.Size = new System.Drawing.Size(102, 44);
            this.bAlgUndo.TabIndex = 3;
            this.bAlgUndo.Text = "Undo";
            this.bAlgUndo.UseVisualStyleBackColor = true;
            this.bAlgUndo.Click += new System.EventHandler(this.bAlgUndo_Click);
            // 
            // bAlgSave
            // 
            this.bAlgSave.Location = new System.Drawing.Point(16, 96);
            this.bAlgSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bAlgSave.Name = "bAlgSave";
            this.bAlgSave.Size = new System.Drawing.Size(102, 44);
            this.bAlgSave.TabIndex = 2;
            this.bAlgSave.Text = "Save";
            this.bAlgSave.UseVisualStyleBackColor = true;
            this.bAlgSave.Click += new System.EventHandler(this.bAlgSave_Click);
            // 
            // bAlgModify
            // 
            this.bAlgModify.Location = new System.Drawing.Point(176, 25);
            this.bAlgModify.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bAlgModify.Name = "bAlgModify";
            this.bAlgModify.Size = new System.Drawing.Size(102, 44);
            this.bAlgModify.TabIndex = 1;
            this.bAlgModify.Text = "Modify";
            this.bAlgModify.UseVisualStyleBackColor = true;
            this.bAlgModify.Click += new System.EventHandler(this.bAlgModify_Click);
            // 
            // bAlgAdd
            // 
            this.bAlgAdd.Location = new System.Drawing.Point(68, 25);
            this.bAlgAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bAlgAdd.Name = "bAlgAdd";
            this.bAlgAdd.Size = new System.Drawing.Size(102, 44);
            this.bAlgAdd.TabIndex = 0;
            this.bAlgAdd.Text = "Add";
            this.bAlgAdd.UseVisualStyleBackColor = true;
            this.bAlgAdd.Click += new System.EventHandler(this.bAlgAdd_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel4.Controls.Add(this.btnHome);
            this.panel4.Controls.Add(this.btnPatDemos);
            this.panel4.Controls.Add(this.lNavigation);
            this.panel4.Controls.Add(this.btnGenHist);
            this.panel4.Controls.Add(this.BtnAlgHist);
            this.panel4.Controls.Add(this.btnFamHist);
            this.panel4.Location = new System.Drawing.Point(1762, 12);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 346);
            this.panel4.TabIndex = 7;
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(16, 35);
            this.btnHome.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(172, 44);
            this.btnHome.TabIndex = 1;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnPatDemos
            // 
            this.btnPatDemos.Location = new System.Drawing.Point(16, 85);
            this.btnPatDemos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPatDemos.Name = "btnPatDemos";
            this.btnPatDemos.Size = new System.Drawing.Size(172, 88);
            this.btnPatDemos.TabIndex = 2;
            this.btnPatDemos.Text = "Patient Demographics";
            this.btnPatDemos.UseVisualStyleBackColor = true;
            this.btnPatDemos.Click += new System.EventHandler(this.btnPatDemos_Click);
            // 
            // lNavigation
            // 
            this.lNavigation.AutoSize = true;
            this.lNavigation.Location = new System.Drawing.Point(40, 6);
            this.lNavigation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lNavigation.Name = "lNavigation";
            this.lNavigation.Size = new System.Drawing.Size(114, 25);
            this.lNavigation.TabIndex = 0;
            this.lNavigation.Text = "Navigation";
            // 
            // btnGenHist
            // 
            this.btnGenHist.Location = new System.Drawing.Point(16, 181);
            this.btnGenHist.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGenHist.Name = "btnGenHist";
            this.btnGenHist.Size = new System.Drawing.Size(172, 44);
            this.btnGenHist.TabIndex = 3;
            this.btnGenHist.Text = "General History";
            this.btnGenHist.UseVisualStyleBackColor = true;
            this.btnGenHist.Click += new System.EventHandler(this.btnGenHist_Click);
            // 
            // BtnAlgHist
            // 
            this.BtnAlgHist.Location = new System.Drawing.Point(16, 231);
            this.BtnAlgHist.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnAlgHist.Name = "BtnAlgHist";
            this.BtnAlgHist.Size = new System.Drawing.Size(172, 44);
            this.BtnAlgHist.TabIndex = 4;
            this.BtnAlgHist.Text = "Allergy History";
            this.BtnAlgHist.UseVisualStyleBackColor = true;
            this.BtnAlgHist.Click += new System.EventHandler(this.BtnAlgHist_Click);
            // 
            // btnFamHist
            // 
            this.btnFamHist.Location = new System.Drawing.Point(16, 281);
            this.btnFamHist.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFamHist.Name = "btnFamHist";
            this.btnFamHist.Size = new System.Drawing.Size(172, 44);
            this.btnFamHist.TabIndex = 5;
            this.btnFamHist.Text = "Family History";
            this.btnFamHist.UseVisualStyleBackColor = true;
            this.btnFamHist.Click += new System.EventHandler(this.btnFamHist_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel5.Controls.Add(this.lSelectedPatient2);
            this.panel5.Controls.Add(this.lSelectedPatient);
            this.panel5.Location = new System.Drawing.Point(1398, 12);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(336, 110);
            this.panel5.TabIndex = 8;
            // 
            // lSelectedPatient2
            // 
            this.lSelectedPatient2.AutoSize = true;
            this.lSelectedPatient2.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSelectedPatient2.Location = new System.Drawing.Point(4, 52);
            this.lSelectedPatient2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lSelectedPatient2.Name = "lSelectedPatient2";
            this.lSelectedPatient2.Size = new System.Drawing.Size(309, 30);
            this.lSelectedPatient2.TabIndex = 1;
            this.lSelectedPatient2.Text = "Error: Patient DOB Not Loaded";
            // 
            // lSelectedPatient
            // 
            this.lSelectedPatient.AutoSize = true;
            this.lSelectedPatient.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSelectedPatient.Location = new System.Drawing.Point(4, 6);
            this.lSelectedPatient.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lSelectedPatient.Name = "lSelectedPatient";
            this.lSelectedPatient.Size = new System.Drawing.Size(322, 30);
            this.lSelectedPatient.TabIndex = 0;
            this.lSelectedPatient.Text = "Error: Patient Name Not Loaded";
            // 
            // AllergyHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1974, 929);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(2000, 1000);
            this.Name = "AllergyHistory";
            this.Text = "AllergyHistory";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AllergyHistory_FormClosing);
            this.Load += new System.EventHandler(this.AllergyHistory_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tAllergyDescription;
        private System.Windows.Forms.Label lAllergyDescription;
        private System.Windows.Forms.TextBox tAllergyEndDate;
        private System.Windows.Forms.Label lAllergyEndDate;
        private System.Windows.Forms.TextBox tAllergyStartDate;
        private System.Windows.Forms.Label lAllergyStartDate;
        private System.Windows.Forms.TextBox tAllergen;
        private System.Windows.Forms.Label lAllergen;
        private System.Windows.Forms.TextBox tAlgPatientID;
        private System.Windows.Forms.Label lAlgPatientID;
        private System.Windows.Forms.TextBox tAllergyID;
        private System.Windows.Forms.Label lAllergyID;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button bAlgDelete;
        private System.Windows.Forms.Button bAlgUndo;
        private System.Windows.Forms.Button bAlgSave;
        private System.Windows.Forms.Button bAlgModify;
        private System.Windows.Forms.Button bAlgAdd;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnPatDemos;
        private System.Windows.Forms.Label lNavigation;
        private System.Windows.Forms.Button btnGenHist;
        private System.Windows.Forms.Button BtnAlgHist;
        private System.Windows.Forms.Button btnFamHist;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox bAlgHist;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lSelectedPatient2;
        private System.Windows.Forms.Label lSelectedPatient;
    }
}