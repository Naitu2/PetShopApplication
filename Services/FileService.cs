namespace PetShopApplication.Services
{
    public class FileService
    {
        public static void ManageAnimalImages(IWebHostEnvironment environment)
        {
            var animalFolderPath = Path.Combine(environment.WebRootPath, "images/Animals");
            var dotAnimalFolderPath = Path.Combine(environment.WebRootPath, "images/.Animals");

            if (Directory.Exists(animalFolderPath))
            {
                Directory.Delete(animalFolderPath, true);
            }

            Directory.CreateDirectory(animalFolderPath);

            if (Directory.Exists(dotAnimalFolderPath))
            {
                foreach (var file in Directory.GetFiles(dotAnimalFolderPath))
                {
                    var fileName = Path.GetFileName(file);
                    var destFile = Path.Combine(animalFolderPath, fileName);
                    File.Copy(file, destFile, true);
                }
            }
        }
    }
}
