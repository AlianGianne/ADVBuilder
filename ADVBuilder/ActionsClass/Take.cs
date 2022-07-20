using ADVBuilder.Common;
using ADVBuilder.Model;
using ADVBuilder_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADVBuilder.ActionsClass
{
    /// <summary>
    /// 
    /// </summary>
    public class Take : aActions, iActions
    {
        public Response Execute(ObjectsData pObj, ObjectsData pCmp, RoomData pRoom, List<ObjectsData> pInventario)
        {
            Object = pObj;
            Room = pRoom;
            Inventario = pInventario;
            if (Object == null)
            {
                Response.Success = true;
                Response.Message = "Seleziona l'oggetto da prendere!";
            }
            else
            {
                Exec();
            }
            return Response;
        }

        public Response Execute(AdventureData ADD, RoomData pRoom, string pDirection, ref int pRoomIdSelected)
        {
            return Response;
        }

        private void Exec()
        {
            if (Object.Status == cCommon.STATUS_TAKE)
            {
                Response.Success = Room.Objects.Remove(Object);
                Inventario.Add(Object);
                Response.Message = SetMessage();
            }
            else
            {
                Response.Success = false;
                Response.Message = string.Format("Non puoi prendere {0}", Object.Title);
            }
            Object = null;
            Room = null;
        }
        private string SetMessage()
        {
            return Response.Success ?
                string.Format("{0} in Inventario.", Object.Title) : "Errore";
        }
    }
}
