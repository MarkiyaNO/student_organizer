using AutoMapper;
using Microsoft.AspNetCore.Identity;
using StudentOrganizer.BLL.Interfaces;
using StudentOrganizer.BLL.Models;
using StudentOrganizer.DAL.Entities;
using StudentOrganizer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StudentOrganizer.BLL.Services
{
    public class ScheduleService : IScheduleService
    {
        // не доробили
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        UserManager<Student> _userManager;

        public ScheduleService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<Student> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task AddAsync(ScheduleDTO model)
        {
            var schedule = _mapper.Map<ScheduleDTO, Schedule>(model);
            
            await _unitOfWork.Schedules.AddAsync(schedule);
            await _unitOfWork.SaveAsync();
        }

        public async Task AddAsync(ScheduleDTO model, ClaimsPrincipal user)
        {
            var schedule = _mapper.Map<ScheduleDTO, Schedule>(model);
            var student = await _userManager.GetUserAsync(user);
            await _unitOfWork.Schedules.AddAsync(schedule, student);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            var schedule = await _unitOfWork.Schedules.GetByIdAsync(modelId);
            _unitOfWork.Schedules.Remove(schedule);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId, ClaimsPrincipal user)
        {
            var student = await _userManager.GetUserAsync(user);
            var schedule = await _unitOfWork.Schedules.GetByIdAsync(modelId, student);
            _unitOfWork.Schedules.Remove(schedule);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ScheduleDTO>> GetAllAsync()
        {
            var schedules = await _unitOfWork.Schedules.GetAllAsync();
            return _mapper.Map<IEnumerable<Schedule>, IEnumerable<ScheduleDTO>>(schedules);
        }

        public async Task<IEnumerable<ScheduleDTO>> GetAllAsync(ClaimsPrincipal user)
        {
            var student = await _userManager.GetUserAsync(user);
            var schedules = await _unitOfWork.Schedules.GetAllAsync(student);
            return _mapper.Map<IEnumerable<Schedule>, IEnumerable<ScheduleDTO>>(schedules);
        }

        public async Task<IEnumerable<ScheduleDTO>> GetAllWithDetailsAsync()
        {
            var schedules = await _unitOfWork.Schedules.GetAllWithDetailsAsync();
            return _mapper.Map<IEnumerable<Schedule>, IEnumerable<ScheduleDTO>>(schedules);
        }

        public async Task<IEnumerable<ScheduleDTO>> GetAllWithDetailsAsync(ClaimsPrincipal user)
        {
            var student = await _userManager.GetUserAsync(user);
            var schedules = await _unitOfWork.Schedules.GetAllWithDetailsAsync(student);
            return _mapper.Map<IEnumerable<Schedule>, IEnumerable<ScheduleDTO>>(schedules);
        }

        public async Task<ScheduleDTO> GetByIdAsync(int id)
        {
            var schedule = await _unitOfWork.Schedules.GetByIdAsync(id);
            return _mapper.Map<Schedule, ScheduleDTO>(schedule);
        }

        public async Task<ScheduleDTO> GetByIdAsync(int id, ClaimsPrincipal user)
        {
            var student = await _userManager.GetUserAsync(user);
            var schedule = await _unitOfWork.Schedules.GetByIdAsync(id,student);
            return _mapper.Map<Schedule, ScheduleDTO>(schedule);
        }

        public async Task<ScheduleDTO> GetByIdWithDetailsAsync(int id)
        {
            var schedule = await _unitOfWork.Schedules.GetByIdWithDetailsAsync(id);
            return _mapper.Map<Schedule, ScheduleDTO>(schedule);
        }

        public async Task<ScheduleDTO> GetByIdWithDetailsAsync(int id, ClaimsPrincipal user)
        {
            var student = await _userManager.GetUserAsync(user);
            var schedule = await _unitOfWork.Schedules.GetByIdWithDetailsAsync(id,student);
            return _mapper.Map<Schedule, ScheduleDTO>(schedule);
        }

        public async Task UpdateAsync(ScheduleDTO model)
        {
            var schedule = _mapper.Map<ScheduleDTO, Schedule>(model);
            _unitOfWork.Schedules.Update(schedule);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(ScheduleDTO model, ClaimsPrincipal user)
        {
            var student = await _userManager.GetUserAsync(user);
            var schedule = _mapper.Map<ScheduleDTO, Schedule>(model);
            _unitOfWork.Schedules.Update(schedule,student);
            await _unitOfWork.SaveAsync();
        }
    }
}
