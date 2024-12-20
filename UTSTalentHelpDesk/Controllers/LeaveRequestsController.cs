using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UTSTalentHelpDesk.Helpers;
using UTSTalentHelpDesk.Helpers.Common;
using UTSTalentHelpDesk.Models.ComplexTypes;
using UTSTalentHelpDesk.Models.Models;
using UTSTalentHelpDesk.Models.ViewModels;
using UTSTalentHelpDesk.Repositories.Interfaces;

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
                        flag
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
        public async Task<IActionResult> ApproveRejectRevokeTalentLeaves(LeaveRequestActions actions)
        {
            try
            {
                #region Pre-Validation
                if (actions == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject() { statusCode = StatusCodes.Status400BadRequest, Message = "Please provide payload" });
                }
                #endregion

                object[] param = new object[]
                {
                    actions.LeaveID,
                    actions.ActionDoneBy,
                    actions.IsActionDoneByAM,
                    actions.LeaveRejectionRemark,
                    actions.Flag
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
        public async Task<IActionResult> GetTalentLeaves(long talentID)
        {
            try
            {
                #region Pre-Validation
                if (talentID == 0)
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject() { statusCode = StatusCodes.Status400BadRequest, Message = "Please provide Talent" });
                #endregion

                object[] param = new object[] {
                    talentID
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
        public async Task<IActionResult> GetTalentLeavesMonthlyCalendar(long talentID, int month, int year)
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
                    year
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

        #endregion
    }
}
