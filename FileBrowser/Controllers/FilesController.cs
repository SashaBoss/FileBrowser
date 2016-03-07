namespace FileBrowser.Controllers
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using FileBrowser.Models;

    public class FilesController : ApiController
    {
        public HttpResponseMessage GetFiles()
        {
            var toSend = GetFromHardDisk();

            return Request.CreateResponse(HttpStatusCode.OK, toSend);
        }

        private static IEnumerable<AboutFile> GetFromHardDisk()
        {
            var path = Directory.GetCurrentDirectory();
            var dirInfo = new DirectoryInfo(path);

            // Get the files in the directory and print out some information about them.
            System.IO.FileInfo[] fileNames = dirInfo.GetFiles("*.*");

            var list = fileNames.Select(f =>
                new AboutFile
                {
                    Name = f.Name,
                    ModificationDate = f.LastAccessTime.ToString(CultureInfo.InvariantCulture),
                    Size = ConvertBytesTokilobytes(f.Length).ToString("F")
            }).ToList();

            return list;
        }

        private static double ConvertBytesTokilobytes(long bytes)
        {
            return (bytes / 1024f) ;
        }
    }
}
