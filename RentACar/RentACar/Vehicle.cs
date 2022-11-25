using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar
{
    public class Vehicle
    {
       public Brand Brand { get; set; }
       public string Km { get; set; }
       public string Year { get; set; }
       public bool IsItRent { get; set; }
       public decimal DailyPrice { get; set; }
       public override string ToString()
       {
           return $"{this.Brand.BrandName}-{this.Brand.Models[0].ModelName}({this.Year})";
       }
    }
}
