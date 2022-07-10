using Gema2022.Class;
using Gema2022.CommonClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ADVBuilder_1.Model
{
    public class Room : cOggettoData
    {
        private const string SELECTBYID = "SelectById";
        public List<RoomData> List = new List<RoomData>();
        public List<string> Directions;
        public Room()
        {
            Settings(this.GetType().Name);
            ReadData();
            ReadOther();

        }

        private void ReadOther()
        {
            ReadList(List);
            Directions = ReadDirections();
            ////////////////
            ReadObjects();
        }

        private List<string> ReadDirections()
        {
            return new List<string>(){ "AA", "BB", "NN", "NE", "EE", "SE", "SS", "SO", "OO", "NO"};
        }

        public Room(int pIdAdv)
        {
            Settings(this.GetType().Name);
            ReadData(pIdAdv);
            ReadOther();
        }
        public void ReadObjects()
        {
            foreach (RoomData rm in List)
            {
                Objects ob = new Objects(rm.Id);
                rm.Objects = ob.List;
            }
        }
        
        private void ReadData(int pIdAdv)
        {
            if (Open())
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("IDADV", pIdAdv);
                Table = ExecuteQuery(SELECTBYID, param, PercorsoFileXml);
                Close();
            }
        }
    }
    public class RoomData
    {
        #region Properties
        [cAttributes(Name = "Id")] public int Id { get; set; }                         //Id stanza 
        [cAttributes(Name = "IdAdv")] public int IdAdv { get; set; }                      //Id avventura
        [cAttributes(Name = "Title")] public string Title { get; set; }                   //Titolo
        [cAttributes(Name = "Description")] public string Description { get; set; }             //Descrizione
        [cAttributes(Name = "ShortDescription")] public string ShortDescription { get; set; }        //Descrizione breve
        [cAttributes(Name = "NN")] public int NN { get; set; }
        [cAttributes(Name = "NE")] public int NE { get; set; }
        [cAttributes(Name = "EE")] public int EE { get; set; }
        [cAttributes(Name = "SE")] public int SE { get; set; }
        [cAttributes(Name = "SS")] public int SS { get; set; }
        [cAttributes(Name = "SO")] public int SO { get; set; }
        [cAttributes(Name = "OO")] public int OO { get; set; }
        [cAttributes(Name = "NO")] public int NO { get; set; }
        [cAttributes(Name = "AA")] public int AA { get; set; }
        [cAttributes(Name = "BB")] public int BB { get; set; }                  //Direzioni perseguibili (Nord, Nord/est, Est, Sud/Est, Sud, Sud/Ovest, Ovest, Nord/Ovest, Alto, Basso)
        public int Layer { get; set; }
        public bool Visited { get; set; } = false;
        public List<string> Directions { get; set; }
        public List<ObjectsData> Objects { get; set; }                          //Eventuali oggetti presenti
        public bool Drawed { get; set; }
        #endregion
    }
}
