using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Collections.Generic;

namespace dotnetapp.Models{

    public class Team{


        [Key]
        public int TeamID{get;set;}
        public string Name{get;set;}
        public ICollection<Player>Players{get;set;}
    }
}