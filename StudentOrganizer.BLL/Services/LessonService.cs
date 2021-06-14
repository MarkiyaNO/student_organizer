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
    public class LessonService : ILessonService
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public LessonService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(LessonDTO model)
        {
            var lesson = _mapper.Map<LessonDTO, Lesson>(model);
            await _unitOfWork.Lessons.AddAsync(lesson);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            var lesson = await _unitOfWork.Lessons.GetByIdAsync(modelId);
            _unitOfWork.Lessons.Remove(lesson);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<LessonDTO>> GetAllAsync()
        {
            var lessons= await _unitOfWork.Lessons.GetAllAsync();
            return _mapper.Map<IEnumerable<Lesson>, IEnumerable<LessonDTO>>(lessons);
        }

        public async Task<LessonDTO> GetByIdAsync(int id)
        {
            var lesson= await _unitOfWork.Lessons.GetByIdAsync(id);
            return _mapper.Map<Lesson, LessonDTO>(lesson);
        }

        public async Task UpdateAsync(LessonDTO model)
        {
            var lesson = _mapper.Map<LessonDTO, Lesson>(model);
            _unitOfWork.Lessons.Update(lesson);
            await _unitOfWork.SaveAsync();
        }
    }
}
