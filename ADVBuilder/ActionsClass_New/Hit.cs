﻿using System;
using System.Collections.Generic;
using ADVBuilder.Common;
using ADVBuilder.Model;

namespace ADVBuilder.ActionsClass_New
{
    public class Hit : aActions, iActions
    {
        public Hit(User pUser, List<ObjectsData> pInventario) : base(pUser, pInventario)
        {
        }

        public Response Execute(CharactersData pCharacter, ObjectsData pObj, ObjectsData pCmp, RoomData pRoom)
        {
            Object = pObj;
            Room = pRoom;
            Character = pCharacter;
            if (Object == null && Character == null)
            {
                Response.Success = false;
                Response.Message = "Seleziona qualcosa o qualcuno da colpire!";
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
            if (Object != null)
            {
                Object.Status = cCommon.STATUS_BROKEN;
                Response.Success = true;
            }
            else if (Character != null)
            {
                Character.LifePoint--;
                //if(Character.LifePoint<=0)
                //    Character.Status = cCommon.STATUS_DEAD;
                Response.Success = true;
            }
            else
            {
                Response.Success = false;
            }
            Response.Message = SetMessage(); 
            Response.Value = 0;
            Object = null;
            Room = null;
        }
        private string SetMessage()
        {
            return Response.Success ?
                Object != null ?
                    string.Format("Oggetto {0} distrutto.", Object.Title) :
                    Character != null ? 
                        Character.Status == cCommon.STATUS_DEAD? 
                            string.Format("Hai ucciso {0}.", Character.Title) :
                            string.Format("Hai colpito {0}.", Character.Title) :
                        string.Format("Non succede nulla.") :
                    string.Format("Non succede nulla.");
        }
    }
}