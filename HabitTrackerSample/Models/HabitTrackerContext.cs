using Microsoft.EntityFrameworkCore;

namespace HabitTrackerSample.Models
{
    public class HabitTrackerContext : DbContext
    {
        public DbSet<Habit> Habits { get; set; }

        public string DbPath { get; }

        public HabitTrackerContext()
        {
            var path = Path.GetTempPath();

            DbPath = Path.Join(path, "HabitTrackerSample.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");
    }
}
