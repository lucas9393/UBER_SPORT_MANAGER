using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UberSportManager.DTO;
using USM_Model;
using Microsoft.AspNetCore.Http;

namespace UberSportManager.Controllers
{
    [Route("api/[controller]")]
    public class FieldController : Controller
    {
        private readonly IMapper _mapper;
        public IUnitOfWork UnitOfWork { get; set; }

        public FieldController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<FieldDTO[]>> GetFields()
        {
            try
            {
                var fields = await UnitOfWork.AllFields();
                return _mapper.Map<FieldDTO[]>(fields);
            }

            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("searchByFieldName")]
        public async Task<ActionResult<FieldDTO[]>> GetByFieldName(string fieldName)
        {
            try
            {
                var result = await UnitOfWork.SearchFieldByName(fieldName);
                if (result == null) return NotFound();
                return _mapper.Map<FieldDTO[]>(result);
            }

            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("searchFieldByType")]
        public async Task<ActionResult<FieldDTO[]>> GetFieldByType(TerrainType fieldType)
        {
            try
            {
                var result = await UnitOfWork.SearchFieldByType(fieldType);
                if (result == null) return NotFound();
                return _mapper.Map<FieldDTO[]>(result);
            }

            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("searchFieldBySportType")]
        public async Task<ActionResult<FieldDTO[]>> GetFieldBySport(SportType sportType)
        {
            try
            {
                var result = await UnitOfWork.SearchFieldBySport(sportType);
                if (result == null) return NotFound();
                return _mapper.Map<FieldDTO[]>(result);
            }

            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
    }
}