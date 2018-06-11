using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteTree
{
    // https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/databases
    public class Database {
        public SQLiteAsyncConnection _connection;

        public Database(string dbPath)
        {
          _connection = new SQLiteAsyncConnection(dbPath);
          _connection.CreateTableAsync<Note>().Wait();
        }

        public Task<List<Note>> GetItemsAsync()
        {
          return _connection.Table<Note>().OrderByDescending(x => x.ID).ToListAsync();
        }

        public Task<Note> GetItemAsync(int id)
        {
          return _connection.Table<Note>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Note item)
        {
          if (item.ID != 0)
          {
            return _connection.UpdateAsync(item);
          }
          else {
            return _connection.InsertAsync(item);
          }
        }

        public Task<int> DeleteItemAsync(Note item)
        {
          return _connection.DeleteAsync(item);
        }
    }
}
