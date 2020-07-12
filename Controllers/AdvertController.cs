    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.API.Model;
using Advertise.API.Response;
using Advertise.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Advertise.API.Controllers
{
    [Route("api/v1/advert")]
    [ApiController]
    public class AdvertController : ControllerBase
    {
        private readonly IAdvertStorageService _advertStoreService;

        public AdvertController(IAdvertStorageService advertStoreService)
        {
            _advertStoreService = advertStoreService;
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200,Type=typeof(CreateAdvertResponse))]
        public async Task<IActionResult> Create(AdvertModel model)
        {
            string recordId;
            try
            {
                 recordId = await _advertStoreService.Add(model);
            }
            catch(KeyNotFoundException )
            {
                return NotFound();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return StatusCode(200, new CreateAdvertResponse() { Id =recordId});

        }

        [HttpPut]
        [Route("Confirm")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Confirm(ConfirmAdvertModel model)
        {
           try
            {
                 await _advertStoreService.Confirm(model);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return new OkResult();

        }
    }
}
