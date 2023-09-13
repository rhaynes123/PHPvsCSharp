using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PowerOutageReporter.Repositories;
using PowerOutageReporter.Models;

namespace PowerOutageReporter.Pages
{
    public class IncidentsModel : PageModel
    {
        private readonly IncidentRepository _repository;

        public IncidentsModel(IncidentRepository repository)
        {
            _repository = repository;
        }

        public IList<Incident> Incident { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var incidents = await _repository.GetIncidentsAsync();
            if (incidents != null)
            {
                Incident = incidents;
            }
        }
    }
}
