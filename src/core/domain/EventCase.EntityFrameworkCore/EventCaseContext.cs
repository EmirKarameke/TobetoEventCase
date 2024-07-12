using EventCase.Domain.Employees;
using EventCase.Domain.EventRequests;
using EventCase.Domain.Events;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EventCase.EntityFrameworkCore;

public class EventCaseContext : DbContext
{


    public EventCaseContext(DbContextOptions<EventCaseContext> options) : base(options)
    {

    }

    public DbSet<Event> Events { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<EventRequest> EventRequest { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Member>(b =>
        {
            b.ToTable("Members");
            //b.HasKey(i => i.Id);

            b.Property(i => i.Id).IsRequired().HasColumnType(SqlDbType.UniqueIdentifier.ToString());
            b.Property(i => i.UserName).IsRequired().HasMaxLength(72).HasColumnType(SqlDbType.NVarChar.ToString());
            b.Property(i => i.FullName).IsRequired().HasMaxLength(72).HasColumnType(SqlDbType.NVarChar.ToString());
            b.Property(i => i.EmailOrUserName).IsRequired().HasMaxLength(72).HasColumnType(SqlDbType.NVarChar.ToString());

            b.HasMany(i => i.Roles).WithOne(i => (Member)i.User).HasForeignKey(i => i.UserId);
            b.HasMany(i => i.Permissions).WithOne(i => (Member)i.User).HasForeignKey(i => i.UserId);
        });
    }
}
