using System;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.MiniBlog.Blog.Dtos;

namespace Abp.MiniBlog.Blog
{
    public interface IBlogAppService
    {
        Task<ListResultDto<BlogDto>> GetListAsync(GetBlogListInput input);
        Task<BlogDetailOutput> GetDetailAsync(EntityDto<Guid> input);
        Task CreateAsync(CreateBlogInput input);
        Task<BlogDto> Update(BlogDto input);
    }
}