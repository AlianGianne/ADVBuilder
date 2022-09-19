using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADVBuilder.Model;
using Newtonsoft.Json;

namespace ADVBuilder.ActionsClass_New
{
    public class Load : aActions, iActions
    {
        public Load(User pUser, List<ObjectsData> pInventario) : base(pUser, pInventario)
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
                    Response.Message = string.Format(
                        "Se carichi ora una partita salvata in precedenza, perderai gli avanzamenti fatti fin'ora.{0}Continuare?"
                        , Environment.NewLine);
                    Response.Success = false;
                    Response.Value = "SHOW";
                    break;
                case 3:         //Risposta negativa
                    Response.Message = "Operazione annullata dall'utente!";
                    Response.Success = false;
                    Response.Value = 0;
                    break;
            }
            return Response;
        }
        private Response Exec()
        {
            using (StreamReader r = new StreamReader(string.Format("{0}_Save.jsn", ADD.Title)))
            {
                string json = r.ReadToEnd();
                Response.Success = true;
                Response.Value = JsonConvert.DeserializeObject<User>(json);
                Response.Message = string.Format("{0}_Save.jsn caricato con successo.", ADD.Title);
            }
            return Response;
        }
    }
}
