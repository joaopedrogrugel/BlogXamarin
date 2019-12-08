using ProcessoSeletivoSigga.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProcessoSeletivoSigga.Business
{
  public interface IFotoBusiness
  {
    List<Foto> GetFotos(float albumId);
    Task InsertFotos(long albumId);
    Task<ICollection<Foto>> LoadFotosApiAsync(long albumId);
  }
}
