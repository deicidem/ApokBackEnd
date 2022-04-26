using System.Collections.Generic;
using ApokBackEnd.Models;
using ApokBackEnd.Services.Dto;

namespace ApokBackEnd.Services
{
    public interface IPlanService
    {
        PlanDto GetPlan(int id);
        IEnumerable<PlanDto> GetAllPlans();
        PlanDto UpdatePlan(PlanDto planDto);
        PlanDto AddPlan(PlanDto planDto);
        PlanDto DeletePlan(int id);
    }
}