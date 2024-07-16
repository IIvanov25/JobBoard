using System.Text;

namespace JobBoard
{
    abstract class JobOffer
    {
        private string jobtitle;
        private string company;
        private double salary;

        public string JobTitle
        {
            get {  return jobtitle; } set {
                if (value.Length < 3 || value.Length > 10000)
                {
                    throw new ArgumentException("JobTitle should be between 3 and 30 characters!");
                }
                jobtitle = value; }
        }
        public string Company
        {
            get { return company; } set {
                if (value.Length < 3 || value.Length > 10000)
                {
                    throw new ArgumentException("Company should be between 3 and 30 characters!");
                }
                company = value; }
        }
        public double Salary
        {
            get { return salary; } set {
                if (value < 0)
                {
                    throw new ArgumentException("Salary should be 0 or positive!");
                }
                salary = value; }
        }
        public JobOffer(string jobtitle, string company, double salary)
        {
            JobTitle = jobtitle;
            Company = company;
            Salary = salary;
        }
        public override string ToString() { 
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Job Title: {JobTitle}");
            sb.AppendLine($"Company: {Company}");
            sb.AppendLine($"Salary: {Salary:f2} BGN");
            return sb.ToString();
        }
    }
}