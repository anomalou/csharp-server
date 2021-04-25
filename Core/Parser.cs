using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// using client.Model;
using Server.Model;
using F10Libs.Networkdata;
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
            Type controllerType;
            if ((controllerType = GetControllerType(dto.type)) == null) {
                //TODO do if failed
                return null;
            }

            MethodInfo dtoCommand = controllerType.GetMethod(dto.command);
            object[] parameters = dto.parameters;

            switch (dto.type) {
                case "ChatController":
                    returned = dtoCommand.Invoke(ChatController.Instance, parameters);
                break;
                case "UserController":
                    returned = dtoCommand.Invoke(UserController.Instance, parameters);
                break;
                case "Disconnect":

                break;
            }

            DTO newDTO = new DTO(dto.command, null, returned, parameters);

            return newDTO;
        }

        private Type GetControllerType(string type) {
            switch (type) {
                case "ChatController":
                    return typeof(ChatController);
                case "UserController":
                    return typeof(UserController);
            }

            return null;
        }
    }
}
