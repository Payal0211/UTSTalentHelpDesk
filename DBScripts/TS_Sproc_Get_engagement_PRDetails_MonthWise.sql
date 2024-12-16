USE [TalentConnect]
GO
/****** Object:  StoredProcedure [dbo].[Sproc_Get_engagement_Edit_All_BR_PR]    Script Date: 09-12-2024 13:38:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TS_Sproc_Get_engagement_PRDetails_MonthWise] 
@OnboardID bigint,
@Month	   int		 = null,
@Year	   int		 = null
as      
begin       

   WITH OnBoardDetails AS (
    SELECT 
        PInfo.ID,
        OBT.ID AS OnBoardID,
        MONTH(ISNULL(PInfo.ClientInvoiceDate, 0)) AS Months, 
        YEAR(ISNULL(PInfo.ClientInvoiceDate, 0)) AS Years,
        ISNULL(OBT.EngagemenID, '') AS EngagemenID,
        ISNULL(CER.CurrencySign, '') AS Currency,
        DATENAME(MONTH, DATEADD(MONTH, MONTH(PInfo.ClientInvoiceDate), 0) - 1) AS MonthNames,        
        ISNULL(PInfo.Actual_pay_Rate, 0) AS PR,       
        ISNULL(PInfo.ContractType, OBTD.ContractType) AS ContractType,
		ISNULL(PInfo.ClientInvoiceDate,'') AS ClientInvoiceDate,
		ISNULL(OBT.EngagemenID,'') + ' / ' + Char(10) + Isnull(SHR.Hr_Number,'') AS EngagementId_HRID,
		--ISNULL(PInfo.AM_SalesPersonID,0) AS AM_SalesPersonID,
		ISNULL(PInfo.AM_SalesPersonID, OBT.AM_SalesPersonID) AS AM_SalesPersonID,
		ISNULL(AM.FullName,'') AS AM_UserName,
		ISNULL(PInfo.TSC_PersonID,0) AS TSC_PersonID,
		ISNULL(TSC.FullName,'') AS TSC_UserName
    FROM gen_OnBoardTalents OBT WITH(NOLOCK)
    INNER JOIN gen_OnBoardClientContractDetails OBTD WITH(NOLOCK) ON OBTD.OnBoardID = OBT.ID
    INNER JOIN gen_Payout_Information PInfo WITH(NOLOCK) ON PInfo.OnBoardID = OBT.ID
	INNER JOIN gen_SalesHiringRequest SHR WITH(NOLOCK) ON PInfo.HiringRequest_ID = SHR.ID 
	Inner join prg_CurrencyExchangeRate CER WITH(NOLOCK) ON CER.CurrencyCode = OBTD.Currency
	--Left join usr_User AM WITH(NOLOCK) ON AM.ID =  isnull(PInfo.AM_SalesPersonID,OBT.AM_SalesPersonID)
	Left join usr_User AM WITH(NOLOCK) ON AM.ID =  case when isnull(PInfo.AM_SalesPersonID,0) = 0 then OBT.AM_SalesPersonID ELSe isnull(PInfo.AM_SalesPersonID,OBT.AM_SalesPersonID) end
	LEFT JOIN usr_User TSC WITH(NOLOCK) ON TSC.ID = PInfo.TSC_PersonID
    WHERE OBT.ID = @onboardid
)
SELECT * FROM OnBoardDetails  
where 
   Months = CASE WHEN ISNULL(@Month,0) > 0  THEN @Month ELSE Months END AND
   Years = CASE WHEN ISNULL(@Year,0) > 0 THEN @Year ELSE Years END
   Order by ClientInvoiceDate

end   