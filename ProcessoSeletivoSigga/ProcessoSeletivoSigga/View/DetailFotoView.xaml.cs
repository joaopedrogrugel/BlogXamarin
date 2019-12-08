using ProcessoSeletivoSigga.Model;
using ProcessoSeletivoSigga.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProcessoSeletivoSigga.View
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class DetailFotoView : ContentPage
  {
    public DetailFotoView(Foto fotoSelected)
    {
      InitializeComponent();
      BindingContext = new DetailFotoViewModel(fotoSelected);
    }
  }
}