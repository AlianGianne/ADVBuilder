using Gema2022.Class;
using Gema2022.CommonClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADVBuilder.Model
{
    public class Characters : cOggettoData
    {
        private const string SELECTBYID = "SelectById";
        /// <summary>
        /// Lista Oggetti
        /// </summary>
        public List<CharactersData> List = new List<CharactersData>();
        public Characters()
        {
            Settings(this.GetType().Name);
            ReadData();
            ReadList(List);
        }
        /// <summary>
        /// Costrutture standard
        /// </summary>
        /// <param name="pIdRoom"></param>
        public Characters(int pIdRoom)
        {
            Settings(this.GetType().Name);
            ReadData(pIdRoom);
            ReadList(List);
            ReadOthers();
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
        private void ReadOthers()
        {
            foreach (CharactersData cd in List)
            {
                Sentences st = new Sentences(cd.Id);
                cd.Sentences = st.List;
            }
        }
    }
    public class CharactersData
    {
        [cAttributes(Name = "Id")] public int Id { get; set; }
        [cAttributes(Name = "Title")] public string Title { get; set; }
        [cAttributes(Name = "Description")] public string Description { get; set; }
        [cAttributes(Name = "ShortDescription")] public string ShortDescription { get; set; }
        [cAttributes(Name = "IdRoom")] public int IdRoom { get; set; }
        [cAttributes(Name = "Status")] public string Status { get; set; }
        [cAttributes(Name = "Action")] public string Action { get; set; }
        [cAttributes(Name = "SufferAction")] public string SufferAction { get; set; }
        public List<SentencesData> Sentences { get; set; }
        public string ViewCharacter
        {
            get { return string.Format("{0} - {1}", Title, ShortDescription); }
        }
    }
}
