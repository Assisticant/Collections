using Collections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.ViewModels
{
    public class HelloViewModel
    {
        private Person _person;

        public HelloViewModel(Person person)
        {
            _person = person;
        }

        public string Greeting
        {
            get { return "Hello, " + _person.Name; }
        }
    }
}
