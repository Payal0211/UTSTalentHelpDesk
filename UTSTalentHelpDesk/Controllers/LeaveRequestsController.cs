﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using UTSTalentHelpDesk.Helpers;
using UTSTalentHelpDesk.Helpers.Common;
using UTSTalentHelpDesk.Models.ComplexTypes;
using UTSTalentHelpDesk.Models.Models;
using UTSTalentHelpDesk.Models.ViewModels;
using UTSTalentHelpDesk.Repositories.Interfaces;
using static UTSTalentHelpDesk.Helpers.Enum;

namespace UTSTalentHelpDesk.Controllers
{
    [Route("LeaveRequests")]
    [ApiController]
    [CustomAuthorize("Authorization", "4b441aae-d361-46e1-ad14-2b2114ffbe17")]
    public class LeaveRequestsController : ControllerBase
    {
        #region Private Variables
        private readonly IConfiguration _iConfiguration;
        private readonly IEmail _iEmail;
        private readonly ILeaveRequest _iLeaveRequest;       
        #endregion

        #region Constructor        
        public LeaveRequestsController(IConfiguration iConfiguration, IEmail iEmail, ILeaveRequest iLeaveRequest)
        {
            _iConfiguration = iConfiguration;
            _iEmail = iEmail;
            _iLeaveRequest = iLeaveRequest;            
        }
        #endregion

        #region public API's

        [HttpGet("GetLeaveTypes")]
        public async Task<IActionResult> GetLeaveTypes()
        {
            try
            {
                List<TsPrgLeaveType> leaveTypes = await _iLeaveRequest.GetLeaveTypes();
                return StatusCode(StatusCodes.Status200OK, new ResponseObject() { statusCode = StatusCodes.Status200OK, Message = "Success", Details = leaveTypes });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("InsertUpdateLeaveRequest")]
        public async Task<IActionResult> InsertUpdateLeaveRequest(LeaveRequestViewModel request)
        {
            try
            {
                #region Pre-Validation
                if (request == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject() { statusCode = StatusCodes.Status400BadRequest, Message = "Please provide payload" });
                }
                #endregion


                string flag = "Add";

                // if we are getting leaveId from payload then 
                if (!string.IsNullOrEmpty(request.LeaveID))
                {
                    flag = "Update";
                }
                else
                {
                    string? guid = Guid.NewGuid().ToString();
                    request.LeaveID = guid;
                }

                for (int i = 0; i < request.NoOfDays; i++) 
                {
                    object[] param = new object[]
                    {                        
                        request.TalentID,
                        request.LeaveDate.Value.AddDays(i).ToString("dd/MM/yyyy"),
                        request.LeaveDuration,
                        request.LeaveReason,
                        request.LeaveID,
                        flag,
                        request.IsFromSalesPortal ? (short)AppActionDoneBy.UTS : (short)AppActionDoneBy.TalentSupport,
                        request.CompanyID,
                        request.LeaveTypeID
                    };

                    string paramasString = CommonLogic.ConvertToParamStringWithNull(param);

                    await _iLeaveRequest.InsertUpdateLeaves(paramasString);

                    flag = "Add";
                }

                // Send email to client that the talent has added a leave request
                EmailBinder emailBinder = new EmailBinder(_iConfiguration, _iEmail);
                emailBinder.SendEmailToClientWhenRequestedForLeave(request);

                return StatusCode(StatusCodes.Status200OK, new ResponseObject() { statusCode = StatusCodes.Status200OK, Message = "Success" });
            }
            catch(Exception ex) 
            {
                throw;
            }
        }

        [HttpPost("ApproveRejectRevokeTalentLeaves")]
        public async Task<IActionResult> ApproveRejectRevokeTalentLeaves([FromForm] LeaveRequestActions actions)
        {
            try
            {
                #region Pre-Validation
                if (actions == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject() { statusCode = StatusCodes.Status400BadRequest, Message = "Please provide payload" });
                }
                #endregion

                string fileName = "";

                #region FileValidation

                if (actions.Files != null && actions.Files.Count != 0)
                {
                    string[] allowedFileExtensions = { ".pdf", ".doc", ".docx", ".txt", ".jpg", ".jpeg", ".png" };
                    double maxFileSizeInMB = 0.5; // 500 KB
                    string uploadPath = System.IO.Path.Combine(_iConfiguration["AdminPath"], "Media/TalentLeaveDocuments");

                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }

                    foreach (var file in actions?.Files)
                    {
                        var fileExtension = Path.GetExtension(file.FileName).ToLower();
                        fileName = Path.GetFileNameWithoutExtension(file.FileName);

                        if (!allowedFileExtensions.Contains(fileExtension))
                        {
                            return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject()
                            {
                                statusCode = StatusCodes.Status400BadRequest,
                                Message = $"File '{fileName}' has an invalid format.",
                                Details = null
                            });
                        }

                        var fileSizeInMB = (file.Length / 1024.0) / 1024.0;
                        if (fileSizeInMB > maxFileSizeInMB)
                        {
                            return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject()
                            {
                                statusCode = StatusCodes.Status400BadRequest,
                                Message = $"File '{fileName}' exceeds the maximum allowed size of 500 KB.",
                                Details = null
                            });
                        }

