using ProjectEBusinessMVC.Areas.EBusinessVAdmin.ViewModels.SpecialTeam;

namespace ProjectEBusinessMVC.Extensions
{
    public static class FileExtension
    {
        public async static Task<string> FileSaveAsync(this IFormFile file, string wwwroot, params string[] pathes)
        {
            try
            {
                string filename = Guid.NewGuid().ToString() + file.FileName;

                string resultPath = wwwroot;
                foreach (string path in pathes)
                {

                    resultPath = Path.Combine(resultPath, path);
                }
                resultPath = Path.Combine(resultPath, filename);

                using (FileStream stream = new FileStream(filename, FileMode.Create))
                {

                    await file.CopyToAsync(stream);
                }

                return filename;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
