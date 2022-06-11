using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RadRiftGame.Contracts.Commands;
using RadRiftGame.Contracts.ValueObjects;
using RadRiftGame.Domain;
using RadRiftGame.Domain.Aggregates;
using RadRiftGame.Domain.Projections;
using RadRiftGame.Domain.Services;
using RadRiftGame.Infrastructure;
using RadRiftGame.Models.GameController;

namespace RadRiftGame.Controllers
{
    public class GameController : Controller
    {
        private FakeBus _bus;
        private IReadModelFacade _readmodel;
        private IGameProcessService _gameProcessService;
        private readonly IRepository<GameRoom> _repository;


        public GameController(FakeBus bus, IReadModelFacade readmodel, IGameProcessService gameProcessService, IRepository<GameRoom> repository, IServiceProvider provider)
        {
            // todo: inject it
            _bus = bus;
            _readmodel = readmodel;
            _gameProcessService = gameProcessService;
            _repository = repository;
            //_repository.SetServiceProvider(provider);
            _gameProcessService.Stub();
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
        public OkObjectResult CreateGameRoom([FromBody] CreateGameRoomRequest request)
        {
            var gameRoomId = Guid.NewGuid();
            _bus.Send(new CreateGameRoom(new GameRoomId(gameRoomId), request.Name, new UserId(request.HostUserId) , SysInfo.CreateSysInfo()));

            return Ok(new {GameRoomid = gameRoomId});
        }
        
        // GET
        [HttpGet]
        [Route("api/game/list")]
        public OkObjectResult JoinGameRoom()
        {
            var concurrentDictionary = _readmodel.GetChatRooms();
            return Ok(concurrentDictionary.ToDictionary(x=>x.Key.Id.ToString(),y=>y.Value));
        }
        
        // GET
        [HttpGet]
        [Route("api/game/{guid}")]
        public OkObjectResult GetGameRoomInfo(Guid guid)
        {
            var room = _repository.GetById(guid);
            return Ok(room.ToString());
        }
        
        // POST
        [HttpPost]
        [Route("api/game/join")]
        public OkResult JoinGameRoom([FromBody] JoinGameRoomRequest request)
        {
            _bus.Send(new JoinGameRoom(new GameRoomId(request.GameRoomId) , new UserId(request.UserId) , SysInfo.CreateSysInfo()));
            return Ok();
        }
    }
}