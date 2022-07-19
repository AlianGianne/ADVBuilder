using Gema2022.Class;
using Gema2022.CommonClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADVBuilder_1.Model
{
    public class Objects : cOggettoData
    {
        private const string SELECTBYID = "SelectById";
        public List<ObjectsData> List = new List<ObjectsData>();
        public Objects()
        {
            Settings(this.GetType().Name);
            ReadData();
            ReadList(List);
        }
        public Objects(int pIdRoom)
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
    public class ObjectsData
    {
        [cAttributes(Name = "Id")] public int Id { get; set; }
        [cAttributes(Name = "Title")] public string Title { get; set; }
        [cAttributes(Name = "Description")] public string Description { get; set; }
        [cAttributes(Name = "ShortDescription")] public string ShortDescription { get; set; }
        [cAttributes(Name = "IdRoom")] public int IdRoom { get; set; }
        [cAttributes(Name = "Position")] public string Position { get; set; }
        [cAttributes(Name = "Status")] public string Status { get; set; }
        public string ViewObject
        {
            get { return string.Format("{0} - {1}", Title, ShortDescription); }
        }
    }
}
