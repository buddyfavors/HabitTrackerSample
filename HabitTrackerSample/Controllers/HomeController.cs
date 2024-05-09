using HabitTrackerSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HabitTrackerSample.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public string Get()
        {
            return $"Hello and welcome to your C# and API test project! This project will servve as a quick and dirty test, it is not expetected to take much time and mimicing existing work in different ways.";
        }

        [HttpGet("/CreateHabit")]
        public async Task<string> CreateHabit()
        {
            using var db = new HabitTrackerContext();

            var habit = new Habit
            {
                Name = Guid.NewGuid().ToString(),
            };

            db.Habits.Add(habit);

            await db.SaveChangesAsync();

            return $"HabitId: {habit.HabitId}";
        }

        [HttpGet("/GetHabitCount")]
        public async Task<string> GetHabitCount()
        {
            using var db = new HabitTrackerContext();

            var habitCount = await db.Habits.CountAsync();

            return $"Habit Count: {habitCount}";
        }
    }
}
