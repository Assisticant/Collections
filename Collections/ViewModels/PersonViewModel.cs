using System;
using System.Collections.Generic;
using System.Linq;
using Collections.Models;

namespace Collections.ViewModels
{
    public class PersonViewModel
    {
        private readonly Person _person;

        public PersonViewModel(Person person)
        {
            _person = person;
        }

        public string Name
        {
            get { return _person.Name; }
            set { _person.Name = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;
            PersonViewModel that = obj as PersonViewModel;
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
