﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageLibrary;


namespace CommonLibrary.Messages.Auth
{
    [Serializable]
    public class SignUpMessage : BaseMessage
    {

        public string Login { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public SignUpMessage() { }


    }
}
