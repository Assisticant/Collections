using System;
using System.Linq;
using Collections.Models;

namespace Collections.ViewModels
{
    public class PersonHeader
    {
        private readonly Person _person;

        public PersonHeader(Person person)
        {
            _person = person;
        }

        public Person Person
        {
            get { return _person; }
        }

        public string Name
        {
            get { return _person.Name ?? "<New Person>"; }
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;
            PersonHeader that = obj as PersonHeader;
            if (that == null)
                return false;
            return Object.Equals(this._person, that._person);
        }

        public override int GetHashCode()
        {
            return _person.GetHashCode();
        }
    }
}
