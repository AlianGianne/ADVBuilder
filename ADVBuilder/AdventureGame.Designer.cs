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
            this.pcbMap = new System.Windows.Forms.PictureBox();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.tltMain = new System.Windows.Forms.ToolTip(this.components);
            this.pnlObjects = new System.Windows.Forms.Panel();
            this.pnlInventario = new System.Windows.Forms.Panel();
            this.pnlPerson = new System.Windows.Forms.Panel();
            this.pnlResult = new System.Windows.Forms.Panel();
            this.txtResult = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbMap)).BeginInit();
            this.pnlResult.SuspendLayout();
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
            this.btnNN.Location = new System.Drawing.Point(371, 476);
            this.btnNN.Name = "btnNN";
            this.btnNN.Size = new System.Drawing.Size(35, 35);
            this.btnNN.TabIndex = 2;
            this.btnNN.Text = "NN";
            this.btnNN.UseVisualStyleBackColor = true;
            this.btnNN.Click += new System.EventHandler(this.btnDIR_Click);
            // 
            // btnNE
            // 
            this.btnNE.Location = new System.Drawing.Point(412, 476);
            this.btnNE.Name = "btnNE";
            this.btnNE.Size = new System.Drawing.Size(35, 35);
            this.btnNE.TabIndex = 3;
            this.btnNE.Text = "NE";
            this.btnNE.UseVisualStyleBackColor = true;
            this.btnNE.Click += new System.EventHandler(this.btnDIR_Click);
            // 
            // btnEE
            // 
            this.btnEE.Location = new System.Drawing.Point(412, 517);
            this.btnEE.Name = "btnEE";
            this.btnEE.Size = new System.Drawing.Size(35, 35);
            this.btnEE.TabIndex = 4;
            this.btnEE.Text = "EE";
            this.btnEE.UseVisualStyleBackColor = true;
            this.btnEE.Click += new System.EventHandler(this.btnDIR_Click);
            // 
            // btnSE
            // 
            this.btnSE.Location = new System.Drawing.Point(412, 558);
            this.btnSE.Name = "btnSE";
            this.btnSE.Size = new System.Drawing.Size(35, 35);
            this.btnSE.TabIndex = 5;
            this.btnSE.Text = "SE";
            this.btnSE.UseVisualStyleBackColor = true;
            this.btnSE.Click += new System.EventHandler(this.btnDIR_Click);
            // 
            // btnSS
            // 
            this.btnSS.Location = new System.Drawing.Point(371, 558);
            this.btnSS.Name = "btnSS";
            this.btnSS.Size = new System.Drawing.Size(35, 35);
            this.btnSS.TabIndex = 6;
            this.btnSS.Text = "SS";
            this.btnSS.UseVisualStyleBackColor = true;
            this.btnSS.Click += new System.EventHandler(this.btnDIR_Click);
            // 
            // btnSO
            // 
            this.btnSO.Location = new System.Drawing.Point(330, 558);
            this.btnSO.Name = "btnSO";
            this.btnSO.Size = new System.Drawing.Size(35, 35);
            this.btnSO.TabIndex = 7;
            this.btnSO.Text = "SO";
            this.btnSO.UseVisualStyleBackColor = true;
            this.btnSO.Click += new System.EventHandler(this.btnDIR_Click);
            // 
            // btnOO
            // 
            this.btnOO.Location = new System.Drawing.Point(330, 517);
            this.btnOO.Name = "btnOO";
            this.btnOO.Size = new System.Drawing.Size(35, 35);
            this.btnOO.TabIndex = 8;
            this.btnOO.Text = "OO";
            this.btnOO.UseVisualStyleBackColor = true;
            this.btnOO.Click += new System.EventHandler(this.btnDIR_Click);
            // 
            // btnNO
            // 
            this.btnNO.Location = new System.Drawing.Point(330, 476);
            this.btnNO.Name = "btnNO";
            this.btnNO.Size = new System.Drawing.Size(35, 35);
            this.btnNO.TabIndex = 9;
            this.btnNO.Text = "NO";
            this.btnNO.UseVisualStyleBackColor = true;
            this.btnNO.Click += new System.EventHandler(this.btnDIR_Click);
            // 
            // btnAA
            // 
            this.btnAA.Location = new System.Drawing.Point(453, 475);
            this.btnAA.Name = "btnAA";
            this.btnAA.Size = new System.Drawing.Size(35, 35);
            this.btnAA.TabIndex = 10;
            this.btnAA.Text = "AA";
            this.btnAA.UseVisualStyleBackColor = true;
            this.btnAA.Click += new System.EventHandler(this.btnDIR_Click);
            // 
            // btnBB
            // 
            this.btnBB.Location = new System.Drawing.Point(453, 558);
            this.btnBB.Name = "btnBB";
            this.btnBB.Size = new System.Drawing.Size(35, 35);
            this.btnBB.TabIndex = 11;
            this.btnBB.Text = "BB";
            this.btnBB.UseVisualStyleBackColor = true;
            this.btnBB.Click += new System.EventHandler(this.btnDIR_Click);
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
            // pnlActions
            // 
            this.pnlActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlActions.Location = new System.Drawing.Point(12, 476);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(312, 116);
            this.pnlActions.TabIndex = 19;
            // 
            // pnlObjects
            // 
            this.pnlObjects.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlObjects.Location = new System.Drawing.Point(12, 13);
            this.pnlObjects.Name = "pnlObjects";
            this.pnlObjects.Size = new System.Drawing.Size(310, 150);
            this.pnlObjects.TabIndex = 20;
            // 
            // pnlInventario
            // 
            this.pnlInventario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInventario.Location = new System.Drawing.Point(12, 165);
            this.pnlInventario.Name = "pnlInventario";
            this.pnlInventario.Size = new System.Drawing.Size(310, 150);
            this.pnlInventario.TabIndex = 21;
            // 
            // pnlPerson
            // 
            this.pnlPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPerson.Location = new System.Drawing.Point(12, 318);
            this.pnlPerson.Name = "pnlPerson";
            this.pnlPerson.Size = new System.Drawing.Size(310, 150);
            this.pnlPerson.TabIndex = 22;
            // 
            // pnlResult
            // 
            this.pnlResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlResult.Controls.Add(this.txtResult);
            this.pnlResult.Location = new System.Drawing.Point(494, 476);
            this.pnlResult.Name = "pnlResult";
            this.pnlResult.Size = new System.Drawing.Size(340, 117);
            this.pnlResult.TabIndex = 23;
            // 
            // txtResult
            // 
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Enabled = false;
            this.txtResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Location = new System.Drawing.Point(0, 0);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(338, 115);
            this.txtResult.TabIndex = 0;
            // 
            // AdventureGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 664);
            this.Controls.Add(this.pnlResult);
            this.Controls.Add(this.pnlPerson);
            this.Controls.Add(this.pnlInventario);
            this.Controls.Add(this.pnlObjects);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pcbMap);
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
            this.pnlResult.ResumeLayout(false);
            this.pnlResult.PerformLayout();
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
        private System.Windows.Forms.PictureBox pcbMap;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.ToolTip tltMain;
        private System.Windows.Forms.Panel pnlObjects;
        private System.Windows.Forms.Panel pnlInventario;
        private System.Windows.Forms.Panel pnlPerson;
        private System.Windows.Forms.Panel pnlResult;
        private System.Windows.Forms.TextBox txtResult;
    }
}