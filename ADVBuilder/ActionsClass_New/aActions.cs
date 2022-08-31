﻿using ADVBuilder.Model;

using System.Collections.Generic;

namespace ADVBuilder.ActionsClass_New
{
    /// <summary>
    ///
    /// </summary>
    public abstract class aActions
    {
        internal User User;
        internal AdventureData ADD;
        internal RoomData Room;
        internal ObjectsData Object;
        internal ObjectsData Complement;
        internal CharactersData Character;
        internal List<ObjectsData> Inventario;
        internal Response Response { get; set; } = new Response();

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="pADD">Avventura in uso</param>
        /// <param name="pInventario">Inventario</param>
        public aActions(User pUser, List<ObjectsData> pInventario)
        {
            SetUser(pUser);
        }
        public void SetUser(User pUsr)
        {
            User = pUsr;
            ADD = User.ADD;
            Inventario = pUsr.Inventario;
        }
    }
}