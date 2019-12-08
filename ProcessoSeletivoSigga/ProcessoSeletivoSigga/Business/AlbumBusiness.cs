using ProcessoSeletivoSigga.Data;
using ProcessoSeletivoSigga.Model;
using ProcessoSeletivoSigga.Services;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProcessoSeletivoSigga.Business
{
  /// <summary>
  /// Parte de négocios do album, inserção no banco e get do banco.
  /// </summary>
  public class AlbumBusiness : IAlbumBusiness
  {
    /// <summary>
    /// Set conection com o banco.
    /// </summary>
    public AlbumBusiness()
    {
      Database<Album>.SetConection(App.PathDataBase);
    }

    /// <summary>
    /// Carrega dados do album do banco, para quando o app estiver offline.
    /// </summary>
    /// <returns></returns>
    public virtual Task<List<Album>> LoadAlbumOffline()
    {
      return Database<Album>.Get();
    }

    /// <summary>
    /// Carrega album da api.
    /// </summary>
    /// <returns></returns>
    public virtual async Task<ICollection<Album>> LoadAlbumApiAsync()
    {
      var albumAPI = RestService.For<IRestApi>(EndPoints.BaseUrl);
      var albunsRetorno = await albumAPI.GetAlbum();
      await Database<Album>.DeleteAll();
      return albunsRetorno;
    }

    /// <summary>
    /// Insere todas as informações do album no banco.
    /// </summary>
    public virtual void InsertAlbum(ICollection<Album> Album)
    {
      Database<Album>.InsertAll(Album);
    }
  }
}
