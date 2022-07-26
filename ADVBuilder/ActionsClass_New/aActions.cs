using ADVBuilder_1.Model;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        internal List<ObjectsData> Inventario;
        internal Response Response { get; set; } = new Response();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pADD"></param>
        /// <param name="pInventario"></param>
        public aActions(AdventureData pADD, List<ObjectsData> pInventario)
        {
            ADD = pADD;
            Inventario = pInventario;
        }
    }
}
