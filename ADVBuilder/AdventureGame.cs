using ADVBuilder.ActionsClass_New;
using ADVBuilder.Common;
using ADVBuilder.Model;

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ADVBuilder
{
    public partial class AdventureGame : CommonForm
    {
        private const int BTN_HEIGHT = 25;
        private const int BTN_WIDTH = 75;
        private const int BTN_GAP = 3;
        private int Room_Zoom = 20;
        private bool Dragging;
        private Point lastLocation;
        private iActions CurrentAction;
        private Dictionary<string, iActions> ClassList = new Dictionary<string, iActions>();
        private List<ObjectsData> Inventario = new List<ObjectsData>();
        private int dx;
        private int dy;
        private int layer = 0;

        private Pen PenGreen = new Pen(Color.Green, 2);
        private Pen PenBlack = new Pen(Color.Black, 2);
        private Pen PenYellow = new Pen(Color.Yellow, 2);

        public Adventure ADV;
        public AdventureData ADD;

        public Actions Actions = new Actions();
        public ActionData Action { get; set; }
        public ObjectsData Object { get; set; }
        public ObjectsData Complement { get; set; }
        public CharactersData Character { get; set; }
        public int AdvIdSelected { get; set; }
        public int RoomIdSelected;

        public AdventureGame()
        {
            InitializeComponent();
        }

        private void AdventureGame_Load(object sender, EventArgs e)
        {
            InitializeInternalComponent();
            InitializeFunction();
            ViewData();
            ViewActions();
            ViewMap();
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

        private void InitializeFunction()
        {
            ClassList.Add("Prendi", new Take(ADD, Inventario));
            ClassList.Add("Lascia", new Drop(ADD, Inventario));
            ClassList.Add("Getta", new Drop(ADD, Inventario));
            ClassList.Add("Guarda", new Examinate(ADD, Inventario));
            ClassList.Add("Esamina", new Examinate(ADD, Inventario));
            ClassList.Add("Osserva", new Examinate(ADD, Inventario));
            ClassList.Add("Apri", new Open(ADD, Inventario));
            ClassList.Add("Usa con...", new UseWith(ADD, Inventario));
            ClassList.Add("Parla", new Speak(ADD, Inventario));
            ClassList.Add("Inimplementato", new Unable(ADD, Inventario));
            ClassList.Add("NN", new Go(ADD, Inventario));
            ClassList.Add("NE", new Go(ADD, Inventario));
            ClassList.Add("EE", new Go(ADD, Inventario));
            ClassList.Add("SE", new Go(ADD, Inventario));
            ClassList.Add("SS", new Go(ADD, Inventario));
            ClassList.Add("SO", new Go(ADD, Inventario));
            ClassList.Add("OO", new Go(ADD, Inventario));
            ClassList.Add("NO", new Go(ADD, Inventario));
            ClassList.Add("AA", new Go(ADD, Inventario));
            ClassList.Add("BB", new Go(ADD, Inventario));
        }

        private void ViewMap()
        {
            pcbMap.Image = Image.FromFile("Images/Papiro 2.jpg");
            Graphics g = Graphics.FromImage(pcbMap.Image);
            Font drawFontA = new Font("Arial", 2);
            Font drawFontB = new Font("Arial", 3);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            int x = (pcbMap.Image.Width - (cCommon.ROOM_WIDTH + Room_Zoom)) / 2 + cCommon.GAP_FACTOR_X;
            int y = (pcbMap.Image.Height - (cCommon.ROOM_HEIGHT + Room_Zoom)) / 2 + cCommon.GAP_FACTOR_Y;
            RoomData actual = ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault();
            layer = actual.Layer;
            foreach (var r in ADD.Rooms) r.Drawed = false;
            DrawMap(actual, x, y, PenGreen, drawFontA, drawBrush, g);
        }

        private void DrawMap(RoomData rd, int x, int y, Pen p, Font drawFont, Brush drawBrush, Graphics g)
        {
            if (rd != null)
            {
                if (!rd.Drawed)
                {
                    rd.Drawed = true;
                    rd.Visited = true;
                    g.DrawString(rd.Id.ToString(), new Font("Arial", 3), drawBrush, x + 2, y);
                    g.DrawString(rd.Title, drawFont, drawBrush, x + 2, y + 12);
                    g.DrawRectangle(p, new Rectangle(x, y, cCommon.ROOM_WIDTH + Room_Zoom, cCommon.ROOM_HEIGHT + Room_Zoom));
                    g.DrawString(string.Format("Piano: {0}", layer), new Font("Arial", 8), drawBrush, cCommon.STR_LAYER_POSITION_X, cCommon.STR_LAYER_POSITION_Y);
                    int xObj = 2;
                    int yObj = (cCommon.ROOM_HEIGHT + Room_Zoom) - 7;
                    foreach (ObjectsData obj in rd.Objects)
                    {
                        g.DrawRectangle(new Pen(Color.Brown, 2), new Rectangle(x + xObj, y + yObj, 5, 5));
                        xObj += 7;
                    }
                    xObj = 2;
                    yObj = (cCommon.ROOM_HEIGHT + Room_Zoom) - 14;
                    foreach (CharactersData obj in rd.Characters)
                    {
                        g.DrawRectangle(new Pen(Color.Violet, 2), new Rectangle(x + xObj, y + yObj, 5, 5));
                        xObj += 7;
                    }
                    if (rd.AA > 0)
                    {
                        g.DrawLine(p, x + (cCommon.ROOM_WIDTH + Room_Zoom) - 4, y + 4, x + (cCommon.ROOM_WIDTH + Room_Zoom) - 8, y + 9);
                    }
                    if (rd.BB > 0)
                    {
                        g.DrawLine(p, x + (cCommon.ROOM_WIDTH + Room_Zoom) - 8, y + (cCommon.ROOM_HEIGHT + Room_Zoom) - 9, x + (cCommon.ROOM_WIDTH + Room_Zoom) - 4, y + (cCommon.ROOM_HEIGHT + Room_Zoom) - 4);
                    }
                    if (rd.NN > 0)
                    {
                        g.DrawLine(p, x + (cCommon.ROOM_WIDTH + Room_Zoom) / 2, y, x + (cCommon.ROOM_WIDTH + Room_Zoom) / 2, y - 5);
                        if (ADD.Rooms.Where(r => r.Id == rd.NN).FirstOrDefault().Visited)
                            DrawMap(ADD.Rooms.Where(r => r.Id == rd.NN).FirstOrDefault(),
                            x, y - ((cCommon.ROOM_HEIGHT + Room_Zoom ) + 5),
                            PenBlack, drawFont, drawBrush, g);
                    }
                    if (rd.NE > 0)
                    {
                        g.DrawLine(p, x + (cCommon.ROOM_WIDTH + Room_Zoom), y, x + (cCommon.ROOM_WIDTH + Room_Zoom) + 3, y - 3);
                        if (ADD.Rooms.Where(r => r.Id == rd.NE).FirstOrDefault().Visited)
                            DrawMap(ADD.Rooms.Where(r => r.Id == rd.NE).FirstOrDefault(),
                            x + (cCommon.ROOM_WIDTH + Room_Zoom + 5), y - ((cCommon.ROOM_HEIGHT + Room_Zoom ) + 5),
                            PenBlack, drawFont, drawBrush, g);
                    }
                    if (rd.EE > 0)
                    {
                        g.DrawLine(p, x + (cCommon.ROOM_WIDTH + Room_Zoom), y + (cCommon.ROOM_HEIGHT + Room_Zoom) / 2, x + (cCommon.ROOM_WIDTH + Room_Zoom) + 5, y + (cCommon.ROOM_HEIGHT + Room_Zoom) / 2);
                        if (ADD.Rooms.Where(r => r.Id == rd.EE).FirstOrDefault().Visited)
                            DrawMap(ADD.Rooms.Where(r => r.Id == rd.EE).FirstOrDefault(),
                                x + (cCommon.ROOM_WIDTH + Room_Zoom + 5), y,
                                PenBlack, drawFont, drawBrush, g);
                    }
                    if (rd.SE > 0)
                    {
                        g.DrawLine(p, x + (cCommon.ROOM_WIDTH + Room_Zoom), y + (cCommon.ROOM_HEIGHT + Room_Zoom), x + (cCommon.ROOM_WIDTH + Room_Zoom) + 3, y + (cCommon.ROOM_HEIGHT + Room_Zoom) + 3);
                        if (ADD.Rooms.Where(r => r.Id == rd.SE).FirstOrDefault().Visited)
                            DrawMap(ADD.Rooms.Where(r => r.Id == rd.SE).FirstOrDefault(),
                            x + (cCommon.ROOM_WIDTH + Room_Zoom + 5), y + ((cCommon.ROOM_HEIGHT + Room_Zoom ) + 5),
                            PenBlack, drawFont, drawBrush, g);
                    }
                    if (rd.SS > 0)
                    {
                        g.DrawLine(p, x + (cCommon.ROOM_WIDTH + Room_Zoom) / 2, y + (cCommon.ROOM_HEIGHT + Room_Zoom), x + (cCommon.ROOM_WIDTH + Room_Zoom) / 2, y + ((cCommon.ROOM_HEIGHT + Room_Zoom)) + 5);
                        if (ADD.Rooms.Where(r => r.Id == rd.SS).FirstOrDefault().Visited)
                            DrawMap(ADD.Rooms.Where(r => r.Id == rd.SS).FirstOrDefault(),
                            x, y + ((cCommon.ROOM_HEIGHT + Room_Zoom ) + 5),
                            PenBlack, drawFont, drawBrush, g);
                    }
                    if (rd.SO > 0)
                    {
                        g.DrawLine(p, x, y + (cCommon.ROOM_HEIGHT + Room_Zoom), x - 3, y + (cCommon.ROOM_HEIGHT + Room_Zoom) + 3);
                        if (ADD.Rooms.Where(r => r.Id == rd.SO).FirstOrDefault().Visited)
                            DrawMap(ADD.Rooms.Where(r => r.Id == rd.SO).FirstOrDefault(),
                            x - (cCommon.ROOM_WIDTH + Room_Zoom + 5), y + ((cCommon.ROOM_HEIGHT + Room_Zoom ) + 5),
                            PenBlack, drawFont, drawBrush, g);
                    }
                    if (rd.OO > 0)
                    {
                        g.DrawLine(p, x, y + ((cCommon.ROOM_HEIGHT + Room_Zoom)) / 2, x - 5, y + ((cCommon.ROOM_HEIGHT + Room_Zoom)) / 2);
                        if (ADD.Rooms.Where(r => r.Id == rd.OO).FirstOrDefault().Visited)
                            DrawMap(ADD.Rooms.Where(r => r.Id == rd.OO).FirstOrDefault(),
                            x - (cCommon.ROOM_WIDTH + Room_Zoom + 5), y,
                            PenBlack, drawFont, drawBrush, g);
                    }
                    if (rd.NO > 0)
                    {
                        g.DrawLine(p, x, y, x - 3, y - 3);
                        if (ADD.Rooms.Where(r => r.Id == rd.NO).FirstOrDefault().Visited)
                            DrawMap(ADD.Rooms.Where(r => r.Id == rd.NO).FirstOrDefault(),
                            x - (cCommon.ROOM_WIDTH + Room_Zoom + 5), y - ((cCommon.ROOM_HEIGHT + Room_Zoom ) + 5),
                            PenBlack, drawFont, drawBrush, g);
                    }
                }
            }
        }

        private Button GetButton(int pX, int pY, object pObject, Color pBackColor, Color pForeColor, EventHandler pEventHandler)
        {
            Type type = pObject.GetType();
            PropertyInfo[] properties = type.GetProperties();

            Button btn = new Button();
            btn.Top = pY;
            btn.Left = pX;
            btn.Width = BTN_WIDTH;
            btn.Height = BTN_HEIGHT;
            btn.Text = properties.Where(p => p.Name == "Title").FirstOrDefault().GetValue(pObject).ToString();
            btn.Tag = pObject;
            btn.BackColor = pBackColor;
            btn.ForeColor = pForeColor;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Click += pEventHandler;
            tltMain.SetToolTip(btn, properties.Where(p => p.Name == "Description").FirstOrDefault().GetValue(pObject).ToString());

            return btn;
        }

        private void ViewActions()
        {
            int r = 200;
            int g = 150;
            int b = 100;

            int x = 0;
            int y = lblAction.Top + lblAction.Height;

            foreach (ActionData a in Actions.List)
            {
                r = r - 3;
                g = g + 2;
                b = b + 2;
                Color color = Color.FromArgb(r, g, b);
                Color foreColor = Color.WhiteSmoke;
                if (a != null)
                {
                    pnlActions.Controls.Add(GetButton(x, y, a, color, foreColor, new EventHandler(btnActions_Click)));
                    if (x < 300 - BTN_WIDTH)
                    {
                        x += BTN_WIDTH + BTN_GAP;
                    }
                    else
                    {
                        x = 0;
                        y += BTN_HEIGHT + BTN_GAP;
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
                Color foreColor = Color.WhiteSmoke;
                if (o != null)
                {
                    pnlObjects.Controls.Add(GetButton(x, y, o, color, foreColor, new EventHandler(btnObjects_Click)));
                    if (x < 300 - BTN_WIDTH)
                    {
                        x += BTN_WIDTH + BTN_GAP;
                    }
                    else
                    {
                        x = 0;
                        y += BTN_HEIGHT + BTN_GAP;
                    }
                }
            }
        }

        private void ViewCharacters()
        {
            int r = 50;
            int g = 20;
            int b = 200;

            int x = 0;
            int y = lblPersons.Top + lblPersons.Height;

            foreach (Control p in pnlPerson.Controls.OfType<Button>().ToList()) pnlPerson.Controls.Remove(p);

            foreach (CharactersData o in ADD.Rooms.Where(l => l.Id == ADD.CurrentRoom).FirstOrDefault().Characters)
            {
                r = r - 3;
                g = g + 2;
                b = b + 2;
                Color color = Color.FromArgb(r, g, b);
                Color foreColor = Color.WhiteSmoke;
                if (o != null)
                {
                    pnlPerson.Controls.Add(GetButton(x, y, o, color, foreColor, new EventHandler(btnCharacters_Click)));
                    if (x < 300 - BTN_WIDTH)
                    {
                        x += BTN_WIDTH + BTN_GAP;
                    }
                    else
                    {
                        x = 0;
                        y += BTN_HEIGHT + BTN_GAP;
                    }
                }
            }
        }

        private void ViewInventario()
        {
            int r = 180;
            int g = 10;
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
                Color foreColor = Color.WhiteSmoke;
                if (o != null)
                {
                    pnlInventario.Controls.Add(GetButton(x, y, o, color, foreColor, new EventHandler(btnInventario_Click)));
                    if (x < 300 - BTN_WIDTH)
                    {
                        x += BTN_WIDTH + BTN_GAP;
                    }
                    else
                    {
                        x = 0;
                        y += BTN_HEIGHT + BTN_GAP;
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
                btn.BackColor = !btn.Enabled ? Color.LightGray : Color.LightSalmon;
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

            //Persone
            ViewCharacters();

            //Directions
            ViewDirections();
        }

        private void btnDIR_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string direction = btn.Text;

            CurrentAction = ClassList[btn.Text];
            Object = null;
            Complement = null;
            ADD.Direction = direction;
            txtResult.Text = CurrentAction.Execute(Character, Object, Complement, ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault()).Message;
            ViewData();
            ViewMap();
        }

        private void btnObjects_Click(object sender, EventArgs e)
        {
            if (CurrentAction != null)
            {
                Button btn = (Button)sender;

                SetActions(Action, btn.Tag as ObjectsData);
                txtResult.Text = CurrentAction.Execute(Character, Object, Complement, ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault()).Message;
                ViewData();
                ViewMap();
            }
        }

        private void btnCharacters_Click(object sender, EventArgs e)
        {
            if (CurrentAction != null)
            {
                Button btn = (Button)sender;

                SetActionsCharacter(Action, btn.Tag as CharactersData);
                txtResult.Text = CurrentAction.Execute(Character, Object, Complement, ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault()).Message;
                ViewData();
                ViewMap();
            }
        }

        private void btnActions_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            CurrentAction = ClassList.Where(cl => cl.Key == btn.Text).FirstOrDefault().Value;

            if (CurrentAction == null) CurrentAction = ClassList["Inimplementato"];

            Object = null;
            Complement = null;
            txtResult.Text = CurrentAction.Execute(Character, Object, Complement, ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault()).Message;
            ViewData();
            ViewMap();
        }

        private void SetActions(ActionData pAction, ObjectsData pObject)
        {
            Action = pAction;
            if (Object == null)
                Object = pObject;
            else
                Complement = pObject;
        }

        private void SetActionsCharacter(ActionData pAction, CharactersData pCharacter)
        {
            Action = pAction;
            Character = pCharacter;
        }

        #region "Maps"
        private void pcbMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (Dragging == true)
            {
                dx = e.X - lastLocation.X;
                dy = e.Y - lastLocation.Y;
                cCommon.GAP_FACTOR_X = dx;
                cCommon.GAP_FACTOR_Y = dy;
                ViewMap();
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
                txtResult.Text = CurrentAction.Execute(Character, Object, Complement, ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault()).Message;
                ViewData();
                ViewMap();
            }
        }

        private void btnZoomPlus_Click(object sender, EventArgs e)
        {
            Room_Zoom += cCommon.ZOOM_FACTOR;
            ViewMap();
        }

        private void btnZoomMinus_Click(object sender, EventArgs e)
        {
            Room_Zoom -= cCommon.ZOOM_FACTOR;
            ViewMap();
        }

        private void btnSuperPlus_Click(object sender, EventArgs e)
        {
            Room_Zoom += cCommon.ZOOM_FACTOR * cCommon.ZOOM_FACTOR_MULTIPLIER;
            ViewMap();
        }

        private void btnSuperMinus_Click(object sender, EventArgs e)
        {
            Room_Zoom -= cCommon.ZOOM_FACTOR * cCommon.ZOOM_FACTOR_MULTIPLIER;
            ViewMap();
        }
        private void btnLeft_Click(object sender, EventArgs e)
        {
            cCommon.GAP_FACTOR_X -= cCommon.GAP_FACTOR;
            ViewMap();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            cCommon.GAP_FACTOR_Y -= cCommon.GAP_FACTOR;
            ViewMap();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            cCommon.GAP_FACTOR_Y += cCommon.GAP_FACTOR;
            ViewMap();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            cCommon.GAP_FACTOR_X += cCommon.GAP_FACTOR;
            ViewMap();
        }
        #endregion "Maps"
    }
}