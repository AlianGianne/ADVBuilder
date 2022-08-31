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
        private const int BTN_HEIGHT = 26;
        private const int BTN_WIDTH = 111;
        private const int BTN_INTER_GAP = 1;
        private const int BTN_GAP = 5;
        private int Room_Zoom = 50;
        private bool Dragging;
        private Point lastLocation;
        private iActions CurrentAction;
        private Dictionary<string, iActions> ClassList = new Dictionary<string, iActions>();
        private List<ObjectsData> Inventario = new List<ObjectsData>();
        private int dx;
        private int dy;
        private int layer = 0;

        //private Pen PenGreen = new Pen(Color.Green, 2);
        //private Pen PenUsed = new Pen(Color.GhostWhite, 2);
        //private Pen PenYellow = new Pen(Color.Yellow, 2);
        //private Pen PenBlu = new Pen(Color.Blue, 2);
        //private Pen PenCyan = new Pen(Color.Cyan, 2);
        //private Pen PenDarkOrange = new Pen(Color.DarkOrange, 2);
        //private Pen PenRed = new Pen(Color.Red, 3);
        private Pen PenGreen = new Pen(Color.Green, 1);
        private Pen PenUsed = new Pen(Color.GhostWhite, 1);
        private Pen PenYellow = new Pen(Color.Yellow, 1);
        private Pen PenBlu = new Pen(Color.Blue, 1);
        private Pen PenCyan = new Pen(Color.Cyan, 1);
        private Pen PenDarkOrange = new Pen(Color.DarkOrange, 1);
        private Pen PenLightGoldenrodYellow = new Pen(Color.LightGoldenrodYellow, 1);
        private Pen PenMidnightBlue = new Pen(Color.MidnightBlue, 1);
        private Pen PenRed = new Pen(Color.Red, 2);
        private Dictionary<int, Pen> AllColors = new Dictionary<int, Pen>();
        private int idxColor = 0;

        public Adventure ADV;
        public AdventureData ADD;

        public User User;

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
            InitializeUser();
            InitializeFunction();
            InitializeColors();
            ViewData();
            ViewActions();
            ViewMap();
        }

        private void InitializeUser()
        {
            User = new User();
            User.Name = "Alessandro";
            User.Surname = "Iannarelli";
            User.UserName = "AlianGianne";
            User.Points = 0;
            User.ADD = ADD;
        }

        private void InitializeColors()
        {
            AllColors.Add(0, PenUsed);
            AllColors.Add(1, PenBlu);
            AllColors.Add(2, PenGreen);
            AllColors.Add(3, PenYellow);
            AllColors.Add(4, PenCyan);
            AllColors.Add(5, PenDarkOrange);
            AllColors.Add(6, PenLightGoldenrodYellow);
            AllColors.Add(7, PenMidnightBlue);
        }

        private void InitializeInternalComponent()
        {
            if (AdvIdSelected != 0)
            {
                ADV = new Adventure(AdvIdSelected);
                ADD = ADV.List.FirstOrDefault();
                RoomIdSelected = ADD.CurrentRoom;
                cCommon.GAP_FACTOR_X = (pcbMap.Image.Width - (cCommon.ROOM_WIDTH + Room_Zoom)) / 2;
                cCommon.GAP_FACTOR_Y = (pcbMap.Image.Height - (cCommon.ROOM_HEIGHT + Room_Zoom)) / 2;
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
            ClassList.Add("Chiudi", new Close(ADD, Inventario));
            ClassList.Add("Usa con...", new UseWith(ADD, Inventario));
            ClassList.Add("Parla", new Speak(ADD, Inventario));
            ClassList.Add("Colpisci", new Hit(ADD, Inventario));
            ClassList.Add("Salva", new Save(ADD, Inventario));
            ClassList.Add("Carica", new Load(ADD, Inventario));
            ClassList.Add("Termina", new End(ADD, Inventario));
            ClassList.Add("Informazioni", new Info(ADD, Inventario));
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
            Font drawFontA = new Font("Arial", 6 + Room_Zoom / 30);
            Font drawFontB = new Font("Arial", 5);
            SolidBrush drawBrush = new SolidBrush(Color.WhiteSmoke);



            RoomData actual = ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault();
            layer = actual.Layer;
            foreach (var r in ADD.Rooms) r.Drawed = false;
            foreach (var r in ADD.Rooms) r.Visited = true;
            DrawMap(actual, cCommon.GAP_FACTOR_X, cCommon.GAP_FACTOR_Y, PenRed, drawFontA, drawBrush, g);
        }

        private void DrawMap(RoomData rd, int x, int y, Pen p, Font drawFont, Brush drawBrush, Graphics g)
        {

            if (rd != null)
            {
                if (!rd.Drawed)
                {
                    PenUsed = AllColors[rd.ColorMap];

                    rd.Drawed = true;
                    rd.Visited = true;
                    g.DrawString(rd.Id.ToString(), new Font("Arial", 6 + Room_Zoom / 30), drawBrush, x + 2 + Room_Zoom / 30 + 6, y + 3 + Room_Zoom / 30 + 6);
                    g.DrawString(rd.Title, drawFont, drawBrush, x + 2 + Room_Zoom / 30 + 6, y + 10 + Room_Zoom / 10 + 6);
                    g.DrawRectangle(p, new Rectangle(x, y, cCommon.ROOM_WIDTH + Room_Zoom, cCommon.ROOM_HEIGHT + Room_Zoom));


                    //Titolo Mappa
                    if (p == PenRed)
                    {
                        label2.Text = string.Format("Luogo: {0} - Piano: {1}", rd.ShortDescription, layer);
                        lblRoomDescription.Text = rd.Title;
                    }

                    //Oggetti in stanza
                    int xObj = 2 + Room_Zoom / 30 + 7;
                    int yObj = (cCommon.ROOM_HEIGHT + Room_Zoom) - Room_Zoom / 4 - 10;
                    Pen colorObject = new Pen(Color.Brown, 1);
                    foreach (ObjectsData obj in rd.Objects)
                    {
                        colorObject = obj.Status == cCommon.STATUS_OPEN ? new Pen(Color.DarkGreen, 1) :
                                      obj.Status == cCommon.STATUS_CLOSED ? new Pen(Color.Brown, 1) :
                                      obj.Status == cCommon.STATUS_LOCKED ? new Pen(Color.DarkOrange, 1) :
                                      obj.Status == cCommon.STATUS_BROKEN ? new Pen(Color.Gray, 1) :
                                                                            new Pen(Color.White);
                        if (obj.Position == "NN")
                        {
                            g.DrawRectangle(colorObject, new Rectangle(x + (cCommon.ROOM_WIDTH + Room_Zoom) / 2 - 5, y, 10, 5));
                        }
                        else
                        if (obj.Position == "NE")
                        {
                            g.DrawRectangle(colorObject, new Rectangle(x + (cCommon.ROOM_WIDTH + Room_Zoom) - 7, y, 7, 7));
                        }
                        else
                        if (obj.Position == "EE")
                        {
                            g.DrawRectangle(colorObject, new Rectangle(x + (cCommon.ROOM_WIDTH + Room_Zoom) - 5, y + (cCommon.ROOM_HEIGHT + Room_Zoom) / 2 - 5, 5, 10));
                        }
                        else
                        if (obj.Position == "SE")
                        {
                            g.DrawRectangle(colorObject, new Rectangle(x + (cCommon.ROOM_WIDTH + Room_Zoom) - 7, y + (cCommon.ROOM_HEIGHT + Room_Zoom) - 7, 7, 7));
                        }
                        else
                        if (obj.Position == "SS")
                        {
                            g.DrawRectangle(colorObject, new Rectangle(x + (cCommon.ROOM_WIDTH + Room_Zoom) / 2 - 5, y + (cCommon.ROOM_HEIGHT + Room_Zoom) - 5, 10, 5));
                        }
                        else
                        if (obj.Position == "SO")
                        {
                            g.DrawRectangle(colorObject, new Rectangle(x, y + (cCommon.ROOM_HEIGHT + Room_Zoom) - 7, 7, 7));
                        }
                        else
                        if (obj.Position == "OO")
                        {
                            g.DrawRectangle(colorObject, new Rectangle(x, y + (cCommon.ROOM_HEIGHT + Room_Zoom) / 2 - 5, 5, 10));
                        }
                        else
                        if (obj.Position == "NO")
                        {
                            g.DrawRectangle(colorObject, new Rectangle(x, y, 7, 7));
                        }
                        else
                        {
                            g.DrawRectangle(colorObject, new Rectangle(x + xObj, y + yObj, 5, 5));
                            xObj += 7;
                        }
                    }

                    //Personaggi in stanza
                    xObj = 2 + Room_Zoom / 30 + 6;
                    yObj = (cCommon.ROOM_HEIGHT + Room_Zoom / 2) - Room_Zoom / 4 + 1;
                    foreach (CharactersData obj in rd.Characters)
                    {
                        SolidBrush color;
                        color = new SolidBrush(GetStatusColor(obj.Status));
                        g.DrawString(obj.Title.Substring(0, 2), new Font("Arial", 6 + Room_Zoom / 30), color, x + xObj, y + yObj);
                        xObj += 12;
                    }

                    //Direzioni percorribili
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
                            x, y - ((cCommon.ROOM_HEIGHT + Room_Zoom) + 5),
                            AllColors[ADD.Rooms.Where(r => r.Id == rd.NN).FirstOrDefault().ColorMap], drawFont, drawBrush, g);
                    }
                    if (rd.NE > 0)
                    {
                        g.DrawLine(p, x + (cCommon.ROOM_WIDTH + Room_Zoom), y, x + (cCommon.ROOM_WIDTH + Room_Zoom) + 3, y - 3);
                        if (ADD.Rooms.Where(r => r.Id == rd.NE).FirstOrDefault().Visited)
                            DrawMap(ADD.Rooms.Where(r => r.Id == rd.NE).FirstOrDefault(),
                            x + (cCommon.ROOM_WIDTH + Room_Zoom + 5), y - ((cCommon.ROOM_HEIGHT + Room_Zoom) + 5),
                            AllColors[ADD.Rooms.Where(r => r.Id == rd.NE).FirstOrDefault().ColorMap], drawFont, drawBrush, g);
                    }
                    if (rd.EE > 0)
                    {
                        g.DrawLine(p, x + (cCommon.ROOM_WIDTH + Room_Zoom), y + (cCommon.ROOM_HEIGHT + Room_Zoom) / 2, x + (cCommon.ROOM_WIDTH + Room_Zoom) + 5, y + (cCommon.ROOM_HEIGHT + Room_Zoom) / 2);
                        if (ADD.Rooms.Where(r => r.Id == rd.EE).FirstOrDefault().Visited)
                            DrawMap(ADD.Rooms.Where(r => r.Id == rd.EE).FirstOrDefault(),
                                x + (cCommon.ROOM_WIDTH + Room_Zoom + 5), y,
                                AllColors[ADD.Rooms.Where(r => r.Id == rd.EE).FirstOrDefault().ColorMap], drawFont, drawBrush, g);
                    }
                    if (rd.SE > 0)
                    {
                        g.DrawLine(p, x + (cCommon.ROOM_WIDTH + Room_Zoom), y + (cCommon.ROOM_HEIGHT + Room_Zoom), x + (cCommon.ROOM_WIDTH + Room_Zoom) + 3, y + (cCommon.ROOM_HEIGHT + Room_Zoom) + 3);
                        if (ADD.Rooms.Where(r => r.Id == rd.SE).FirstOrDefault().Visited)
                            DrawMap(ADD.Rooms.Where(r => r.Id == rd.SE).FirstOrDefault(),
                            x + (cCommon.ROOM_WIDTH + Room_Zoom + 5), y + ((cCommon.ROOM_HEIGHT + Room_Zoom) + 5),
                            AllColors[ADD.Rooms.Where(r => r.Id == rd.SE).FirstOrDefault().ColorMap], drawFont, drawBrush, g);
                    }
                    if (rd.SS > 0)
                    {
                        g.DrawLine(p, x + (cCommon.ROOM_WIDTH + Room_Zoom) / 2, y + (cCommon.ROOM_HEIGHT + Room_Zoom), x + (cCommon.ROOM_WIDTH + Room_Zoom) / 2, y + ((cCommon.ROOM_HEIGHT + Room_Zoom)) + 5);
                        if (ADD.Rooms.Where(r => r.Id == rd.SS).FirstOrDefault().Visited)
                            DrawMap(ADD.Rooms.Where(r => r.Id == rd.SS).FirstOrDefault(),
                            x, y + ((cCommon.ROOM_HEIGHT + Room_Zoom) + 5),
                            AllColors[ADD.Rooms.Where(r => r.Id == rd.SS).FirstOrDefault().ColorMap], drawFont, drawBrush, g);
                    }
                    if (rd.SO > 0)
                    {
                        g.DrawLine(p, x, y + (cCommon.ROOM_HEIGHT + Room_Zoom), x - 3, y + (cCommon.ROOM_HEIGHT + Room_Zoom) + 3);
                        if (ADD.Rooms.Where(r => r.Id == rd.SO).FirstOrDefault().Visited)
                            DrawMap(ADD.Rooms.Where(r => r.Id == rd.SO).FirstOrDefault(),
                            x - (cCommon.ROOM_WIDTH + Room_Zoom + 5), y + ((cCommon.ROOM_HEIGHT + Room_Zoom) + 5),
                            AllColors[ADD.Rooms.Where(r => r.Id == rd.SO).FirstOrDefault().ColorMap], drawFont, drawBrush, g);
                    }
                    if (rd.OO > 0)
                    {
                        g.DrawLine(p, x, y + ((cCommon.ROOM_HEIGHT + Room_Zoom)) / 2, x - 5, y + ((cCommon.ROOM_HEIGHT + Room_Zoom)) / 2);
                        if (ADD.Rooms.Where(r => r.Id == rd.OO).FirstOrDefault().Visited)
                            DrawMap(ADD.Rooms.Where(r => r.Id == rd.OO).FirstOrDefault(),
                            x - (cCommon.ROOM_WIDTH + Room_Zoom + 5), y,
                            AllColors[ADD.Rooms.Where(r => r.Id == rd.OO).FirstOrDefault().ColorMap], drawFont, drawBrush, g);
                    }
                    if (rd.NO > 0)
                    {
                        g.DrawLine(p, x, y, x - 3, y - 3);
                        if (ADD.Rooms.Where(r => r.Id == rd.NO).FirstOrDefault().Visited)
                            DrawMap(ADD.Rooms.Where(r => r.Id == rd.NO).FirstOrDefault(),
                            x - (cCommon.ROOM_WIDTH + Room_Zoom + 5), y - ((cCommon.ROOM_HEIGHT + Room_Zoom) + 5),
                            AllColors[ADD.Rooms.Where(r => r.Id == rd.NO).FirstOrDefault().ColorMap], drawFont, drawBrush, g);
                    }
                }
            }
        }

        private Color GetStatusColor(string pStatus)
        {
            Color ret = new Color();
            ret = Color.Gainsboro;
            switch (pStatus)
            {
                case cCommon.STATUS_STATIC:
                    ret = Color.Yellow;
                    break;
                case cCommon.STATUS_FRIEND:
                    ret = Color.SteelBlue;
                    break;
                case cCommon.STATUS_DEAD:
                    ret = Color.Gray;
                    break;
            }
            return ret;
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
            int r1 = 55;
            int g1 = 105;
            int b1 = 155;
            int x = BTN_GAP;
            int y = lblAction.Top + lblAction.Height + BTN_GAP;

            foreach (ActionData a in Actions.List)
            {
                r = r - 2;
                g = g + 3;
                b = b + 3;
                r1 = 255 - r;
                g1 = 255 - g;
                b1 = 255 - b;
                Color color = Color.FromArgb(r, g, b);
                Color foreColor = Color.FromArgb(r1, g1, b1);
                if (a != null)
                {

                    pnlActions.Controls.Add(GetButton(x, y, a, color, foreColor, new EventHandler(btnActions_Click)));
                    if (x < 355 - BTN_WIDTH)
                    {
                        x += BTN_WIDTH + BTN_INTER_GAP;
                    }
                    else
                    {
                        x = BTN_GAP;
                        y += BTN_HEIGHT + BTN_INTER_GAP;
                    }
                }
            }
        }

        private void ViewObjects()
        {
            int r = 150;
            int g = 200;
            int b = 52;

            int x = BTN_GAP;
            int y = lblAction.Top + lblAction.Height + BTN_GAP;

            foreach (Control p in pnlObjects.Controls.OfType<Button>().ToList()) pnlObjects.Controls.Remove(p);

            foreach (ObjectsData o in ADD.Rooms.Where(l => l.Id == ADD.CurrentRoom).FirstOrDefault().Objects)
            {
                r = r + 3;
                g = g - 2;
                b = b + 3;
                Color color = Color.FromArgb(r, g, b);
                Color foreColor = Color.Black;
                switch (o.Status)
                {
                    case cCommon.STATUS_CLOSED:
                        foreColor = Color.DarkRed;
                        break;
                    case cCommon.STATUS_OPEN:
                        foreColor = Color.DarkGreen;
                        break;
                    case cCommon.STATUS_STATIC:
                        foreColor = Color.Yellow;
                        break;
                }
                if (o != null)
                {
                    pnlObjects.Controls.Add(GetButton(x, y, o, color, foreColor, new EventHandler(btnObjects_Click)));
                    if (x < 300 - BTN_WIDTH)
                    {
                        x += BTN_WIDTH + BTN_INTER_GAP;
                    }
                    else
                    {
                        x = BTN_GAP;
                        y += BTN_HEIGHT + BTN_INTER_GAP;
                    }
                }
            }
        }

        private void ViewCharacters()
        {
            int r = 50;
            int g = 20;
            int b = 200;
            int r1 = 50;
            int g1 = 20;
            int b1 = 200;
            int x = BTN_GAP;
            int y = lblAction.Top + lblAction.Height + BTN_GAP;

            foreach (Control p in pnlPerson.Controls.OfType<Button>().ToList()) pnlPerson.Controls.Remove(p);

            foreach (CharactersData o in ADD.Rooms.Where(l => l.Id == ADD.CurrentRoom).FirstOrDefault().Characters)
            {
                r = r - 2;
                g = g + 3;
                b = b + 3;
                r1 = 255 - r;
                g1 = 255 - g;
                b1 = 255 - b;
                Color color = Color.FromArgb(r, g, b);
                Color foreColor = Color.FromArgb(r1, g1, b1);
                if (o != null)
                {
                    pnlPerson.Controls.Add(GetButton(x, y, o, color, foreColor, new EventHandler(btnCharacters_Click)));
                    if (x < 300 - BTN_WIDTH)
                    {
                        x += BTN_WIDTH + BTN_INTER_GAP;
                    }
                    else
                    {
                        x = BTN_GAP;
                        y += BTN_HEIGHT + BTN_INTER_GAP;
                    }
                }
            }
        }

        private void ViewInventario()
        {
            int r = 180;
            int g = 10;
            int b = 80;
            int r1 = 180;
            int g1 = 10;
            int b1 = 100;
            int x = BTN_GAP;
            int y = lblAction.Top + lblAction.Height + BTN_GAP;

            foreach (Control p in pnlInventario.Controls.OfType<Button>().ToList()) pnlInventario.Controls.Remove(p);

            foreach (ObjectsData o in Inventario)
            {
                r = r - 3;
                g = g + 2;
                b = b - 2;
                r1 = 255 - r;
                g1 = 255 - g;
                b1 = 255 - b;
                Color color = Color.FromArgb(r, g, b);
                Color foreColor = Color.FromArgb(r1, g1, b1);
                if (o != null)
                {
                    pnlInventario.Controls.Add(GetButton(x, y, o, color, foreColor, new EventHandler(btnInventario_Click)));
                    if (x < 300 - (BTN_WIDTH + BTN_GAP))
                    {
                        x += BTN_WIDTH + BTN_INTER_GAP;
                    }
                    else
                    {
                        x = BTN_GAP;
                        y += BTN_HEIGHT + BTN_INTER_GAP;
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
            //Header
            lblRoomsVisited.Text = String.Format("Luoghi visitati: {0} su {1}", User.RoomsVisitedCount().ToString(), ADD.Rooms.Count);
            lblCharacterEncountered.Text = String.Format("Personaggi incontrati: {0}", User.CharactersMeetCount().ToString());
            lblPunteggio.Text = String.Format("Punteggio: {0}", User.Points.ToString());
            lblTitleAdventure.Text = ADD.Title;

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

            CurrentAction = ClassList[direction];
            Object = null;
            Complement = null;
            ADD.Direction = direction;
            MoveCharacter();
            txtResult.Text = CurrentAction.Execute(Character, Object, Complement, ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault()).Message;

            foreach (CharactersData c in ADD.ActualRoom().Characters)
                User.AddCharacterMeet(c);

            User.AddRoom(ADD.ActualRoom());
            ViewData();
            ViewMap();
        }
        private void MoveCharacter()
        {
            foreach (RoomData r in ADD.Rooms)
            {
                if (r.Visited)
                {
                    for (int i = r.Characters.Count - 1; i >= 0; i--)
                    {
                        if (r.Characters[i].Status != cCommon.STATUS_STATIC)
                        {
                            int newIdRoom = GetNewRoom(r, r.Characters[i].IdRoom);

                            if (r.Characters[i].Status == cCommon.STATUS_FRIEND ||
                                r.Characters[i].Status == ADD.Rooms.Where(ro => ro.Id == newIdRoom).FirstOrDefault().ShortDescription)
                            {
                                r.Characters[i].IdRoom = newIdRoom;

                                ADD.Rooms.Where(ro => ro.Id == r.Characters[i].IdRoom).FirstOrDefault().Characters.Add(r.Characters[i]);
                                r.Characters.Remove(r.Characters[i]);
                            }
                        }
                    }
                }
            }
        }
        Random rnd = new Random();
        private int GetNewRoom(RoomData pR, int pIdRoom)
        {

            List<int> newRooms = new List<int>();
            newRooms.Add(pR.NE);
            newRooms.Add(pR.NN);
            newRooms.Add(pR.NO);
            newRooms.Add(pR.OO);
            newRooms.Add(pR.SE);
            newRooms.Add(pR.SO);
            newRooms.Add(pR.SS);
            newRooms.Add(pR.AA);
            newRooms.Add(pR.BB);
            newRooms.Add(pR.EE);

            int ret = newRooms[rnd.Next(0, newRooms.Count)];

            return ret == -1 ? pIdRoom : ret;
        }

        private void btnObjects_Click(object sender, EventArgs e)
        {
            if (CurrentAction != null)
            {
                Response response = null;
                Button btn = (Button)sender;

                SetActions(Action, btn.Tag as ObjectsData);
                response = CurrentAction.Execute(Character, Object, Complement, ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault());
                txtResult.Text = response.Message;
                if (response.Success)
                {
                    //CurrentAction = null;
                    Object = null;
                    Complement = null;
                    Character = null;
                }
                ViewData();
                ViewMap();
            }
        }

        private void btnCharacters_Click(object sender, EventArgs e)
        {
            if (CurrentAction != null)
            {
                Response response = null;

                Button btn = (Button)sender;

                SetActionsCharacter(Action, btn.Tag as CharactersData);
                response = CurrentAction.Execute(Character, Object, Complement, ADD.Rooms.Where(r => r.Id == ADD.CurrentRoom).FirstOrDefault());
                txtResult.Text = response.Message;
                if (response.Success)
                {
                    //CurrentAction = null;
                    Object = null;
                    Complement = null;
                    Character = null;
                }
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
            Character = null;
            Response r = CurrentAction.Execute(Character, Object, Complement, ADD.Rooms.Where(rs => rs.Id == ADD.CurrentRoom).FirstOrDefault());
            txtResult.Text = r.Message;

            ViewData();
            ViewMap();
            if (r.Value.ToString() == "END") Close();
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
                cCommon.GAP_FACTOR_X -= dx;
                cCommon.GAP_FACTOR_Y -= dy;
                dx = e.X - lastLocation.X;
                dy = e.Y - lastLocation.Y;

                cCommon.GAP_FACTOR_X += dx;
                cCommon.GAP_FACTOR_Y += dy;
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
            cCommon.GAP_FACTOR_X += dx;
            cCommon.GAP_FACTOR_Y += dy;
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

        private void tmrAdv_Tick(object sender, EventArgs e)
        {
            ADD.IncrementTime();
            lblDate.Text = ADD.CurrentDate;
            lblHour.Text = ADD.CurrentTime;
        }
    }
}