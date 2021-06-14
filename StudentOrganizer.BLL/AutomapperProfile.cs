using AutoMapper;
using StudentOrganizer.BLL.Models;
using StudentOrganizer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentOrganizer.BLL
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            /*
            CreateMap<Lesson, LessonDTO>()
                .ForMember(x => x.ScheduleLessons, m => m.MapFrom(y => y.ScheduleLessons))
                .ReverseMap();

            CreateMap<ScheduleLesson, ScheduleLessonDTO>()
               .ForMember(x => x.LessonId, m => m.MapFrom(y => y.LessonId))
               .ForMember(x => x.Lesson, m => m.MapFrom(y => y.Lesson))
               .ForMember(x => x.ScheduleId, m => m.MapFrom(y => y.ScheduleId))
               .ForMember(x => x.Schedule, m => m.MapFrom(y => y.Schedule))
               .ForMember(x => x.Assignments, m => m.MapFrom(y => y.Assignments))
               .ReverseMap();

            CreateMap<Schedule, ScheduleDTO>()
               .ForMember(x => x.ScheduleLessons, m => m.MapFrom(y => y.ScheduleLessons))
               .ForMember(x => x.Student, m => m.MapFrom(y => y.Student))
               .ReverseMap();

            CreateMap<Student, StudentDTO>()
                .ForMember(x => x.Schedules, m => m.MapFrom(y => y.Schedules))
                .ForMember(x => x.StudentProfile, m => m.MapFrom(y => y.StudentProfile))
                .ForMember(x => x.Email, m => m.MapFrom(y => y.Email))
                .ReverseMap();

            CreateMap<StudentProfile, StudentProfileDTO>()
                .ForMember(x => x.Student, m => m.MapFrom(y => y.Student))
                .ReverseMap();

            CreateMap<Assignment, AssignmentDTO>()
                .ForMember(x => x.ScheduleLesson, m => m.MapFrom(y => y.ScheduleLesson))
                .ReverseMap();
            */

            CreateMap<Lesson, LessonDTO>().ReverseMap();

            CreateMap<ScheduleLesson, ScheduleLessonDTO>().ReverseMap();

            CreateMap<Schedule, ScheduleDTO>().ReverseMap();

            CreateMap<Student, StudentDTO>().ReverseMap();

            CreateMap<Assignment, AssignmentDTO>().ReverseMap();
        }
    }
}
