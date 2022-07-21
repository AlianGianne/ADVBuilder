using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADVBuilder.Common
{
    static class cCommon
    {
        #region "Objects Status"
        /// <summary>
        /// Oggetto semplicemente chiuso apribile senza altri oggetti (es.: Porta apribile senza chiave)
        /// </summary>
        public const string STATUS_CLOSED = "Closed";
        /// <summary>
        /// Oggetto chiuso. Serve un altro oggetto per aprirlo (es.: Porta apribile solo con la relativa chiave)
        /// </summary>
        public const string STATUS_LOCKED = "Locked";
        /// <summary>
        /// Oggetto aperto
        /// </summary>
        public const string STATUS_OPEN = "Open";
        /// <summary>
        /// Oggetto fisso, non spostabile e non prendibile
        /// </summary>
        public const string STATUS_STATIC = "Static";
        /// <summary>
        /// Oggetto raccoglibile
        /// </summary>
        public const string STATUS_TAKE = "Take";
        #endregion
        #region "Inventario"
        /// <summary>
        /// Massimo numero di oggetti in Inventario
        /// </summary>
        public const int INVENTARIO_MAX = 20;
        #endregion
    }
}
