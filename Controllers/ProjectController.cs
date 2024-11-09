using DepiMvcTask1.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DepiMvcTask1.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectRepository projectRepository;

        public ProjectController(IProjectRepository projectRepository) 
        {
            this.projectRepository = projectRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Project> projects = projectRepository.GetAll();
            return View("Index",projects);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        public async Task<IActionResult> SaveAdd(Project project)
        {
            if (ModelState.IsValid && project.realImage != null && project.realImage.Length > 0)
            {
                // Define the path where the file will be saved
                var fileName = Path.GetFileName(project.realImage.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                // Ensure the directory exists
                var directory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // Save the file to the specified path
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await project.realImage.CopyToAsync(stream);
                }

                // Store the file path or filename in the database
                project.image = $"/images/{fileName}";

                //mycontext.projects.Add(project);
                projectRepository.Add(project);
                projectRepository.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Add", project);
        }

    }
}
