using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Data
{
    public interface IWebAPIRepo
    {
        Content VerifyItem(string itemName);
        void AddItem(Content item);
        void RemoveItem(string itemName);
        void RemoveAllItems();
        string ReturnAllItems();
    }
}
