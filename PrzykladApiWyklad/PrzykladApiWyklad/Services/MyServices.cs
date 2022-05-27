
using PrzykladApiWyklad.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzykladApiWyklad.Services
{

    public class MyServices : IMyServices
    {

        private static List<Student> studentList;

        public StreamWriter streamWriter;



        public bool AddStudent(Student student)
        {

            if (student != null)
            {
                /*streamWriter = new StreamWriter("Data/Studenci.csv",true);
                streamWriter.WriteLine(student);
                streamWriter.Close();*/
                studentList.Add(student);
                File.AppendAllText("Data/Studenci.csv", student.ToString() + Environment.NewLine);

                return true;

            }
            else
                return false;

        }

        public Student GetStudent(string nrIndex)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetStudents()
        {

            studentList = new List<Student>();
            StreamReader streamReader = new StreamReader("Data/Studenci.csv");
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                string[] parts = line.Split(",");
                var student = new Student()
                {
                    FirstName = parts[0],
                    LastName = parts[1],
                    IndexNumber = parts[2],
                    DateOfBirth = (parts[3]),
                    Program = parts[4],
             
                };

                studentList.Add(student);

            }
            streamReader.Close();

            return studentList;
        }

        public void DeleteStudent(string index)
        {
            studentList = studentList.Where(u => u.IndexNumber != index).ToList();
            string[] array = studentList.Select(i => i.ToString()).ToArray();
            File.WriteAllLines("Data/Studenci.csv", array);

        }

        public void UpdateStudent(Student student, string id)
        {
            Student studentObj = studentList.Find(e => e.IndexNumber == id);
            studentObj.FirstName = student.FirstName;
            studentObj.LastName = student.LastName;
            studentObj.DateOfBirth = student.DateOfBirth;
            studentObj.Program = student.Program;
 


            string[] array = studentList.Select(i => i.ToString()).ToArray();
            File.WriteAllLines("Data/Studenci.csv", array);

        }


    }
}