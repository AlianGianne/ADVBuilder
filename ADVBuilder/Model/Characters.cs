using ADVBuilder.Common;
using ADVBuilder.Model.Abstract;
using Gema2022.Class;
using Gema2022.CommonClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

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
            ReadSkills();
            ReadOthers();
        }

        private void ReadSkills()
        {
            foreach (CharactersData cd in List)
            {
                cd.Skills = JsonConvert.DeserializeObject<CharacterSkills>(cd.Skls);
            }         
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

    public class CharactersData : CharProperties
    {
        //private int lifePoint;
        
        [cAttributes(Name = "Id")] public int Id { get; set; }
        [cAttributes(Name = "Title")] public string Title { get; set; }
        [cAttributes(Name = "Description")] public string Description { get; set; }
        [cAttributes(Name = "ShortDescription")] public string ShortDescription { get; set; }
        [cAttributes(Name = "IdRoom")] public int IdRoom { get; set; }
        [cAttributes(Name = "Status")] public string Status { get; set; }
        [cAttributes(Name = "Action")] public string Action { get; set; }
        [cAttributes(Name = "SufferAction")] public string SufferAction { get; set; }
        [cAttributes(Name = "LifePoint")]
        public int LifePoint
        {
            get => Skills.Life;
            set
            {
                Skills.Life = value;
                if (Skills.Life <= 0)
                {
                    Status = cCommon.STATUS_DEAD;
                    Skills.Life = 0;
                }
            }
        }
        [cAttributes(Name = "Skls")] public string Skls { get; set; }
        public CharacterSkills Skills { get; set; } = new CharacterSkills();
        public List<SentencesData> Sentences { get; set; }
        public List<ObjectsData> Inventario { get; set; } = new List<ObjectsData>();
        public string ViewCharacter
        {
            get { return string.Format("{0} - {1}", Title, ShortDescription); }
        }
    }
}