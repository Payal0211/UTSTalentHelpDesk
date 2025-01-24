using Microsoft.AspNetCore.Mvc;
using UTSTalentHelpDesk.Helpers.Common;
using UTSTalentHelpDesk.Models.ComplexTypes;
using UTSTalentHelpDesk.Models.Models;
using UTSTalentHelpDesk.Repositories.Interfaces;

namespace UTSTalentHelpDesk.Controllers
{
    [Route("AppliedJobs/", Name = "Applied Jobs")]
    [ApiController]
    //[Authorize]
    public class AppliedJobsController : ControllerBase
    {

        #region Private Variables
        private readonly IAppliedjobs _iappliedjobs;
        private readonly IConfiguration _iConfiguration;
        private readonly IEmail _iEmail;
        #endregion

        #region Constructor        
        public AppliedJobsController(IConfiguration iConfiguration, IEmail iEmail, IAppliedjobs iappliedjobs)
        {
            _iConfiguration = iConfiguration;
            _iEmail = iEmail;
            _iappliedjobs = iappliedjobs;
        }
        #endregion

        #region Get Active Engagement List
        [HttpGet("GetActiveEngagementList")]
        public async Task<IActionResult> GetActiveEngagementList(long TalentId)
        {
            try
            {
                #region Pre-Validation
                if (TalentId == 0)
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject() { statusCode = StatusCodes.Status400BadRequest, Message = "Please provide Talent" });
                #endregion

                object[] param = new object[] {
                    TalentId
                };

                string paramasString = CommonLogic.ConvertToParamStringWithNull(param);

                List<TS_Sproc_GetActive_EngagementList_Result> listEngagement = await _iappliedjobs.GetActive_EngagementList(paramasString);
                if (listEngagement.Any())
                {
                    return StatusCode(StatusCodes.Status200OK, new ResponseObject() { statusCode = StatusCodes.Status200OK, Message = "Success", Details = listEngagement });
                }
                else
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseObject() { statusCode = StatusCodes.Status404NotFound, Message = "No Engagement" });

                
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Get Close Engagement List
        [HttpGet("GetCloseEngagementList")]
        public async Task<IActionResult> GetCloseEngagementList(long TalentId)
        {
            try
            {
                #region Pre-Validation
                if (TalentId == 0)
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject() { statusCode = StatusCodes.Status400BadRequest, Message = "Please provide Talent" });
                #endregion

                object[] param = new object[] {
                    TalentId
                };


                string paramasString = CommonLogic.ConvertToParamStringWithNull(param);

                List<TS_Sproc_GetClose_EngagementList_Result> listEngagement = await _iappliedjobs.GetClose_EngagementList(paramasString);
                if (listEngagement.Any())
                {
                    return StatusCode(StatusCodes.Status200OK, new ResponseObject() { statusCode = StatusCodes.Status200OK, Message = "Success", Details = listEngagement });
                }
                else
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseObject() { statusCode = StatusCodes.Status404NotFound, Message = "No Engagement" });


            }
            catch (Exception)
            {

                throw;
            }



        }
        #endregion

        #region Get Engagement PR Details Month Wise
        [HttpGet("GetEngagementPRDetailsMonthWise")]
        public async Task<IActionResult> GetEngagementPRDetailsMonthWise(long onBoardId)
        {
            try
            {
                #region Pre-Validation
                if (onBoardId == 0)
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject() { statusCode = StatusCodes.Status400BadRequest, Message = "Please provide engagement" });
                #endregion

                object[] param = new object[] {
                    onBoardId
                };

                string paramasString = CommonLogic.ConvertToParamStringWithNull(param);

                List<TS_Sproc_Get_engagement_PRDetails_MonthWise_Result> listEngagementPRDetails = await _iappliedjobs.GetEngagementPRDetailsMonthWiseResult(paramasString);
                if (listEngagementPRDetails.Any())
                {
                    return StatusCode(StatusCodes.Status200OK, new ResponseObject() { statusCode = StatusCodes.Status200OK, Message = "Success", Details = listEngagementPRDetails });
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseObject() { statusCode = StatusCodes.Status404NotFound, Message = "No Details" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }
}
