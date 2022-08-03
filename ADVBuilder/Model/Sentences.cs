using Gema2022.Class;
using Gema2022.CommonClass;

using System.Collections.Generic;

namespace ADVBuilder.Model
{
    /// <summary>
    ///
    /// </summary>
    public class Sentences : cOggettoData
    {
        private const string SELECTBYID = "SelectById";
        public List<SentencesData> List = new List<SentencesData>();

        public Sentences()
        {
            Settings(this.GetType().Name);
            ReadData();
            ReadList(List);
        }

        /// <summary>
        /// Costrutture standard
        /// </summary>
        /// <param name="pIdCharacter"></param>
        public Sentences(int pIdCharacter)
        {
            Settings(this.GetType().Name);
            ReadData(pIdCharacter);
            ReadList(List);
        }

        private void ReadData(int pIdCharacter)
        {
            if (Open())
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("IDCHARACTER", pIdCharacter);
                Table = ExecuteQuery(SELECTBYID, param, PercorsoFileXml);
                Close();
            }
        }
    }

    public class SentencesData
    {
        [cAttributes(Name = "Id")] public int Id { get; set; }
        [cAttributes(Name = "IdCharacter")] public int IdCharacter { get; set; }
        [cAttributes(Name = "Sentence")] public string Sentence { get; set; }
        [cAttributes(Name = "Level")] public int Level { get; set; }
    }
}