ALTER PROCEDURE [dbo].[TS_Sproc_Get_Talent_Contact_Details]
	@TalentID BIGINT = NULL
AS
BEGIN 

	SELECT TOP 1 C.EmailID, C.FullName, C.ID, C.CompanyID, T.FirstName + ' ' + T.LastName AS TalentName, T.EmailID AS TalentEmail
	FROM gen_OnBoardTalents OBT WITH(NOLOCK) 
	INNER JOIN gen_Contact C WITH(NOLOCK) ON OBT.ContactID = C.ID
	INNER JOIN gen_Talent T WITH(NOLOCK) ON T.ID = OBT.Talent_ID
	WHERE Talent_ID = @TalentID AND OBT.Joiningdate IS NOT NULL
	ORDER BY OBT.TalentOnBoardingDate DESC

END