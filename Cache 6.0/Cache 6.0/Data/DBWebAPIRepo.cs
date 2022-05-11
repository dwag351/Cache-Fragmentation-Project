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

        public void AddEvent(EventContent item)
        {
            EntityEntry<EventContent> e = _dbContext.EventContent.Add(item);
            _dbContext.SaveChanges();
        }

        public void EditItem(Content item)
        {
            Content oldItem = _dbContext.Content.FirstOrDefault(e => e.Filename == item.Filename);
            EntityEntry<Content> e = _dbContext.Content.Remove(oldItem);
            e = _dbContext.Content.Add(item);
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
            _dbContext.SaveChanges();
        }

        public void RemoveAllEvents()
        {
            while (_dbContext.EventContent.FirstOrDefault() != null)
            {
                EventContent item = _dbContext.EventContent.FirstOrDefault();
                _dbContext.EventContent.Remove(item);
                _dbContext.SaveChanges();
            }
            _dbContext.SaveChanges();
        }

        public string ReturnAllItems()
        {
            IEnumerable<Content> items = _dbContext.Content.ToList();

            /*
            DateTime date = DateTime.Now;

            foreach (Content item in items)
            {
                DateTime oldDate;
                DateTime.TryParse(item.Time, out oldDate);
                Console.WriteLine(oldDate.ToString());
                Console.WriteLine(date.ToString());
                if (oldDate.TimeOfDay <= date.TimeOfDay)
                {
                    Content c = new Content { Filename = item.Filename, TotalChunks = item.TotalChunks, Data = "", ChunksLoaded = 0, Time = "N/A" };
                    EditItem(c);
                }
            }
            */

            string str = "";
            foreach (Content item in items)
            {
                str = str + item.Filename + "," + item.TotalChunks + "," + item.ChunksLoaded + "," + item.Time + ",;";
            }
            return str;
        }

        public string ReturnAllEvents()
        {
            IEnumerable<EventContent> items = _dbContext.EventContent.ToList();

            string str = "";
            foreach (EventContent item in items)
            {
                str = str + item.Event + ";";
            }
            return str;
        }

        public string ReturnAllItemNames()
        {
            IEnumerable<Content> items = _dbContext.Content.ToList();

            string str = "";
            foreach (Content item in items)
            {
                str = str + item.Filename + "," + item.TotalChunks + ";";
            }
            return str;
        }

        public Content VerifyItem(string itemName)
        {
            Content item = _dbContext.Content.FirstOrDefault(e => e.Filename == itemName);
            return item;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
