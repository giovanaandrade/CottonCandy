﻿
using CottonCandy.Application.AppUser.Interfaces;
using CottonCandy.Application.AppUsuario.Input;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CottonCandy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioInput usuarioInput)
        {
            try {
                var usuario = await _usuarioAppService.InsertAsync(usuarioInput).ConfigureAwait(false);

                return Created("", usuario);
            }
            catch (ArgumentException arg)
            {
                return BadRequest(arg.Message);
            }

        }

        //fim do método post

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var perfil = await _usuarioAppService
                                .ObterInformacoesPorIdAsync(id)
                                .ConfigureAwait(false);

            if (perfil is null)
                return NotFound();

            return Ok(perfil);

        }




    }



}
