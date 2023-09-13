using System;
using Microsoft.EntityFrameworkCore;
using PowerOutageReporter.Data;
using PowerOutageReporter.Models;

namespace PowerOutageReporter.Repositories
{
    public sealed class IncidentRepository
    {
        private readonly IncidentDbContext _dbContext;

        public IncidentRepository(IncidentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Incident>> GetIncidentsAsync()
        {
            return await _dbContext.Incidents.ToListAsync();
        }
    }
}

