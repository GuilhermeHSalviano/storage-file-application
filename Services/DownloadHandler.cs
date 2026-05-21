using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace api_for_uploading_files;

public class DownloadHandler
{
    public static string Download(string fileName) {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", fileName);
        if(!File.Exists(path)) throw new Exception("O arquivo não foi encontrado");
        return path;
    }
}
