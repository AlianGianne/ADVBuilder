using Gema2022.Class;
using Gema2022.CommonClass;

using System.Collections.Generic;

namespace ADVBuilder.Model
{
    /// <summary>
    ///
    /// </summary>
    public class Objects : cOggettoData
    {
        private const string SELECTBYID = "SelectById";

        /// <summary>
        /// Lista Oggetti
        /// </summary>
        public List<ObjectsData> List = new List<ObjectsData>();

        public Objects()
        {
            Settings(this.GetType().Name);
            ReadData();
            ReadList(List);
        }

        /// <summary>
        /// Costrutture standard
        /// </summary>
        /// <param name="pIdRoom"></param>
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

    /// <summary>
    /// Struttura Objects
    /// </summary>
    public class ObjectsData
    {
        [cAttributes(Name = "Id")] public int Id { get; set; }
        [cAttributes(Name = "Title")] public string Title { get; set; }
        [cAttributes(Name = "Description")] public string Description { get; set; }
        [cAttributes(Name = "ShortDescription")] public string ShortDescription { get; set; }
        [cAttributes(Name = "IdRoom")] public int IdRoom { get; set; }
        [cAttributes(Name = "Position")] public string Position { get; set; }
        [cAttributes(Name = "Status")] public string Status { get; set; }
        [cAttributes(Name = "Action")] public string Action { get; set; }
        [cAttributes(Name = "SufferAction")] public string SufferAction { get; set; }
        [cAttributes(Name = "XP")] public string XP { get; set; }

        public string ViewObject
        {
            get { return string.Format("{0} - {1}", Title, ShortDescription); }
        }
    }
}