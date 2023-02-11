using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Extensions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BabyMemory_V2.Model.Childern;
using BabyMemory_V2.Model.Children;
using BabyMemory_V2.Users.Dto;
using Microsoft.EntityFrameworkCore;

namespace BabyMemory_V2.Childrens
{
    public class ChildrenAppService : AsyncCrudAppService<Children, ChildrenDto, long, PagedUserResultRequestDto, CreateChildrenDto, ChildrenDto>
    {
        public ChildrenAppService(IRepository<Children, long> repository)
            : base(repository)
        {
        }

        public override Task<ChildrenDto> CreateAsync(CreateChildrenDto input)
        {
            return base.CreateAsync(input);
        }

        public async Task<ChildrenDto[]> GetAllCildenByUser(long? userId)
        { 
            //todo: if userId is null

            var result = await Repository
                .GetAll()
                .AsNoTracking()
                .Where(x => x.UserId == userId)
                .Select(c => new ChildrenDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    LastName = c.LastName,
                    BirthDate = c.BirthDate,
                    Picture = c.Picture,
                    Memories = c.Memories,
                    HealthProcedures = c.HealthProcedures
                })
                .ToArrayAsync();

            return result;
        }
    }
}
