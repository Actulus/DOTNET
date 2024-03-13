using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Lab3WPF.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

		public override string ToString()
		{
			return this.UserId + "," + this.FirstName + "," + this.LastName + "," + this.City + "," + this.State + "," + this.Country;
		}
	}
}
