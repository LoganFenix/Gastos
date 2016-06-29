using EmoticonPlatzi.Models;
using EmoticonPlatzi.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EmoticonPlatzi.Controllers
{
    public class EmoUploaderController : Controller
    {

        string ServerFolderPath;
        EmotionHelper emoHelper;
        string key;
        EmoticonPlatziContext db = new EmoticonPlatziContext();

        // GET: EmoUploader

        public EmoUploaderController()
        {
            
            ServerFolderPath = ConfigurationManager.AppSettings["UPLOAD_DIR"];
            key = ConfigurationManager.AppSettings["EMOTION_KEY"];
            emoHelper = new EmotionHelper(key);
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(HttpPostedFileBase file)
        {

            try
            {
                if (file?.ContentLength > 0)
                {

                    var pictureName = Guid.NewGuid().ToString();
                    pictureName += Path.GetExtension(file.FileName);
                    var route = Server.MapPath(ServerFolderPath);
                    route = route + "/" + pictureName;
                    file.SaveAs(route);
                    var emoPicture = await emoHelper.DetectAndExtractFacesAsync(file.InputStream);

                    emoPicture.Name = file.FileName;
                    emoPicture.Path = $"{ServerFolderPath}/{pictureName}";

                    db.EmoPictures.Add(emoPicture);
                    await db.SaveChangesAsync();


                    return RedirectToAction("Details", "EmoPictures", new { Id = emoPicture.Id });
                }
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                      .SelectMany(x => x.ValidationErrors)
                      .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);

            }
            catch (DbUpdateException ex)
            {

                //HandleDbUpdateException(ex);

                string mesage = ex.Message;

            }
            return View();
        }
    }
}