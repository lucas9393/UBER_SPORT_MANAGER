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

        public ReservationsController(IMapper mapper)
        {
           
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<ReservationDTO[]> Get()
        {
            try
            {
                Field campo1 = new TennisField(name: "pippo", terrainType: TerrainType.Grass, price: 70.00m);
                Field campo2 = new PaddleField(name: "pluto", terrainType: TerrainType.Grass, price: 70.00m);
                Field campo3 = new SoccerField(name: "paperino", terrainType: TerrainType.Grass, price: 70.00m, isSeven: true);

                Member user1 = new Member(nome: "Luca", cognome: "Vaccaro", dor: DateTime.Now);
                Member user2 = new Member(nome: "Gianluca", cognome: "Marino", dor: DateTime.Now);


                Reservation reservation1 = new Reservation(field: campo1, member: user1, date: DateTime.Now, isDouble: false);
                Reservation reservation2 = new Reservation(field: campo2, member: user2, date: DateTime.Now, isDouble: false);
                Reservation reservation3 = new Reservation(field: campo3, member: user1, date: DateTime.Now, isDouble: false);


                var results = new List<Reservation>()
                {
                    reservation1, reservation2, reservation3
                };

                return _mapper.Map<ReservationDTO[]>(results.ToArray());
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("{nomeCampo}")]
        public ActionResult<ReservationDTO> Get(string nomeCampo)
        {
            try
            {

                Field campo1 = new TennisField(name: "pippo", terrainType: TerrainType.Grass, price: 70.00m);
                Field campo2 = new PaddleField(name: "pluto", terrainType: TerrainType.Grass, price: 70.00m);
                Field campo3 = new SoccerField(name: "paperino", terrainType: TerrainType.Grass, price: 70.00m, isSeven: true);

                Member user1 = new Member(nome: "Luca", cognome: "Vaccaro", dor: DateTime.Now);
                Member user2 = new Member(nome: "Gianluca", cognome: "Marino", dor: DateTime.Now);


                Reservation reservation1 = new Reservation(field: campo1, member: user1, date: DateTime.Now, isDouble: false);
                Reservation reservation2 = new Reservation(field: campo2, member: user2, date: DateTime.Now, isDouble: false);
                Reservation reservation3 = new Reservation(field: campo3, member: user1, date: DateTime.Now, isDouble: false);


                var results = new List<Reservation>()
                {
                    reservation1, reservation2, reservation3
                };


                var result = results.Where(r => r.Field.Name == nomeCampo).First();

                if (result == null) return NotFound();

                return _mapper.Map<ReservationDTO>(result);

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("search")]
        public ActionResult<ReservationDTO[]> SearchByDate(string nomeUtente)
        {
            try
            {
                Field campo1 = new TennisField(name: "pippo", terrainType: TerrainType.Grass, price: 70.00m);
                Field campo2 = new PaddleField(name: "pluto", terrainType: TerrainType.Grass, price: 70.00m);
                Field campo3 = new SoccerField(name: "paperino", terrainType: TerrainType.Grass, price: 70.00m, isSeven: true);

                Member user1 = new Member(nome: "Luca", cognome: "Vaccaro", dor: DateTime.Now);
                Member user2 = new Member(nome: "Gianluca", cognome: "Marino", dor: DateTime.Now);


                Reservation reservation1 = new Reservation(field: campo1, member: user1, date: DateTime.Now, isDouble: false);
                Reservation reservation2 = new Reservation(field: campo2, member: user2, date: DateTime.Now, isDouble: false);
                Reservation reservation3 = new Reservation(field: campo3, member: user1, date: DateTime.Now, isDouble: false);


                var results = new List<Reservation>()
                {
                    reservation1, reservation2, reservation3
                };


                var result1 = results.Where(r => r.Member.Name.Contains(nomeUtente));
                

                if (!result1.Any()) return NotFound();

                return _mapper.Map<ReservationDTO[]>(result1);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
    }
}