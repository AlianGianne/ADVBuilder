using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADVBuilder.Model;

namespace ADVBuilder.ActionsClass_New
{
    class End : aActions, iActions
    {
        public End(User pUser, List<ObjectsData> pInventario) : base(pUser, pInventario)
        {
        }

        public Response Execute(CharactersData pCharacter, ObjectsData pObj, ObjectsData pCmp, RoomData pRoom)
        {
            Response.Value = "END";
            return Response;
        }
    }
}
