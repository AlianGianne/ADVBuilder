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
            this.components = new System.ComponentModel.Container();
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
            this.lblAction = new System.Windows.Forms.Label();
            this.lblObject1 = new System.Windows.Forms.Label();
            this.lblObject2 = new System.Windows.Forms.Label();
            this.pcbMap = new System.Windows.Forms.PictureBox();
            this.lstPersons = new System.Windows.Forms.ListBox();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.tltMain = new System.Windows.Forms.ToolTip(this.components);
            this.lstInventario = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbMap)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRoomDescription
            // 
            this.txtRoomDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRoomDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoomDescription.Location = new System.Drawing.Point(330, 13);
            this.txtRoomDescription.Multiline = true;
            this.txtRoomDescription.Name = "txtRoomDescription";
            this.txtRoomDescription.Size = new System.Drawing.Size(504, 456);
            this.txtRoomDescription.TabIndex = 0;
            // 
            // btnNN
            // 
            this.btnNN.Location = new System.Drawing.Point(547, 475);
            this.btnNN.Name = "btnNN";
            this.btnNN.Size = new System.Drawing.Size(35, 35);
            this.btnNN.TabIndex = 2;
            this.btnNN.Text = "NN";
            this.btnNN.UseVisualStyleBackColor = true;
            this.btnNN.Click += new System.EventHandler(this.btnDIR_Click);
            // 
            // btnNE
            // 
            this.btnNE.Location = new System.Drawing.Point(588, 475);
            this.btnNE.Name = "btnNE";
            this.btnNE.Size = new System.Drawing.Size(35, 35);
            this.btnNE.TabIndex = 3;
            this.btnNE.Text = "NE";
            this.btnNE.UseVisualStyleBackColor = true;
            this.btnNE.Click += new System.EventHandler(this.btnDIR_Click);
            // 
            // btnEE
            // 
            this.btnEE.Location = new System.Drawing.Point(588, 516);
            this.btnEE.Name = "btnEE";
            this.btnEE.Size = new System.Drawing.Size(35, 35);
            this.btnEE.TabIndex = 4;
            this.btnEE.Text = "EE";
            this.btnEE.UseVisualStyleBackColor = true;
            this.btnEE.Click += new System.EventHandler(this.btnDIR_Click);
            // 
            // btnSE
            // 
            this.btnSE.Location = new System.Drawing.Point(588, 557);
            this.btnSE.Name = "btnSE";
            this.btnSE.Size = new System.Drawing.Size(35, 35);
            this.btnSE.TabIndex = 5;
            this.btnSE.Text = "SE";
            this.btnSE.UseVisualStyleBackColor = true;
            this.btnSE.Click += new System.EventHandler(this.btnDIR_Click);
            // 
            // btnSS
            // 
            this.btnSS.Location = new System.Drawing.Point(547, 557);
            this.btnSS.Name = "btnSS";
            this.btnSS.Size = new System.Drawing.Size(35, 35);
            this.btnSS.TabIndex = 6;
            this.btnSS.Text = "SS";
            this.btnSS.UseVisualStyleBackColor = true;
            this.btnSS.Click += new System.EventHandler(this.btnDIR_Click);
            // 
            // btnSO
            // 
            this.btnSO.Location = new System.Drawing.Point(506, 557);
            this.btnSO.Name = "btnSO";
            this.btnSO.Size = new System.Drawing.Size(35, 35);
            this.btnSO.TabIndex = 7;
            this.btnSO.Text = "SO";
            this.btnSO.UseVisualStyleBackColor = true;
            this.btnSO.Click += new System.EventHandler(this.btnDIR_Click);
            // 
            // btnOO
            // 
            this.btnOO.Location = new System.Drawing.Point(506, 516);
            this.btnOO.Name = "btnOO";
            this.btnOO.Size = new System.Drawing.Size(35, 35);
            this.btnOO.TabIndex = 8;
            this.btnOO.Text = "OO";
            this.btnOO.UseVisualStyleBackColor = true;
            this.btnOO.Click += new System.EventHandler(this.btnDIR_Click);
            // 
            // btnNO
            // 
            this.btnNO.Location = new System.Drawing.Point(506, 475);
            this.btnNO.Name = "btnNO";
            this.btnNO.Size = new System.Drawing.Size(35, 35);
            this.btnNO.TabIndex = 9;
            this.btnNO.Text = "NO";
            this.btnNO.UseVisualStyleBackColor = true;
            this.btnNO.Click += new System.EventHandler(this.btnDIR_Click);
            // 
            // btnAA
            // 
            this.btnAA.Location = new System.Drawing.Point(629, 474);
            this.btnAA.Name = "btnAA";
            this.btnAA.Size = new System.Drawing.Size(35, 35);
            this.btnAA.TabIndex = 10;
            this.btnAA.Text = "AA";
            this.btnAA.UseVisualStyleBackColor = true;
            this.btnAA.Click += new System.EventHandler(this.btnDIR_Click);
            // 
            // btnBB
            // 
            this.btnBB.Location = new System.Drawing.Point(629, 557);
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
            this.lsbObjects.Location = new System.Drawing.Point(12, 13);
            this.lsbObjects.Name = "lsbObjects";
            this.lsbObjects.Size = new System.Drawing.Size(312, 108);
            this.lsbObjects.TabIndex = 12;
            this.lsbObjects.SelectedIndexChanged += new System.EventHandler(this.lsbObjects_SelectedIndexChanged);
            // 
            // lblAction
            // 
            this.lblAction.Location = new System.Drawing.Point(1018, 474);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(100, 23);
            this.lblAction.TabIndex = 14;
            this.lblAction.Text = "label1";
            // 
            // lblObject1
            // 
            this.lblObject1.Location = new System.Drawing.Point(1124, 474);
            this.lblObject1.Name = "lblObject1";
            this.lblObject1.Size = new System.Drawing.Size(100, 23);
            this.lblObject1.TabIndex = 15;
            this.lblObject1.Text = "label2";
            // 
            // lblObject2
            // 
            this.lblObject2.Location = new System.Drawing.Point(1230, 474);
            this.lblObject2.Name = "lblObject2";
            this.lblObject2.Size = new System.Drawing.Size(100, 23);
            this.lblObject2.TabIndex = 16;
            this.lblObject2.Text = "label2";
            // 
            // pcbMap
            // 
            this.pcbMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pcbMap.Image = global::ADVBuilder.Properties.Resources.Withe;
            this.pcbMap.Location = new System.Drawing.Point(840, 12);
            this.pcbMap.Name = "pcbMap";
            this.pcbMap.Size = new System.Drawing.Size(515, 457);
            this.pcbMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcbMap.TabIndex = 17;
            this.pcbMap.TabStop = false;
            this.pcbMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pcbMap_MouseDown);
            this.pcbMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcbMap_MouseMove);
            this.pcbMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pcbMap_MouseUp);
            // 
            // lstPersons
            // 
            this.lstPersons.FormattingEnabled = true;
            this.lstPersons.Location = new System.Drawing.Point(12, 244);
            this.lstPersons.Name = "lstPersons";
            this.lstPersons.Size = new System.Drawing.Size(312, 225);
            this.lstPersons.TabIndex = 18;
            // 
            // pnlActions
            // 
            this.pnlActions.Location = new System.Drawing.Point(13, 476);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(311, 116);
            this.pnlActions.TabIndex = 19;
            // 
            // lstInventario
            // 
            this.lstInventario.FormattingEnabled = true;
            this.lstInventario.Location = new System.Drawing.Point(12, 127);
            this.lstInventario.Name = "lstInventario";
            this.lstInventario.Size = new System.Drawing.Size(312, 108);
            this.lstInventario.TabIndex = 20;
            this.lstInventario.SelectedIndexChanged += new System.EventHandler(this.lstInventario_SelectedIndexChanged);
            // 
            // AdventureGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 664);
            this.Controls.Add(this.lstInventario);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.lstPersons);
            this.Controls.Add(this.pcbMap);
            this.Controls.Add(this.lblObject2);
            this.Controls.Add(this.lblObject1);
            this.Controls.Add(this.lblAction);
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
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.Label lblObject1;
        private System.Windows.Forms.Label lblObject2;
        private System.Windows.Forms.PictureBox pcbMap;
        private System.Windows.Forms.ListBox lstPersons;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.ToolTip tltMain;
        private System.Windows.Forms.ListBox lstInventario;
    }
}