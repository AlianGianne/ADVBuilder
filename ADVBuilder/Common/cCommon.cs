using System;

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

        private static Random Rnd { get; set; } = new Random(DateTime.Now.Second);

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
        /// Oggetto raccoglibile
        /// </summary>
        public const string STATUS_BROKEN = "Broken";
        /// <summary>
        /// Personaggio amico, non spostabile e non prendibile
        /// </summary>
        public const string STATUS_FRIEND = "Friend";
        /// <summary>
        /// Personaggio nemico, non spostabile e non prendibile
        /// </summary>
        public const string STATUS_ENEMY = "Enemy";

        /// <summary>
        /// Personaggio morto, non spostabile e non prendibile
        /// </summary>
        public const string STATUS_DEAD = "Dead";
        #endregion "Objects Status"

        #region "Object Actions"

        public const string ACTION_OPEN = "Open";
        public const string ACTION_CLOSE = "Close";
        public const string ACTION_SHOOT = "Hit";
        public const string ACTION_RECHARGE = "Recharge";
        public const string ACTION_RISE = "Rise";
        public const string ACTION_BUY = "Buy";
        public const string ACTION_SELL = "Sell";
        public const string ACTION_STOLE = "Stole";

        #endregion "Object Actions"

        #region "Result Actions"
        public const string RESULT_ACTION_END = "END";
        public const string RESULT_ACTION_SHOW = "SHOW";
        public const int RESULT_ACTION_NOTHING = 0;
        public const int RESULT_ACTION_VIEW = 1;
        public const int RESULT_ACTION_YES = 2;
        public const int RESULT_ACTION_NO = 3;
        #endregion

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
        #region "Common Methods"
        public static int GetRandom(int pFrom, int pTo)
        {
            return Rnd.Next(pFrom, pTo);
        }
        #endregion
    }
}