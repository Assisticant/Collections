using System.Linq;
using Assisticant.Fields;

namespace Collections.Models
{
    public class Selection
    {
        private Observable<Person> _selectedPerson = new Observable<Person>();

        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set { _selectedPerson.Value = value; }
        }
    }
}
