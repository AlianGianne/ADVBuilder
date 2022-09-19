using System.Collections.Generic;
using System.IO;
using ADVBuilder.Model;
using Newtonsoft.Json;

namespace ADVBuilder.ActionsClass_New
{
    public class Save : aActions, iActions
    {
        public Save(User pUser, List<ObjectsData> pInventario) : base(pUser, pInventario)
        {
        }
        public Response Execute(CharactersData pCharacter, ObjectsData pObj, ObjectsData pCmp, RoomData pRoom)
        {
            switch (Dialog)
            {
                case 0:         //Non Visualizzre dialogo
                case 2:         //Risposta positiva
                    Response = Exec();
                    break;
                case 1:         //Visualizza dialogo
                    Response.Message = "Se salvi ora sostituirai il salvataggio precedente. Continuare?";
                    Response.Success = false;
                    Response.Value = "SHOW";
                    break;
                case 3:         //Risposta negativa
                    Response.Message = "Operazione annullata dall'utente";
                    Response.Success = false;
                    Response.Value = 0;
                    break;
            }
            return Response;
        }
        private Response Exec()
        {
            using (StreamWriter file = File.CreateText(string.Format("{0}_Save.jsn", ADD.Title)))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, User);
                file.Close();
                Response.Message = string.Format("{0}_Save.jsn salvato con successo.", ADD.Title);
                Response.Success = true;
                Response.Value = 0;
            }
            return Response;
        }
    }
}
