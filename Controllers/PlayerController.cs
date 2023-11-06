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
            return View();
        }


        public IActionResult List()
        {
            return View(players);
        }
         public IActionResult Find(int id)
        {
            var data = players.FirstOrDefault(p=>p.Id == id);
            return View(data);
        }
         public IActionResult Add()
        {

            return View();
        }
        [HttpPost]
         public IActionResult Add(Player newPlayer)
        {
            newPlayer.Id = players.Count() + 1;
            players.Add(newPlayer);
            return RedirectToAction("List");
        }
          public IActionResult Edit(int id)
        {
            var data = players.FirstOrDefault(p=>p.Id==id);
            return View(data);
        }
        [HttpPost]
         public IActionResult Edit(Player changePlayer)
        {

            Player player = players.FirstOrDefault(p=>p.Id==changePlayer.Id);
            if(player!=null)
            {
              player.Age = changePlayer.Age;
              player.Name = changePlayer.Name;
              player.Category = changePlayer.Category;
              player.BiddingAmount = changePlayer.BiddingAmount;
            }
            return RedirectToAction("List");
        }
          public IActionResult Delete(int id)
        {
            var data = players.FirstOrDefault(p=>p.Id==id);
             if(data!=null)
             {
                players.Remove(data);
             }
             return RedirectToAction("List");
        }
       

    }
}

