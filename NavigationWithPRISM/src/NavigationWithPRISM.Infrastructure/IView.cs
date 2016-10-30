namespace NavigationWithPRISM.Infrastructure
{
    public interface IView<TViewModel> where TViewModel : BindableBase
    {
        TViewModel ViewModel { get; set; }
    }
}
