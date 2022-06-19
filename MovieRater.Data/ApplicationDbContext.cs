using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<MovieEntity> Movies {get; set;}
        // public DbSet<ShowEntity> Shows {get; set;}
        public DbSet<RatingEntity> Ratings {get; set;}
    }
