namespace ADVBuilder
{
    partial class AdventureGame
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
            this.txtRoomDescription = new System.Windows.Forms.TextBox();
            this.btnNN = new System.Windows.Forms.Button();
            this.btnNE = new System.Windows.Forms.Button();
            this.btnEE = new System.Windows.Forms.Button();
            this.btnSE = new System.Windows.Forms.Button();
            this.btnSS = new System.Windows.Forms.Button();
            this.btnSO = new System.Windows.Forms.Button();
            this.btnOO = new System.Windows.Forms.Button();
            this.btnNO = new System.Windows.Forms.Button();
            this.btnAA = new System.Windows.Forms.Button();
            this.btnBB = new System.Windows.Forms.Button();
            this.lsbObjects = new System.Windows.Forms.ListBox();
            this.lstActions = new System.Windows.Forms.ListBox();
            this.lblAction = new System.Windows.Forms.Label();
            this.lblObject1 = new System.Windows.Forms.Label();
            this.lblObject2 = new System.Windows.Forms.Label();
            this.pcbMap = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbMap)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRoomDescription
            // 
            this.txtRoomDescription.Location = new System.Drawing.Point(12, 12);
            this.txtRoomDescription.Multiline = true;
            this.txtRoomDescription.Name = "txtRoomDescription";
            this.txtRoomDescription.Size = new System.Drawing.Size(531, 225);
            this.txtRoomDescription.TabIndex = 0;
            // 
            // btnNN
            // 
            this.btnNN.Location = new System.Drawing.Point(53, 243);
            this.btnNN.Name = "btnNN";
            this.btnNN.Size = new System.Drawing.Size(35, 35);
            this.btnNN.TabIndex = 2;
            this.btnNN.Text = "NN";
            this.btnNN.UseVisualStyleBackColor = true;
            this.btnNN.Click += new System.EventHandler(this.btnDIR_Click);
            // 
            // btnNE
            // 
            this.btnNE.Location = new System.Drawing.Point(94, 243);
            this.btnNE.Name = "btnNE";
            this.btnNE.Size = new System.Drawing.Size(35, 35);
            this.btnNE.TabIndex = 3;
            this.btnNE.Text = "NE";
            this.btnNE.UseVisualStyleBackColor = true;
            this.btnNE.Click += new System.EventHandler(this.btnDIR_Click);
            // 
            // btnEE
            // 
            this.btnEE.Location = new System.Drawing.Point(94, 284);
            this.btnEE.Name = "btnEE";
            this.btnEE.Size = new System.Drawing.Size(35, 35);
            this.btnEE.TabIndex = 4;
            this.btnEE.Text = "EE";
            this.btnEE.UseVisualStyleBackColor = true;
            this.btnEE.Click += new System.EventHandler(this.btnDIR_Click);
            // 
            // btnSE
            // 
            this.btnSE.Location = new System.Drawing.Point(94, 325);
            this.btnSE.Name = "btnSE";
            this.btnSE.Size = new System.Drawing.Size(35, 35);
            this.btnSE.TabIndex = 5;
            this.btnSE.Text = "SE";
            this.btnSE.UseVisualStyleBackColor = true;
            this.btnSE.Click += new System.EventHandler(this.btnDIR_Click);
            // 
            // btnSS
            // 
            this.btnSS.Location = new System.Drawing.Point(53, 325);
            this.btnSS.Name = "btnSS";
            this.btnSS.Size = new System.Drawing.Size(35, 35);
            this.btnSS.TabIndex = 6;
            this.btnSS.Text = "SS";
            this.btnSS.UseVisualStyleBackColor = true;
            this.btnSS.Click += new System.EventHandler(this.btnDIR_Click);
            // 
            // btnSO
            // 
            this.btnSO.Location = new System.Drawing.Point(12, 325);
            this.btnSO.Name = "btnSO";
            this.btnSO.Size = new System.Drawing.Size(35, 35);
            this.btnSO.TabIndex = 7;
            this.btnSO.Text = "SO";
            this.btnSO.UseVisualStyleBackColor = true;
            this.btnSO.Click += new System.EventHandler(this.btnDIR_Click);
            // 
            // btnOO
            // 
            this.btnOO.Location = new System.Drawing.Point(12, 284);
            this.btnOO.Name = "btnOO";
            this.btnOO.Size = new System.Drawing.Size(35, 35);
            this.btnOO.TabIndex = 8;
            this.btnOO.Text = "OO";
            this.btnOO.UseVisualStyleBackColor = true;
            this.btnOO.Click += new System.EventHandler(this.btnDIR_Click);
            // 
            // btnNO
            // 
            this.btnNO.Location = new System.Drawing.Point(12, 243);
            this.btnNO.Name = "btnNO";
            this.btnNO.Size = new System.Drawing.Size(35, 35);
            this.btnNO.TabIndex = 9;
            this.btnNO.Text = "NO";
            this.btnNO.UseVisualStyleBackColor = true;
            this.btnNO.Click += new System.EventHandler(this.btnDIR_Click);
            // 
            // btnAA
            // 
            this.btnAA.Location = new System.Drawing.Point(135, 242);
            this.btnAA.Name = "btnAA";
            this.btnAA.Size = new System.Drawing.Size(35, 35);
            this.btnAA.TabIndex = 10;
            this.btnAA.Text = "AA";
            this.btnAA.UseVisualStyleBackColor = true;
            this.btnAA.Click += new System.EventHandler(this.btnDIR_Click);
            // 
            // btnBB
            // 
            this.btnBB.Location = new System.Drawing.Point(135, 325);
            this.btnBB.Name = "btnBB";
            this.btnBB.Size = new System.Drawing.Size(35, 35);
            this.btnBB.TabIndex = 11;
            this.btnBB.Text = "BB";
            this.btnBB.UseVisualStyleBackColor = true;
            this.btnBB.Click += new System.EventHandler(this.btnDIR_Click);
            // 
            // lsbObjects
            // 
            this.lsbObjects.FormattingEnabled = true;
            this.lsbObjects.Location = new System.Drawing.Point(549, 12);
            this.lsbObjects.Name = "lsbObjects";
            this.lsbObjects.Size = new System.Drawing.Size(312, 225);
            this.lsbObjects.TabIndex = 12;
            this.lsbObjects.SelectedIndexChanged += new System.EventHandler(this.lsbObjects_SelectedIndexChanged);
            // 
            // lstActions
            // 
            this.lstActions.FormattingEnabled = true;
            this.lstActions.Location = new System.Drawing.Point(176, 243);
            this.lstActions.Name = "lstActions";
            this.lstActions.Size = new System.Drawing.Size(367, 121);
            this.lstActions.TabIndex = 13;
            this.lstActions.SelectedIndexChanged += new System.EventHandler(this.lstActions_SelectedIndexChanged);
            // 
            // lblAction
            // 
            this.lblAction.Location = new System.Drawing.Point(549, 341);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(100, 23);
            this.lblAction.TabIndex = 14;
            this.lblAction.Text = "label1";
            // 
            // lblObject1
            // 
            this.lblObject1.Location = new System.Drawing.Point(655, 341);
            this.lblObject1.Name = "lblObject1";
            this.lblObject1.Size = new System.Drawing.Size(100, 23);
            this.lblObject1.TabIndex = 15;
            this.lblObject1.Text = "label2";
            // 
            // lblObject2
            // 
            this.lblObject2.Location = new System.Drawing.Point(761, 341);
            this.lblObject2.Name = "lblObject2";
            this.lblObject2.Size = new System.Drawing.Size(100, 23);
            this.lblObject2.TabIndex = 16;
            this.lblObject2.Text = "label2";
            // 
            // pcbMap
            // 
            this.pcbMap.Image = global::ADVBuilder.Properties.Resources.Withe;
            this.pcbMap.Location = new System.Drawing.Point(868, 13);
            this.pcbMap.Name = "pcbMap";
            this.pcbMap.Size = new System.Drawing.Size(471, 351);
            this.pcbMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcbMap.TabIndex = 17;
            this.pcbMap.TabStop = false;
            this.pcbMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pcbMap_MouseDown);
            this.pcbMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcbMap_MouseMove);
            this.pcbMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pcbMap_MouseUp);
            // 
            // AdventureGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 723);
            this.Controls.Add(this.pcbMap);
            this.Controls.Add(this.lblObject2);
            this.Controls.Add(this.lblObject1);
            this.Controls.Add(this.lblAction);
            this.Controls.Add(this.lstActions);
            this.Controls.Add(this.lsbObjects);
            this.Controls.Add(this.btnBB);
            this.Controls.Add(this.btnAA);
            this.Controls.Add(this.btnNO);
            this.Controls.Add(this.btnOO);
            this.Controls.Add(this.btnSO);
            this.Controls.Add(this.btnSS);
            this.Controls.Add(this.btnSE);
            this.Controls.Add(this.btnEE);
            this.Controls.Add(this.btnNE);
            this.Controls.Add(this.btnNN);
            this.Controls.Add(this.txtRoomDescription);
            this.Name = "AdventureGame";
            this.Text = "AdventureGame";
            this.Load += new System.EventHandler(this.AdventureGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRoomDescription;
        private System.Windows.Forms.Button btnNN;
        private System.Windows.Forms.Button btnNE;
        private System.Windows.Forms.Button btnEE;
        private System.Windows.Forms.Button btnSE;
        private System.Windows.Forms.Button btnSS;
        private System.Windows.Forms.Button btnSO;
        private System.Windows.Forms.Button btnOO;
        private System.Windows.Forms.Button btnNO;
        private System.Windows.Forms.Button btnAA;
        private System.Windows.Forms.Button btnBB;
        private System.Windows.Forms.ListBox lsbObjects;
        private System.Windows.Forms.ListBox lstActions;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.Label lblObject1;
        private System.Windows.Forms.Label lblObject2;
        private System.Windows.Forms.PictureBox pcbMap;
    }
}