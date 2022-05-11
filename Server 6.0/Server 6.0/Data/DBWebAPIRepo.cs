using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Server.Models;

namespace Server.Data
{
    public class DBWebAPIRepo : IWebAPIRepo
    {
        private readonly WebAPIDBContext _dbContext;

        public DBWebAPIRepo(WebAPIDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddItem(Content item)
        {
            EntityEntry<Content> e = _dbContext.Content.Add(item);
            _dbContext.SaveChanges();
        }

        public void RemoveItem(string itemName)
        {
            Content item = _dbContext.Content.FirstOrDefault(e => e.Filename == itemName);
            EntityEntry<Content> e = _dbContext.Content.Remove(item);
            _dbContext.SaveChanges();
        }

        public void RemoveAllItems()
        {
            while (_dbContext.Content.FirstOrDefault() != null)
            {
                Content item = _dbContext.Content.FirstOrDefault();
                _dbContext.Content.Remove(item);
                _dbContext.SaveChanges();
            }
        }

        public Content VerifyItem(string itemName)
        {
            Content item = _dbContext.Content.FirstOrDefault(e => e.Filename == itemName);
            return item;
        }

        public string ReturnAllItems()
        {
            IEnumerable<Content> items = _dbContext.Content.ToList();
            string str = "";
            foreach (Content item in items)
            {
                str = str + item.Filename + "," + item.TotalChunks + ";";
            }
            return str;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
