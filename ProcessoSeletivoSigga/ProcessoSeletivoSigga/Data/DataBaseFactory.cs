using ProcessoSeletivoSigga.Model;
using SQLite;

namespace ProcessoSeletivoSigga.Data
{
  /// <summary>
  /// Trata da criação da base de dados.
  /// </summary>
  public static class DataBaseFactory
  {
    private static SQLiteAsyncConnection _database;
    /// <summary>
    /// Cria tabelas na base de dados.
    /// </summary>
    public static void CreateDataBase(string dbPath)
    {
      _database = new SQLiteAsyncConnection(dbPath);
      _database.CreateTableAsync<Album>().Wait();
      _database.CreateTableAsync<Foto>().Wait();
    }
  }
}
