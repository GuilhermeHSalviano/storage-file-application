namespace api_for_uploading_files;

public class UploadHandler
{
    public string Upload(IFormFile file)
    {
        //get the extension of the file
        string extension = Path.GetExtension(file.FileName);

        //define all the valid extensions that our application will accept
        List<string> validExtensions = new List<string>() { ".jpg", ".png", ".gif" };

        //verifies whether the file passed has a valid extension
        if (!validExtensions.Contains(extension))
        {
            return $"Extension is not valid ({string.Join(',', validExtensions)})";
        }

        //this storage the size of the file in bytes
        long size = file.Length;

        //verifies whether or not the size of the file is lower than 5Mb. 
        //the expression in parenthesis is a calculation that is equivalent to 5MB,
        //once the size variable is mesured in bytes, not mega bytes.
        if (size > (5 * 1024 * 1024))
        {
            return "Maximun size can be 5mb";
        }

        //change the name of the incomming file.
        //GUID stands for Globally Unique Identifier
        string fileName = Guid.NewGuid().ToString() + extension;

        //once every OS has its own way to define paths, this Path.Combine
        //sets a dynamic path that works in every OS
        //the Directory method get the currenct directory of the file we're working on now
        //the "Uploads" string represents another part of the path that point to Uploads directory
        string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

        //the file we receives is of type byte but, in order to see it as a normal file,
        //we need to transform it in a FileStream, a C# type.
        //It takes two arguments: the combination of the path and the file name is the first one.
        //the second one is 
        using FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create);

        //CopyTo is a method of IFormFile. In our case, it copy the file we're receiving
        //to the stream new object we've just created
        file.CopyTo(stream);

        return fileName;

    }
}
