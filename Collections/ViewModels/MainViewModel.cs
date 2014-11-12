using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Collections.Models;
using Assisticant;

namespace Collections.ViewModels
{
    public class MainViewModel
    {
        private readonly AddressBook _addressBook;
		private readonly Selection _selection;

        public MainViewModel(AddressBook addressBook, Selection selection)
        {
            _addressBook = addressBook;
			_selection = selection;
        }

        public IEnumerable<PersonHeader> People
        {
            get
            {
                return
                    from person in _addressBook.People
                    select new PersonHeader(person);
            }
        }

        public PersonHeader SelectedPerson
        {
            get
            {
                return _selection.SelectedPerson == null
                    ? null
                    : new PersonHeader(_selection.SelectedPerson);
            }
            set
            {
                if (value != null)
                    _selection.SelectedPerson = value.Person;
            }
        }

        public PersonViewModel PersonDetail
        {
            get
            {
                return _selection.SelectedPerson == null
                    ? null
                    : new PersonViewModel(_selection.SelectedPerson);
            }
        }

        public ICommand AddPerson
        {
            get
            {
                return MakeCommand
                    .Do(delegate
                    {
                        _selection.SelectedPerson = _addressBook.NewPerson();
                    });
            }
        }

        public ICommand DeletePerson
        {
            get
            {
                return MakeCommand
                    .When(() => _selection.SelectedPerson != null)
                    .Do(delegate
                    {
                        _addressBook.DeletePerson(_selection.SelectedPerson);
                        _selection.SelectedPerson = null;
                    });
            }
        }

        public ICommand MovePersonDown
        {
            get
            {
                return MakeCommand
                    .When(() =>
                        _selection.SelectedPerson != null &&
                        _addressBook.CanMoveDown(_selection.SelectedPerson))
                    .Do(delegate
                    {
                        _addressBook.MoveDown(_selection.SelectedPerson);
                    });
            }
        }

        public ICommand MovePersonUp
        {
            get
            {
                return MakeCommand
                    .When(() =>
                        _selection.SelectedPerson != null &&
                        _addressBook.CanMoveUp(_selection.SelectedPerson))
                    .Do(delegate
                    {
                        _addressBook.MoveUp(_selection.SelectedPerson);
                    });
            }
        }
    }
}
