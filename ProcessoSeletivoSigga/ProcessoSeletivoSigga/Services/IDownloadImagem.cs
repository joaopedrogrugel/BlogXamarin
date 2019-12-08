using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoSigga.Services
{
  public interface IDownloadImagem
  {
    byte[] GetImagem(string url);
  }
}
