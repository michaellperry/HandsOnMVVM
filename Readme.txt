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