                        DateTime now = DateTime.Now;
                        string formattedDate = now.ToString("dd/MM/yyyy HH:mm:ss");
                        string pattern = @"[^a-zA-Z0-9._]";
                        // Replace specified special characters with an empty string
                        string uniqueFileName = $"{fileName}_{formattedDate}.{fileExtension}";
                        string cleanName = Regex.Replace(uniqueFileName, pattern, "");
                        // file.FileName + "" + System.DateTime.Now.ToString("ddmmyyyyhh:mm") + fileExtension;
                        string fullPath = Path.Combine(uploadPath, cleanName);

                        using (var fileStream = new FileStream(fullPath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }

                        fileName = cleanName;
                    }
                }

                #endregion

                object[] param = new object[]
                {
                    actions.LeaveID,
                    actions.ActionDoneBy,
                    actions.IsActionDoneByAM,
                    actions.LeaveRejectionRemark,
                    actions.Flag,
                    fileName
                };

                string paramasString = CommonLogic.ConvertToParamStringWithNull(param);

                await _iLeaveRequest.ApproveRejectRevokeTalentLeaves(paramasString);

                return StatusCode(StatusCodes.Status200OK, new ResponseObject() { statusCode = StatusCodes.Status200OK, Message = "Success" });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("GetTalentLeaves")]
        public async Task<IActionResult> GetTalentLeaves(long talentID, int month, int year, long onBoardId, long companyId)
        {
            try
            {
                #region Pre-Validation
                if (talentID == 0)
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject() { statusCode = StatusCodes.Status400BadRequest, Message = "Please provide Talent" });
                #endregion

                object[] param = new object[] {
                    talentID,
                    month,
                    year,
                    onBoardId,
                    companyId
                };

                string paramasString = CommonLogic.ConvertToParamString(param);

                List<TS_Sproc_GetTalentLeaves_Result> leaves = await _iLeaveRequest.Get_Talent_LeavesList(paramasString);
                if (leaves.Any())
                {
                    return StatusCode(StatusCodes.Status200OK, new ResponseObject() { statusCode = StatusCodes.Status200OK, Message = "Success", Details = leaves });
                }
                else
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseObject() { statusCode = StatusCodes.Status404NotFound, Message = "No Details" });

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetTalentLeavesMonthlyCalendar")]
        public async Task<IActionResult> GetTalentLeavesMonthlyCalendar(long talentID, int month, int year, long companyId)
        {
            try
            {
                #region Pre-Validation
                if (talentID == 0)
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject() { statusCode = StatusCodes.Status400BadRequest, Message = "Please provide Talent" });
                #endregion

                object[] param = new object[] {
                    talentID,
                    month,
                    year,
                    companyId
                };

                string paramasString = CommonLogic.ConvertToParamString(param);

                List<TS_Sproc_Get_Talent_Leaves_Monthly_Calendar_Result> leaves = await _iLeaveRequest.Get_Talent_LeavesList_Monthly(paramasString);
                if (leaves.Any())
                {
                    return StatusCode(StatusCodes.Status200OK, new ResponseObject() { statusCode = StatusCodes.Status200OK, Message = "Success", Details = leaves });
                }
                else
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseObject() { statusCode = StatusCodes.Status404NotFound, Message = "No Details" });


            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetTalentLeavesHistory")]
        public async Task<IActionResult> GetTalentLeavesHistory(long talentID, long onBoardId)
        {
            try
            {
                #region Pre-Validation
                if (talentID == 0)
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject() { statusCode = StatusCodes.Status400BadRequest, Message = "Please provide Talent" });
                #endregion

                object[] param = new object[] {
                    onBoardId,
                    talentID 
                };

                string paramasString = CommonLogic.ConvertToParamString(param);

                List<TS_Sproc_GetLeaveBalance_History_Result> leavesHistory = await _iLeaveRequest.GetLeaveBalance_History_Results(paramasString);
                if (leavesHistory.Any())
                {
                    return StatusCode(StatusCodes.Status200OK, new ResponseObject() { statusCode = StatusCodes.Status200OK, Message = "Success", Details = leavesHistory });
                }
                else
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseObject() { statusCode = StatusCodes.Status404NotFound, Message = "No Details" });

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
