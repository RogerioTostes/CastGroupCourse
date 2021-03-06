﻿using CastGroupCourse.Core.Aggregate.CourseAgg.Interfaces.Repositories;
using CastGroupCourse.Core.Aggregate.CourseAgg.Interfaces.Services;
using CastGroupCourse.Core.Aggregate.CourseAgg.Services;
using CastGroupCourse.Core.CourseAgg.Interfaces.Repositories;
using CastGroupCourse.Core.CourseAgg.Interfaces.Services;
using CastGroupCourse.Core.CourseAgg.Service;
using CastGroupCourse.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CastGroupCourse.CrossCutting
{
    public static class Injector
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICategoryAndCourseService, CategoryAndCourseService>();

            services.AddScoped<ICategory, CategoryRepository>();
            services.AddScoped<ICourse, CourseRepository>();
            services.AddScoped<ICategoryAndCourse, CategoryAndCourseRepository>();

           
        }
    }
}
