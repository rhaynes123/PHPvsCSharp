using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PowerOutageReporter.Data;
using PowerOutageReporter.Models;

namespace PowerOutageReporter.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IncidentDbContext _dbContext;
    [BindProperty]
    public Incident Incident { get; set; } = default!;

    public IndexModel(ILogger<IndexModel> logger, IncidentDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public void OnGet()
    {

    }

    public async Task<IActionResult> OnPostAsync()
    {
        if(Incident is null || Incident == default)
        {
            _logger.LogWarning("Incident was null");
            return Page();
        }
        await _dbContext.Incidents.AddAsync(Incident);
        await _dbContext.SaveChangesAsync();
        return Page();
    }
}

