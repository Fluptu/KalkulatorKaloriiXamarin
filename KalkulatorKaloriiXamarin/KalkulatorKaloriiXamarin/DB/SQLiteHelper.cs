using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using KalkulatorKaloriiXamarin.Models;

namespace KalkulatorKaloriiXamarin.DB
{
    public class SQLiteHelper
    {
        private readonly SQLiteAsyncConnection conn;
        public SQLiteHelper(string db_path)
        {
            conn = new SQLiteAsyncConnection(db_path);
            conn.CreateTableAsync<User>();
            conn.CreateTableAsync<UserHistory>();
        }
        public Task<int> CreateUser(User user)
        {
            return conn.InsertAsync(user);
        }
        public Task<List<User>> SelectUsers()
        {
            return conn.Table<User>().ToListAsync();
        }
        public Task<int> UpdateUser(User user)
        {
            return conn.UpdateAsync(user);
        }
        public Task<int> DeleteUser(User user)
        {
            return conn.DeleteAsync(user);
        }

        public Task<int> AddToHistory(UserHistory h)
        {
            return conn.InsertAsync(h);
        }

        public Task<List<UserHistory>> SelectHistoryForDate(int userId,string d)
        {
            return conn.Table<UserHistory>().Where(i => i.UserID == userId && i.Date==d).ToListAsync();
        }

        public Task<int> UpdateHistory(UserHistory h)
        {
            return conn.UpdateAsync(h);
        }
        public Task<int> DeleteHistory(UserHistory h)
        {
            return conn.DeleteAsync(h);
        }
    }
}
