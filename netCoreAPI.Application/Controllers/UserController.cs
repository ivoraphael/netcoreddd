using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using netCoreAPI.Domain.DTOModels;
using netCoreAPI.Domain.ViewModels;
using netCoreAPI.Service.Helpers;
using netCoreAPI.Service.Services;
using netCoreAPI.Service.Validators;
using System;
using System.Collections.Generic;

namespace netCoreAPI.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService service = new UserService();

        [AllowAnonymous]
        [HttpPost]
        public object Login([FromBody]User model, [FromServices]SigningConfigurations signingConfigurations, [FromServices]TokenConfigurations tokenConfigurations)
        {
            try
            {
                User user = service.Login(model);
                return Ok(JWTHelper.GenerateAuthToken(user, signingConfigurations, tokenConfigurations));
            }
            catch (Exception ex)
            {
                var rc = ExceptionHelper.ResponseException(ex);
                return StatusCode(rc.statusCode, rc.value);
            }

        }

        [Authorize("Bearer")]
        [HttpPost]
        public IActionResult Post([FromBody] User item)
        {
            try
            {
                item = service.Post<UserValidator>(item);

                return new ObjectResult(item.Id);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize("Bearer")]
        [HttpPost]
        public IActionResult Put([FromBody] User item)
        {
            try
            {
                item = service.Put<UserValidator>(item);

                return new ObjectResult(item);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize("Bearer")]
        [HttpPost]
        public IActionResult Delete([FromBody] int id)
        {
            try
            {
                service.Delete(id);

                return new NoContentResult();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize("Bearer")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return new ObjectResult(service.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize("Bearer")]
        [HttpGet]
        public IActionResult Get([FromBody] User model)
        {
            try
            {
                return new ObjectResult(service.Get<UserValidator>(model));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize("Bearer")]
        [HttpGet]
        public IActionResult GetById([FromBody] int id)
        {
            try
            {
                return new ObjectResult(service.GetById(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}