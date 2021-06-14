using StudentOrganizer.BLL.Models;
using StudentOrganizer.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StudentOrganizer.DAL.Interfaces;
using AutoMapper;
using StudentOrganizer.DAL.Entities;

namespace StudentOrganizer.BLL.Services
{
    public class AssignmentService : IAssignmentService
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public AssignmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(AssignmentDTO model)
        {
            var assignment = _mapper.Map<AssignmentDTO, Assignment>(model);
            await _unitOfWork.Assignments.AddAsync(assignment);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            var assignment = await _unitOfWork.Assignments.GetByIdAsync(modelId);
            _unitOfWork.Assignments.Remove(assignment);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<AssignmentDTO>> GetAllAsync()
        {
            var assignments = await _unitOfWork.Assignments.GetAllAsync();
            return _mapper.Map<IEnumerable<Assignment>, IEnumerable<AssignmentDTO>>(assignments);
        }

        public  async Task<AssignmentDTO> GetByIdAsync(int id)
        {
            var assignment = await _unitOfWork.Assignments.GetByIdAsync(id);
            return _mapper.Map<Assignment, AssignmentDTO>(assignment);
        }

        public async Task UpdateAsync(AssignmentDTO model)
        {
            var assignment = _mapper.Map<AssignmentDTO, Assignment>(model);
            _unitOfWork.Assignments.Update(assignment);
            await _unitOfWork.SaveAsync();
        }
    }
}
