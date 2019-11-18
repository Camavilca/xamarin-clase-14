using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CRUD.Model;
using SQLite;

namespace CRUD.ViewModel
{
    public class TodoItemDatabase
    {
        readonly SQLiteAsyncConnection database;

        public TodoItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Persona>().Wait();
        }

        public Task<List<Persona>> GetItemsAsync()
        {
            return database.Table<Persona>().ToListAsync();
        }

        public Task<List<Persona>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Persona>("SELECT * FROM [Persona] WHERE [Done] = 0");
        }

        public Task<Persona> GetItemAsync(int id)
        {
            return database.Table<Persona>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Persona persona)
        {
            if (persona.ID != 0)
            {
                return database.UpdateAsync(persona);
            }
            else
            {
                return database.InsertAsync(persona);
            }
        }

        public Task<int> DeleteItemAsync(Persona item)
        {
            return database.DeleteAsync(item);
        }

    }
}
