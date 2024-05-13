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
                Created = DateTime.UtcNow
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
        [HttpGet("/GetHabitsCreatedTodayCount")]
        public async Task<string> GetHabitsCreatedTodayCount()
        {
            using var db = new HabitTrackerContext();

            //Today start
            var today = DateTime.Today;

            //Tomrrow start
            var tomorrow = today.AddDays(1);

            //Taking only in the range of {today, tomorrow}
            var habitCountToday = await db.Habits.Where(h => h.Created >= today && h.Created < tomorrow).CountAsync();

            return $"Habit Count Today: {habitCountToday}";
        }
    }
}
