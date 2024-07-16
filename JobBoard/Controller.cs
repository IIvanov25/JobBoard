using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace JobBoard
{
    internal class Controller
    {
        private readonly Dictionary<string, Category> categories;
        public Controller()
        {
            categories = new Dictionary<string, Category>();
        }
        public string AddCategory(List<string> args)
        {
            string name = args[1];
            var category = new Category(name);
            categories.Add(category.Name, category);
            return $"Created category {name}";
        }
        public string AddJobOffer(List<string> args)
        {
            string name = args[1];
            string jobtitle = args[2];
            string company = args[3];
            double salary = double.Parse(args[4]);
            string type = args[5];
            JobOffer job;
            foreach (KeyValuePair<string, Category> category in categories)
            {
                Category cat = category.Value;
                if (category.Value.Name == args[0])
                {
                    if (type == "onsite")
                    {
                        job = new OnSiteJobOffer(jobtitle, company, salary, args.Last());
                        cat.AddJobOffer(job);
                    }
                    else
                    {
                        job = new RemoteJobOffer(jobtitle, company, salary, bool.Parse(args.Last()));
                        cat.AddJobOffer(job);
                    }
                }
            }
            return $"Created JobOffer {args[2]} in Category {args[1]}".Trim();
        }
        public string GetAverageSalary(List<string> args)
        {
            string category = args[1];
            double averageSalary = categories[category].AverageSalary();
            return $"The average salary is {averageSalary:f2}";
        }
        public string GetOffersAboveSalary(List<string> args)
        {
            string category = args[1];
            double salary = double.Parse(args[2]);
            List<JobOffer> offersAboveSalary = categories[category].GetOffersAboveSalary(salary);
            return $"{offersAboveSalary}";
        }
        public string GetOffersWithoutSalary(List<string> args)
        {
            //TODO: Implement me...
            throw new NotImplementedException();
        }
    }
}