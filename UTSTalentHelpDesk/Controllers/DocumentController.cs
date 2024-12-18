using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Dynamic;
using UTSTalentHelpDesk.Helpers.Common;
using UTSTalentHelpDesk.Models.Models;
using UTSTalentHelpDesk.Models.ViewModels;
using UTSTalentHelpDesk.Repositories.Interfaces;

namespace UTSTalentHelpDesk.Controllers
{
    [Route("Document/", Name = "Document")]
    [ApiController]
    [Authorize]
    public class DocumentController : ControllerBase
    {
        #region Private Variables
        private readonly IConfiguration _iConfiguration;
        private readonly IEmail _iEmail;
        private readonly IDocument _idocument;
        private readonly UTSTalentHelpDeskDBConnection _connection;
        #endregion

        #region Constructor        
        public DocumentController(IConfiguration iConfiguration, IEmail iEmail, IDocument idocument, UTSTalentHelpDeskDBConnection connection)
        {
            _iConfiguration = iConfiguration;
            _iEmail = iEmail;
            _idocument = idocument;
            _connection = connection;
        }
        #endregion

        [HttpGet("Filters")]
        public async Task<ObjectResult> Filters()
        {
            try
            {
                DocumentFilters documentFilters = new DocumentFilters();

                documentFilters.DocumentType = _connection.TsPrgDocumentTypes.Where(x => x.IsActive == true).ToList().Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.DocumentType
                }).OrderBy(y => y.Text); 
                
                return StatusCode(StatusCodes.Status200OK, new ResponseObject() { statusCode = StatusCodes.Status200OK, Message = "Filter List", Details = documentFilters });

            }
            catch (Exception)
            {
                throw;
            }
        }

        #region UploadFiles
        [HttpPost("UploadFiles")]
        public async Task<ObjectResult> UploadFiles([FromForm] ImageUpload files)
        {
            try
            {
                if (files == null || files.Files.Count == 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject()
                    {
                        statusCode = StatusCodes.Status400BadRequest,
                        Message = "No files provided.",
                        Details = null
                    });
                }

                string[] allowedFileExtensions = { ".pdf", ".doc", ".docx", ".txt", ".jpg", ".jpeg", ".png" };
                double maxFileSizeInMB = 0.5; // 500 KB
                string uploadPath = "Media/TalentDocuments";

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                List<dynamic> uploadedFiles = new List<dynamic>();

                foreach (var file in files.Files)
                {
                    #region Validation
                    if (file == null || file.Length == 0)
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject()
                        {
                            statusCode = StatusCodes.Status400BadRequest,
                            Message = "One or more files are empty or corrupt.",
                            Details = null
                        });
                    }

                    var fileExtension = Path.GetExtension(file.FileName).ToLower();
                    if (!allowedFileExtensions.Contains(fileExtension))
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject()
                        {
                            statusCode = StatusCodes.Status400BadRequest,
                            Message = $"File '{file.FileName}' has an invalid format.",
                            Details = null
                        });
                    }

                    var fileSizeInMB = (file.Length / 1024.0) / 1024.0;
                    if (fileSizeInMB > maxFileSizeInMB)
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject()
                        {
                            statusCode = StatusCodes.Status400BadRequest,
                            Message = $"File '{file.FileName}' exceeds the maximum allowed size of 500 KB.",
                            Details = null
                        });
                    }
                    #endregion

                    #region Save File
                    string uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
                    string fullPath = Path.Combine(uploadPath, uniqueFileName);

                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    object[] paramwebhook = new object[] {
                                files.DocumentTypeID,
                                files.TalentID,
                                file.FileName,
                                files.TalentID
                            };
                    string paramasStringwebhook = CommonLogic.ConvertToParamString(paramwebhook);

                    _idocument.CreateDocument(paramasStringwebhook);

                    uploadedFiles.Add(new { FileName = file.FileName, SavedAs = uniqueFileName, Path = fullPath });
                    #endregion
                }

                return StatusCode(StatusCodes.Status200OK, new ResponseObject()
                {
                    statusCode = StatusCodes.Status200OK,
                    Message = "Files uploaded successfully.",
                    Details = uploadedFiles
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseObject()
                {
                    statusCode = StatusCodes.Status500InternalServerError,
                    Message = "An error occurred while uploading files.",
                    Details = ex.Message
                });
            }
        }
        #endregion

    }
}
