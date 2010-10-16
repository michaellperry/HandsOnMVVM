using Hands_On_MVVM.Model;

namespace Hands_On_MVVM.ViewModel
{
    public class DisplayStrategyVewModel
    {
        private Person _person;
        private DisplayStrategy _displayStrategy;

        public DisplayStrategyVewModel(Person person, DisplayStrategy displayStrategy)
        {
            _person = person;
            _displayStrategy = displayStrategy;
        }

        public DisplayStrategy DisplayStrategy
        {
            get { return _displayStrategy; }
        }

        public override string ToString()
        {
            return _person.DisplayUsingStrategy(_displayStrategy);
        }
    }
}
