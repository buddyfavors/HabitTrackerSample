using System;
using System.ComponentModel.DataAnnotations;


namespace HabitTrackerSample.Models
{
    public class Rewards
    {
        [Key]
        public int RewardId { get; set; }
        public string Name { get; set;}
        public DateTime Created {  get; set; }
    }
}
