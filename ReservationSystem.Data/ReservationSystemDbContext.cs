using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReservationSystem.Data.Matches;
using ReservationSystem.Data.Stadiums;
using ReservationSystem.Data.Reservations;
using ReservationSystem.Data.Users;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ReservationSystem.Data;

public class ReservationSystemDbContext : IdentityDbContext<User, Role, string>
{
    public required DbSet<Match> Matches { get; set; }

    public required DbSet<Stadium> Stadiums { get; set; }

    // public DbSet<Team> Teams { get; set; }

    public required DbSet<Ticket> Tickets { get; set; }

    public required DbSet<Reservation> Reservations { get; set; }

    public ReservationSystemDbContext(DbContextOptions<ReservationSystemDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // modelBuilder.Entity<Team>().HasData(Team.QualifiedTeams.Select(t => new Team { Name = t }));

        modelBuilder.Entity<Match>().ToTable(t =>
        {
            t.HasCheckConstraint("CK_Matches_HomeTeamName_AwayTeamName", "HomeTeamName <> AwayTeamName");
        });

        SeedInitialUsers(modelBuilder);

        SeedData(modelBuilder);
    }

    private static void SeedInitialUsers(ModelBuilder modelBuilder)
    {
        var hasher = new PasswordHasher<User>();
        var admin = new User
        {
            Id = "admin",
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            Email = "admin@domain.com",
            NormalizedEmail = "ADMIN@DOMAIN.COM",
            FirstName = "AdminFirstName",
            LastName = "AdminLastName",
            Birthdate = new DateTime(2000, 5, 12),
            Gender = Gender.Unspecified,
            Nationality = "eg"
        };
        admin.PasswordHash = hasher.HashPassword(admin, "admin");

        var initialManager = new User
        {
            Id = "initial-manager",
            UserName = "initialManager",
            NormalizedUserName = "INITIALMANAGER",
            Email = "initialmanager@domain.com",
            NormalizedEmail = "INITIALMANAGER@DOMAIN.COM",
            FirstName = "ManagerFirstName",
            LastName = "ManagerLastName",
            Birthdate = new DateTime(2000, 5, 12),
            Gender = Gender.Unspecified,
            Nationality = "eg"
        };
        initialManager.PasswordHash = hasher.HashPassword(initialManager, "manager");

        var initialUser = new User
        {
            Id = "initial-user",
            UserName = "initialUser",
            NormalizedUserName = "INITIALUSER",
            Email = "initialuser@domain.com",
            NormalizedEmail = "INITIALUSER@DOMAIN.COM",
            FirstName = "UserFirstName",
            LastName = "UserLastName",
            Birthdate = new DateTime(2000, 5, 12),
            Gender = Gender.Unspecified,
            Nationality = "eg"
        };
        initialUser.PasswordHash = hasher.HashPassword(initialUser, "user");

        modelBuilder.Entity<User>().HasData(admin, initialManager, initialUser);

        modelBuilder.Entity<Role>().HasData(Role.Roles);

        var adminRole = new IdentityUserRole<string>
        {
            RoleId = Role.AdminRole.Id,
            UserId = admin.Id
        };

        var initialManagerRole = new IdentityUserRole<string>
        {
            RoleId = Role.ManagerRole.Id,
            UserId = initialManager.Id
        };

        var initialUserRole = new IdentityUserRole<string>
        {
            RoleId = Role.UserRole.Id,
            UserId = initialUser.Id
        };

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(adminRole, initialManagerRole, initialUserRole);
    }

    public static void SeedData(ModelBuilder modelBuilder)
    {
        var stadiums = new Stadium[]
        {
            new Stadium { Name = "Lusail Stadium", Rows = 1, Columns = 2 },
            new Stadium { Name = "Al Bayt Stadium", Rows = 2, Columns = 4 },
            new Stadium { Name = "Khalifa International Stadium", Rows = 4, Columns = 8 },
            new Stadium { Name = "Ahmad bin Ali Stadium", Rows = 8, Columns = 16 },
            new Stadium { Name = "Education City Stadium", Rows = 32, Columns = 64 },
            new Stadium { Name = "Al Thumama Stadium", Rows = 64, Columns = 128 }
        };

        modelBuilder.Entity<Stadium>().HasData(stadiums);

        var seedingTeams = new[]
        {
            "Belgium",
            "Croatia",
            "France",
            "Germany",
            "Netherlands",
            "Portugal",
            "Spain"
        };

        var matchIdToStadiumIndex = new Dictionary<int, int>();
        var matches = new List<Match>();

        for (int i = 0; i < 6; i++)
        {
            var id = i + 1;
            int stadiumIndex = i * 3 % stadiums.Length;
            matchIdToStadiumIndex[id] = stadiumIndex;
            var match = new Match
            {
                Id = id,
                HomeTeamName = seedingTeams[i * 13 % seedingTeams.Length],
                AwayTeamName = seedingTeams[(i * 11 + 13) % seedingTeams.Length],
                StadiumName = stadiums[stadiumIndex].Name,
                DateTime = new DateTime(2023, i % 12 + 1, i % 29 + 1, i % 14 + 8, 0, 0),
                Referee = "Referee " + ((i % 4) + 1),
                FirstLinesman = "First Linesman " + ((i % 3) + 1),
                SecondLinesman = "Second Linesman " + ((i % 2) + 1)
            };
            matches.Add(match);
        }

        modelBuilder.Entity<Match>().HasData(matches);

        var tickets = matches.SelectMany(match =>
        {
            var stadium = stadiums[matchIdToStadiumIndex[match.Id]];
            var tickets = new List<Ticket>();
            for (int i = 0; i < stadium.Rows; i++)
            {
                for (int j = 0; j < stadium.Columns; j++)
                {
                    tickets.Add(new Ticket
                    {
                        MatchId = match.Id,
                        Row = i,
                        Column = j
                    });
                }
            }
            return tickets;
        });

        modelBuilder.Entity<Ticket>().HasData(tickets);
    }
}
