using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assisticant;
using Collections.Models;

namespace Collections.ViewModels
{
    public class ViewModelLocator : ViewModelLocatorBase
    {
        private AddressBook _addressBook;
		private Selection _selection;

        public ViewModelLocator()
        {
			if (DesignMode)
				_addressBook = LoadDesignModeAddressBook();
			else
				_addressBook = LoadAddressBook();
			_selection = new Selection();
        }

        public object Main
        {
            get { return ViewModel(() => new MainViewModel(_addressBook, _selection)); }
        }

		public object Person
		{
			get
			{
				return ViewModel(() => _selection.SelectedPerson == null
					? null
					: new PersonViewModel(_selection.SelectedPerson));
			}
		}

        //public object Hello
        //{
        //    get
        //    {
        //        return ViewModel(() => _selection.SelectedPerson == null
        //            ? null
        //            : new HelloViewModel(_selection.SelectedPerson));
        //    }
        //}

		private AddressBook LoadAddressBook()
		{
			// TODO: Load your document here.
            AddressBook document = new AddressBook();
            var one = document.NewPerson();
            one.Name = "Larry";
            var two = document.NewPerson();
            two.Name = "Moe";
            var three = document.NewPerson();
            three.Name = "Curly";
            return document;
		}

		private AddressBook LoadDesignModeAddressBook()
		{
            AddressBook document = new AddressBook();
            var one = document.NewPerson();
            one.Name = "Design";
            var two = document.NewPerson();
            two.Name = "Mode";
            var three = document.NewPerson();
            three.Name = "Data";
            return document;
		}
    }
}
