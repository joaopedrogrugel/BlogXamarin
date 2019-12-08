using ProcessoSeletivoSigga.Model;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProcessoSeletivoSigga.Services
{
  public interface IRestApi
  {
    [Get("/albums")]
    Task<ICollection<Album>> GetAlbum();

    [Get("/photos")]
    Task<ICollection<Foto>> GetPhotos();
  }
}
