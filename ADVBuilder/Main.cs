using ADVBuilder.Common;

using ADVBuilder_1.Model;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ADVBuilder
{
    public partial class Main : CommonForm
    {
        private Adventure ADV;
        public int AdvIdSelected { get; set; }
        public int RoomIdSelected { get; set; }

        public Main()
        {
            InitializeComponent();
            InitializeInternalComponent();
            DataBind();
        }

        private void InitializeInternalComponent()
        {
            ADV = new Adventure();
        }

        private void DataBind()
        {
            dgvAdvList.DataSource = ADV.List;
        }
        private void SetDirectionCombo()
        {
            SetCombo(cmbNN);
            SetCombo(cmbNE);
            SetCombo(cmbEE);
            SetCombo(cmbSE);
            SetCombo(cmbSS);
            SetCombo(cmbSO);
            SetCombo(cmbOO);
            SetCombo(cmbNO);
            SetCombo(cmbAA);
            SetCombo(cmbBB);
        }
        private void SetCombo(ComboBox cmb)
        {
            List<RoomData> rmd = new List<RoomData>();
            rmd.Add(new RoomData() { Id = -1, IdAdv = -1, Title = "Scegli..." });
            rmd.AddRange(ADV.List.Where(ad => ad.Id == AdvIdSelected).FirstOrDefault().Rooms);
            
            cmb.DisplayMember = "Title";
            cmb.ValueMember = "Id";
            cmb.DataSource = rmd;
        }
        private void dgvAdvList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            AdvIdSelected = int.Parse(dgvAdvList.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            ADV.ReadParamForForm(ADV.List.Where(l => l.Id == AdvIdSelected).FirstOrDefault(), pnlAdvList, AdvIdSelected);
            dgvRooms.DataSource = ADV.List.Where(ad => ad.Id == AdvIdSelected).FirstOrDefault().Rooms;
            SetDirectionCombo();
        }

        private void dgvObjects_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dgvRooms.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            ADV.ReadParamForForm(ADV.List.Where(ad => ad.Id == AdvIdSelected).FirstOrDefault()
                .Rooms.Where(r => r.Id == id).FirstOrDefault()
                .Objects.Where(o => o.Id == id).FirstOrDefault(), pnlObjects, id);
        }

        private void dgvRooms_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            RoomIdSelected = int.Parse(dgvRooms.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            ADV.ReadParamForForm(ADV.List.Where(ad => ad.Id == AdvIdSelected).FirstOrDefault()
                .Rooms.Where(r => r.Id == RoomIdSelected).FirstOrDefault(), pnlRoom, RoomIdSelected);
            dgvObjects.DataSource = ADV.List.Where(ad => ad.Id == AdvIdSelected).FirstOrDefault()
                .Rooms.Where(r => r.Id == RoomIdSelected).FirstOrDefault().Objects;
        }

        private void btnAddAdv_Click(object sender, EventArgs e)
        {
            AdventureData adv = new AdventureData();
            ADV.ReadParamForObj(ADV.List, pnlAdvList);
            adv = ADV.List.FirstOrDefault();
            if (adv.Id < 0)
                ADV.InsertData(adv);
            else
                ADV.UpdateData(adv);
            InitializeInternalComponent();
            DataBind();
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            InsertDataRoom();
            InitializeInternalComponent();
            DataBind();
        }
        private void InsertDataRoom()
        {
            Room rmn = new Room();
            RoomData rmd = new RoomData();
            rmn.ReadParamForObj(ADV.List.Where(a => a.Id == AdvIdSelected).FirstOrDefault().Rooms, pnlRoom);
            rmd = ADV.List.Where(a => a.Id == AdvIdSelected).FirstOrDefault().Rooms.FirstOrDefault();
            if (rmd.Id < 0)
                rmn.InsertData(rmd);
            else
                rmn.UpdateData(rmd);
        }
        
        private void btnAddObject_Click(object sender, EventArgs e)
        {
            Room rmn = new Room();
            Objects obs = new Objects();
            RoomData rmd = new RoomData();
            ObjectsData obd = new ObjectsData();
            obs.ReadParamForObj(ADV.List.Where(a => a.Id == AdvIdSelected).FirstOrDefault().Rooms.Where(r=> r.Id==RoomIdSelected).FirstOrDefault().Objects, pnlObjects);
            obd = ADV.List.Where(a => a.Id == AdvIdSelected).FirstOrDefault().Rooms.FirstOrDefault().Objects.FirstOrDefault();
            if (obd.Id < 0)
                obs.InsertData(obd);
            else
                obs.UpdateData(obd);
            InitializeInternalComponent();
            DataBind();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            CleanFields(pnlAdvList);
        }

        private void btnNewRoom_Click(object sender, EventArgs e)
        {
            CleanFields(pnlRoom);
            rmnIdAdv.Text = AdvIdSelected.ToString();
        }

        private void btnNewObj_Click(object sender, EventArgs e)
        {
            CleanFields(pnlObjects);
            objIdRoom.Text = RoomIdSelected.ToString();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            AdventureGame AdvGame = new AdventureGame();
            AdvGame.AdvIdSelected = AdvIdSelected;
            AdvGame.Show();
        }
    }
}