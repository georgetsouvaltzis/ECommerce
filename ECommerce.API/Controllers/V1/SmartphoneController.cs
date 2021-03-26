using ECommerce.Service.Abstract;
using ECommerce.Service.Models.Smartphone.Create;
using ECommerce.Service.Models.Smartphone.Delete;
using ECommerce.Service.Models.Smartphone.Details;
using ECommerce.Service.Models.Smartphone.Read;
using ECommerce.Service.Models.Smartphone.Update;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SmartphoneController : ControllerBase
    {
        private readonly ISmartphoneService _smartphoneService;
        public SmartphoneController(ISmartphoneService smartphoneService)
        {
            _smartphoneService = smartphoneService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public ActionResult GetSmartphones()
        {
            return Ok(_smartphoneService.GetSmartphones(new ReadSmartphoneRequest()));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public ActionResult Details(int id)
        {
            var smartphone = _smartphoneService.Detail(new DetailSmartphoneRequest { Id = id });
            if (smartphone.IsSuccess)
                return Ok(smartphone);

            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Route("create")]
        // CreateRequestresponseModel
        public ActionResult Create([FromBody] CreateSmartphoneRequest smartphoneRequest)
        {
            var response = _smartphoneService.Create(new CreateSmartphoneRequest
            {
                SmartphoneModel = smartphoneRequest.SmartphoneModel,
                ManufacturerModel = smartphoneRequest.ManufacturerModel
            });


            return Ok(response);
        }

        [HttpPost]
        [Route("/delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult Delete([FromBody] DeleteSmartphoneRequest request)
        {
            var response = _smartphoneService.Delete(request);
            if (response.IsSuccess)
                return Ok();

            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult Update([FromBody] UpdateSmartphoneRequest request)
        {
            var result = _smartphoneService.Update(request);

            if (result.IsSuccess) return Ok(result.Data);

            return NotFound();
        }

    }
}
