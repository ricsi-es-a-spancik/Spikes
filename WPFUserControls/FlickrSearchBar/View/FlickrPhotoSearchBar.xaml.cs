using FlickrSearchBar.Enum;
using System;
using System.Linq;
using System.Windows.Controls;

namespace FlickrSearchBar.View
{
    /// <summary>
    /// Interaction logic for FlickrPhotoSearchBar.xaml
    /// </summary>
    public partial class FlickrPhotoSearchBar : UserControl
    {
        public static readonly Colors[] ColorCollection = System.Enum.GetValues(typeof(Colors)).Cast<Colors>().ToArray();

        public static readonly Styles[] StyleCollection = System.Enum.GetValues(typeof(Styles)).Cast<Styles>().ToArray();

        public FlickrPhotoSearchBar()
        {
            
            InitializeComponent();
        }
    }
}
