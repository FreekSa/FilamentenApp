using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Filamentenlijst.Models;

namespace Filamentenlijst.Data
{
    class FilamentItemDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<FilamentItemDatabase> Instance = new AsyncLazy<FilamentItemDatabase>(async () =>
        {
            var instance = new FilamentItemDatabase();
            CreateTableResult result = await Database.CreateTableAsync<Filament>();
            return instance;
        });

        public FilamentItemDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<Filament>> GetItemsAsync()
        {
            return Database.Table<Filament>().ToListAsync();
        }

        //SQL query
        //public Task<List<Filament>> GetItemsNotDoneAsync()
        //{
        //    return Database.QueryAsync<Filament>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        //}

        public Task<Filament> GetItemAsync(int id)
        {
            return Database.Table<Filament>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Filament item)
        {
            if (item.Id != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Filament item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
