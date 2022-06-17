#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace wedding_planner.Models
{
    public class Attendee
    {
        [Key]
        public int AttendeeId {get; set;}
        public int UserId {get; set;}
        public int WeddingId {get; set;}
        public User User {get; set;}
        public Wedding Wedding {get; set;}
    }
}