using System;
using DDDExample.Core.Application.DTO;
using DDDExample.Core.Application.Services;
using DDDExample.Core.Domain.Abstract;
using DDDExample.Web.Model;
using Microsoft.AspNetCore.Mvc;

namespace DDDExample.Web.Controllers
{
    [ApiController]
    [Route("bookings")]
    public class BookingsController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IBookingCacheService _bookingCacheService;

        public BookingsController(IBookingService bookingService, IBookingCacheService bookingCacheService)
        {
            _bookingService = bookingService;
            _bookingCacheService = bookingCacheService;
        }

        [HttpPost]
        public IActionResult Create(BookRequest request)
        {
            var dto = new BookingDTO(request.LocationId, request.UserIds, request.StartDate);
            try
            {
                var id = _bookingService.Add(dto);
                return Created(Url.Action(nameof(Get), new {id}), new {id});
            }
            catch (DomainException e)
            {
                return BadRequest(new {ErrorCode = e.Code, ErrorMessage = e.Message});
            }
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _bookingService.Cancel(id);
                return NoContent();
            }
            catch (DomainException e)
            {
                return BadRequest(new {ErrorCode = e.Code, ErrorMessage = e.Message});
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var dto = _bookingCacheService.Get(id);
            if (dto is null)
            {
                return NotFound();
            }

            return Ok(dto);
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var dtos = _bookingCacheService.GetAll();
            if (dtos is null)
            {
                return NotFound();
            }

            return Ok(dtos);
        }
    }
}