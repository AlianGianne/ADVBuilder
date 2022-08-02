﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADVBuilder.Model;
using ADVBuilder_1.Model;

namespace ADVBuilder.ActionsClass_New
{
    /// <summary>
    /// 
    /// </summary>
    public class Speak : aActions, iActions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pADD"></param>
        /// <param name="pInventario"></param>
        public Speak(AdventureData pADD, List<ObjectsData> pInventario) : base(pADD, pInventario)
        {
        }
        /// <summary>
        /// 
        /// </summary>
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
                Response.Message = Character.Sentences[new Random(DateTime.Now.Second).Next(0, Character.Sentences.Count)].Sentence;
                Response.Success = true;
                Response.Value = 0;
            }
            return Response;
        }
    }
}
