using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADVBuilder.Common;
using ADVBuilder_1.Model;

namespace ADVBuilder.ActionsClass
{
    public class Open : aActions, iActions
    {
        public Response Execute(ObjectsData pObj, ObjectsData pCmp, RoomData pRoom, List<ObjectsData> pInventario)
        {
            Object = pObj;
            Room = pRoom;
            Inventario = pInventario;
            if (Object == null)
            {
                Response.Success = true;
                Response.Message = "Seleziona l'oggetto da aprire!";
            }
            else
            {
                Exec();
            }
            return Response;
        }

        private void Exec()
        {
            if (Object.Status == null || Object.Status == cCommon.STATUS_CLOSED)
            {
                Object.Status = cCommon.STATUS_OPEN;
                Room.Objects.Where(o => o.Id == Object.Id).FirstOrDefault().Status = cCommon.STATUS_OPEN;
                Response.Success = true;
                Response.Message = SetMessage();
            }
            else
            {
                Response.Success = false;
                Response.Message = string.Format("Non puoi aprire {0}", Object.Title);
            }
            Object = null;
            Room = null;
        }
        private string SetMessage()
        {
            return Response.Success ?
                string.Format("Oggetto {0} aperto con successo.", Object.Title) : "Errore";
        }
        public Response Execute(AdventureData ADD, RoomData pRoom, string pDirection, ref int pRoomIdSelected)
        {
            return Response;
        }

    }
}
