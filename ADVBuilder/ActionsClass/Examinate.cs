using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADVBuilder_1.Model;

namespace ADVBuilder.ActionsClass
{
    public class Examinate : aActions, iActions
    {
        public Response Execute(ObjectsData pObj, ObjectsData pCmp, RoomData pRoom, List<ObjectsData> pInventario)
        {
            Object = pObj;
            Room = pRoom;
            Inventario = pInventario;
            Response.Message = SetMessage();
            return Response;
        }

        public Response Execute(AdventureData ADD, RoomData pRoom, string pDirection, ref int pRoomIdSelected)
        {
            return Response;
        }

        private string SetMessage()
        {
            Response.Success = Object != null;
            return Response.Success ? Object.Description : "Seleziona qualcosa da guardare...";
        }
    }
}
