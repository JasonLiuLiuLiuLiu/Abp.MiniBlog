using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.MiniBlog.Blog.Dtos;

namespace Abp.MiniBlog.Blog
{
    public interface IBlogAppService
    {
        Task<ListResultDto<BlogListDto>> GetListAsync(GetBlogListInput input);
    }
}