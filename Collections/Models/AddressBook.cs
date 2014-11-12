using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assisticant.Collections;
using Assisticant.Fields;

namespace Collections.Models
{
    public class AddressBook
    {
		private Observable<string> _name = new Observable<string>();
        private ObservableList<Person> _people = new ObservableList<Person>();

		public string Name
		{
			get { return _name; }
			set { _name.Value = value; }
		}

        public IEnumerable<Person> People
        {
            get { return _people; }
        }

        public Person NewPerson()
        {
            Person person = new Person();
            _people.Add(person);
            return person;
        }

        public void DeletePerson(Person person)
        {
            _people.Remove(person);
        }

        public bool CanMoveDown(Person person)
        {
            return _people.IndexOf(person) < _people.Count - 1;
        }

        public bool CanMoveUp(Person person)
        {
            return _people.IndexOf(person) > 0;
        }

        public void MoveDown(Person person)
        {
            int index = _people.IndexOf(person);
            _people.RemoveAt(index);
            _people.Insert(index + 1, person);
        }

        public void MoveUp(Person person)
        {
            int index = _people.IndexOf(person);
            _people.RemoveAt(index);
            _people.Insert(index - 1, person);
        }
    }
}
