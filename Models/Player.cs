using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
   public class Player {
     
     public int Id{get;set;} 
     public string Name{get;set;} 
     public int Age{get;set;} 
     public string Category{get;set;} 
     public decimal BiddingAmount{get;set;} 
     }
}
