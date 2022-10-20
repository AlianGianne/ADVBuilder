using System;
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
            int hitPoints = 0;
            if (Object != null)
            {
                if (Object.Status != cCommon.STATUS_BROKEN)
                {
                    Object.Status = cCommon.STATUS_BROKEN;
                    Response.Value = "XP|1";
                    Response.Success = true;
                }
                else
                {
                    Response.Success = false;
                    Response.Message = "E' già rotto!";
                    Response.Value = 0;
                }
            }
            else if (Character != null)
            {
                if (Character.LifePoint > 0)
                {
                    int levelGap = User.Skills.Level - Character.Skills.Level;
                    int forceGap = User.Skills.Force - Character.Skills.Force;
                    hitPoints = levelGap + forceGap;

                    if (hitPoints < 0) hitPoints = cCommon.GetRandom(0, 2);

                    Character.LifePoint-=hitPoints;
                    Response.Success = true;
                    Response.Value = Character.Status == cCommon.STATUS_DEAD ? Character.Skills.Level.ToString() : "XP|1";
                }
                else
                {
                    Response.Success = false;
                    Response.Message = "E' già morto!";
                    Response.Value = 0;
                }
            }
            else
            {
                Response.Success = false;
            }
            Response.Message = SetMessage(hitPoints);

            Object = null;
            Room = null;
        }
        private string SetMessage(int hitPoints)
        {
            return Response.Success ?
                Object != null ?
                    string.Format("Oggetto {0} distrutto.", Object.Title) :
                    Character != null ?
                        Character.Status == cCommon.STATUS_DEAD ?
                            string.Format("Hai ucciso {0}.", Character.Title) :
                            string.Format("Hai colpito {0}.{2}Punti ferita: {1}", Character.Title, hitPoints, Environment.NewLine) :
                    string.Format("Non succede nulla.") :
                string.Format("Non succede nulla.");
        }
    }
}
