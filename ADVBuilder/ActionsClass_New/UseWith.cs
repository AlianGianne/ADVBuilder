using ADVBuilder.Common;
using ADVBuilder.Model;

using System;
using System.Collections.Generic;

namespace ADVBuilder.ActionsClass_New
{
    internal class UseWith : aActions, iActions
    {
        public UseWith(User pUser, List<ObjectsData> pInventario) : base(pUser, pInventario)
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
                Response.Message = "Seleziona l'oggetto da utilizzare!";
                Response.Value = 0;
            }
            else
            {
                if (Complement == null && Character == null)
                {
                    Response.Success = false;
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
                case cCommon.ACTION_SHOOT:
                    SetShootAction();
                    break;
                case cCommon.ACTION_RECHARGE:
                    SetRechargeAction();
                    break;
                default:
                    SetNothingToDo();
                    break;
            }
            Complement = null;
            Object = null;
            Room = null;
        }

        private void SetNothingToDo()
        {
            Response.Success=false;
            Response.Message = "Un'azione alquanto inutile che non produce risultati.";
            Response.Value=0;
        }

        private void SetRechargeAction()
        {
            if (Character != null)
            {
                Response.Success = false;
                Response.Message = String.Format("Non puoi caricare {0}.", Character.Description);
                Response.Value = 0;
            }
            else
            {
                if (Complement.Action != cCommon.ACTION_SHOOT)
                {
                    Response.Success = false;
                    Response.Message = String.Format("Non puoi caricare {0}.", Complement.Description);
                    Response.Value = 0;
                }
                else
                {
                    Complement.SufferAction = Object.SufferAction;
                    Inventario.Remove(Object);
                    Room.Objects.Remove(Object);
                    Response.Success = true;
                    Response.Message = String.Format("Hai caricato {0} con {1} colpi.", Complement.Description, Object.SufferAction);
                    Response.Value = "XP|2";
                }
            }
        }

        private void SetShootAction()
        {
            if (int.Parse(Object.SufferAction) > 0)
            {
                if (Complement != null)
                {
                    Response.Success = true;
                    Response.Message = String.Format("Non puoi sparare a {0}.", Complement.Description);
                    Response.Value = 0;
                }
                else
                {
                    if (Character.LifePoint > 1)
                    {
                        Character.LifePoint--;
                        Response.Success = true;
                        Response.Message = String.Format("Hai colpito {0}, ma sembra ancora vivo.{1}Punit vita: {2}",
                            Character.Description, Environment.NewLine, Character.LifePoint);
                        Response.Value = "XP|1";
                    }
                    else
                    {
                        Character.Status = cCommon.STATUS_DEAD;
                        Response.Success = true;
                        Response.Message = String.Format("{0} morto.", Character.Description);
                        Response.Value = "XP|5";
                    }
                }
                Object.SufferAction = (int.Parse(Object.SufferAction) - 1).ToString();
            }
            else
            {
                Response.Success = false;
                Response.Message = String.Format("{0} non ha più colpi.", Object.Description);
                Response.Value = 0;
            }
        }
        private void SetCloseAction()
        {
            if (int.Parse(Object.SufferAction) == Complement.Id)
            {
                Complement.Status = cCommon.STATUS_CLOSED;
                Response.Success = true;
                Response.Message = String.Format("{0} chiuso.", Complement.Description);
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
            if (Object.SufferAction == Complement.Id.ToString())
            {
                Complement.Status = cCommon.STATUS_OPEN;
                Response.Success = true;
                Response.Message = String.Format("{0} aperto.", Complement.Description);
                Response.Value = "XP|1";
            }
            else
            {
                Response.Success = false;
                Response.Message = String.Format("{0} non può aprire {1}.", Object.Description, Complement.Description);
                Response.Value = 0;
            }
        }
    }
}