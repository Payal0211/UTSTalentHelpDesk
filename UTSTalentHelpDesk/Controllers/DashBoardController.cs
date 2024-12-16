using Microsoft.AspNetCore.Mvc;

using UTSTalentHelpDesk.Helpers.Common;
using UTSTalentHelpDesk.Models.ComplexTypes;
using UTSTalentHelpDesk.Models.Models;
using UTSTalentHelpDesk.Repositories.Interfaces;

namespace UTSTalentHelpDesk.Controllers
{
    [Route("Dashboard/", Name = "Home Page")]
    [ApiController]
    [Authorize]
    public class DashBoardController : ControllerBase
    {
        #region Private Variables
        private readonly IDashboard _iDashboard;
        private readonly IConfiguration _iConfiguration;
        private readonly IEmail _iEmail;
        #endregion

        #region Constructor        
        public DashBoardController(IConfiguration iConfiguration,IEmail iEmail,IDashboard iDashboard)
        {
            _iConfiguration = iConfiguration;
            _iEmail = iEmail;
            _iDashboard = iDashboard;
        }
        #endregion

        [HttpGet("DashboardDetails")]
        public async Task<ObjectResult> GetDashboardDetails(long talentId)
        {
            #region Pre Validation
            if (talentId == 0)
            {
                talentId = SessionValues.LoginUserId;
            }
            #endregion


            object[] param = new object[] {
                talentId
                };


            string paramasString = CommonLogic.ConvertToParamString(param);

            List<TS_Sproc_Get_DashBoradCounts_Result> dashBoradCounts = await _iDashboard.GetDashBoradCounts(paramasString);
            if (dashBoradCounts.Any())
            {
                return StatusCode(StatusCodes.Status200OK, new ResponseObject() { statusCode = StatusCodes.Status200OK, Message = "Success", Details = dashBoradCounts });
            }
            else
                return StatusCode(StatusCodes.Status404NotFound, new ResponseObject() { statusCode = StatusCodes.Status404NotFound, Message = "No Count" });

        }

    }
}
