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
    public class StudentService: IStudentService
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(StudentDTO model)
        {
            var student = _mapper.Map<StudentDTO, Student>(model);
            await _unitOfWork.Students.AddAsync(student);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            var student = await _unitOfWork.Students.GetByIdAsync(modelId);
            _unitOfWork.Students.Remove(student);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<StudentDTO>> GetAllAsync()
        {
            var students = await _unitOfWork.Students.GetAllAsync();
            return _mapper.Map<IEnumerable<Student>, IEnumerable<StudentDTO>>(students);
        }

        public async Task<StudentDTO> GetByIdAsync(int id)
        {
            var student = await _unitOfWork.Students.GetByIdAsync(id);
            return _mapper.Map<Student,StudentDTO>(student);
        }

        public async Task UpdateAsync(StudentDTO model)
        {
            var student = _mapper.Map<StudentDTO, Student>(model);
            _unitOfWork.Students.Update(student);
            await _unitOfWork.SaveAsync();
        }
    }
}
