using System;
using System.Net;

namespace ProcessoSeletivoSigga.Services
{
  /// <summary>
  /// Classe para tratar do download das imagens, de thumb e a própria imagem, para o app funcionar normalmente quando estiver offline.
  /// </summary>
  public sealed class DownloadImagem : IDisposable, IDownloadImagem
  {
    WebClient _webClient;
    /// <summary>
    /// Cria instancia do WebClient para não precisar criar nova instancia sempre que for baixar a imagem.
    /// </summary>
    private WebClient webClient
    {
      get
      {
        if (_webClient == null)
          _webClient = new WebClient();

        return _webClient;
      }
    }

    /// <summary>
    /// Dispose
    /// </summary>
    public void Dispose()
    {
      webClient.Dispose();
    }

    /// <summary>
    /// Realiza o download da imagem.
    /// </summary>
    public byte[] GetImagem(string url)
    {
      byte[] imagem;
      imagem = webClient.DownloadData(url);
      return imagem;
    }
  }
}
