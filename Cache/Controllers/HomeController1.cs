using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Cors;
using Server.Data;
using Server.Models;

namespace Cache.Controllers
{
    [Route("api")]
    [ApiController]
    public class HomeController1 : Controller
    {
        static readonly HttpClient client = new HttpClient();

        private readonly IWebAPIRepo _repository;
        public HomeController1(IWebAPIRepo repository)
        {
            _repository = repository;
        }

        [EnableCors]
        [HttpGet("DownloadItem/{element}")]
        public async Task<ActionResult<string>> ReturnItemAsync(string element)
        {
            string str = "Something went wrong!";
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                string name = element.Split(",")[0];
                string totalChunks = element.Split(",")[1];

                Content oldContent = _repository.VerifyItem(name);
                string oldData = oldContent.Data;
                int oldChunksLoaded = oldContent.ChunksLoaded;

                int permOldChunksLoaded = oldChunksLoaded;

                Console.WriteLine(permOldChunksLoaded);

                string dateFormat = "MM/dd/yyyy hh:mm:ss";
                DateTime date = DateTime.Now;

                EventContent e = new EventContent { Event = "User Request: File " + name + " at " + date.ToString(dateFormat) };
                _repository.AddEvent(e);

                try
                {
                    while (oldChunksLoaded < oldContent.TotalChunks)
                    {
                        HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/DownloadItem/" + name + "," + oldChunksLoaded);
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        oldData = oldData + responseBody;
                        oldChunksLoaded++;
                    }

                    DateTime date1 = DateTime.Now;

                    Content c = new Content { Filename = name, TotalChunks = Int32.Parse(totalChunks), Data = oldData, ChunksLoaded = oldChunksLoaded, Time = date1.ToString(dateFormat) };
                    _repository.EditItem(c);

                    EventContent e1 = new EventContent { Event = "Response: " + ((float)permOldChunksLoaded / (float)c.TotalChunks * 100).ToString("0") + "% of file " + name + " was constructed with the cached data" };
                    _repository.AddEvent(e1);

                    return (c.Data);
                } catch
                {
                    DateTime date2 = DateTime.Now;

                    Content c = new Content { Filename = name, TotalChunks = Int32.Parse(totalChunks), Data = oldData, ChunksLoaded = oldChunksLoaded, Time = date2.ToString(dateFormat) };
                    _repository.EditItem(c);

                    Console.WriteLine(permOldChunksLoaded);

                    EventContent e2 = new EventContent { Event = "Response: " + ((float)permOldChunksLoaded / (float)c.TotalChunks * 100).ToString("0") + "% of file " + name + " was constructed with the cached data" };
                    _repository.AddEvent(e2);

                    return (oldData);
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return Ok(str);
        }

        [EnableCors]
        [HttpGet("UpdateCache")]
        public ActionResult<string> ReturnCache()
        {
            string str = "Something went wrong!";
            str = _repository.ReturnAllItems();
            return Ok(str);
        }

        [EnableCors]
        [HttpGet("ClearCache")]
        public ActionResult<string> ClearCache()
        {
            string str = "Cache Cleared!";
            _repository.RemoveAllItems();
            return Ok(str);
        }

        [EnableCors]
        [HttpGet("ClearCacheLog")]
        public ActionResult<string> ClearCacheLog()
        {
            string str = "Cache Log Cleared!";
            _repository.RemoveAllEvents();
            return Ok(str);
        }

        [EnableCors]
        [HttpGet("GetData/{element}")]
        public ActionResult<string> ReturnData(string element)
        {
            string name = element.Split(",")[0];
            int chunk = Int32.Parse(element.Split(",")[1]);
            Content c = _repository.VerifyItem(name);
            try
            {
                c.Data = c.Data.Substring(chunk * 650, 650);
            }
            catch
            {
                c.Data = c.Data.Substring(chunk * 650);
            }
            return Ok(c.Data);
        }

        [EnableCors]
        [HttpGet("GetAllEvents")]
        public ActionResult<string> ReturnEvents()
        {
            string str = _repository.ReturnAllEvents();
            return Ok(str);
        }

        [EnableCors]
        [HttpGet("RefreshCache")]
        public async Task<ActionResult<string>> RefreshCacheAsync()
        {
            string str = "Something went wrong!";
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                _repository.RemoveAllItems();

                HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/UpdateServerContent");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            try
            {
                _repository.RemoveAllItems();

                HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/GetAllItems");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                string temp = responseBody.Remove(responseBody.Length - 1, 1);
                string[] ret = temp.Split(';');
                foreach (string element in ret)
                {
                    string name = element.Split(',')[0];
                    string totalChunks = element.Split(',')[1];
                    Content c = new Content { Filename = name, TotalChunks = Int32.Parse(totalChunks), Data = "", ChunksLoaded = 0, Time = "N/A" };
                    _repository.AddItem(c);
                }

                str = _repository.ReturnAllItems();
                return Ok(str);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return Ok(str);
        }

        [EnableCors]
        [HttpGet("GetListItems")]
        public ActionResult<string> ReturnListItems()
        {
            string str = _repository.ReturnAllItemNames();
            return Ok(str);
        }
    }
}
