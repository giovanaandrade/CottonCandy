﻿using CottonCandy.Application.AppUser.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace CottonCandy.Application.AppPostagem.Input
{
    public class PostagemInput
    {
        public int UsuarioId { get; set; }
        public string Texto { get; set; }
        public string FotoPost { get; set; }
    }
}