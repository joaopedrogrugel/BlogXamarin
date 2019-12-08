using ProcessoSeletivoSigga.Business;
using ProcessoSeletivoSigga.Model;
using ProcessoSeletivoSigga.View;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProcessoSeletivoSigga.ViewModel
{
  /// <summary>
  /// ViewModel da página principal.
  /// </summary>
  public class MainPageViewModel : ViewModelBase
  {
    public ObservableCollection<Album> AlbunsListView { get; }
    public ICommand ItemSelected { get; set; }

    #region ItemSelecioned
    //Métodos utilizados para abrir a tela de detalhe do Album, quando um Album for selecionado.
    Album _selectedItem;
    public Album SelectedItem
    {
      get
      {
        return _selectedItem;
      }
      set
      {
        _selectedItem = value;
        OnPropertyChanged("SelectedItem");
        OnSelectedItem();
      }
    }

    private void OnSelectedItem()
    {
      if (_selectedItem == null)
        return;
      this._navigation.PushAsync(new DetailAlbumView(_selectedItem));
    }
    #endregion

    readonly INavigation _navigation;
    /// <summary>
    /// View model da página principal, utiliza a ViewModelBase para evitar duplicidade de código.
    /// </summary>
    public MainPageViewModel(INavigation navigation) : base()
    {
      _navigation = navigation;
      AlbunsListView = new ObservableCollection<Album>();
      LoadAlbuns();
      ItemSelected = new Command(s =>
      {
        LoadItens();
      });
    }

    /// <summary>
    /// Load Itens - Utilizado para retornar também os itens, quando a tela for atualizada.
    /// </summary>
    public override void LoadItens()
    {
      LoadAlbuns();
    }

    /// <summary>
    /// Carrega os Albuns de acordo se estiver online ou offline.
    /// </summary>
    /// <returns></returns>
    private async Task LoadAlbuns()
    {
      IsBusy = true;
      AlbunsListView.Clear();

      if (App.IsOnline())
        await LoadAlbunsDaApi();
      else
        await LoadAlbunsOffline();
      IsBusy = false;
    }

    /// <summary>
    /// Carrega Fotos Offline, buscando os albuns que estão salvos no banco.
    /// </summary>
    private async Task LoadAlbunsOffline()
    {
      var albumBusiness = DependencyService.Resolve<IAlbumBusiness>();
      AddAlbunsToView(albumBusiness.LoadAlbumOffline().Result);
    }

    /// <summary>
    /// Carrega Albuns utilizando a API.
    /// </summary>
    private async Task LoadAlbunsDaApi()
    {
      var albumBusiness = DependencyService.Resolve<IAlbumBusiness>();
      var albums = await albumBusiness.LoadAlbumApiAsync();
      AddAlbunsToView(albums);
      albumBusiness.InsertAlbum(albums);
    }

    /// <summary>
    /// Adiciona os albuns na listview que será exibida na tela. Utilizado tanto online e offline.
    /// </summary>
    private void AddAlbunsToView(ICollection<Album> albunsRetorno)
    {
      foreach (var album in albunsRetorno)
      {
        AlbunsListView.Add(album);
      }
    }
  }
}