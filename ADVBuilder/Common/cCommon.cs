namespace ADVBuilder.Common
{
    internal static class cCommon
    {
        #region "Maps"

        public const int ROOM_WIDTH = 60;
        public const int ROOM_HEIGHT = 20;
        public const int ZOOM_FACTOR = 1;
        public const int ZOOM_FACTOR_MULTIPLIER = 10;
        public const int GAP_FACTOR = 50;
        public const int STR_LAYER_POSITION_X = 550;
        public const int STR_LAYER_POSITION_Y = 300;
        public static int GAP_FACTOR_X = 0;
        public static int GAP_FACTOR_Y = 0;
        #endregion "Maps"

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

        /// <summary>
        /// Oggetto amico, non spostabile e non prendibile
        /// </summary>
        public const string STATUS_FRIEND = "Friend";

        #endregion "Objects Status"

        #region "Object Actions"

        public const string ACTION_OPEN = "Open";
        public const string ACTION_CLOSE = "Close";
        public const string ACTION_SHOOT = "Shoot";
        public const string ACTION_RISE = "Rise";

        #endregion "Object Actions"

        #region "Inventario"

        /// <summary>
        /// Massimo numero di oggetti in Inventario
        /// </summary>
        public const int INVENTARIO_MAX = 15;

        #endregion "Inventario"
        #region "Common Methods"
        internal static string GetDirectionText(string pDirection)
        {
            string ret = "";
            switch (pDirection)
            {
                case "NN":
                    ret = "Nord";
                    break;
                case "NE":
                    ret = "Nord-Est";
                    break;
                case "EE":
                    ret = "Est";
                    break;
                case "SE":
                    ret = "Sud-Est";
                    break;
                case "SS":
                    ret = "Sud";
                    break;
                case "SO":
                    ret = "Sud-Ovest";
                    break;
                case "OO":
                    ret = "Ovest";
                    break;
                case "NO":
                    ret = "Nord-Ovest";
                    break;
                case "AA":
                    ret = "Alto";
                    break;
                case "BB":
                    ret = "Basso";
                    break;
            }
            return ret;
        }
        #endregion
    }
}