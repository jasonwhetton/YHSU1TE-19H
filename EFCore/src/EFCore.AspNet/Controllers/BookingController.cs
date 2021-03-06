﻿using System;
using System.Collections.Generic;
using System.Linq;
using EFCore.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static EFCore.Domain.BookingService;

namespace EFCore.AspNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly ILogger<BookingsController> logger;
        private readonly BookingService bookingService;

        public BookingsController(BookingService bookingService, ILogger<BookingsController> logger)
        {
            this.bookingService = bookingService;
            this.logger = logger;
        }

        [HttpPost]
        public IActionResult CreateBooking([FromBody]CreateBookingRequest request)
        {
            bookingService.CreateBooking(new BookingService.CreateBookingRequest(request.Id, request.RequestedBy, request.Date));

            return Ok();
        }

        public class CancelBookingRequest
        {
            public string Id { get; set; }
        }

        /// <summary>
        /// Asp.net wants public properties.
        /// </summary>
        public class CreateBookingRequest
        {
            public string Id { get; set; }
            public string RequestedBy { get; set;  }
            public DateTime Date { get; set; }
        }
    }
}
