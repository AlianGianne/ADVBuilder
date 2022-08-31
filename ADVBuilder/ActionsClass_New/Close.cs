using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADVBuilder.Common;
using ADVBuilder.Model;

namespace ADVBuilder.ActionsClass_New
{
    public class Close : aActions, iActions
    {
        public Close(User pUser, List<ObjectsData> pInventario) : base(pUser, pInventario)
        {
        }

        public Response Execute(CharactersData pCharacter, ObjectsData pObj, ObjectsData pCmp, RoomData pRoom)
        {
            Object = pObj;
            Room = pRoom;
            if (Object == null)
            {
                Response.Success = false;
                Response.Message = "Seleziona l'oggetto da chiudere!";
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
            if (Object.Status == null || Object.Status == cCommon.STATUS_OPEN)
            {
                Object.Status = cCommon.STATUS_CLOSED;
                Response.Success = true;
            }
            else
            {
                Response.Success = false;
            }
            Response.Message = SetMessage(); ;
            Response.Value = 0;
            Object = null;
            Room = null;
        }
        private string SetMessage()
        {
            return Response.Success ?
                string.Format("Oggetto {0} chiuso con successo.", Object.Title) : 
                string.Format("Non puoi chiudere {0}", Object.Title);
        }
    }
}
