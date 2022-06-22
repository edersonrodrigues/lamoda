
using Rgm.ServiceInterfaceLayer.Dto;
using AutoMapper;
using Rgm.Domain.Entities.Entities;
using Rgm.Domain.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Rgm.BusinessEntities.Entities;

namespace Rgm.Application.Controller
{
    [Route("api/v1/Token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IToken _service { get; set; }
        public IMapper _mapper;
        public IConfiguration _config;

        public TokenController(IToken service, IMapper mapper, IConfiguration config)
        {
            _service = service;
            _mapper = mapper;
            _config = config;
        }

        [HttpGet("GerarToken")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TokenDto))]
        [ProducesResponseType(statusCode: 400)]
        [ProducesResponseType(statusCode: 401)]
        [ProducesResponseType(statusCode: 500)]
        public TokenEntity GerarToken([FromHeader] string login, [FromHeader] string senha)
        {
            var appLogin = _config.GetSection("jwt:login");
            var appSenha = _config.GetSection("jwt:senha");
            var appSecret = _config.GetSection("jwt:secret");
            return _service.GerarToken(login, senha, appLogin.Value, appSenha.Value, appSecret.Value);
        }
    }
}

