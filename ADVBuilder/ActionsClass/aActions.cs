using ADVBuilder.Model;
using ADVBuilder_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADVBuilder.ActionsClass
{
    public abstract class aActions
    {
        internal RoomData Room;
        internal ObjectsData Object;
        internal ObjectsData Complement;
        internal List<ObjectsData> Inventario;
        internal Response Response { get; set; } = new Response();
    }
}
