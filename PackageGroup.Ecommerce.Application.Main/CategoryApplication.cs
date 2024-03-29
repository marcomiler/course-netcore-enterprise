using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using PackageGroup.Ecommerce.Application.DTO;
using PackageGroup.Ecommerce.Application.Interface;
using PackageGroup.Ecommerce.Domain.Interface;
using PackageGroup.Ecommerce.Transversal.Common;
using System.Text;
using System.Text.Json;

namespace PackageGroup.Ecommerce.Application.Main
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly ICategoryDomain _categoryDomain;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _distributedCache;

        public CategoryApplication(
            ICategoryDomain categoryDomain,
            IMapper mapper,
            IDistributedCache distributedCache
        )
        {
            _categoryDomain = categoryDomain;
            _mapper = mapper;
            _distributedCache = distributedCache;
        }

        public async Task<Response<IEnumerable<CategoryDTO>>> GetAll()
        {
            var response = new Response<IEnumerable<CategoryDTO>>();
            var cacheKey = "categoryList";

            try
            {
                var redisCategory = await _distributedCache.GetAsync(cacheKey);
                
                if ( redisCategory is not null )
                {
                    response.Data = JsonSerializer.Deserialize<IEnumerable<CategoryDTO>>(redisCategory);
                } else
                {
                    var categories = await _categoryDomain.GetAll();
                    response.Data = _mapper.Map<IEnumerable<CategoryDTO>>(categories);

                    if ( response.Data is not null )
                    {
                        var serializerCategory = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(response.Data));
                        var options = new DistributedCacheEntryOptions()
                            .SetAbsoluteExpiration(DateTime.Now.AddHours(8))
                            //si nadie consulta el cache, caduca en 60 min
                            .SetSlidingExpiration(TimeSpan.FromMinutes(60));

                        await _distributedCache.SetAsync(cacheKey, serializerCategory, options);
                    }
                }                
                
                if ( response.Data is not null )
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
