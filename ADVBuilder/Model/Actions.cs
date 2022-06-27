using Gema2022.Class;
using Gema2022.CommonClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADVBuilder.Model
{
    /// <summary>
    /// Costruttore Actions
    /// </summary>
    public class Actions : cOggettoData
    {
        public List<ActionData> List = new List<ActionData>();
        public Actions()
        {
            Settings(this.GetType().Name);
            ReadData();
            ReadList(List);
        }
    }
    /// <summary>
    /// Struttura Actions
    /// </summary>
    public class ActionData
    {
        [cAttributes(Name = "Id")]
        public int Id { get; set; }
        [cAttributes(Name = "Action")]
        public string Action { get; set; }
        [cAttributes(Name = "Description")]
        public string Description { get; set; }
        [cAttributes(Name = "DeepObjects")]
        public string DeepObjects { get; set; }
    }
}
