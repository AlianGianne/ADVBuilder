﻿using ADVBuilder.Model;
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
            Response.Success = Room.Objects.Remove(Object) ;
            Inventario.Add(Object);
            Response.Message = SetMessage();
            Object = null;
            Room = null;
        }
        private string SetMessage()
        {
            return Response.Success ? "Oggetto in Inventario." : "Errore";
        }
    }
}
