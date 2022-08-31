﻿using ADVBuilder.Model;

namespace ADVBuilder.ActionsClass_New
{
    /// <summary>
    ///
    /// </summary>
    public interface iActions
    {
        /// <summary>
        /// Esegue l'azione preposta
        /// </summary>
        /// <param name="pObj">Oggetto che esegue l'azione</param>
        /// <param name="pCmp">Oggetto che subisce l'azione</param>
        /// <param name="pRoom">Stanza di riferimento</param>
        /// <returns></returns>
        Response Execute(CharactersData pCharacter, ObjectsData pObj, ObjectsData pCmp, RoomData pRoom);

        void SetUser(User pUsr);
    }
}