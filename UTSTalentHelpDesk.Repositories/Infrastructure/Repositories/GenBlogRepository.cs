using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenBlogRepository : GenericRepository<GenBlog>, IGenBlogRepository
{
public GenBlogRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
