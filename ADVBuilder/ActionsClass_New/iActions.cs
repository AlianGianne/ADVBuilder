using ADVBuilder_1.Model;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADVBuilder.ActionsClass_New
{
    public interface iActions
    {
        Response Execute(ObjectsData pObj, ObjectsData pCmp, RoomData pRoom);
    }
}
