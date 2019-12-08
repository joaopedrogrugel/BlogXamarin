using ProcessoSeletivoSigga.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProcessoSeletivoSigga.Business
{
  public interface IFotoBusiness
  {
    List<Foto> GetFotos(long albumId);
    Task InsertFotos(long albumId);
    Task<ICollection<Foto>> LoadFotosApiAsync(long albumId);
  }
}
