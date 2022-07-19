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
    public partial class Design : Form
    {
        private Pen PenGreen = new Pen(Color.Green, 2);
        private Pen PenBlack = new Pen(Color.Black);
        private const int BTN_ROOM_HEIGHT = 50;
        private const int BTN_ROOM_WIDTH = 100;
        private const int BTN_ROOM_GAP = 3;
        public Adventure ADV;
        public AdventureData ADD;
        public int AdvIdSelected { get; set; }
        public int RoomIdSelected { get; set; }
        public Design()
        {
            InitializeComponent();

        }

        private void InitializeInternalComponent()
        {
            if (AdvIdSelected > 0)
            {
                ADV = new Adventure();
                ADD = ADV.List.Where(a => a.Id == AdvIdSelected).FirstOrDefault();
                ViewRoom();
            }
        }

        private void ViewRoom()
        {
            int r = 200;
            int g = 196;
            int b = 222;

            int x = 0;
            int y = 0;
            foreach (RoomData a in ADD.Rooms)
            {
                r = r - 3;
                g = g + 2;
                b = b + 2;
                Color color = Color.FromArgb(r, g, b);
                if (a != null)
                {
                    pnlRooms.Controls.Add(GetRoomButton(x, y, a, color));
                    if (x < BTN_ROOM_WIDTH + BTN_ROOM_GAP)
                    {
                        x += BTN_ROOM_WIDTH + BTN_ROOM_GAP;
                    }
                    else
                    {
                        x = 0;
                        y += BTN_ROOM_HEIGHT + BTN_ROOM_GAP;
                    }
                }
            }
        }

        private Button GetRoomButton(int pX, int pY, RoomData pRoom, Color pColor)
        {
            Button btn = new Button();
            btn.Top = pY;
            btn.Left = pX;
            btn.Width = BTN_ROOM_WIDTH;
            btn.Height = BTN_ROOM_HEIGHT;
            btn.Text = pRoom.Title;
            btn.Tag = pRoom.Layer;
            btn.BackColor = pColor;
            //            btn.Click += new EventHandler(btnActions_Click);
            tltMain.SetToolTip(btn, pRoom.Description);

            return btn;
        }

        private void Design_Load(object sender, EventArgs e)
        {
            InitializeInternalComponent();
            ViewMap();
        }
        private void ViewMap()
        {
            pcbMap.Image = Image.FromFile("Images/Withe.png");
            Graphics g = Graphics.FromImage(pcbMap.Image);
            Font drawFont = new Font("Arial", 5);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            int x = (pcbMap.Width - 50) / 2;
            int y = (pcbMap.Height - 13) / 2;
            RoomData actual = ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault();
            foreach (var r in ADD.Rooms) r.Drawed = false;
            DrawMap(actual, x, y, PenGreen, drawFont, drawBrush, g);
        }
        private void DrawMap(RoomData rd, int x, int y, Pen p, Font drawFont, Brush drawBrush, Graphics g)
        {
            if (rd != null)
            {
                if (!rd.Drawed)
                {
                    rd.Drawed = true;
                    rd.Visited = true;
                    g.DrawRectangle(p, new Rectangle(x, y, 50, 25));
                    g.DrawString(rd.Title, drawFont, drawBrush, x + 2, y + 12);
                    if (rd.AA > 0)
                    {
                        g.DrawLine(p, x + 48, y + 2, x + 48, y + 7);

                        DrawMap(ADD.Rooms.Where(r => r.Id == rd.AA).FirstOrDefault(),
                        (pcbMap.Image.Width - 50) / 2,
                        (pcbMap.Image.Height - 13) / 2,
                        PenBlack, drawFont, drawBrush, g);
                    }
                    if (rd.BB > 0)
                    {
                        g.DrawLine(p, x + 48, y + 25 - 7, x + 48, y + 25 - 2);

                        DrawMap(ADD.Rooms.Where(r => r.Id == rd.BB).FirstOrDefault(),
                            (pcbMap.Image.Width - 50) / 2,
                            (pcbMap.Image.Height - 13) / 2,
                            PenBlack, drawFont, drawBrush, g);
                    }
                    if (rd.NN > 0)
                    {
                        g.DrawLine(p, x + 25, y, x + 25, y - 5);

                        DrawMap(ADD.Rooms.Where(r => r.Id == rd.NN).FirstOrDefault(),
                        x, y - 30,
                        PenBlack, drawFont, drawBrush, g);
                    }
                    if (rd.NE > 0)
                    {
                        g.DrawLine(p, x + 50, y, x + 53, y - 3);

                        DrawMap(ADD.Rooms.Where(r => r.Id == rd.NE).FirstOrDefault(),
                        x + 55, y - 30,
                        PenBlack, drawFont, drawBrush, g);
                    }
                    if (rd.EE > 0)
                    {
                        g.DrawLine(p, x + 50, y + 12, x + 55, y + 12);

                        DrawMap(ADD.Rooms.Where(r => r.Id == rd.EE).FirstOrDefault(),
                            x + 55, y,
                            PenBlack, drawFont, drawBrush, g);
                    }
                    if (rd.SE > 0)
                    {
                        g.DrawLine(p, x + 50, y + 25, x + 53, y + 28);

                        DrawMap(ADD.Rooms.Where(r => r.Id == rd.SE).FirstOrDefault(),
                        x + 55, y + 30,
                        PenBlack, drawFont, drawBrush, g);
                    }
                    if (rd.SS > 0)
                    {
                        g.DrawLine(p, x + 25, y + 25, x + 25, y + 30);

                        DrawMap(ADD.Rooms.Where(r => r.Id == rd.SS).FirstOrDefault(),
                        x, y + 30,
                        PenBlack, drawFont, drawBrush, g);
                    }
                    if (rd.SO > 0)
                    {
                        g.DrawLine(p, x, y + 25, x - 3, y + 28);

                        DrawMap(ADD.Rooms.Where(r => r.Id == rd.SO).FirstOrDefault(),
                        x - 55, y + 30,
                        PenBlack, drawFont, drawBrush, g);
                    }
                    if (rd.OO > 0)
                    {
                        g.DrawLine(p, x, y + 12, x - 5, y + 12);

                        DrawMap(ADD.Rooms.Where(r => r.Id == rd.OO).FirstOrDefault(),
                        x - 55, y,
                        PenBlack, drawFont, drawBrush, g);
                    }
                    if (rd.NO > 0)
                    {
                        g.DrawLine(p, x, y, x - 3, y - 3);

                        DrawMap(ADD.Rooms.Where(r => r.Id == rd.NO).FirstOrDefault(),
                        x - 55, y - 30,
                        PenBlack, drawFont, drawBrush, g);
                    }
                }
            }
        }

    }
}
