using System;

namespace FSMS.Models
{
    public class Volunteer
    {
        public int VolunteerID { get; set; }

        public int UserID { get; set; }

        public string FullName { get; set; }

        public string Phone { get; set; }

        public string Area { get; set; }

        public string Status { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}