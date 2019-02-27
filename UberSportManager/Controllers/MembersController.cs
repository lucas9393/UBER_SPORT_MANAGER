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
    public class MembersController : ControllerBase
    {
        private readonly IMapper _mapper;
        public IUnitOfWork UnitOfWork { get; set; }

        public MembersController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<MemberDTO[]>> GetMembers()
        {
            try
            {

                var members = await UnitOfWork.AllMembers();

                return _mapper.Map<MemberDTO[]>(members);
            }

            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }


        [HttpGet("searchByName")]
        public async Task<ActionResult<MemberDTO []>> GetMembersByString(string queryString)
        {
            try
            {
                var result = await UnitOfWork.SearchMemberByString(queryString);
                if (result == null) return NotFound();
                return _mapper.Map<MemberDTO []>(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("searchByAge")]
        public async Task<ActionResult<MemberDTO[]>> GetMembersByAge(int startAge, int endAge)
        {
            try
            {
                var result = await UnitOfWork.SearchMemberByAgeRange(startAge, endAge);

                if (result == null) return NotFound();

                return _mapper.Map<MemberDTO[]>(result);

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("searchByDateOfRegistration")]
        public async Task<ActionResult<MemberDTO[]>> GetMembersByDateOfRegistration(DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = await UnitOfWork.SearchMemberByDateOfRegistration(startDate, endDate);

                if (result == null) return NotFound();

                return _mapper.Map<MemberDTO[]>(result);

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

    }

}
