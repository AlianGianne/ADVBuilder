using ADVBuilder.Common;
using ADVBuilder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADVBuilder.ActionsClass_New
{
    public class Give : aActions, iActions
    {
        public Give(User pUser, List<ObjectsData> pInventario) : base(pUser, pInventario)
        {
        }

        public Response Execute(CharactersData pCharacter, ObjectsData pObj, ObjectsData pCmp, RoomData pRoom)
        {
            Object = pObj;
            Complement = pCmp;
            Character = pCharacter;
            Room = pRoom;
            if (Object == null)
            {
                Response.Success = false;
                Response.Message = "Seleziona l'oggetto da consegnare!";
                Response.Value = 0;
            }
            else
            {
                if (Complement == null && Character == null)
                {
                    Response.Success = false;
                    Response.Message = string.Format("Seleziona l'oggetto a cui consegnare {0}!", Object);
                    Response.Value = 0;
                }
                else
                {
                    Exec();
                }
            }
            return Response;
        }

        private void Exec()
        {
            if (Object.SufferAction!="" && int.Parse(Object.SufferAction) > 0)         //Indica a chi consegnare l'oggetto
            {
                if (Complement != null)
                {
                    Response.Success = true;
                    Response.Message = String.Format("Non puoi consegnare {0} a {1}.", Object.Description, Complement.Description);
                    Response.Value = 0;
                }
                else
                {
                    if (Character != null)
                    {
                        Character.SufferAction = Object.Id.ToString();
                        Inventario.Remove(Object);
                        Response.Success = true;
                        Response.Message = String.Format("Hai consegnato {0} a {1}",
                            Object.Description, Character.Description);
                        Response.Value = string.Format("XP|{0}", Object.XP);
                    }
                    else
                    {
                        Character.Status = cCommon.STATUS_DEAD;
                        Response.Success = true;
                        Response.Message = String.Format("Seleziona qualcuno a cui consegnare l'oggetto.", Character.Description);
                        Response.Value = 0;
                    }
                }
            }
            else
            {
                Response.Success = false;
                Response.Message = String.Format("{0} non può essere consegnato ad alcuna persona.", Object.Description);
                Response.Value = 0;
            }
        }
    }
}
