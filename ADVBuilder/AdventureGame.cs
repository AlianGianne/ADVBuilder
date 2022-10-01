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
        private const int BTN_INTER_GAP = 2;
        private const int BTN_GAP = 5;
        private int Room_Zoom = 50;
        private bool Dragging;
        private Point lastLocation;
        private iActions CurrentAction;
        private Dictionary<string, iActions> ClassList = new Dictionary<string, iActions>();
        private int dx;
        private int dy;
        private int layer = 0;

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
        //public AdventureData ADD;

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
            InitializeGame();
            InitializeFunction();
            InitializeColors();
            ViewData();
            ViewActions();
            ViewMap();
        }

        private void InitializeGame()
        {
            RoomIdSelected = User.ADD.CurrentRoom;
        }

        private void InitializeUser()
        {
            User = new User();
            User.Name = "Alessandro";
            User.Surname = "Iannarelli";
            User.UserName = "AlianGianne";
            User.Points = 0;
            User.Xp = 0;
            User.Level = 1;
            User.XpNextLevel = 10;
            User.ADD = ADV.List.FirstOrDefault();
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


                cCommon.GAP_FACTOR_X = (pcbMap.Image.Width - (cCommon.ROOM_WIDTH + Room_Zoom)) / 2;
                cCommon.GAP_FACTOR_Y = (pcbMap.Image.Height - (cCommon.ROOM_HEIGHT + Room_Zoom)) / 2;
            }
        }

        private void InitializeFunction()
        {
            ClassList.Add("Prendi", new Take(User, User.Inventario));
            ClassList.Add("Lascia", new Drop(User, User.Inventario));
            ClassList.Add("Getta", new Drop(User, User.Inventario));
            ClassList.Add("Guarda", new Examinate(User, User.Inventario));
            ClassList.Add("Esamina", new Examinate(User, User.Inventario));
            ClassList.Add("Osserva", new Examinate(User, User.Inventario));
            ClassList.Add("Apri", new Open(User, User.Inventario));
            ClassList.Add("Chiudi", new Close(User, User.Inventario));
            ClassList.Add("Usa con...", new UseWith(User, User.Inventario));
            ClassList.Add("Parla", new Speak(User, User.Inventario));
            ClassList.Add("Colpisci", new Hit(User, User.Inventario));
            ClassList.Add("Consegna", new Give(User, User.Inventario));
            ClassList.Add("Salva", new Save(User, User.Inventario));
            ClassList.Add("Carica", new Load(User, User.Inventario));
            ClassList.Add("Termina", new End(User, User.Inventario));
            ClassList.Add("Informazioni", new Info(User, User.Inventario));
            ClassList.Add("Inimplementato", new Unable(User, User.Inventario));
            ClassList.Add("NN", new Go(User, User.Inventario));
            ClassList.Add("NE", new Go(User, User.Inventario));
            ClassList.Add("EE", new Go(User, User.Inventario));
            ClassList.Add("SE", new Go(User, User.Inventario));
            ClassList.Add("SS", new Go(User, User.Inventario));
            ClassList.Add("SO", new Go(User, User.Inventario));
            ClassList.Add("OO", new Go(User, User.Inventario));
            ClassList.Add("NO", new Go(User, User.Inventario));
            ClassList.Add("AA", new Go(User, User.Inventario));
            ClassList.Add("BB", new Go(User, User.Inventario));
        }

        private void ViewMap()
        {
            pcbMap.Image = Image.FromFile("Images/Papiro 2.jpg");
            Graphics g = Graphics.FromImage(pcbMap.Image);
            Font drawFontA = new Font("Arial", 6 + Room_Zoom / 30);
            Font drawFontB = new Font("Arial", 5);
            SolidBrush drawBrush = new SolidBrush(Color.WhiteSmoke);



            RoomData actual = User.ADD.ActualRoom();
            layer = actual.Layer;
            foreach (var r in User.ADD.Rooms) r.Drawed = false;
            //foreach (var r in User.ADD.Rooms) r.Visited = true;
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
                                      obj.Status == cCommon.STATUS_CLOSED ? new Pen(Color.LightBlue, 1) :
                                      obj.Status == cCommon.STATUS_LOCKED ? new Pen(Color.DarkOrange, 1) :
                                      obj.Status == cCommon.STATUS_BROKEN ? new Pen(Color.Gray, 1) :
                                      obj.Status == cCommon.STATUS_TAKE ? new Pen(Color.White, 1) :
                                      obj.Status == cCommon.STATUS_STATIC ? new Pen(Color.Yellow, 1) :
                                                                            new Pen(Color.WhiteSmoke);
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
                        if (User.ADD.Rooms.Where(r => r.Id == rd.NN).FirstOrDefault().Visited)
                            DrawMap(User.ADD.Rooms.Where(r => r.Id == rd.NN).FirstOrDefault(),
                            x, y - ((cCommon.ROOM_HEIGHT + Room_Zoom) + 5),
                            AllColors[User.ADD.Rooms.Where(r => r.Id == rd.NN).FirstOrDefault().ColorMap], drawFont, drawBrush, g);
                    }
                    if (rd.NE > 0)
                    {
                        g.DrawLine(p, x + (cCommon.ROOM_WIDTH + Room_Zoom), y, x + (cCommon.ROOM_WIDTH + Room_Zoom) + 3, y - 3);
                        if (User.ADD.Rooms.Where(r => r.Id == rd.NE).FirstOrDefault().Visited)
                            DrawMap(User.ADD.Rooms.Where(r => r.Id == rd.NE).FirstOrDefault(),
                            x + (cCommon.ROOM_WIDTH + Room_Zoom + 5), y - ((cCommon.ROOM_HEIGHT + Room_Zoom) + 5),
                            AllColors[User.ADD.Rooms.Where(r => r.Id == rd.NE).FirstOrDefault().ColorMap], drawFont, drawBrush, g);
                    }
                    if (rd.EE > 0)
                    {
                        g.DrawLine(p, x + (cCommon.ROOM_WIDTH + Room_Zoom), y + (cCommon.ROOM_HEIGHT + Room_Zoom) / 2, x + (cCommon.ROOM_WIDTH + Room_Zoom) + 5, y + (cCommon.ROOM_HEIGHT + Room_Zoom) / 2);
                        if (User.ADD.Rooms.Where(r => r.Id == rd.EE).FirstOrDefault().Visited)
                            DrawMap(User.ADD.Rooms.Where(r => r.Id == rd.EE).FirstOrDefault(),
                                x + (cCommon.ROOM_WIDTH + Room_Zoom + 5), y,
                                AllColors[User.ADD.Rooms.Where(r => r.Id == rd.EE).FirstOrDefault().ColorMap], drawFont, drawBrush, g);
                    }
                    if (rd.SE > 0)
                    {
                        g.DrawLine(p, x + (cCommon.ROOM_WIDTH + Room_Zoom), y + (cCommon.ROOM_HEIGHT + Room_Zoom), x + (cCommon.ROOM_WIDTH + Room_Zoom) + 3, y + (cCommon.ROOM_HEIGHT + Room_Zoom) + 3);
                        if (User.ADD.Rooms.Where(r => r.Id == rd.SE).FirstOrDefault().Visited)
                            DrawMap(User.ADD.Rooms.Where(r => r.Id == rd.SE).FirstOrDefault(),
                            x + (cCommon.ROOM_WIDTH + Room_Zoom + 5), y + ((cCommon.ROOM_HEIGHT + Room_Zoom) + 5),
                            AllColors[User.ADD.Rooms.Where(r => r.Id == rd.SE).FirstOrDefault().ColorMap], drawFont, drawBrush, g);
                    }
                    if (rd.SS > 0)
                    {
                        g.DrawLine(p, x + (cCommon.ROOM_WIDTH + Room_Zoom) / 2, y + (cCommon.ROOM_HEIGHT + Room_Zoom), x + (cCommon.ROOM_WIDTH + Room_Zoom) / 2, y + ((cCommon.ROOM_HEIGHT + Room_Zoom)) + 5);
                        if (User.ADD.Rooms.Where(r => r.Id == rd.SS).FirstOrDefault().Visited)
                            DrawMap(User.ADD.Rooms.Where(r => r.Id == rd.SS).FirstOrDefault(),
                            x, y + ((cCommon.ROOM_HEIGHT + Room_Zoom) + 5),
                            AllColors[User.ADD.Rooms.Where(r => r.Id == rd.SS).FirstOrDefault().ColorMap], drawFont, drawBrush, g);
                    }
                    if (rd.SO > 0)
                    {
                        g.DrawLine(p, x, y + (cCommon.ROOM_HEIGHT + Room_Zoom), x - 3, y + (cCommon.ROOM_HEIGHT + Room_Zoom) + 3);
                        if (User.ADD.Rooms.Where(r => r.Id == rd.SO).FirstOrDefault().Visited)
                            DrawMap(User.ADD.Rooms.Where(r => r.Id == rd.SO).FirstOrDefault(),
                            x - (cCommon.ROOM_WIDTH + Room_Zoom + 5), y + ((cCommon.ROOM_HEIGHT + Room_Zoom) + 5),
                            AllColors[User.ADD.Rooms.Where(r => r.Id == rd.SO).FirstOrDefault().ColorMap], drawFont, drawBrush, g);
                    }
                    if (rd.OO > 0)
                    {
                        g.DrawLine(p, x, y + ((cCommon.ROOM_HEIGHT + Room_Zoom)) / 2, x - 5, y + ((cCommon.ROOM_HEIGHT + Room_Zoom)) / 2);
                        if (User.ADD.Rooms.Where(r => r.Id == rd.OO).FirstOrDefault().Visited)
                            DrawMap(User.ADD.Rooms.Where(r => r.Id == rd.OO).FirstOrDefault(),
                            x - (cCommon.ROOM_WIDTH + Room_Zoom + 5), y,
                            AllColors[User.ADD.Rooms.Where(r => r.Id == rd.OO).FirstOrDefault().ColorMap], drawFont, drawBrush, g);
                    }
                    if (rd.NO > 0)
                    {
                        g.DrawLine(p, x, y, x - 3, y - 3);
                        if (User.ADD.Rooms.Where(r => r.Id == rd.NO).FirstOrDefault().Visited)
                            DrawMap(User.ADD.Rooms.Where(r => r.Id == rd.NO).FirstOrDefault(),
                            x - (cCommon.ROOM_WIDTH + Room_Zoom + 5), y - ((cCommon.ROOM_HEIGHT + Room_Zoom) + 5),
                            AllColors[User.ADD.Rooms.Where(r => r.Id == rd.NO).FirstOrDefault().ColorMap], drawFont, drawBrush, g);
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
            int r = 250;
            int g = 150;
            int b = 100;
            int r1 = 55;
            int g1 = 105;
            int b1 = 155;
            int x = BTN_GAP;
            int y = lblAction.Top + lblAction.Height + BTN_GAP;

            foreach (ActionData a in Actions.List)
            {
                int r3 = 0;
                int g3 = 0;
                int b3 = 0;
                r = r - 1;
                g = g + 2;
                b = b + 3;
                r1 = 255 - r;
                g1 = 255 - g;
                b1 = 255 - b;
                if (a.DeepObjects < 0)
                {
                    r3 = -50;
                    g3 = 150;
                    b3 = 100;
                }
                Color color = Color.FromArgb(r + r3, g - g3, b - b3);
                Color foreColor = Color.FromArgb(r1 - r3, g1 + g3, b1 + b3);
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

            foreach (ObjectsData o in User.ADD.Rooms.Where(l => l.Id == User.ADD.CurrentRoom).FirstOrDefault().Objects)
            {
                r = r + 2;
                g = g - 4;
                b = b + 1;
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

            foreach (CharactersData o in User.ADD.Rooms.Where(l => l.Id == User.ADD.CurrentRoom).FirstOrDefault().Characters)
            {
                r = r + 2;
                g = g + 3;
                b = b - 3;
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

            foreach (ObjectsData o in User.Inventario)
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
                        btn.Enabled = User.ADD.ActualRoom().NN > 0;
                        break;

                    case "NE":
                        btn.Enabled = User.ADD.ActualRoom().NE > 0;
                        break;

                    case "EE":
                        btn.Enabled = User.ADD.ActualRoom().EE > 0;
                        break;

                    case "SE":
                        btn.Enabled = User.ADD.ActualRoom().SE > 0;
                        break;

                    case "SS":
                        btn.Enabled = User.ADD.ActualRoom().SS > 0;
                        break;

                    case "SO":
                        btn.Enabled = User.ADD.ActualRoom().SO > 0;
                        break;

                    case "OO":
                        btn.Enabled = User.ADD.ActualRoom().OO > 0;
                        break;

                    case "NO":
                        btn.Enabled = User.ADD.ActualRoom().NO > 0;
                        break;

                    case "AA":
                        btn.Enabled = User.ADD.ActualRoom().AA > 0;
                        break;

                    case "BB":
                        btn.Enabled = User.ADD.ActualRoom().BB > 0;
                        break;
                }
                btn.BackColor = !btn.Enabled ? Color.LightGray : Color.LightSalmon;
            }
        }

        private void ViewData()
        {
            //Header
            lblRoomsVisited.Text = String.Format("Luoghi visitati: {0} su {1}", User.RoomsVisitedCount().ToString(), User.ADD.Rooms.Count);
            lblCharacterEncountered.Text = String.Format("Personaggi incontrati: {0}", User.CharactersMeetCount().ToString());
            lblPunteggio.Text = String.Format("Punteggio: {0}", User.Points.ToString());
            lblTitleAdventure.Text = User.ADD.Title;
            lblEta.Text = String.Format("Età: {0}", User.Age.ToString()); ;
            lblName.Text = String.Format("Nome: {0}", User.Name);
            lblLifePoint.Text = String.Format("Vita: {0}", User.Life.ToString());
            lblLevel.Text = string.Format("Livello: {0}", User.Level);
            lblNextXP.Text = string.Format("XP livello successivo: {0}", User.XpNextLevel);
            lblXP.Text = string.Format("XP: {0}", User.Xp);
            //Rooms
            txtRoomDescription.Text = User.ADD.ViewRoom();

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
            CurrentAction.SetUser(User);
            NullifyObjects();
            User.ADD.Direction = direction;
            MoveCharacter();
            txtResult.Text = CurrentAction.Execute(Character, Object, Complement, User.ADD.ActualRoom()).Message;

            foreach (CharactersData c in User.ADD.ActualRoom().Characters)
                User.AddCharacterMeet(c);
            User.AddRoom(User.ADD.ActualRoom());

            ViewData();
            ViewMap();
        }
        private void MoveCharacter()
        {
            //TODO: Inserire movimento automatico dei Character nel modulo ADD
            foreach (RoomData r in User.ADD.Rooms)
            {
                if (r.Visited)
                {
                    for (int i = r.Characters.Count - 1; i >= 0; i--)
                    {
                        if (r.Characters[i].Status != cCommon.STATUS_STATIC)
                        {
                            int newIdRoom = GetNewRoom(r, r.Characters[i].IdRoom);

                            if (r.Characters[i].Status == cCommon.STATUS_FRIEND ||
                                r.Characters[i].Status == User.ADD.Rooms.Where(ro => ro.Id == newIdRoom).FirstOrDefault().ShortDescription)
                            {
                                r.Characters[i].IdRoom = newIdRoom;

                                User.ADD.Rooms.Where(ro => ro.Id == r.Characters[i].IdRoom).FirstOrDefault().Characters.Add(r.Characters[i]);
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
                CurrentAction.SetUser(User);
                SetActions(Action, btn.Tag as ObjectsData);
                response = CurrentAction.Execute(Character, Object, Complement, User.ADD.ActualRoom());
                txtResult.Text = response.Message;
                if (response.Success)
                {
                    NullifyObjects();
                }

                EvaluateXP(response);

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
                CurrentAction.SetUser(User);
                SetActionsCharacter(Action, btn.Tag as CharactersData);
                response = CurrentAction.Execute(Character, Object, Complement, User.ADD.ActualRoom());
                txtResult.Text = response.Message;
                if (response.Success)
                {
                    NullifyObjects();
                }

                EvaluateXP(response);

                ViewData();
                ViewMap();
            }
        }

        private void btnActions_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            SetCurrentAction(btn);

            NullifyObjects();

            Response r = CurrentAction.Execute(Character, Object, Complement, User.ADD.ActualRoom());
            txtResult.Text = r.Message;

            EvaluateResponse(r);

            EvaluateXP(r);

            ViewData();
            ViewMap();

        }

        private void NullifyObjects()
        {
            Object = null;
            Complement = null;
            Character = null;
        }

        private void SetCurrentAction(Button btn)
        {
            CurrentAction = ClassList.Where(cl => cl.Key == btn.Text).FirstOrDefault().Value;
            if (CurrentAction == null)
            {
                CurrentAction = ClassList["Inimplementato"];
                CurrentAction.Dialog = -1;
            }
            else
                CurrentAction.Dialog = (btn.Tag as ActionData).Dialog;
            CurrentAction.SetUser(User);            
        }

        private void EvaluateXP(Response r)
        {
            //TODO: Rivedere calcolo xp livello successivo
            if (r.Value.ToString().StartsWith("XP"))
            {
                string[] vet = r.Value.ToString().Split('|');
                User.Xp += int.Parse(vet[1]);
                if (User.Xp > User.XpNextLevel) { User.Level += 1; User.XpNextLevel = User.XpNextLevel * (User.Level / 2); }
            }
        }
        
        private void EvaluateResponse(Response r)
        {
            if (r.Value.ToString() == cCommon.RESULT_ACTION_END) Close();
            if (r.Value.ToString() == cCommon.RESULT_ACTION_SHOW) { ShowInternalDialog(r); }
            if (r.Value is User) { User = (User)r.Value; }
        }

        private void ShowInternalDialog(Response r, string btn1 = "SI", string btn2 = "NO")
        {
            using (var bmp = new Bitmap(this.Width, this.Height))
            {
                this.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                pnlDialog.BackgroundImage = bmp;
                lblDialogMessage.Text = r.Message;
                pnlDialog.Location = new Point(-8, -31);
                pnlDialog.BringToFront();
                pnlDialog.Visible = true;
                btnChooseSi.Visible = true;
                btnChooseNo.Visible = true;
                btnChooseSi.Text = btn1;
                btnChooseNo.Text = btn2;
                if (CurrentAction.Dialog == -1)
                {
                    btnChooseSi.Visible = false;
                    btnChooseNo.Text = "Ok";
                }
            }
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
                txtResult.Text = CurrentAction.Execute(Character, Object, Complement, User.ADD.ActualRoom()).Message;
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
            if (User.ADD.IncrementTime()) User.Age++; ;
            lblDate.Text = User.ADD.CurrentDate;
            lblHour.Text = User.ADD.CurrentTime;
            lblTipoGiornata.Text = User.ADD.CurrentDayTime;
        }

        private void btnChooseNo_Click(object sender, EventArgs e)
        {
            CurrentAction.Dialog = cCommon.RESULT_ACTION_NO;
            Response r = CurrentAction.Execute(Character, Object, Complement, User.ADD.ActualRoom());
            txtResult.Text = r.Message;
            pnlDialog.Visible = false;

            EvaluateResponse(r);

            EvaluateXP(r);

            ViewData();
            ViewMap();
        }

        private void btnChooseSi_Click(object sender, EventArgs e)
        {
            CurrentAction.Dialog = cCommon.RESULT_ACTION_YES;
            Response r = CurrentAction.Execute(Character, Object, Complement, User.ADD.ActualRoom());
            txtResult.Text = r.Message;
            pnlDialog.Visible = false;

            EvaluateResponse(r);

            EvaluateXP(r);

            ViewData();
            ViewMap();
        }
    }
}