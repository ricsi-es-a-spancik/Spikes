using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PhotosSearchWPF.View
{
    /// <summary>
    /// Interaction logic for TagsCollectionView.xaml
    /// </summary>
    public partial class TagsCollectionView : UserControl
    {
        public ICollection<string> Tags
        {
            get { return (ICollection<string>)GetValue(TagsProperty); }
            set { SetValue(TagsProperty, value); }
        }

        public static readonly DependencyProperty TagsProperty =
            DependencyProperty.Register("Tags", typeof(ICollection<string>), typeof(TagsCollectionView));

        public ICommand SearchByTagSelectedCommand
        {
            get { return (ICommand)GetValue(SearchByTagSelectedCommandProperty); }
            set { SetValue(SearchByTagSelectedCommandProperty, value); }
        }

        public static readonly DependencyProperty SearchByTagSelectedCommandProperty =
            DependencyProperty.Register("SearchByTagSelectedCommand", typeof(ICommand), typeof(TagsCollectionView));

        public TagsCollectionView()
        {
            InitializeComponent();
        }
    }
}
