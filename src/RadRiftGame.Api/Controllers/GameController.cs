using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RadRiftGame.Contracts.Commands;
using RadRiftGame.Contracts.ValueObjects;
using RadRiftGame.Domain.Projections;
using RadRiftGame.Infrastructure;
using RadRiftGame.Models.GameController;

namespace RadRiftGame.Controllers
{
    public class GameController : Controller
    {
        private FakeBus _bus;
        private IReadModelFacade _readmodel;

        public GameController(FakeBus bus, IReadModelFacade readmodel)
        {
            // todo: inject it
            _bus = bus;
            _readmodel = readmodel;
        }

        // GET
        public IActionResult Index()
        {
            //return View();
            return null;
        }
        
        // POST
        [HttpPost]
        [Route("api/game/create")]
        public OkResult CreateGameRoom([FromBody] CreateGameRoomRequest request)
        {
            var gameRoomId = Guid.NewGuid();
            _bus.Send(new CreateGameRoom(new GameRoomId(gameRoomId), request.Name, SysInfo.CreateSysInfo()));

            return Ok(new {GameRoomid = gameRoomId});
        }
        
        // POST
        [HttpPost]
        [Route("api/game/join")]
        public OkResult JoinGameRoom([FromBody] JoinGameRoomRequest request)
        {
            _bus.Send(new JoinGameRoom(request.GameRoomId, request.UserId, SysInfo.CreateSysInfo()));
            return Ok();
        }
    }
}