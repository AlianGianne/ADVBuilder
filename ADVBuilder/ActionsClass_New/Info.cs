using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADVBuilder.Model;

namespace ADVBuilder.ActionsClass_New
{
    public class Info : aActions, iActions
    {
        public Info(AdventureData pADD, List<ObjectsData> pInventario) : base(pADD, pInventario)
        {
        }

        public Response Execute(CharactersData pCharacter, ObjectsData pObj, ObjectsData pCmp, RoomData pRoom)
        {
            Response.Message = string.Format("Titolo:{4}{0}{3}Sotto Titolo:\t{1}{3}Autore:{4}{2}",ADD.Title, ADD.SubTitle, ADD.Author, Environment.NewLine, "\t\t");
            return Response;
        }
    }
}
