namespace WPFUserControls.ViewModel
{
    public class ResourceViewModel : ViewModelBase
    {
        private string _stringField;
        private int _intField;
        private bool _boolField;

        public string StringField
        {
            get { return _stringField; }
            set { _stringField = value; NotifyPropertyChanged(); }
        }

        public int IntField
        {
            get { return _intField; }
            set { _intField = value; NotifyPropertyChanged(); }
        }

        public bool BoolField
        {
            get { return _boolField; }
            set { _boolField = value; NotifyPropertyChanged(); }
        }
    }
}
