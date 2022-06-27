using Gema2022.Class;
using Gema2022.CommonClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADVBuilder_1.Model
{
    public class Directions : cOggettoData
    {
        private const string SELECTBYID = "SelectById";
        public List<DirectionsData> List = new List<DirectionsData>();
        public Directions()
        {
            Settings(this.GetType().Name);
            ReadData();
            ReadList(List);
        }
        public Directions(int pIdRoom)
        {
            Settings(this.GetType().Name);
            ReadData(pIdRoom);
            ReadList(List);
        }
        private void ReadData(int pIdRoom)
        {
            if (Open())
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("IDROOM", pIdRoom);
                Table = ExecuteQuery(SELECTBYID, param, PercorsoFileXml);
                Close();
            }
        }
    }
    public class DirectionsData
    {
        #region Properties
        [cAttributes(Name = "NN")] public int NN { get; set; }
        [cAttributes(Name = "NE")] public int NE { get; set; }
        [cAttributes(Name = "EE")] public int EE { get; set; }
        [cAttributes(Name = "SE")] public int SE { get; set; }
        [cAttributes(Name = "SS")] public int SS { get; set; }
        [cAttributes(Name = "SO")] public int SO { get; set; }
        [cAttributes(Name = "OO")] public int OO { get; set; }
        [cAttributes(Name = "NO")] public int NO { get; set; }
        [cAttributes(Name = "AA")] public int AA { get; set; }
        [cAttributes(Name = "BB")] public int BB { get; set; }
        #endregion  
    }
}
