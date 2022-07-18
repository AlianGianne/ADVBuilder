using ADVBuilder_1.Model;
using ADVBuilder.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADVBuilder.ActionsClass
{
    public class Drop : aActions, iActions
    {
        public Response Response { get; set; } = new Response();
        public Response Execute(ObjectsData pObj, ObjectsData pCmp, RoomData pRoom, List<ObjectsData> pInventario)
        {
            Object = pObj;
            Room = pRoom;
            Inventario = pInventario;
            if (Object == null)
            {
                Response.Success = true;
                Response.Message = "Seleziona l'oggetto da prendere";
            }
            else
            {
                Exec();
            }
            return Response;


        }
        private void Exec()
        {
            Object.IdRoom = Room.Id;
            Room.Objects.Add(Object);
            Inventario.Remove(Object);
            Response.Success = true;
            Response.Message = SetMessage();
            Object = null;
            Room = null;
        }
        private string SetMessage()
        {
            return Response.Success ? "Oggetto lasciato." : "Errore";
        }
    }
}
