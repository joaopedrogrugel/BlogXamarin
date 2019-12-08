namespace ProcessoSeletivoSigga.Model
{
  public partial class Album
  {
    /// <summary>
    /// Id do usuário.
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Id do album.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Titulo do album.
    /// </summary>
    public string Title { get; set; }
  }
}
