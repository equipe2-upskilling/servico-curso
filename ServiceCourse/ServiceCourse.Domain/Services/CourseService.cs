﻿using ServiceCourse.Data.Entities;
using ServiceCourse.Data.Repositories;
using ServiceCourse.Domain.Models;
using System;
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
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                Duration = course.Duration,
                Price = course.Price,
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
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Duration = c.Duration,
                    Price = c.Price,
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
                EnrollmentStatusId = (int)Course.EnrollmentStatus.Abertas
            };

            _repository.CreateCourse(course);
        }

        public void UpdateCourse(CourseModel courseModel)
        {
            Course course = new Course()
            {
                Id = courseModel.Id,
                Name = courseModel.Name,
                Description = courseModel.Description,
                Duration = courseModel.Duration,
                Price = courseModel.Price,
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
