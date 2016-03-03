using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Dropbox.Api;
using Dropbox.Api.Files;
using FileBrowser.Models;

namespace FileBrowser.Controllers
{
    public class FilesController : ApiController
    {
        public HttpResponseMessage GetFiles()
        {
            //var currentDirectory = Directory.GetCurrentDirectory();

            //var files = Directory.GetFiles(currentDirectory, "*.*",
            //    SearchOption.AllDirectories)
            //    .Select(d => new FileInfo(d));

            //var fileInfos = files.ToArray();

            var toSend = GetData();

            return Request.CreateResponse(HttpStatusCode.OK, toSend);
        }

        //private async Task<List<Metadata>> GetListFiles()
        //{
        //    var list = await dbx.Files.ListFolderAsync(String.Empty);
        //    List<Metadata> files = list.Entries.ToList();
        //    return files;
        //}
        private StructElement GetData()
        {
            var list = new StructElement()
            {
                Name = "Folder1",
                Path = "Path1",
                Type = "folder",
                Items = new List<StructElement>()
                {
                    new StructElement()
                    {
                        Name = "Inside",
                        Path = "Path1/Path2",
                        Type = "folder",
                        Items = new List<StructElement>()
                        {
                            new StructElement()
                            {
                                Name = "Heap.txt",
                                Type = "file",
                                Path = "Path1/Path2/Path3"
                            }
                        }
                    },
                    new StructElement()
                    {
                        Name = "Folder",
                        Path = "Path1/Path2",
                        Type = "folder"
                    }
                }
            };

            return list;
        }
    }
}
