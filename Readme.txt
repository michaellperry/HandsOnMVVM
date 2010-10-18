--------------------------------------

        private void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
--------------------------------------
    public enum DisplayStrategy
    {
        FirstLast,
        LastFirst,
        Email
    }
--------------------------------------

        public string DisplayUsingStrategy(DisplayStrategy displayStrategy)
        {
            if (displayStrategy == Model.DisplayStrategy.FirstLast)
                return string.Format("{0} {1}", FirstName, LastName);
            else if (displayStrategy == Model.DisplayStrategy.LastFirst)
                return string.Format("{0}, {1}", LastName, FirstName);
            else
                return Email;
        }
--------------------------------------

        public IEnumerable<string> DisplayAsOptions
        {
            get
            {
                return Enum.GetValues(typeof(DisplayStrategy))
                    .OfType<DisplayStrategy>()
                    .Select(displayStrategy => DisplayUsingStrategy(displayStrategy));
            }
        }

        public string DisplayAs
        {
            get { return DisplayUsingStrategy(DisplayStrategy); }
            set
            {
                IEnumerable<DisplayStrategy> displayStrategies = Enum.GetValues(typeof(DisplayStrategy))
                    .OfType<DisplayStrategy>();
                foreach (DisplayStrategy displayStrategy in displayStrategies)
                {
                    if (value == DisplayUsingStrategy(displayStrategy))
                        DisplayStrategy = displayStrategy;
                }
            }
        }
--------------------------------------

        public string FirstName
        {
            get { return _person.FirstName; }
            set { _person.FirstName = value; }
        }

        public string LastName
        {
            get { return _person.LastName; }
            set { _person.LastName = value; }
        }

        public string Phone
        {
            get { return _person.Phone; }
            set { _person.Phone = value; }
        }

        public string Email
        {
            get { return _person.Email; }
            set { _person.Email = value; }
        }
--------------------------------------
    public class CommandObject : ICommand
    {
        private Action _action;

        public CommandObject(Action action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _action();
        }
    }
--------------------------------------
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                // Add the corresponding view models.
                int index = e.NewStartingIndex;
                foreach (Person person in e.NewItems)
                {
                    _personItemViewModels.Insert(index, new PersonItemViewModel(person));
                    ++index;
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                // Delete the corresponding view models.
                for (int i = 0; i < e.OldItems.Count; i++)
                {
                    _personItemViewModels.RemoveAt(i + e.OldStartingIndex);
                }
            }
            else
            {
                // Just give up and start over.
                _personItemViewModels.Clear();
                PopulatePersonItemViewModels();
            }
