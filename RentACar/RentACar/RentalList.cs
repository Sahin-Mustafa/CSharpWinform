using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar
{
    public class RentalVehicle
    {
        public Vehicle Vehicle { get; set; }
        public string PersonFullName { get; set; }
        public string Id { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal DownPayment { get; set; }
        public int Days{ get { return EndDate.Subtract(RentalDate).Days; }  }
        public decimal TotalPrice { get { return Days * Vehicle.DailyPrice; } }

        public override string ToString()
        {
            return $"{this.PersonFullName} ({this.RentalDate.ToString("MM/dd/yyyy")} - {this.EndDate.ToString("MM/dd/yyyy")}) Days {this.Days} Total Price {this.TotalPrice}";
        }
    }
}
