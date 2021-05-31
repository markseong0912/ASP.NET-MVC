using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel //list of membership types
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; } //iterate over the membership types
        public Customer Customer { get; set; }
    }
}