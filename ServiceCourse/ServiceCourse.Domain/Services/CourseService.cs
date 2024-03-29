﻿using ServiceCourse.Data.Entities;
using ServiceCourse.Data.Repositories;
using ServiceCourse.Domain.Models;
using System.Collections.Generic;

namespace ServiceCourse.Domain.Services
{
    public class CourseService
    {
        public CourseRepository _repository = new CourseRepository();

        public CourseModel GetCourseById(int Id)
        {
            var course = _repository.GetCourseById(Id);

            var courseModel = new CourseModel()
            {
                CourseId = course.CourseId,
                Name = course.Name,
                Description = course.Description,
                Duration = course.Duration,
                TeacherId = course.TeacherId,
                Price = course.Price,
                CoverImg = course.CoverImg,
                Status = (CourseModel.EnrollmentStatus)course.EnrollmentStatusId
            };

            return courseModel;
        }

        public List<CourseModel> GetCourses()
        {
            var course = _repository.GetCourses();
            List<CourseModel> coursesModel = new List<CourseModel>();

            foreach (var c in course)
            {
                coursesModel.Add(new CourseModel
                {
                    CourseId = c.CourseId,
                    Name = c.Name,
                    Description = c.Description,
                    Duration = c.Duration,
                    TeacherId = c.TeacherId,
                    Price = c.Price,
                    CoverImg = c.CoverImg,
                    Status = (CourseModel.EnrollmentStatus)c.EnrollmentStatusEnum
                });
            }

            return coursesModel;
        }

        public void CreateCourse(CourseModel courseModel)
        {
            Course course = new Course()
            {
                Name = courseModel.Name,
                Description = courseModel.Description,
                Duration = courseModel.Duration,
                Price = courseModel.Price,
                TeacherId = courseModel.TeacherId,
                CoverImg = courseModel.CoverImg,
                EnrollmentStatusId = (int)Course.EnrollmentStatus.Abertas
            };

            _repository.CreateCourse(course);
        }

        public void UpdateCourse(CourseModel courseModel)
        {
            Course course = new Course()
            {
                CourseId = courseModel.CourseId,
                Name = courseModel.Name,
                Description = courseModel.Description,
                Duration = courseModel.Duration,
                Price = courseModel.Price,
                TeacherId = courseModel.TeacherId,
                CoverImg = courseModel.CoverImg,
                EnrollmentStatusId = (int)courseModel.Status
            };

            _repository.UpdateCourse(course);

        }

        public void DeleteCourse(int Id)
        {
            _repository.DeleteCourse(Id);
        }
    }
}
