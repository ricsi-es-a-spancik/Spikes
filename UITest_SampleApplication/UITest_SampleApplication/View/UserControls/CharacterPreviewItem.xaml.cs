namespace UITest_SampleApplication.View.UserControls
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    public partial class CharacterPreviewItem
    {
        public static readonly DependencyProperty OpenCharacterDetailsCommandProperty =
            DependencyProperty.Register("OpenCharacterDetailsCommand", typeof(ICommand), typeof(UserControl));

        public CharacterPreviewItem()
        {
            InitializeComponent();
        }

        public ICommand OpenCharacterDetailsCommand
        {
            get { return (ICommand)GetValue(OpenCharacterDetailsCommandProperty); }
            set { SetValue(OpenCharacterDetailsCommandProperty, value); }
        }
    }
}
