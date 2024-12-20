using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
using UTSTalentHelpDesk.Repositories.Infrastructure.Repositories;
using UTSTalentHelpDesk.Repositories.Interfaces;
using UTSTalentHelpDesk.Repositories.Repositories;

namespace UTSTalentHelpDesk.Repositories.Infrastructure.ServiceExtension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient();
        
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUniversalProcRunner, UniversalProcRunnerRepository>();

            services.AddDbContextPool<UTSTalentHelpDeskDBConnection>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("UTSTalentHelpDeskDBConnection"), 
                    sqlOptions => sqlOptions.CommandTimeout(120)
                );
            });

            services.AddDbContext<UTSTalentHelpDeskDBConnection>(ServiceLifetime.Transient);
            services.AddDbContext<InMemoryDbContext>(ServiceLifetime.Scoped,ServiceLifetime.Scoped);
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IGenCompanyRepository, GenCompanyRepository>();
            services.AddScoped<IGenCompanyContractDetailRepository, GenCompanyContractDetailRepository>();
          
            services.AddScoped<IGenContactRepository, GenContactRepository>();
            
            services.AddScoped<IGenContactPointofContactRepository, GenContactPointofContactRepository>();
            services.AddScoped<IGenContactTalentPriorityRepository, GenContactTalentPriorityRepository>();
            services.AddScoped<IGenDealRepository, GenDealRepository>();
            
            services.AddScoped<IGenOnBoardTalentRepository, GenOnBoardTalentRepository>();
 
            services.AddScoped<IGenOnBoardTalentsReplacementDetailRepository, GenOnBoardTalentsReplacementDetailRepository>();
          
            services.AddScoped<IGenSalesHiringRequestRepository, GenSalesHiringRequestRepository>();
   
            services.AddScoped<IGenSalesHiringRequestSkillDetailRepository, GenSalesHiringRequestSkillDetailRepository>();
    
            services.AddScoped<IGenTalentRepository, GenTalentRepository>();
         
            services.AddScoped<IGenTeamRepository, GenTeamRepository>();
         
            services.AddScoped<IPrgActionFilterRepository, PrgActionFilterRepository>();
       
            services.AddScoped<IPrgDealStageRepository, PrgDealStageRepository>();
       
            services.AddScoped<IPrgDealTypeRepository, PrgDealTypeRepository>();
        
            services.AddScoped<IPrgGeoRepository, PrgGeoRepository>();
      
            services.AddScoped<IPrgHiringRequestStatusRepository, PrgHiringRequestStatusRepository>();
        
            services.AddScoped<IPrgPipelineRepository, PrgPipelineRepository>();
       
            services.AddScoped<IPrgSkillRepository, PrgSkillRepository>();
         
            services.AddScoped<IPrgSummaryStagesForReportRepository, PrgSummaryStagesForReportRepository>();
       
            services.AddScoped<IPrgTalentRoleRepository, PrgTalentRoleRepository>();
        
            services.AddScoped<IPrgTempSkillRepository, PrgTempSkillRepository>();
         
            services.AddScoped<IUsrUserRoleRepository, UsrUserRoleRepository>();
            services.AddScoped<IUsrUserRoleDetailRepository, UsrUserRoleDetailRepository>();
        
            services.AddScoped<IUsrUserTypeRepository, UsrUserTypeRepository>();
           
            services.AddScoped<IStoreAPIUrlRepository, StoreAPIUrlRepository>();           

            return services;
        }
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IAccount, AccountRepository>();           
            services.AddScoped<IUsrUserRepository, UsrUserRepository>();
            services.AddScoped<ITicket, TicketRepository>();
            services.AddScoped<IEmail, EmailRepository>();
            services.AddScoped<IDashboard, DashBoardRepository>();
            services.AddScoped<IAppliedjobs, AppliedJobsRepository>();
            services.AddScoped<IDocument, DocumentRepository>();
            services.AddScoped<ILeaveRequest, LeaveRequestRepository>();
        }
    }
}
