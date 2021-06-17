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
    public class ScheduleLessonService : IScheduleLessonService
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public ScheduleLessonService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(ScheduleLessonDTO model)
        {
            var scheduleLesson = _mapper.Map<ScheduleLessonDTO, ScheduleLesson>(model);
            await _unitOfWork.ScheduleLessons.AddAsync(scheduleLesson);
            await _unitOfWork.SaveAsync();
        }

        public async Task AddAsync(ScheduleLessonDTO model, ScheduleDTO schedule)
        {
            var _schedule = _mapper.Map<ScheduleDTO, Schedule>(schedule);
            var scheduleLesson = _mapper.Map<ScheduleLessonDTO, ScheduleLesson>(model);
            await _unitOfWork.ScheduleLessons.AddAsync(scheduleLesson, _schedule);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            var scheduleLesson = await _unitOfWork.ScheduleLessons.GetByIdAsync(modelId);
            _unitOfWork.ScheduleLessons.Remove(scheduleLesson);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId, ScheduleDTO schedule)
        {
            var _schedule = _mapper.Map<ScheduleDTO, Schedule>(schedule);
            var scheduleLesson = await _unitOfWork.ScheduleLessons.GetByIdAsync(modelId);
            _unitOfWork.ScheduleLessons.Remove(scheduleLesson,_schedule);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ScheduleLessonDTO>> GetAllAsync()
        {
            var scheduleLessons = await _unitOfWork.ScheduleLessons.GetAllAsync();
            return _mapper.Map<IEnumerable<ScheduleLesson>, IEnumerable<ScheduleLessonDTO>>(scheduleLessons);
        }

        public async Task<IEnumerable<ScheduleLessonDTO>> GetAllAsync(ScheduleDTO schedule)
        {
            var _schedule = _mapper.Map<ScheduleDTO, Schedule>(schedule);
            var scheduleLessons = await _unitOfWork.ScheduleLessons.GetAllAsync(_schedule);
            return _mapper.Map<IEnumerable<ScheduleLesson>, IEnumerable<ScheduleLessonDTO>>(scheduleLessons);
        }

        public async Task<ScheduleLessonDTO> GetByIdAsync(int id)
        {
            var scheduleLesson = await _unitOfWork.ScheduleLessons.GetByIdAsync(id);
            return _mapper.Map<ScheduleLesson, ScheduleLessonDTO>(scheduleLesson);
        }

        public async Task<ScheduleLessonDTO> GetByIdAsync(int id, ScheduleDTO schedule)
        {
            var _schedule = _mapper.Map<ScheduleDTO, Schedule>(schedule);
            var scheduleLesson = await _unitOfWork.ScheduleLessons.GetByIdAsync(id,_schedule);
            return _mapper.Map<ScheduleLesson, ScheduleLessonDTO>(scheduleLesson);
        }

        public async Task UpdateAsync(ScheduleLessonDTO model)
        {
            var scheduleLesson = _mapper.Map<ScheduleLessonDTO, ScheduleLesson>(model);
            _unitOfWork.ScheduleLessons.Update(scheduleLesson);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(ScheduleLessonDTO model, ScheduleDTO schedule)
        {
            var _schedule = _mapper.Map<ScheduleDTO, Schedule>(schedule);
            var scheduleLesson = _mapper.Map<ScheduleLessonDTO, ScheduleLesson>(model);
            _unitOfWork.ScheduleLessons.Update(scheduleLesson,_schedule);
            await _unitOfWork.SaveAsync();
        }
    }
}
