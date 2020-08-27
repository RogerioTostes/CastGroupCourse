﻿using CastGroupCourse.Core.Aggregate.CourseAgg.Entities;
using CastGroupCourse.Core.Aggregate.CourseAgg.Interfaces.Repositories;
using CastGroupCourse.Core.CourseAgg.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;
using Slapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CastGroupCourse.Infra.Data.Repositories
{
  public  class CategoryAndCourseRepository: ICategoryAndCourse
    {

        private readonly IDbConnection conexao;
        public CategoryAndCourseRepository(IConfiguration conf) => conexao = new SqlConnection("Data Source=localhost,1433;Initial Catalog=CastGroup;Persist Security Info=False;User ID=tmds;Password=tmds;MultipleActiveResultSets=False;");

        public List<CategoryAndCourse> CategoryAndCourse()
        {
            var dados = conexao.Query<dynamic>(
                        "SELECT R.Id,R.Description,E.SubjectDescription as Courses_SubjectDescription,E.StartDate as Courses_StartDate,E.EndDate as Courses_EndDate,E.NumberStudents as Courses_NumberStudents,E.Id as Courses_Id " +
                        "FROM dbo.Category R " +
                        "INNER JOIN dbo.Course E ON E.IdCategory = R.id");
            AutoMapper.Configuration.AddIdentifier(
                typeof(Category), "Id");
            AutoMapper.Configuration.AddIdentifier(
                typeof(Course), "Id");
            List<CategoryAndCourse> categories = (AutoMapper.MapDynamic<CategoryAndCourse>(dados)
                as IEnumerable<CategoryAndCourse>).ToList();
            return categories;

        }
    }
}
