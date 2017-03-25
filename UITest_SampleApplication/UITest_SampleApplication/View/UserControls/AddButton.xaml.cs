namespace UITest_SampleApplication.View.UserControls
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    public partial class AddButton
    {
        public static readonly DependencyProperty CommandProperty = 
            DependencyProperty.Register("Command", typeof(ICommand), typeof(UserControl));

        public AddButton()
        {
            InitializeComponent();
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
    }
}
