﻿using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

using Server.Model;
using Server.Controller;

namespace Server.Core {
    class Parser {

        #region Singleton

        private static Parser INSTANCE;
        private static readonly object padlock = new object();

        public static Parser Instance {
            get {
                lock (padlock) {
                    if(INSTANCE == null)
                        INSTANCE = new Parser();
                    return INSTANCE;
                }
            }
        }

        #endregion

        public DTO ParseAndExecute (DTO dto) {
            Object returned = null;
            MethodInfo dtoCommand = Type.GetType(dto.type).GetMethod(dto.command);
            object[] parameters = dto.parameters;

            switch (dto.type) {
                case "ChatController":
                    returned = dtoCommand.Invoke(ChatController.Instance, parameters);
                break;
                case "UserController":
                    returned = dtoCommand.Invoke(UserController.Instance, parameters);
                break;
            }

            DTO newDTO = new DTO(dto.command, null, returned, parameters);

            return newDTO;
        }
    }
}
