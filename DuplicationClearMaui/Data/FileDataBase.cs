using DuplicationClearMaui.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicationClearMaui.Data
{    
    public class FileDataBase
    {
        SQLiteAsyncConnection Database;
        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<FileItem>(); 
        }

        public async Task<List<FileItem>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<FileItem>().ToListAsync();
        }

        public async Task<List<FileItem>> GetFolderItemsAsync()
        {
            await Init();
            return await Database.Table<FileItem>().Where(t => t.FileHash == null).ToListAsync();

            // SQL queries are also possible
            //return await Database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public async Task<FileItem> GetItemAsync(string fullpath)
        {
            await Init();
            return await Database.Table<FileItem>().Where(i => i.FilePath == fullpath).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(FileItem item)
        {
            await Init();

            //일단 Insert 이후 예외처리함.
            var result=0;
            result = await Database.InsertAsync(item);
            return result;
        }

        public async Task<int> DeleteItemAsync(FileItem item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }
    }
}
