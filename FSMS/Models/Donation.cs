using System;

namespace FSMS.Models
{
    public class Donation
    {
        public int DonationID { get; set; }

        public int RestaurantID { get; set; }

        public string FoodType { get; set; }

        public int Quantity { get; set; }

        public DateTime DonationDate { get; set; }

        public DateTime ExpiryTime { get; set; }

        public string Status { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}