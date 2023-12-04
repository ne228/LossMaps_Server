using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class StatementRepository
{
    private readonly YourDbContext _dbContext;

    public StatementRepository(YourDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    // Create
    public async Task CreateStatementAsync(Statement statement)
    {
        await _dbContext.Statement.AddAsync(statement);
        await _dbContext.SaveChangesAsync();
    }

    // Read
    public async Task<Statement> GetStatementByIdAsync(long id)
    {
        return await _dbContext.Statement.FindAsync(id);
    }

    public async Task<List<Statement>> GetAllStatementsAsync()
    {
        return await _dbContext.Statement.ToListAsync();
    }

    // Update
    public async Task UpdateStatementAsync(Statement statement)
    {
        _dbContext.Entry(statement).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    // Delete
    public async Task DeleteStatementAsync(long id)
    {
        var statement = await _dbContext.Statement.FindAsync(id);
        if (statement != null)
        {
            _dbContext.Statement.Remove(statement);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<List<Statement>> FindStatement(string surname, string name, string patronymic)
    {
        IQueryable<Statement> query = _dbContext.Statement;

        if (!string.IsNullOrEmpty(surname))
        {
            query = query.Where(x => x.LastName == surname);
        }

        if (!string.IsNullOrEmpty(name))
        {
            query = query.Where(x => x.FirstName == name);
        }

        if (!string.IsNullOrEmpty(patronymic))
        {
            query = query.Where(x => x.Patronymic == patronymic);
        }

        return await query.ToListAsync();
    }

}


public class YourDbContext : DbContext
{
    public DbSet<Statement> Statement { get; set; }

    public YourDbContext(DbContextOptions<YourDbContext> options) : base(options)
    {
    }

    public YourDbContext()
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Задайте формат даты в базе данных
        modelBuilder.Entity<Statement>()
            .Property(x => x.BirthDate)
            .HasColumnType("TEXT")
            .HasConversion(
                v => v.ToString("yyyy-MM-dd"), // Форматируйте дату перед сохранением в базу данных
                v => DateTime.ParseExact(v, "yyyy-MM-dd", null) // Восстанавливайте дату при чтении из базы данных
            );
    }
}

