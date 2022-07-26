using ADVBuilder_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADVBuilder.ActionsClass_New
{
    internal class Drop : aActions, iActions
    {
        public Drop(AdventureData pADD, List<ObjectsData> pInventario) : base(pADD, pInventario)
        {
        }

        public Response Execute(ObjectsData pObj, ObjectsData pCmp, RoomData pRoom)
        {
            Object = pObj;
            Room = pRoom;
            if (Object == null)
            {
                Response.Success = true;
                Response.Message = "Seleziona l'oggetto da lasciare!";
                Response.Value = 0;
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
            Response.Success = Inventario.Remove(Object);
            Response.Message = SetMessage();
            Response.Value = 0;
            Object = null;
            Room = null;
        }
        private string SetMessage()
        {
            return Response.Success ? string.Format("Oggetto {0} lasciato.", Object.Title) : "Errore";
        }
    }
}
