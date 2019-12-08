namespace ProcessoSeletivoSigga.Model
{
  public partial class Foto
  {
    /// <summary>
    /// Id do album.
    /// </summary>
    public long AlbumId { get; set; }

    /// <summary>
    /// Id da foto.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Titulo da foto.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Url da foto principal
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// Url da thumbnail da foto.
    /// </summary>
    public string ThumbnailUrl { get; set; }

    /// <summary>
    /// Imagem da thumbnail em byte[];
    /// </summary>
    public byte[] ImagemThumb { get; set; }

    /// <summary>
    /// Imagem em byte[];
    /// </summary>
    public byte[] Imagem { get; set; }
  }
}
