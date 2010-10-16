using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using Step5.Model;

namespace Step5.ViewModel
{
    public class DisplayStrategyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Person _person;
        private DisplayStrategy _displayStrategy;

        public DisplayStrategyViewModel(Person person, DisplayStrategy displayStrategy)
        {
            _person = person;
            _displayStrategy = displayStrategy;

            _person.PropertyChanged += PersonPropertyChanged;
        }

        public DisplayStrategy DisplayStrategy
        {
            get { return _displayStrategy; }
        }

        public string Display
        {
            get { return _person.DisplayUsingStrategy(_displayStrategy); }
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;
            DisplayStrategyViewModel that = obj as DisplayStrategyViewModel;
            if (that == null)
                return false;
            return _displayStrategy == that._displayStrategy;
        }

        public override int GetHashCode()
        {
            return _displayStrategy.GetHashCode();
        }

        private void PersonPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "FirstName" || e.PropertyName == "LastName" || e.PropertyName == "Email")
                FirePropertyChanged("Display");
        }

        private void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
