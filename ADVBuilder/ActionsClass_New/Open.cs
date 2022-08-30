using ADVBuilder.Common;
using ADVBuilder.Model;

using System.Collections.Generic;

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
                Response.Success = false;
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
            }
            else
            {
                Response.Success = false;
            }

            Response.Message =SetMessage();
            Response.Value = 0;
            Object = null;
            Room = null;
        }

        private string SetMessage()
        {
            return Response.Success ?
                string.Format("Oggetto {0} aperto con successo.", Object.Title) : string.Format("Non puoi aprire {0}", Object.Title);
        }
    }
}