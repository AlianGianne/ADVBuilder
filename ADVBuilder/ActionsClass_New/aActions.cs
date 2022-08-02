using ADVBuilder_1.Model;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADVBuilder.Model;

namespace ADVBuilder.ActionsClass_New
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class aActions
    {
        internal AdventureData ADD;
        internal RoomData Room;
        internal ObjectsData Object;
        internal ObjectsData Complement;
        internal CharactersData Character;
        internal List<ObjectsData> Inventario;
        internal Response Response { get; set; } = new Response();
        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="pADD">Avventura in uso</param>
        /// <param name="pInventario">Inventario</param>
        public aActions(AdventureData pADD, List<ObjectsData> pInventario)
        {
            ADD = pADD;
            Inventario = pInventario;
        }
    }
}
