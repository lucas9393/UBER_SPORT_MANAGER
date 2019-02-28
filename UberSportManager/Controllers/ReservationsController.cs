using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using UberSportManager.DTO;
using USM_Model;
using Microsoft.AspNetCore.Http;

namespace UberSportManager.Controllers
{
  
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly IMapper _mapper;
        public IUnitOfWork UnitOfWork { get; set; }

        public ReservationsController(IMapper mapper, IUnitOfWork unitOfWork)
        {          
            _mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<ReservationDTO[]>> GetReservations()
        {
            try
            {
                var reservations = await UnitOfWork.AllReservations();
                return _mapper.Map<ReservationDTO[]>(reservations);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("searchByField")]
        public async Task<ActionResult<ReservationDTO[]>> GetReservaitonByField(string queryStringField)
        {
            try
            {
                var result = await UnitOfWork.SearchReservationsByField(queryStringField);
                if (result == null) return NotFound();
                return _mapper.Map<ReservationDTO[]>(result);
            }

            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }


        [HttpGet("SearchByMemberName")]
        public async Task<ActionResult<ReservationDTO[]>> GetByMemberName(string memberName)
        {
            try
            {
                var result = await UnitOfWork.SearchReservationsByMemberName(memberName);
                if (result == null) return NotFound();
                return _mapper.Map<ReservationDTO[]>(result);
            }

            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("searchByDate")]
        public async Task<ActionResult<ReservationDTO[]>> GetReservationsByDate(DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = await UnitOfWork.SearchReservationsByDate(startDate, endDate);
                if (result == null) return NotFound();
                return _mapper.Map<ReservationDTO[]>(result);

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
    }
}