using ADVBuilder.ActionsClass;
using ADVBuilder_1.Model;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADVBuilder.ActionClass_New
{
    public abstract class aActions
    {
        internal RoomData Room;
        internal ObjectsData Object;
        internal ObjectsData Complement;
        internal List<ObjectsData> Inventario;
        internal Response Response { get; set; } = new Response();
        public aActions()
        {

        }
    }
}
