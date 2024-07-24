using Microsoft.EntityFrameworkCore;
using Scratch_Cards_API.Models;

namespace Scratch_Cards_API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {        
    }

    public DbSet<ScratchCard> ScratchCards { get; set; }
}
