namespace ADVBuilder
{
    partial class Main
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAddAdv = new System.Windows.Forms.Button();
            this.pnlAdvList = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.txtShortDescription = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtSubTitle = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.advId = new System.Windows.Forms.TextBox();
            this.dgvAdvList = new System.Windows.Forms.DataGridView();
            this.pnlRoom = new System.Windows.Forms.Panel();
            this.cmbNN = new System.Windows.Forms.ComboBox();
            this.cmbBB = new System.Windows.Forms.ComboBox();
            this.cmbNE = new System.Windows.Forms.ComboBox();
            this.rmnShortDescription = new System.Windows.Forms.TextBox();
            this.cmbAA = new System.Windows.Forms.ComboBox();
            this.rmnDescription = new System.Windows.Forms.TextBox();
            this.cmbEE = new System.Windows.Forms.ComboBox();
            this.rmnTitle = new System.Windows.Forms.TextBox();
            this.cmbNO = new System.Windows.Forms.ComboBox();
            this.rmnIdAdv = new System.Windows.Forms.TextBox();
            this.cmbSE = new System.Windows.Forms.ComboBox();
            this.btnNewRoom = new System.Windows.Forms.Button();
            this.cmbOO = new System.Windows.Forms.ComboBox();
            this.rmnId = new System.Windows.Forms.TextBox();
            this.cmbSS = new System.Windows.Forms.ComboBox();
            this.dgvDirections = new System.Windows.Forms.DataGridView();
            this.cmbSO = new System.Windows.Forms.ComboBox();
            this.btnAddRoom = new System.Windows.Forms.Button();
            this.dgvRooms = new System.Windows.Forms.DataGridView();
            this.pnlObjects = new System.Windows.Forms.Panel();
            this.objIdRoom = new System.Windows.Forms.TextBox();
            this.btnNewObj = new System.Windows.Forms.Button();
            this.objId = new System.Windows.Forms.TextBox();
            this.btnAddObject = new System.Windows.Forms.Button();
            this.dgvObjects = new System.Windows.Forms.DataGridView();
            this.objShortDescription = new System.Windows.Forms.TextBox();
            this.objDescription = new System.Windows.Forms.TextBox();
            this.objTitle = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.pnlAdvList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdvList)).BeginInit();
            this.pnlRoom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDirections)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).BeginInit();
            this.pnlObjects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObjects)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddAdv
            // 
            this.btnAddAdv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAdv.Location = new System.Drawing.Point(3, 220);
            this.btnAddAdv.Name = "btnAddAdv";
            this.btnAddAdv.Size = new System.Drawing.Size(204, 50);
            this.btnAddAdv.TabIndex = 0;
            this.btnAddAdv.Text = "Aggiungi ADV";
            this.btnAddAdv.UseVisualStyleBackColor = true;
            this.btnAddAdv.Click += new System.EventHandler(this.btnAddAdv_Click);
            // 
            // pnlAdvList
            // 
            this.pnlAdvList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlAdvList.Controls.Add(this.btnPlay);
            this.pnlAdvList.Controls.Add(this.btnDelete);
            this.pnlAdvList.Controls.Add(this.btnNew);
            this.pnlAdvList.Controls.Add(this.txtAuthor);
            this.pnlAdvList.Controls.Add(this.txtVersion);
            this.pnlAdvList.Controls.Add(this.txtShortDescription);
            this.pnlAdvList.Controls.Add(this.txtDescription);
            this.pnlAdvList.Controls.Add(this.txtSubTitle);
            this.pnlAdvList.Controls.Add(this.txtTitle);
            this.pnlAdvList.Controls.Add(this.advId);
            this.pnlAdvList.Controls.Add(this.dgvAdvList);
            this.pnlAdvList.Controls.Add(this.btnAddAdv);
            this.pnlAdvList.Location = new System.Drawing.Point(12, 12);
            this.pnlAdvList.Name = "pnlAdvList";
            this.pnlAdvList.Size = new System.Drawing.Size(518, 700);
            this.pnlAdvList.TabIndex = 1;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(120, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(27, 20);
            this.btnNew.TabIndex = 8;
            this.btnNew.Text = "...";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtAuthor
            // 
            this.txtAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuthor.Location = new System.Drawing.Point(303, 194);
            this.txtAuthor.Multiline = true;
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(212, 20);
            this.txtAuthor.TabIndex = 7;
            // 
            // txtVersion
            // 
            this.txtVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVersion.Location = new System.Drawing.Point(76, 194);
            this.txtVersion.Multiline = true;
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(212, 20);
            this.txtVersion.TabIndex = 6;
            // 
            // txtShortDescription
            // 
            this.txtShortDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShortDescription.Location = new System.Drawing.Point(76, 140);
            this.txtShortDescription.Multiline = true;
            this.txtShortDescription.Name = "txtShortDescription";
            this.txtShortDescription.Size = new System.Drawing.Size(439, 48);
            this.txtShortDescription.TabIndex = 5;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(76, 56);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(439, 78);
            this.txtDescription.TabIndex = 4;
            // 
            // txtSubTitle
            // 
            this.txtSubTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubTitle.Location = new System.Drawing.Point(303, 30);
            this.txtSubTitle.Multiline = true;
            this.txtSubTitle.Name = "txtSubTitle";
            this.txtSubTitle.Size = new System.Drawing.Size(212, 20);
            this.txtSubTitle.TabIndex = 3;
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(76, 30);
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(212, 20);
            this.txtTitle.TabIndex = 2;
            // 
            // advId
            // 
            this.advId.Enabled = false;
            this.advId.Location = new System.Drawing.Point(76, 3);
            this.advId.Multiline = true;
            this.advId.Name = "advId";
            this.advId.Size = new System.Drawing.Size(38, 20);
            this.advId.TabIndex = 1;
            this.advId.Tag = "Integer";
            // 
            // dgvAdvList
            // 
            this.dgvAdvList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAdvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdvList.Location = new System.Drawing.Point(3, 276);
            this.dgvAdvList.Name = "dgvAdvList";
            this.dgvAdvList.Size = new System.Drawing.Size(512, 421);
            this.dgvAdvList.TabIndex = 0;
            this.dgvAdvList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAdvList_RowEnter);
            // 
            // pnlRoom
            // 
            this.pnlRoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlRoom.Controls.Add(this.cmbNN);
            this.pnlRoom.Controls.Add(this.cmbBB);
            this.pnlRoom.Controls.Add(this.cmbNE);
            this.pnlRoom.Controls.Add(this.rmnShortDescription);
            this.pnlRoom.Controls.Add(this.cmbAA);
            this.pnlRoom.Controls.Add(this.rmnDescription);
            this.pnlRoom.Controls.Add(this.cmbEE);
            this.pnlRoom.Controls.Add(this.rmnTitle);
            this.pnlRoom.Controls.Add(this.cmbNO);
            this.pnlRoom.Controls.Add(this.rmnIdAdv);
            this.pnlRoom.Controls.Add(this.cmbSE);
            this.pnlRoom.Controls.Add(this.btnNewRoom);
            this.pnlRoom.Controls.Add(this.cmbOO);
            this.pnlRoom.Controls.Add(this.rmnId);
            this.pnlRoom.Controls.Add(this.cmbSS);
            this.pnlRoom.Controls.Add(this.dgvDirections);
            this.pnlRoom.Controls.Add(this.cmbSO);
            this.pnlRoom.Controls.Add(this.btnAddRoom);
            this.pnlRoom.Controls.Add(this.dgvRooms);
            this.pnlRoom.Location = new System.Drawing.Point(536, 12);
            this.pnlRoom.Name = "pnlRoom";
            this.pnlRoom.Size = new System.Drawing.Size(524, 700);
            this.pnlRoom.TabIndex = 2;
            // 
            // cmbNN
            // 
            this.cmbNN.FormattingEnabled = true;
            this.cmbNN.Location = new System.Drawing.Point(50, 194);
            this.cmbNN.Name = "cmbNN";
            this.cmbNN.Size = new System.Drawing.Size(89, 21);
            this.cmbNN.TabIndex = 15;
            // 
            // cmbBB
            // 
            this.cmbBB.FormattingEnabled = true;
            this.cmbBB.Location = new System.Drawing.Point(430, 221);
            this.cmbBB.Name = "cmbBB";
            this.cmbBB.Size = new System.Drawing.Size(89, 21);
            this.cmbBB.TabIndex = 24;
            // 
            // cmbNE
            // 
            this.cmbNE.FormattingEnabled = true;
            this.cmbNE.Location = new System.Drawing.Point(145, 194);
            this.cmbNE.Name = "cmbNE";
            this.cmbNE.Size = new System.Drawing.Size(89, 21);
            this.cmbNE.TabIndex = 16;
            // 
            // rmnShortDescription
            // 
            this.rmnShortDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rmnShortDescription.Location = new System.Drawing.Point(80, 140);
            this.rmnShortDescription.Multiline = true;
            this.rmnShortDescription.Name = "rmnShortDescription";
            this.rmnShortDescription.Size = new System.Drawing.Size(439, 48);
            this.rmnShortDescription.TabIndex = 14;
            // 
            // cmbAA
            // 
            this.cmbAA.FormattingEnabled = true;
            this.cmbAA.Location = new System.Drawing.Point(335, 221);
            this.cmbAA.Name = "cmbAA";
            this.cmbAA.Size = new System.Drawing.Size(89, 21);
            this.cmbAA.TabIndex = 23;
            // 
            // rmnDescription
            // 
            this.rmnDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rmnDescription.Location = new System.Drawing.Point(80, 56);
            this.rmnDescription.Multiline = true;
            this.rmnDescription.Name = "rmnDescription";
            this.rmnDescription.Size = new System.Drawing.Size(439, 78);
            this.rmnDescription.TabIndex = 13;
            // 
            // cmbEE
            // 
            this.cmbEE.FormattingEnabled = true;
            this.cmbEE.Location = new System.Drawing.Point(240, 194);
            this.cmbEE.Name = "cmbEE";
            this.cmbEE.Size = new System.Drawing.Size(89, 21);
            this.cmbEE.TabIndex = 17;
            // 
            // rmnTitle
            // 
            this.rmnTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rmnTitle.Location = new System.Drawing.Point(80, 30);
            this.rmnTitle.Multiline = true;
            this.rmnTitle.Name = "rmnTitle";
            this.rmnTitle.Size = new System.Drawing.Size(212, 20);
            this.rmnTitle.TabIndex = 12;
            // 
            // cmbNO
            // 
            this.cmbNO.FormattingEnabled = true;
            this.cmbNO.Location = new System.Drawing.Point(240, 221);
            this.cmbNO.Name = "cmbNO";
            this.cmbNO.Size = new System.Drawing.Size(89, 21);
            this.cmbNO.TabIndex = 22;
            // 
            // rmnIdAdv
            // 
            this.rmnIdAdv.Enabled = false;
            this.rmnIdAdv.Location = new System.Drawing.Point(157, 5);
            this.rmnIdAdv.Multiline = true;
            this.rmnIdAdv.Name = "rmnIdAdv";
            this.rmnIdAdv.Size = new System.Drawing.Size(38, 20);
            this.rmnIdAdv.TabIndex = 11;
            this.rmnIdAdv.Tag = "Integer";
            // 
            // cmbSE
            // 
            this.cmbSE.FormattingEnabled = true;
            this.cmbSE.Location = new System.Drawing.Point(335, 194);
            this.cmbSE.Name = "cmbSE";
            this.cmbSE.Size = new System.Drawing.Size(89, 21);
            this.cmbSE.TabIndex = 18;
            // 
            // btnNewRoom
            // 
            this.btnNewRoom.Location = new System.Drawing.Point(124, 5);
            this.btnNewRoom.Name = "btnNewRoom";
            this.btnNewRoom.Size = new System.Drawing.Size(27, 20);
            this.btnNewRoom.TabIndex = 10;
            this.btnNewRoom.Text = "...";
            this.btnNewRoom.UseVisualStyleBackColor = true;
            this.btnNewRoom.Click += new System.EventHandler(this.btnNewRoom_Click);
            // 
            // cmbOO
            // 
            this.cmbOO.FormattingEnabled = true;
            this.cmbOO.Location = new System.Drawing.Point(145, 221);
            this.cmbOO.Name = "cmbOO";
            this.cmbOO.Size = new System.Drawing.Size(89, 21);
            this.cmbOO.TabIndex = 21;
            // 
            // rmnId
            // 
            this.rmnId.Enabled = false;
            this.rmnId.Location = new System.Drawing.Point(80, 5);
            this.rmnId.Multiline = true;
            this.rmnId.Name = "rmnId";
            this.rmnId.Size = new System.Drawing.Size(38, 20);
            this.rmnId.TabIndex = 9;
            this.rmnId.Tag = "Integer";
            // 
            // cmbSS
            // 
            this.cmbSS.FormattingEnabled = true;
            this.cmbSS.Location = new System.Drawing.Point(430, 194);
            this.cmbSS.Name = "cmbSS";
            this.cmbSS.Size = new System.Drawing.Size(89, 21);
            this.cmbSS.TabIndex = 19;
            // 
            // dgvDirections
            // 
            this.dgvDirections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDirections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDirections.Location = new System.Drawing.Point(3, 505);
            this.dgvDirections.Name = "dgvDirections";
            this.dgvDirections.Size = new System.Drawing.Size(518, 191);
            this.dgvDirections.TabIndex = 3;
            // 
            // cmbSO
            // 
            this.cmbSO.FormattingEnabled = true;
            this.cmbSO.Location = new System.Drawing.Point(50, 221);
            this.cmbSO.Name = "cmbSO";
            this.cmbSO.Size = new System.Drawing.Size(89, 21);
            this.cmbSO.TabIndex = 20;
            // 
            // btnAddRoom
            // 
            this.btnAddRoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRoom.Location = new System.Drawing.Point(3, 256);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(518, 50);
            this.btnAddRoom.TabIndex = 2;
            this.btnAddRoom.Text = "Aggiungi Room";
            this.btnAddRoom.UseVisualStyleBackColor = true;
            this.btnAddRoom.Click += new System.EventHandler(this.btnAddRoom_Click);
            // 
            // dgvRooms
            // 
            this.dgvRooms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRooms.Location = new System.Drawing.Point(3, 312);
            this.dgvRooms.Name = "dgvRooms";
            this.dgvRooms.Size = new System.Drawing.Size(518, 191);
            this.dgvRooms.TabIndex = 1;
            this.dgvRooms.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRooms_RowEnter);
            // 
            // pnlObjects
            // 
            this.pnlObjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlObjects.Controls.Add(this.objShortDescription);
            this.pnlObjects.Controls.Add(this.objDescription);
            this.pnlObjects.Controls.Add(this.objTitle);
            this.pnlObjects.Controls.Add(this.objIdRoom);
            this.pnlObjects.Controls.Add(this.btnNewObj);
            this.pnlObjects.Controls.Add(this.objId);
            this.pnlObjects.Controls.Add(this.btnAddObject);
            this.pnlObjects.Controls.Add(this.dgvObjects);
            this.pnlObjects.Location = new System.Drawing.Point(1066, 12);
            this.pnlObjects.Name = "pnlObjects";
            this.pnlObjects.Size = new System.Drawing.Size(524, 700);
            this.pnlObjects.TabIndex = 3;
            // 
            // objIdRoom
            // 
            this.objIdRoom.Enabled = false;
            this.objIdRoom.Location = new System.Drawing.Point(80, 6);
            this.objIdRoom.Multiline = true;
            this.objIdRoom.Name = "objIdRoom";
            this.objIdRoom.Size = new System.Drawing.Size(38, 20);
            this.objIdRoom.TabIndex = 12;
            this.objIdRoom.Tag = "Integer";
            // 
            // btnNewObj
            // 
            this.btnNewObj.Location = new System.Drawing.Point(47, 5);
            this.btnNewObj.Name = "btnNewObj";
            this.btnNewObj.Size = new System.Drawing.Size(27, 20);
            this.btnNewObj.TabIndex = 10;
            this.btnNewObj.Text = "...";
            this.btnNewObj.UseVisualStyleBackColor = true;
            this.btnNewObj.Click += new System.EventHandler(this.btnNewObj_Click);
            // 
            // objId
            // 
            this.objId.Enabled = false;
            this.objId.Location = new System.Drawing.Point(3, 5);
            this.objId.Multiline = true;
            this.objId.Name = "objId";
            this.objId.Size = new System.Drawing.Size(38, 20);
            this.objId.TabIndex = 9;
            this.objId.Tag = "Integer";
            // 
            // btnAddObject
            // 
            this.btnAddObject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddObject.Location = new System.Drawing.Point(3, 220);
            this.btnAddObject.Name = "btnAddObject";
            this.btnAddObject.Size = new System.Drawing.Size(518, 50);
            this.btnAddObject.TabIndex = 2;
            this.btnAddObject.Text = "Aggiungi Oggetto";
            this.btnAddObject.UseVisualStyleBackColor = true;
            this.btnAddObject.Click += new System.EventHandler(this.btnAddObject_Click);
            // 
            // dgvObjects
            // 
            this.dgvObjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvObjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObjects.Location = new System.Drawing.Point(3, 276);
            this.dgvObjects.Name = "dgvObjects";
            this.dgvObjects.Size = new System.Drawing.Size(518, 421);
            this.dgvObjects.TabIndex = 1;
            this.dgvObjects.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvObjects_RowEnter);
            // 
            // objShortDescription
            // 
            this.objShortDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objShortDescription.Location = new System.Drawing.Point(3, 140);
            this.objShortDescription.Multiline = true;
            this.objShortDescription.Name = "objShortDescription";
            this.objShortDescription.Size = new System.Drawing.Size(518, 48);
            this.objShortDescription.TabIndex = 17;
            // 
            // objDescription
            // 
            this.objDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objDescription.Location = new System.Drawing.Point(3, 56);
            this.objDescription.Multiline = true;
            this.objDescription.Name = "objDescription";
            this.objDescription.Size = new System.Drawing.Size(518, 78);
            this.objDescription.TabIndex = 16;
            // 
            // objTitle
            // 
            this.objTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objTitle.Location = new System.Drawing.Point(3, 30);
            this.objTitle.Multiline = true;
            this.objTitle.Name = "objTitle";
            this.objTitle.Size = new System.Drawing.Size(291, 20);
            this.objTitle.TabIndex = 15;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(213, 220);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(204, 50);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Cancella ADV";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlay.Location = new System.Drawing.Point(423, 221);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(92, 50);
            this.btnPlay.TabIndex = 10;
            this.btnPlay.Text = "Gioca ADV";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1594, 724);
            this.Controls.Add(this.pnlObjects);
            this.Controls.Add(this.pnlRoom);
            this.Controls.Add(this.pnlAdvList);
            this.Name = "Main";
            this.Text = "ADVBuilder";
            this.pnlAdvList.ResumeLayout(false);
            this.pnlAdvList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdvList)).EndInit();
            this.pnlRoom.ResumeLayout(false);
            this.pnlRoom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDirections)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).EndInit();
            this.pnlObjects.ResumeLayout(false);
            this.pnlObjects.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObjects)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddAdv;
        private System.Windows.Forms.Panel pnlAdvList;
        private System.Windows.Forms.DataGridView dgvAdvList;
        private System.Windows.Forms.Panel pnlRoom;
        private System.Windows.Forms.TextBox advId;
        private System.Windows.Forms.DataGridView dgvRooms;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtSubTitle;
        private System.Windows.Forms.TextBox txtShortDescription;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Panel pnlObjects;
        private System.Windows.Forms.DataGridView dgvObjects;
        private System.Windows.Forms.Button btnAddRoom;
        private System.Windows.Forms.Button btnAddObject;
        private System.Windows.Forms.DataGridView dgvDirections;
        private System.Windows.Forms.Button btnNewRoom;
        private System.Windows.Forms.TextBox rmnId;
        private System.Windows.Forms.Button btnNewObj;
        private System.Windows.Forms.TextBox objId;
        private System.Windows.Forms.TextBox rmnIdAdv;
        private System.Windows.Forms.TextBox rmnShortDescription;
        private System.Windows.Forms.TextBox rmnDescription;
        private System.Windows.Forms.TextBox rmnTitle;
        private System.Windows.Forms.TextBox objIdRoom;
        private System.Windows.Forms.ComboBox cmbBB;
        private System.Windows.Forms.ComboBox cmbAA;
        private System.Windows.Forms.ComboBox cmbNO;
        private System.Windows.Forms.ComboBox cmbOO;
        private System.Windows.Forms.ComboBox cmbSO;
        private System.Windows.Forms.ComboBox cmbSS;
        private System.Windows.Forms.ComboBox cmbSE;
        private System.Windows.Forms.ComboBox cmbEE;
        private System.Windows.Forms.ComboBox cmbNE;
        private System.Windows.Forms.ComboBox cmbNN;
        private System.Windows.Forms.TextBox objShortDescription;
        private System.Windows.Forms.TextBox objDescription;
        private System.Windows.Forms.TextBox objTitle;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnDelete;
    }
}

