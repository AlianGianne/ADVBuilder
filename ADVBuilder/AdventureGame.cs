﻿using ADVBuilder.Common;
using ADVBuilder.Model;
using ADVBuilder_1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADVBuilder
{
    public partial class AdventureGame : CommonForm
    {
        public Adventure ADV;
        public AdventureData ADD;
        public Actions Actions = new Actions();
        public ActionData Action { get; set; }
        public ObjectsData Object { get; set; }
        public int AdvIdSelected { get; set; }
        public int RoomIdSelected { get; set; }
        public AdventureGame()
        {
            InitializeComponent();
        }
        private void AdventureGame_Load(object sender, EventArgs e)
        {
            InitializeInternalComponent();
            ViewData();
            ViewMap();
        }
        private void ViewMap()
        {
            int x = (pcbMap.Image.Width - 50) / 2;
            int y = (pcbMap.Image.Height - 13) / 2;
            Pen p = new Pen(Color.Green);
            RoomData actual = ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault();
            DrawMap(actual, x, y, p);
            p = new Pen(Color.Black);
            //if (actual.AA != 0) { actual = ADD.Rooms.Where(r => r.Id == actual.AA).FirstOrDefault(); DrawMap(actual, x, y); }
            //if (actual.BB != 0) { actual = ADD.Rooms.Where(r => r.Id == actual.AA).FirstOrDefault(); DrawMap(actual, x, y); }
            if (actual.NN != 0) { actual = ADD.Rooms.Where(r => r.Id == actual.NN).FirstOrDefault(); DrawMap(actual, x, y - 30, p); }
            if (actual.NE != 0) { actual = ADD.Rooms.Where(r => r.Id == actual.NE).FirstOrDefault(); DrawMap(actual, x + 55, y - 30, p); }
            if (actual.EE != 0) { actual = ADD.Rooms.Where(r => r.Id == actual.EE).FirstOrDefault(); DrawMap(actual, x + 55, y, p); }
            if (actual.SE != 0) { actual = ADD.Rooms.Where(r => r.Id == actual.SE).FirstOrDefault(); DrawMap(actual, x + 55, y + 30, p); }
            if (actual.SS != 0) { actual = ADD.Rooms.Where(r => r.Id == actual.SS).FirstOrDefault(); DrawMap(actual, x, y + 30, p); }
            if (actual.SO != 0) { actual = ADD.Rooms.Where(r => r.Id == actual.SO).FirstOrDefault(); DrawMap(actual, x - 55, y + 30, p); }
            if (actual.OO != 0) { actual = ADD.Rooms.Where(r => r.Id == actual.OO).FirstOrDefault(); DrawMap(actual, x - 55, y, p); }
            if (actual.NO != 0) { actual = ADD.Rooms.Where(r => r.Id == actual.NO).FirstOrDefault(); DrawMap(actual, x - 55, y - 30, p); }
        }
        private void DrawMap(RoomData rd, int x, int y, Pen p)
        {
            Graphics g = Graphics.FromImage(pcbMap.Image);
            Font drawFont = new Font("Arial", 3);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            g.DrawRectangle(p, new Rectangle(x, y, 50, 25));
            g.DrawString(rd.Title, drawFont, drawBrush , x + 2, y + 12);
            if (rd.AA != 0) g.DrawLine(p, x + 48, y + 2, x + 48, y + 7);
            if (rd.BB != 0) g.DrawLine(p, x + 48, y + 25 - 7, x + 48, y + 25 - 2);
            if (rd.NN != 0) g.DrawLine(p, x + 25, y, x + 25, y - 5);
            if (rd.NE != 0) g.DrawLine(p, x + 50, y, x + 53, y - 3);
        }
        private void InitializeInternalComponent()
        {
            if (AdvIdSelected != 0)
            {
                ADV = new Adventure(AdvIdSelected);
                ADD = ADV.List.FirstOrDefault();
                RoomIdSelected = ADD.CurrentRoom;
            }
        }
        private void ViewData()
        {
            //Rooms
            txtRoomDescription.Text = ADD.ViewRoom();
            //Objects
            lsbObjects.DisplayMember = "ViewObject";
            lsbObjects.ValueMember = "Id";
            lsbObjects.DataSource = ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault().Objects;
            //Directions
            foreach (Button btn in this.Controls.OfType<Button>())
            {
                switch (btn.Name.Substring(3))
                {
                    case "NN":
                        btn.Enabled = ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault().NN > 0;
                        break;
                    case "NE":
                        btn.Enabled = ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault().NE > 0;
                        break;
                    case "EE":
                        btn.Enabled = ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault().EE > 0;
                        break;
                    case "SE":
                        btn.Enabled = ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault().SE > 0;
                        break;
                    case "SS":
                        btn.Enabled = ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault().SS > 0;
                        break;
                    case "SO":
                        btn.Enabled = ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault().SO > 0;
                        break;
                    case "OO":
                        btn.Enabled = ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault().OO > 0;
                        break;
                    case "NO":
                        btn.Enabled = ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault().NO > 0;
                        break;
                    case "AA":
                        btn.Enabled = ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault().AA > 0;
                        break;
                    case "BB":
                        btn.Enabled = ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault().BB > 0;
                        break;
                }
            }
            //Actions
            lstActions.DisplayMember = "Action";
            lstActions.ValueMember = "Id";
            lstActions.DataSource = Actions.List;
        }
        private void btnDIR_Click(object sender, EventArgs e)
        {
            string direction = (sender as Button).Text;
            switch (direction)
            {
                case "NN":
                    ADD.CurrentRoom = ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault().NN;
                    RoomIdSelected = ADD.CurrentRoom;
                    break;
                case "NE":
                    ADD.CurrentRoom = ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault().NE;
                    RoomIdSelected = ADD.CurrentRoom;
                    break;
                case "EE":
                    ADD.CurrentRoom = ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault().EE;
                    RoomIdSelected = ADD.CurrentRoom;
                    break;
                case "SE":
                    ADD.CurrentRoom = ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault().SE;
                    RoomIdSelected = ADD.CurrentRoom;
                    break;
                case "SS":
                    ADD.CurrentRoom = ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault().SS;
                    RoomIdSelected = ADD.CurrentRoom;
                    break;
                case "SO":
                    ADD.CurrentRoom = ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault().SO;
                    RoomIdSelected = ADD.CurrentRoom;
                    break;
                case "OO":
                    ADD.CurrentRoom = ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault().OO;
                    RoomIdSelected = ADD.CurrentRoom;
                    break;
                case "NO":
                    ADD.CurrentRoom = ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault().NO;
                    RoomIdSelected = ADD.CurrentRoom;
                    break;
                case "AA":
                    ADD.CurrentRoom = ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault().AA;
                    RoomIdSelected = ADD.CurrentRoom;
                    break;
                case "BB":
                    ADD.CurrentRoom = ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault().BB;
                    RoomIdSelected = ADD.CurrentRoom;
                    break;
            }
            ViewData();
            ViewMap();
        }

        private void lstActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetActions(lstActions.SelectedItem as ActionData, null);
        }

        private void lsbObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetActions(Action, lsbObjects.SelectedItem as ObjectsData);
            if (Action != null)
            {
                SetActions(null, null);
            }
        }
        private void SetActions(ActionData pAction, ObjectsData pObject)
        {
            Action = pAction;
            Object = pObject;
            lblObject1.Text = Object == null ? "" : Object.Title;
            lblAction.Text = Action == null ? "" : Action.Action;
        }
    }
}
