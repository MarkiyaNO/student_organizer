using AutoMapper;
using StudentOrganizer.BLL.Interfaces;
using StudentOrganizer.BLL.Models;
using StudentOrganizer.DAL.Entities;
using StudentOrganizer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentOrganizer.BLL.Services
{
    public class ScheduleService : IScheduleService
    {
        // не доробили
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public ScheduleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task AddAsync(ScheduleDTO model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int modelId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ScheduleDTO>> GetAllAsync()
        {
            var schedules = await _unitOfWork.Schedules.GetAllAsync();
            return _mapper.Map<IEnumerable<Schedule>, IEnumerable<ScheduleDTO>>(schedules);
        }

        public async Task<IEnumerable<ScheduleDTO>> GetAllWithDetailsAsync()
        {
            var schedules = await _unitOfWork.Schedules.GetAllWithDetailsAsync();
            return _mapper.Map<IEnumerable<Schedule>, IEnumerable<ScheduleDTO>>(schedules);
        }

        public async Task<ScheduleDTO> GetByIdAsync(int id)
        {
            var schedule = await _unitOfWork.Schedules.GetByIdAsync(id);
            return _mapper.Map<Schedule, ScheduleDTO>(schedule);
        }

        public async Task<ScheduleDTO> GetByIdWithDetailsAsync(int id)
        {
            var schedule = await _unitOfWork.Schedules.GetByIdWithDetailsAsync(id);
            return _mapper.Map<Schedule, ScheduleDTO>(schedule);
        }

        public Task UpdateAsync(ScheduleDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
