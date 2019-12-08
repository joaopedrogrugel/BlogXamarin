using ProcessoSeletivoSigga.Business;
using ProcessoSeletivoSigga.Model;
using ProcessoSeletivoSigga.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProcessoSeletivoSigga.ViewModel
{
  /// <summary>
  /// ViewModel da tela de detalhes do album.
  /// </summary>
  public class DetailAlbumViewModel : ViewModelBase
  {
    public ObservableCollection<Foto> FotosList { get; }
    private readonly Album _album;
    /// <summary>
    /// ViewModel da tela de detalhes do album.
    /// </summary>
    public DetailAlbumViewModel(Album album) : base()
    {
      FotosList = new ObservableCollection<Foto>();
      _album = album;
      LoadFotos(album);
    }

    /// <summary>
    /// Load Itens - Utilizado para retornar também os itens, quando a tela for atualizada.
    /// </summary>
    public override void LoadItens()
    {
      LoadFotos(_album);
    }

    /// <summary>
    /// Carrega as Fotos de acordo se estiver online ou offline
    /// </summary>
    private async Task LoadFotos(Album album)
    {
      IsBusy = true;
      FotosList.Clear();

      if (App.IsOnline())
        await LoadFotosApi(album);
      else
        LoadFotosOffline(album.Id);

      IsBusy = false;
    }

    /// <summary>
    /// Carrega Fotos Offline, buscando os albuns que já foram acessados e estão salvos no banco.
    /// </summary>
    private void LoadFotosOffline(long albumId)
    {
      var fotoBusiness = DependencyService.Resolve<IFotoBusiness>();
      foreach (Foto foto in fotoBusiness.GetFotos(albumId))
      {
        FotosList.Add(foto);
      }
    }

    /// <summary>
    /// Carrega Fotos utilizando a Api.
    /// </summary>
    private async Task LoadFotosApi(Album album)
    {
      var fotoBusiness = DependencyService.Resolve<IFotoBusiness>();
      var _fotos = await fotoBusiness.LoadFotosApiAsync(album.Id);
      AddFotosFromApi(_fotos);
      await fotoBusiness.InsertFotos(album.Id);
    }

    /// <summary>
    /// Adiciona Fotos da Api na listview que será exibida na tela. É feito o download das imagens, para permitir o correto funcionamento offline.
    /// </summary>
    private void AddFotosFromApi(ICollection<Foto> fotosDoAlbum)
    {
      var downloadImagem = DependencyService.Resolve<IDownloadImagem>();
      foreach (Foto foto in fotosDoAlbum)
      {
        foto.ImagemThumb = downloadImagem.GetImagem(foto.ThumbnailUrl);
        foto.Imagem = downloadImagem.GetImagem(foto.Url);
        FotosList.Add(foto);
      }
    }
  }
}
