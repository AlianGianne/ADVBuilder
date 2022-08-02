using ADVBuilder.Common;
using ADVBuilder.Model;
using ADVBuilder_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADVBuilder.ActionsClass_New
{
    internal class Open : aActions, iActions
    {
        public Open(AdventureData pADD, List<ObjectsData> pInventario) : base(pADD, pInventario)
        {
        }

        public Response Execute(CharactersData pCharacter, ObjectsData pObj, ObjectsData pCmp, RoomData pRoom)
        {
            Object = pObj;
            Room = pRoom;
            if (Object == null)
            {
                Response.Success = true;
                Response.Message = "Seleziona l'oggetto da aprire!";
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
            if (Object.Status == null || Object.Status == cCommon.STATUS_CLOSED)
            {
                Object.Status = cCommon.STATUS_OPEN;
                Response.Success = true;
                Response.Message = SetMessage();
                Response.Value = 0;
            }
            else
            {
                Response.Success = false;
                Response.Message = string.Format("Non puoi aprire {0}", Object.Title);
                Response.Value = 0;
            }
            Object = null;
            Room = null;
        }
        private string SetMessage()
        {
            return Response.Success ?
                string.Format("Oggetto {0} aperto con successo.", Object.Title) : "Errore";
        }
    }
}
