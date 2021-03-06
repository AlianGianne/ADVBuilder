using ADVBuilder.ActionsClass;
using ADVBuilder.Common;
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
        private const int BTN_ACTION_HEIGHT = 25;
        private const int BTN_ACTION_WIDTH = 75;
        private const int BTN_ACTION_GAP = 3;
        private bool Dragging;
        private Point lastLocation;
        private iActions CurrentAction;
        private Dictionary<string, iActions> ClassList = new Dictionary<string, iActions>();
        private List<ObjectsData> Inventario = new List<ObjectsData>();
        private int dx;
        private int dy;

        Pen PenGreen = new Pen(Color.Green, 2);
        Pen PenBlack = new Pen(Color.Black, 2);
        Pen PenYellow = new Pen(Color.Yellow, 2);

        public Adventure ADV;
        public AdventureData ADD;

        public Actions Actions = new Actions();
        public ActionData Action { get; set; }
        public ObjectsData Object { get; set; }
        public int AdvIdSelected { get; set; }
        public int RoomIdSelected;

        public AdventureGame()
        {
            InitializeComponent();
        }
        private void AdventureGame_Load(object sender, EventArgs e)
        {
            InitializeFunction();
            InitializeInternalComponent();
            ViewData();
            ViewActions();
            ViewMap();
        }
        private void InitializeFunction()
        {
            ClassList.Add("Prendi", new Take());
            ClassList.Add("Lascia", new Drop());
            ClassList.Add("Getta", new Drop());
            ClassList.Add("Guarda", new Examinate());
            ClassList.Add("Esamina", new Examinate());
            ClassList.Add("Osserva", new Examinate());
            ClassList.Add("Apri", new Open());
            ClassList.Add("NN", new Go());
            ClassList.Add("NE", new Go());
            ClassList.Add("EE", new Go());
            ClassList.Add("SE", new Go());
            ClassList.Add("SS", new Go());
            ClassList.Add("SO", new Go());
            ClassList.Add("OO", new Go());
            ClassList.Add("NO", new Go());
            ClassList.Add("AA", new Go());
            ClassList.Add("BB", new Go());
        }
        private void ViewMap()
        {
            pcbMap.Image = Image.FromFile("Images/Papiro1.jpg");
            Graphics g = Graphics.FromImage(pcbMap.Image);
            Font drawFont = new Font("Arial", 2);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            int x = (pcbMap.Image.Width - 50) / 2;
            int y = (pcbMap.Image.Height - 13) / 2;
            RoomData actual = ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault();
            foreach (var r in ADD.Rooms) r.Drawed = false;
            DrawMap(actual, x, y, PenYellow, drawFont, drawBrush, g);
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
                        //g.DrawLine(p, x + 48, y + 2, x + 48, y + 7);
                        //if (ADD.Rooms.Where(r => r.Id == rd.AA).FirstOrDefault().Visited)
                        //    DrawMap(ADD.Rooms.Where(r => r.Id == rd.AA).FirstOrDefault(),
                        //    (pcbMap.Image.Width - 50) / 2,
                        //    (pcbMap.Image.Height - 13) / 2,
                        //    PenBlack, drawFont, drawBrush, g);
                    }
                    if (rd.BB > 0)
                    {
                        //g.DrawLine(p, x + 48, y + 25 - 7, x + 48, y + 25 - 2);
                        //if (ADD.Rooms.Where(r => r.Id == rd.BB).FirstOrDefault().Visited)
                        //    DrawMap(ADD.Rooms.Where(r => r.Id == rd.BB).FirstOrDefault(),
                        //        (pcbMap.Image.Width - 50) / 2,
                        //        (pcbMap.Image.Height - 13) / 2,
                        //        PenBlack, drawFont, drawBrush, g);
                    }
                    if (rd.NN > 0)
                    {
                        g.DrawLine(p, x + 25, y, x + 25, y - 5);
                        if (ADD.Rooms.Where(r => r.Id == rd.NN).FirstOrDefault().Visited)
                            DrawMap(ADD.Rooms.Where(r => r.Id == rd.NN).FirstOrDefault(),
                            x, y - 30,
                            PenBlack, drawFont, drawBrush, g);
                    }
                    if (rd.NE > 0)
                    {
                        g.DrawLine(p, x + 50, y, x + 53, y - 3);
                        if (ADD.Rooms.Where(r => r.Id == rd.NE).FirstOrDefault().Visited)
                            DrawMap(ADD.Rooms.Where(r => r.Id == rd.NE).FirstOrDefault(),
                            x + 55, y - 30,
                            PenBlack, drawFont, drawBrush, g);
                    }
                    if (rd.EE > 0)
                    {
                        g.DrawLine(p, x + 50, y + 12, x + 55, y + 12);
                        if (ADD.Rooms.Where(r => r.Id == rd.EE).FirstOrDefault().Visited)
                            DrawMap(ADD.Rooms.Where(r => r.Id == rd.EE).FirstOrDefault(),
                                x + 55, y,
                                PenBlack, drawFont, drawBrush, g);
                    }
                    if (rd.SE > 0)
                    {
                        g.DrawLine(p, x + 50, y + 25, x + 53, y + 28);
                        if (ADD.Rooms.Where(r => r.Id == rd.SE).FirstOrDefault().Visited)
                            DrawMap(ADD.Rooms.Where(r => r.Id == rd.SE).FirstOrDefault(),
                            x + 55, y + 30,
                            PenBlack, drawFont, drawBrush, g);
                    }
                    if (rd.SS > 0)
                    {
                        g.DrawLine(p, x + 25, y + 25, x + 25, y + 30);
                        if (ADD.Rooms.Where(r => r.Id == rd.SS).FirstOrDefault().Visited)
                            DrawMap(ADD.Rooms.Where(r => r.Id == rd.SS).FirstOrDefault(),
                            x, y + 30,
                            PenBlack, drawFont, drawBrush, g);
                    }
                    if (rd.SO > 0)
                    {
                        g.DrawLine(p, x, y + 25, x - 3, y + 28);
                        if (ADD.Rooms.Where(r => r.Id == rd.SO).FirstOrDefault().Visited)
                            DrawMap(ADD.Rooms.Where(r => r.Id == rd.SO).FirstOrDefault(),
                            x - 55, y + 30,
                            PenBlack, drawFont, drawBrush, g);
                    }
                    if (rd.OO > 0)
                    {
                        g.DrawLine(p, x, y + 12, x - 5, y + 12);
                        if (ADD.Rooms.Where(r => r.Id == rd.OO).FirstOrDefault().Visited)
                            DrawMap(ADD.Rooms.Where(r => r.Id == rd.OO).FirstOrDefault(),
                            x - 55, y,
                            PenBlack, drawFont, drawBrush, g);
                    }
                    if (rd.NO > 0)
                    {
                        g.DrawLine(p, x, y, x - 3, y - 3);
                        if (ADD.Rooms.Where(r => r.Id == rd.NO).FirstOrDefault().Visited)
                            DrawMap(ADD.Rooms.Where(r => r.Id == rd.NO).FirstOrDefault(),
                            x - 55, y - 30,
                            PenBlack, drawFont, drawBrush, g);
                    }
                }
            }
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
        private Button GetActionButton(int pX, int pY, ActionData pAction, Color pColor)
        {
            Button btn = new Button();
            btn.Top = pY;
            btn.Left = pX;
            btn.Width = BTN_ACTION_WIDTH;
            btn.Height = BTN_ACTION_HEIGHT;
            btn.Text = pAction.Action;
            btn.Tag = pAction.DeepObjects;
            btn.BackColor = pColor;
            btn.Click += new EventHandler(btnActions_Click);
            tltMain.SetToolTip(btn, pAction.Description);

            return btn;
        }
        private Button GetObjectButton(int pX, int pY, ObjectsData pObject, Color pColor)
        {
            Button btn = new Button();
            btn.Top = pY;
            btn.Left = pX;
            btn.Width = BTN_ACTION_WIDTH;
            btn.Height = BTN_ACTION_HEIGHT;
            btn.Text = pObject.Title;
            btn.Tag = pObject;
            btn.BackColor = pColor;
            btn.Click += new EventHandler(btnObjects_Click);
            tltMain.SetToolTip(btn, pObject.Description);

            return btn;
        }
        private Button GetInventarioButton(int pX, int pY, ObjectsData pObject, Color pColor)
        {
            Button btn = new Button();
            btn.Top = pY;
            btn.Left = pX;
            btn.Width = BTN_ACTION_WIDTH;
            btn.Height = BTN_ACTION_HEIGHT;
            btn.Text = pObject.Title;
            btn.Tag = pObject;
            btn.BackColor = pColor;
            btn.ForeColor = Color.White;
            btn.Click += new EventHandler(btnInventario_Click);
            tltMain.SetToolTip(btn, pObject.Description);

            return btn;
        }
        private void btnActions_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            CurrentAction = ClassList[btn.Text];
            Object = null;
            txtResult.Text = CurrentAction.Execute(Object, null, ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault(), Inventario).Message;
            ViewData();
            ViewMap();
        }
        private void ViewActions()
        {
            int r = 200;
            int g = 196;
            int b = 222;

            int x = 0;
            int y = lblAction.Top + lblAction.Height;


            foreach (ActionData a in Actions.List)
            {
                r = r - 3;
                g = g + 2;
                b = b + 2;
                Color color = Color.FromArgb(r, g, b);
                if (a != null)
                {
                    pnlActions.Controls.Add(GetActionButton(x, y, a, color));
                    if (x < 300 - BTN_ACTION_WIDTH)
                    {
                        x += BTN_ACTION_WIDTH + BTN_ACTION_GAP;
                    }
                    else
                    {
                        x = 0;
                        y += BTN_ACTION_HEIGHT + BTN_ACTION_GAP;
                    }
                }
            }
        }
        private void ViewObjects()
        {
            int r = 50;
            int g = 200;
            int b = 52;

            int x = 0;
            int y = lblObjects.Top + lblObjects.Height;

            foreach (Control p in pnlObjects.Controls.OfType<Button>().ToList()) pnlObjects.Controls.Remove(p);

            foreach (ObjectsData o in ADD.Rooms.Where(l => l.Id == ADD.CurrentRoom).FirstOrDefault().Objects)
            {
                r = r - 3;
                g = g + 2;
                b = b + 2;
                Color color = Color.FromArgb(r, g, b);
                if (o != null)
                {
                    pnlObjects.Controls.Add(GetObjectButton(x, y, o, color));
                    if (x < 300 - BTN_ACTION_WIDTH)
                    {
                        x += BTN_ACTION_WIDTH + BTN_ACTION_GAP;
                    }
                    else
                    {
                        x = 0;
                        y += BTN_ACTION_HEIGHT + BTN_ACTION_GAP;
                    }
                }
            }
        }
        private void ViewInventario()
        {
            int r = 200;
            int g = 50;
            int b = 100;

            int x = 0;
            int y = lblInventario.Top + lblInventario.Height;

            foreach (Control p in pnlInventario.Controls.OfType<Button>().ToList()) pnlInventario.Controls.Remove(p);

            foreach (ObjectsData o in Inventario)
            {
                r = r - 3;
                g = g + 2;
                b = b + 2;
                Color color = Color.FromArgb(r, g, b);
                if (o != null)
                {
                    pnlInventario.Controls.Add(GetInventarioButton(x, y, o, color));
                    if (x < 300 - BTN_ACTION_WIDTH)
                    {
                        x += BTN_ACTION_WIDTH + BTN_ACTION_GAP;
                    }
                    else
                    {
                        x = 0;
                        y += BTN_ACTION_HEIGHT + BTN_ACTION_GAP;
                    }
                }
            }
        }
        private void ViewDirections()
        {
            foreach (Button btn in pnlDirection.Controls.OfType<Button>())
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
        }
        private void ViewData()
        {
            //Rooms
            txtRoomDescription.Text = ADD.ViewRoom();

            //Objects
            ViewObjects();

            //Inventario
            ViewInventario();

            //Directions
            ViewDirections();
        }
        private void btnDIR_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string direction = btn.Text;

            CurrentAction = ClassList[btn.Text];
            Object = null;
            txtResult.Text = CurrentAction.Execute(ADD, ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault(), direction, ref RoomIdSelected).Message;
            ViewData();
            ViewMap();
        }

        private void btnObjects_Click(object sender, EventArgs e)
        {
            if (CurrentAction != null)
            {
                Button btn = (Button)sender;

                SetActions(Action, btn.Tag as ObjectsData);
                txtResult.Text = CurrentAction.Execute(Object, null, ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault(), Inventario).Message;
                ViewData();
                ViewMap();
            }
        }
        private void SetActions(ActionData pAction, ObjectsData pObject)
        {
            Action = pAction;
            Object = pObject;
        }

        private void pcbMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (Dragging == true)
            {
                dx = e.X - lastLocation.X;
                dy = e.Y - lastLocation.Y;


                pcbMap.Padding = new Padding(Padding.Left + dx, Padding.Top + dy, Padding.Right - dx, Padding.Bottom - dy);

                pcbMap.Invalidate();

            }
        }

        private void pcbMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Dragging = true;
                lastLocation = e.Location;
            }
        }

        private void pcbMap_MouseUp(object sender, MouseEventArgs e)
        {
            Dragging = false;
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            if (CurrentAction != null)
            {
                Button btn = (Button)sender;

                SetActions(Action, btn.Tag as ObjectsData);
                txtResult.Text = CurrentAction.Execute(Object, null, ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault(), Inventario).Message;
                ViewData();
                ViewMap();
            }
        }
    }
}
