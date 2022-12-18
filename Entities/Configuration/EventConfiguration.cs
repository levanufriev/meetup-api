using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasData(
                new Event
                {
                    Id = Guid.NewGuid(),
                    Theme = "1",
                    Description = "111",
                    Speaker = "1",
                    Date = new DateTime(2022, 12, 31),
                    Place = "1",
                },
                new Event
                {
                    Id = Guid.NewGuid(),
                    Theme = "2",
                    Description = "222",
                    Speaker = "2",
                    Date = new DateTime(2023, 1, 1),
                    Place = "2",
                },
                new Event
                {
                    Id = Guid.NewGuid(),
                    Theme = "3",
                    Description = "333",
                    Speaker = "3",
                    Date = new DateTime(2023, 2, 2),
                    Place = "3",
                },
                new Event
                {
                    Id = Guid.NewGuid(),
                    Theme = "4",
                    Description = "444",
                    Speaker = "4",
                    Date = new DateTime(2023, 3, 3),
                    Place = "4",
                },
                new Event
                {
                    Id = Guid.NewGuid(),
                    Theme = "5",
                    Description = "555",
                    Speaker = "5",
                    Date = new DateTime(2023, 4, 4),
                    Place = "5",
                });
        }
    }
}
