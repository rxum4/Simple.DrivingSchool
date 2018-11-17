namespace Simple.DrivingSchool.Server.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Simple.DrivingSchool.BusinessLogic.Models;
    using Simple.DrivingSchool.BusinessLogic.Services.Abstraction;

    public class StudentController : ControllerBase
    {
        public IStudentService StudentService { get; }

        public StudentController(IStudentService studentService)
        {
            StudentService = studentService;
        }

        public async Task<IActionResult> CreateAsync(Student student)
        {
            await StudentService.CreateAsync(student);
            return null;
        }
    }
}
