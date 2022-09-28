using ADVBuilder.Common;
using ADVBuilder.Model;

using System;
using System.Collections.Generic;
using System.Linq;

namespace ADVBuilder.ActionsClass_New
{
    /// <summary>
    ///
    /// </summary>
    public class Speak : aActions, iActions
    {
        private Random rnd= new Random();
        /// <summary>
        ///
        /// </summary>
        /// <param name="pADD"></param>
        /// <param name="pInventario"></param>
        public Speak(User pUser, List<ObjectsData> pInventario) : base(pUser, pInventario)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pCharacter"></param>
        /// <param name="pObj"></param>
        /// <param name="pCmp"></param>
        /// <param name="pRoom"></param>
        /// <returns></returns>
        public Response Execute(CharactersData pCharacter, ObjectsData pObj, ObjectsData pCmp, RoomData pRoom)
        {
            Character = pCharacter;
            if (Character == null)
            {
                Response.Message = "Con chi vuoi parlare?";
                Response.Success = false;
                Response.Value = 0;
            }
            else
            {
                if (Character.Status == cCommon.STATUS_DEAD)
                {
                    Response.Message = string.Format("{0} sembra essere morto. Non può parlare.", Character.Title);
                    Response.Success = true;
                    Response.Value = 0;
                }
                else if (Character.Sentences.Count > 0)
                {
                    int idx = GetSentence();
                    Response.Message = string.Format("{0} dice:\n\r {1}", Character.Title, Character.Sentences[idx].Sentence);
                    Response.Success = true;
                    Response.Value = string.Format("XP|{0}", Character.Sentences[idx].XpPaied ? 0: Character.Sentences[idx].XP);
                    Character.Sentences[idx].Readed = true;
                    Character.Sentences[idx].XpPaied = true;
                }
                else
                {
                    Response.Message = string.Format("{0} non ha nulla da dire", Character.Title);
                    Response.Success = true;
                    Response.Value = 0;
                }
            }
            return Response;
        }
        private int GetSentence()
        {
            if (Character.Sentences.Where(s => !s.Readed).ToList().Count == 0) { Character.Sentences.ForEach(s => s.Readed = false); }
            int idx = rnd.Next(0, Character.Sentences.Count);
            while (Character.Sentences[idx].Readed)
            {
                idx = rnd.Next(0, Character.Sentences.Count);
            }
            return idx;
        }
    }
}