using System;
using System.ComponentModel.DataAnnotations;
using RadRiftGame.Domain.Aggregates;

namespace RadRiftGame.Domain.Services.Db
{
    public class GameResult  
    {  
        [Key]
        public Guid GameId { get; set; }  
        public Guid Player1Id { get; set; }  
        public Guid HostId { get; set; }  
        public decimal Player1Health { get; set; }  
        public decimal HostHealth { get; set; }
        public string Status { get; set; }
    }
}