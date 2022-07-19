using ADVBuilder_1.Model;
using ADVBuilder.Model;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADVBuilder.ActionsClass
{
    public interface iActions
    {
        Response Execute(ObjectsData pObj, ObjectsData pCmp, RoomData pRoom, List<ObjectsData> pInventario);
        Response Execute(AdventureData ADD, RoomData pRoom, string pDirection, ref int pRoomIdSelected);
    }
}
