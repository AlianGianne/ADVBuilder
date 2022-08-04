using ADVBuilder.Common;
using ADVBuilder.Model;

using System.Collections.Generic;
using System.Linq;

namespace ADVBuilder.ActionsClass_New
{
    internal class Take : aActions, iActions
    {
        public Take(AdventureData pADD, List<ObjectsData> pInventario) : base(pADD, pInventario)
        {
        }

        /// <summary>
        /// Esegue la prima azione Take
        /// </summary>
        /// <param name="pObj"></param>
        /// <param name="pCmp"></param>
        /// <param name="pRoom"></param>
        /// <returns>Response</returns>
        public Response Execute(CharactersData pCharacter, ObjectsData pObj, ObjectsData pCmp, RoomData pRoom)
        {
            Object = pObj;
            Room = pRoom;
            if (Object == null)
            {
                Response.Success = true;
                Response.Message = "Seleziona l'oggetto da prendere!";
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
            if (Object.Status == cCommon.STATUS_TAKE)
            {
                if (Inventario.Count() < cCommon.INVENTARIO_MAX)
                {
                    if (!Inventario.Contains(Object))
                    {
                        Inventario.Add(Object);
                        Response.Success = Room.Objects.Remove(Object);
                        Response.Message = SetMessage();
                        Response.Value = 0;
                    }
                    else
                    {
                        Response.Success = false;
                        Response.Message = string.Format("{0} è già presente in inventario!", Object.Title);
                        Response.Value = 0;
                    }
                }
                else
                {
                    Response.Success = false;
                    Response.Message = string.Format("Non puoi prendere {0}, inventario pieno!", Object.Title);
                    Response.Value = 0;
                }
            }
            else
            {
                Response.Success = false;
                Response.Message = string.Format("Non puoi prendere {0}", Object.Title);
                Response.Value = 0;
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