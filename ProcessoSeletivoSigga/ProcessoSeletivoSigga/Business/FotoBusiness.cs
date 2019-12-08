using ProcessoSeletivoSigga.Model;
using ProcessoSeletivoSigga.Services;
using Refit;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessoSeletivoSigga.Business
{
  /// <summary>
  /// Parte de négocios da foto, será feito o download da imagem, inserção no banco e get do banco.
  /// </summary>
  public sealed class FotoBusiness : IFotoBusiness
  {
    /// <summary>
    /// Set conection com o banco.
    /// </summary>
    public FotoBusiness()
    {
      Data.Database<Foto>.SetConection(App.PathDataBase);
    }

    /// <summary>
    /// Recupera as fotos salvas no banco, para quando o app estiver no modo offline.
    /// </summary>
    public List<Foto> GetFotos(float albumId)
    {
      var fotosBanco = Data.Database<Foto>.Get();
      return (from x in fotosBanco.Result where x.AlbumId == albumId select x).ToList();
    }

    ICollection<Foto> _fotosAll;
    ICollection<Foto> _fotos;
    /// <summary>
    /// Insere as Fotos do album selecionado no banco. Verifica, se já existe fotos do album no banco.
    /// </summary>
    public async Task InsertFotos(long albumId)
    {
      bool hasFotoAlbum = await Data.Database<Foto>.Find(x => x.AlbumId == albumId) != null;

      if (!hasFotoAlbum)
        await Data.Database<Foto>.InsertAll(_fotos);
    }

    /// <summary>
    /// Carrega as Fotos Da Api, para quando o app estiver online.
    /// </summary>
    public async Task<ICollection<Foto>> LoadFotosApiAsync(long albumId)
    {
      if (_fotosAll == null)
      {
        await Data.Database<Foto>.DeleteAll();
        var fotosAPI = RestService.For<IRestApi>(EndPoints.BaseUrl);
        _fotosAll = await fotosAPI.GetPhotos();
      }
      _fotos = (from x in _fotosAll where x.AlbumId == albumId select x).ToList();
      return _fotos;
    }
  }
}
