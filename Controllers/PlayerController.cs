using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;

namespace dotnetapp.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private static List<Player>players = new List<Player>{new Player{Id=1,Name="Virat",Age=22,Category="Lord",BiddingAmount=33939}};


        public PlayerController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index(){
            var data = _context.Players.ToList();
            return View(data);
        }

        public IActionResult DisplayPlayers()
        {
            var data = _context.Players.ToList();
            return View(data);

        }

        public IActionResult DisplayTeams(){
            var data = _context.Teams.ToList();
            return View(data);
        }

        public IActionResult AddTeam(){
            return View();

        }
        [HttpPost]
        public IActionResult AddTeam(Team team){
         _context.Teams.Add(team);
         _context.SaveChanges();
         return RedirectToAction("DisplaysAllPlayers");
            
        }


        public IActionResult DisplaysAllPlayers()
        {
           var data = _context.Players.ToList();
            return View(data);
        }

        
         public IActionResult Find(int id)
        {
          //  var data = players.FirstOrDefault(p=>p.Id == id);
          var data = _context.Players.Find(id);
            return View(data);
        }
         public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
         public IActionResult Create(Player newPlayer)
        {
            // newPlayer.Id = players.Count() + 1;
            _context.Players.Add(newPlayer);
            _context.SaveChanges();
            // players.Add(newPlayer);

            return RedirectToAction("DisplaysAllPlayers");
        }
          public IActionResult Edit(int id)
        {
            //var data = players.FirstOrDefault(p=>p.Id==id);
            var data = _context.Players.Find(id);
            return View(data);
        }
        [HttpPost]
         public IActionResult Edit(Player changePlayer)
        {
          // Player player = players.FirstOrDefault(p=>p.Id==changePlayer.Id);
            if(ModelState.IsValid)
            {
            Player player = _context.Players.Find(changePlayer.Id);
              player.Age = changePlayer.Age;
              player.Name = changePlayer.Name;
              player.Category = changePlayer.Category;
              player.BiddingAmount = changePlayer.BiddingAmount;
              _context.SaveChanges();
            return RedirectToAction("DisplaysAllPlayers");
            }
            return View();
        }
          public IActionResult Delete(int id)
        {
            var data = players.FirstOrDefault(p=>p.Id==id);
             if(data!=null)
             {
                players.Remove(data);
             }
             return RedirectToAction("DisplaysAllPlayers");
        }

        public IActionResult DeleteConfirmed(int id)
        {
            var data = _context.Players.Find(id);
            Player play = _context.Players.Find(id);
            _context.Players.Remove(play);
            _context.SaveChanges();
            return RedirectToAction("DisplaysAllPlayers");
        }

        [HttpPost]
         public IActionResult DeleteConfirmed(Player p)
        {
            
            Player play = _context.Players.Find(p.Id);
                _context.Players.Remove(play);
                _context.SaveChanges();
            
            var data = _context.Players.Find(p.Id);
            return View(data);
             
             return RedirectToAction("DisplaysAllPlayers");
        }

   
       

    }
}

