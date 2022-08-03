using Gema2022.Class;
using Gema2022.CommonClass;

using System.Collections.Generic;

namespace ADVBuilder.Model
{
    /// <summary>
    /// Azioni possibili per l'avventura
    /// </summary>
    public class Actions : cOggettoData
    {
        /// <summary>
        /// Lista delle Azioni
        /// </summary>
        public List<ActionData> List = new List<ActionData>();

        public Actions()
        {
            Settings(this.GetType().Name);
            ReadData();
            ReadList(List);
        }
    }

    /// <summary>
    /// Struttura di ogni singola Azione
    /// </summary>
    public class ActionData
    {
        /// <summary>
        /// Identificativo Univoco
        /// </summary>
        [cAttributes(Name = "Id")] public int Id { get; set; }

        /// <summary>
        /// Nome dell'Azione
        /// </summary>
        [cAttributes(Name = "Title")] public string Title { get; set; }

        /// <summary>
        /// Descrizione dell'Azione
        /// </summary>
        [cAttributes(Name = "Description")] public string Description { get; set; }

        /// <summary>
        /// Profondità di Oggetti da utilizzare nell'Azione
        /// Es.: Usa Chiave su Porta
        /// </summary>
        [cAttributes(Name = "DeepObjects")] public string DeepObjects { get; set; }
    }
}