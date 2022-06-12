using System;
using System.ComponentModel.DataAnnotations;

namespace RadRiftGame.Domain.DbModels
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