﻿using MessageLibrary;
using System;

namespace CommonLibrary.Messages.Auth
{
    [Serializable]
    public class SignUpStage2ResultMessage : Message
    {
        public AuthenticationResult result { get; set; }

        public SignUpStage2ResultMessage(AuthenticationResult result) => this.result = result;
    }
}
