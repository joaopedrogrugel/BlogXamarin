using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProcessoSeletivoSigga.Data
{
  /// <summary>
  /// Database, criada classe para ser genêrica, e buscar qualquer objeto com o mesmo método.
  /// </summary>
  public static class Database<T> where T : class, new()
  {
    private static SQLiteAsyncConnection _database;
    /// <summary>
    /// Set Conection com o banco.
    /// </summary>
    public static void SetConection(string dbPath)
    {
      _database = new SQLiteAsyncConnection(dbPath);
    }

    /// <summary>
    /// Procura um dado no banco, de acordo com a condição passada.
    /// </summary>
    public static Task<T> Find(Expression<Func<T, bool>> predicate) =>
             _database.FindAsync<T>(predicate);

    /// <summary>
    /// Recupera todos os dados de uma tabela.
    /// </summary>
    public static Task<List<T>> Get() =>
             _database.Table<T>().ToListAsync();

    /// <summary>
    /// Deleta todos os dados de uma tabela.
    /// </summary>
    public static async Task<int> DeleteAll() =>
          await _database.DeleteAllAsync<T>();

    /// <summary>
    /// Insere todos os dados em uma tabela.
    /// </summary>
    public static async Task<int> InsertAll(ICollection<T> entity) =>
          await _database.InsertAllAsync(entity);

  }
}
