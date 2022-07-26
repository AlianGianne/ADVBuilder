using ADVBuilder_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADVBuilder.ActionsClass_New
{
    internal class Examinate : aActions, iActions
    {
        public Examinate(AdventureData pADD, List<ObjectsData> pInventario) : base(pADD, pInventario)
        {
        }

        public Response Execute(ObjectsData pObj, ObjectsData pCmp, RoomData pRoom)
        {
            Object = pObj;
            Room = pRoom;
            Response.Message = SetMessage();
            return Response;
        }
        private string SetMessage()
        {
            Response.Success = Object != null;
            return Response.Success ? Object.Description : "Seleziona qualcosa da guardare...";
        }
    }
}
