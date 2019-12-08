using ProcessoSeletivoSigga.ViewModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace ProcessoSeletivoSigga
{
  [DesignTimeVisible(false)]
  public partial class MainPageView : ContentPage
  {
    public MainPageView()
    {
      InitializeComponent();
      BindingContext = new MainPageViewModel(Navigation);
    }
  }
}
