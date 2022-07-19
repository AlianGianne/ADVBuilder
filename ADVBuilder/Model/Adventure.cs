using Gema2022.Class;
using Gema2022.CommonClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADVBuilder_1.Model
{
    public class Adventure : cOggettoData
    {
        private const string SELECTBYID = "SelectById";

        public List<AdventureData> List = new List<AdventureData>();
        public Adventure()
        {
            Settings(this.GetType().Name);
            ReadData();
            ReadList(List);
            ///////////////
            ReadRooms();
        }
        public Adventure(int pIdAdv)
        {
            Settings(this.GetType().Name);
            ReadData(pIdAdv);
            ReadList(List);
            ///////////////
            ReadRooms();
        }

        private void ReadData(int pIdAdv)
        {
            if (Open())
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("ID", pIdAdv);
                Table = ExecuteQuery(SELECTBYID, param, PercorsoFileXml);
                Close();
            }
        }

        public void ReadRooms()
        {
            foreach (AdventureData ad in List)
            {
                Room rm = new Room(ad.Id);
                ad.Rooms = rm.List;
            }
        }
    }
    public class AdventureData
    {
        #region "Properties"
        [cAttributes(Name = "Id")]
        public int Id { get; set; }
        [cAttributes(Name = "Title")]
        public string Title { get; set; }                   //Titolo
        [cAttributes(Name = "SubTitle")]
        public string SubTitle { get; set; }
        [cAttributes(Name = "Description")]
        public string Description { get; set; }             //Descrizione
        [cAttributes(Name = "ShortDescription")]
        public string ShortDescription { get; set; }        //Descrizione breve
        [cAttributes(Name = "Version")]
        public string Version { get; set; }
        [cAttributes(Name = "Author")]
        public string Author { get; set; }
        public List<RoomData> Rooms { get; set; }
        [cAttributes(Name = "CurrentRoom")]
        public int CurrentRoom { get; set; }
        #endregion
        #region "Methods"
        /// <summary>
        /// Restituisce la descrizione lunga della Room
        /// </summary>
        /// <returns>string: descrizione lunga della Room</returns>
        public string ViewRoom()
        {
            return Rooms.Where(r=> r.Id== CurrentRoom).FirstOrDefault().Description;
        }
        #endregion
    }

}
