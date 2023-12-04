using LossMaps_Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

[Route("api/statements")]
[ApiController]
public class StatementController : ControllerBase
{
    private readonly StatementRepository _statementRepository;

    public StatementController(StatementRepository statementRepository)
    {
        _statementRepository = statementRepository ?? throw new ArgumentNullException(nameof(statementRepository));
    }

    // GET api/statements
    [HttpGet]
    public async Task<IActionResult> GetAllStatements()
    {
        var statements = await _statementRepository.GetAllStatementsAsync();
        return Ok(statements);
    }

    // GET api/statements/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetStatementById(long id)
    {
        var statement = await _statementRepository.GetStatementByIdAsync(id);

        if (statement == null)
        {
            return NotFound();
        }

        return Ok(statement);
    }


    // Get api/gen/count
    [HttpGet("gen/{count}")]
    public async Task<IActionResult> CreateStatement(int count = 5)
    {
        
        StatementRandomGenerator statementRandomGenerator = new StatementRandomGenerator();

        var statements = new List<Statement>(); 
        
        for (int i = 0; i < count; i++)
        {
            var statement = statementRandomGenerator.GetRandomStatement();
            statements.Add(statement);
            await _statementRepository.CreateStatementAsync(statement);          
         
        }




        return Ok(statements);
    }

    // POST api/statements
    [HttpPost]
    public async Task<IActionResult> CreateStatement([FromBody] Statement statement)
    {
        if (statement == null)
        {
            return BadRequest("Invalid statement object");
        }

        await _statementRepository.CreateStatementAsync(statement);

        return CreatedAtAction(nameof(GetStatementById), new { id = statement.Id }, statement);
    }

    // PUT api/statements/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStatement(long id, [FromBody] Statement updatedStatement)
    {
        if (updatedStatement == null || id != updatedStatement.Id)
        {
            return BadRequest("Invalid statement object");
        }

        var existingStatement = await _statementRepository.GetStatementByIdAsync(id);

        if (existingStatement == null)
        {
            return NotFound();
        }

        await _statementRepository.UpdateStatementAsync(updatedStatement);

        return NoContent();
    }

    // DELETE api/statements/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStatement(long id)
    {
        var statement = await _statementRepository.GetStatementByIdAsync(id);

        if (statement == null)
        {
            return NotFound();
        }

        await _statementRepository.DeleteStatementAsync(id);

        return NoContent();
    }

    [HttpGet("find")]
    public async Task<ActionResult<List<Statement>>> FindStatement([FromQuery] string surname ="", [FromQuery] string name ="", [FromQuery] string patronymic = "")
    {
        try
        {
            var result = await _statementRepository.FindStatement(surname, name, patronymic);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }
}
