﻿using System;

namespace APIVendas.Services.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) :
            base(message)
        {
        }
    }
}