using AppDapper.Data;
using AppDapper.Event;
using AppDapper.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppDapper.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUserService _config;

        public HomeController(IUserService config)
        {
            _config = config;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _config.GetUsers();
            if (result is null)
            {
                return BadRequest(new ResTemplate()
                {
                    Response = nameof(ResponseType.Error),
                    Date = null

                });
            }

            return BadRequest(new ResTemplate()
            {
                Response = nameof(ResponseType.Successfully),
                Date = result

            });

        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = BadRequest(await _config.Get(id));
            if (result is null)
            {
                return BadRequest(new ResTemplate()
                {
                    Response = nameof(ResponseType.Error),
                    Date = null

                });
            }

            return BadRequest(new ResTemplate()
            {
                Response = nameof(ResponseType.Successfully),
                Date = result
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserModel model)
        {
            var result = BadRequest(await _config.Create(model));

            if (result is null)
            {
                return BadRequest(new ResTemplate()
                {
                    Response = nameof(ResponseType.Error),
                    Date = null

                });
            }

            return BadRequest(new ResTemplate()
            {
                Response = nameof(ResponseType.Successfully),
                Date = result

            });
        }

        [HttpPut]
        public async Task<IActionResult> Update(int Id, UserModel model)
        {
            var result = BadRequest(await _config.Update(Id, model));

            if (result is null)
            {
                return BadRequest(new ResTemplate()
                {
                    Response = nameof(ResponseType.Error),
                    Date = null

                });
            }

            return BadRequest(new ResTemplate()
            {
                Response = nameof(ResponseType.Successfully),
                Date = result
            });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = BadRequest(await _config.Delete(id));

            if (result is null)
            {
                return BadRequest(new ResTemplate()
                {
                    Response = nameof(ResponseType.Error),
                    Date = null
                });
            }

            return BadRequest(new ResTemplate()
            {
                Response = nameof(ResponseType.Successfully),
                Date = result
            });
        }
    }
}
