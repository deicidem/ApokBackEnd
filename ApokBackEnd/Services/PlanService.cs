using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ApokBackEnd.Data;
using ApokBackEnd.Models;
using ApokBackEnd.Services.Dto;
using System.Collections.Generic;
using System.Linq;

namespace ApokBackEnd.Services
{
    public class PlanService:IPlanService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        
        public PlanService(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<PlanDto> GetAllPlans()
        {
            return _mapper.Map<IEnumerable<PlanModel>, IEnumerable<PlanDto>>(_context.Plans.ToList());
        }
        public PlanDto GetPlan(int id)
        {
            return _mapper.Map<PlanDto>(_context.Plans.FirstOrDefault(m => m.Id == id));
        }

        public PlanDto UpdatePlan(PlanDto planDto)
        {
            if (planDto.Id == null)
            {
                //упрощение для примера
                //лучше всего генерировать ошибки и обрабатывать их на уровне конроллера
                return null;
            }
            
            try
            {
                var plan = _mapper.Map<PlanModel>(planDto);
                
                _context.Update(plan);
                _context.SaveChanges();
                
                return _mapper.Map<PlanDto>(plan);
            }
            catch (DbUpdateException)
            {
                if (!PlanExists((int) planDto.Id))
                {
                    //упрощение для примера
                    //лучше всего генерировать ошибки и обрабатывать их на уровне конроллера
                    return null;
                }
                else
                {
                    //упрощение для примера
                    //лучше всего генерировать ошибки и обрабатывать их на уровне конроллера
                    return null;
                }
            }
        }

        public PlanDto AddPlan(PlanDto planDto)
        {
            var plan = _context.Add(_mapper.Map<PlanModel>(planDto)).Entity;
            _context.SaveChanges();
            return _mapper.Map<PlanDto>(plan);
        }

        public PlanDto DeletePlan(int id)
        {
            var plan = _context.Plans.Find(id);
            if (plan == null)
            {
                //упрощение для примера
                //лучше всего генерировать ошибки и обрабатывать их на уровне конроллера
                return null;
            }

            _context.Plans.Remove(plan);
            _context.SaveChanges();
            
            return _mapper.Map<PlanDto>(plan);
        }
        
        private bool PlanExists(int id)
        {
            return _context.Plans.Any(e => e.Id == id);
        }

    }
}