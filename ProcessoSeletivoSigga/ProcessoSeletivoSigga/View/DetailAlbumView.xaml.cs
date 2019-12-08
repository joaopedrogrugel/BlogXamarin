using ProcessoSeletivoSigga.Model;
using ProcessoSeletivoSigga.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProcessoSeletivoSigga.View
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class DetailAlbumView : ContentPage
  {
    /// <summary>
    /// View de detalhes do album, sendo exibido as thumb das imagens, e o titulo.
    /// </summary>
    public DetailAlbumView(Album selectedAlbum)
    {
      InitializeComponent();
      BindingContext = new DetailAlbumViewModel(selectedAlbum);
      this.Title = selectedAlbum.Title;
    }

    /// <summary>
    /// Ao clicar em detalhes, verificação para mensagem quando não for selecionado um item na lista, e clicar em "Detalhes".
    /// </summary>
    void OnItemClicked(object sender, EventArgs e)
    {
      if (FotosListView.SelectedItem != null)
        Navigation.PushAsync(new DetailFotoView((Foto)FotosListView.SelectedItem));
      else
        DisplayAlert("Erro!", "Favor selecionar pelo menos um item.", "OK");
    }
  }
}