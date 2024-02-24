namespace MauiApp1.Models
{
    public class Student(int id = 0, String FirstName = "", String LastName = "", Double percentage = 0.0)
    {

        public int StudentId { get; set; } = id;
        public String StudentFirstName { get; set; } = FirstName;
        public String StudentLastName { get; set; } = LastName;
        public Double StudentPercentage { get; set; } = percentage;

        public override string ToString()
        {
            return $"{StudentId} {StudentFirstName} {StudentLastName} {StudentPercentage}";
        }
    }
}