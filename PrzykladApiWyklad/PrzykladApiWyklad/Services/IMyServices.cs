
using PrzykladApiWyklad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrzykladApiWyklad.Services
{
    public interface IMyServices
    {
        List<Student> GetStudents();
        Student GetStudent(string nrIndex);

        bool AddStudent(Student student);

        void DeleteStudent(string nrIndex);

        void UpdateStudent(Student student, string nrIndex);
    }
}