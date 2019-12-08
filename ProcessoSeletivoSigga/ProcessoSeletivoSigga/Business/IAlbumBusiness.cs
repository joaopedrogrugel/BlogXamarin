using ProcessoSeletivoSigga.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProcessoSeletivoSigga.Business
{
  public interface IAlbumBusiness
  {
    Task<List<Album>> LoadAlbumOffline();
    Task<ICollection<Album>> LoadAlbumApiAsync();
    void InsertAlbum(ICollection<Album> Album);
  }
}
