using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.Dtos;
using Server.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Cors;

namespace Server.Controllers
{
    [Route("api")]
    [ApiController]
    public class MyController : Controller
    {
        private readonly IWebAPIRepo _repository;
        public MyController(IWebAPIRepo repository)
        {
            _repository = repository;
        }

        [EnableCors]
        [HttpGet("UpdateServerContent")]
        public ActionResult<string> UpdateFiles()
        {
            _repository.RemoveAllItems();

            string filePath = Directory.GetCurrentDirectory();
            string fileDir = Path.Combine(filePath, "wwwroot/Images/");
            string[] filePaths = Directory.GetFiles(fileDir);
            
            foreach (string name in filePaths)
            {

                byte[] imageArray = System.IO.File.ReadAllBytes(name);
                string base64ImageRepresentation = Convert.ToBase64String(imageArray);

                int totalChunks = base64ImageRepresentation.Length / 650;

                if (base64ImageRepresentation.Length % 650 > 0)
                {
                    totalChunks++;
                }

                Content c = new Content { Filename = name.Substring(name.LastIndexOf("/") + 1), TotalChunks = totalChunks, Data = base64ImageRepresentation };
                _repository.AddItem(c);
            }

            return Ok("Server Files Updated");
        }

        [EnableCors]
        [HttpGet("GetItem/{name}")]
        public ActionResult ReturnFile(string name)
        {
            string path = Directory.GetCurrentDirectory();
            string imgDir = Path.Combine(path, "wwwroot/Images/");
            string fileName = Path.Combine(imgDir, name + ".bmp");
            string respHeader = "image/bmp";
            if (System.IO.File.Exists(fileName) == false)
            {
                return NotFound();
            }
            return PhysicalFile(fileName, respHeader);
        }

        [EnableCors]
        [HttpGet("GetItemByteFile/{name}")]
        public ActionResult ReturnByteFile(string name)
        {
            string path = Directory.GetCurrentDirectory();
            string imgDir = Path.Combine(path, "wwwroot/Images/");
            string fileName = Path.Combine(imgDir, name + ".bmp");

            byte[] imageArray = System.IO.File.ReadAllBytes(fileName);
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);

            if (System.IO.File.Exists(fileName) == false)
            {
                return NotFound();
            }
            return Ok(base64ImageRepresentation);
        }

        [EnableCors]
        [HttpGet("DownloadItem/{oldName}")]
        public ActionResult ReturnDownloadItem(string oldName)
        {
            string name = oldName.Split(",")[0];
            int chunkNumber = Int32.Parse(oldName.Split(",")[1]);

            Content c = _repository.VerifyItem(name);
            try
            {
                c.Data = c.Data.Substring(chunkNumber * 650, 650);
            } catch
            {
                c.Data = c.Data.Substring(chunkNumber * 650);
            }
            
            
            return Ok(c.Data);
        }

        [EnableCors]
        [HttpGet("AddItem/{name}")]
        public ActionResult<string> ConvertItemFile(string name)
        {
            string path = Directory.GetCurrentDirectory();
            string imgDir = Path.Combine(path, "wwwroot/Images/");
            string fileName = Path.Combine(imgDir, name + ".bmp");

            byte[] imageArray = System.IO.File.ReadAllBytes(fileName);
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);

            Content c = new Content { Filename = name + ".bmp", TotalChunks = base64ImageRepresentation.Length / 650, Data = base64ImageRepresentation };
            if (_repository.VerifyItem(name + ".bmp") == null)
            {
                _repository.AddItem(c);
                return "Content Added";
            }
            else
            {
                return "Content Not Added";
            }
        }

        [EnableCors]
        [HttpGet("RemoveItem/{name}")]
        public ActionResult<string> RemoveItemFile(string name)
        {
            string path = Directory.GetCurrentDirectory();
            string imgDir = Path.Combine(path, "wwwroot/Images/");
            string fileName = Path.Combine(imgDir, name + ".bmp");

            byte[] imageArray = System.IO.File.ReadAllBytes(fileName);
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);

            Content c = new Content { Filename = name + ".bmp", TotalChunks = base64ImageRepresentation.Length / 650, Data = base64ImageRepresentation };
            if (_repository.VerifyItem(name + ".bmp") == null)
            {
                return "Content Not Removed";
            }
            else
            {
                _repository.RemoveItem(name + ".bmp");
                return "Content Removed";
            }
        }

        [EnableCors]
        [HttpGet("GetAllItems")]
        public ActionResult ReturnAllFilenamesAndTotalChunks()
        {
            string str = _repository.ReturnAllItems();
            return Ok(str);
        }

        [EnableCors]
        [HttpGet("GetAllItemsOld")]
        public ActionResult ReturnAllFilenames()
        {
            DirectoryInfo d = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/"));

            FileInfo[] Files = d.GetFiles("*.bmp");
            string str = "";

            foreach (FileInfo file in Files)
            {
                str = str + " " + file.Name;
            }
            return Ok(str);
        }

        [EnableCors]
        [HttpGet("GetVersion")]
        public ActionResult<string> ReturnVersion()
        { 
            return "V1";
        }
    }
}