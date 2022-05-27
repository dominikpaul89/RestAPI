
namespace PrzykladApiWyklad.Models
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string DateOfBirth { get; set; }

        public string IndexNumber { get; set; }

        public string Program { get; set; }

        public override string ToString()
        {
            return $"{FirstName},{LastName},{IndexNumber},{DateOfBirth}";
        }
    }
}
