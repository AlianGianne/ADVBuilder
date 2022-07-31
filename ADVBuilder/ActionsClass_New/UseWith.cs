﻿using ADVBuilder.Common;
using ADVBuilder_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADVBuilder.ActionsClass_New
{
    internal class UseWith : aActions, iActions
    {
        public UseWith(AdventureData pADD, List<ObjectsData> pInventario) : base(pADD, pInventario)
        {
        }

        public Response Execute(ObjectsData pObj, ObjectsData pCmp, RoomData pRoom)
        {
            Object = pObj;
            Complement = pCmp;
            Room = pRoom;
            if (Object == null)
            {
                Response.Success = true;
                Response.Message = "Seleziona l'oggetto da utilizzare!";
                Response.Value = 0;
            }
            else
            {
                if (Complement == null)
                {
                    Response.Success = true;
                    Response.Message = "Seleziona l'oggetto con cui interagire!";
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
            switch (Object.Action)
            {
                case cCommon.ACTION_OPEN:
                    SetOpenAction();
                    break;
                case cCommon.ACTION_CLOSE:
                    SetCloseAction();
                    break;
            }
            Complement = null;
            Object = null;
            Room = null;
        }

        private void SetCloseAction()
        {
            if (int.Parse(Object.SufferAction) == Complement.Id)
            {
                Complement.Status = cCommon.STATUS_CLOSED;
                Response.Success = true;
                Response.Message = String.Format("{0} aperto.", Complement.Description);
                Response.Value = 0;
            }
            else
            {
                Response.Success = false;
                Response.Message = String.Format("{0} non può chiudere {1}.", Object.Description, Complement.Description);
                Response.Value = 0;
            }
        }

        private void SetOpenAction()
        {
            if (int.Parse(Object.SufferAction) == Complement.Id)
            {
                Complement.Status = cCommon.STATUS_OPEN;
                Response.Success = true;
                Response.Message = String.Format("{0} aperto.", Complement.Description);
                Response.Value = 0;
            }
            else
            {
                Response.Success = false;
                Response.Message = String.Format("{0} non può aprire {1}.", Object.Description, Complement.Description);
                Response.Value = 0;
            }
        }

        private string SetMessage()
        {
            return Response.Success ?
                string.Format("{0} in Inventario.", Object.Title) : "Errore";
        }
    }
}