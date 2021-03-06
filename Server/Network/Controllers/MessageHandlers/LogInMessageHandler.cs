﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameData.Network;
using GameData.Network.Messages;
using Server.Database;
using Server.Services;
using Server.Unity;

namespace Server.Network.Controllers.MessageHandlers
{
    public class LogInMessageHandler : IMessageHandler
    {
        public IContent Execute(IContent content,object sender = null)
        {
            if(!(content is LogInMessage))
                throw new InvalidOperationException();

            var message = (LogInMessage) content;

            try
            {
                var user = UnityKernel.Get<UserService>().LogIn(message.Username, message.Password);
                message.AnswerData = user;
                return message;
            }
            catch (Exception e)
            {
                return new ErrorMessage();
            }
        }
    }
}
