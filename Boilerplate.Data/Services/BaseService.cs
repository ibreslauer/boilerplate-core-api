using AutoMapper;
using Boilerplate.Data.Context;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace Boilerplate.Data.Services
{
    public abstract class BaseService
    {
        protected readonly IServiceProvider _serviceProvider;
        private readonly Lazy<IMemoryCache> _cache;
        private readonly Lazy<IMapper> _mapper;

        protected BoilerplateDataContext DataContext { get; private set; }
        protected IMemoryCache Cache => _cache.Value;
        protected IMapper Mapper => _mapper.Value;

        protected BaseService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            DataContext = serviceProvider.GetService(typeof(BoilerplateDataContext)) as BoilerplateDataContext;
            _cache = new Lazy<IMemoryCache>(() => (IMemoryCache)serviceProvider.GetService(typeof(IMemoryCache)));
            _mapper = new Lazy<IMapper>(() => (IMapper)serviceProvider.GetService(typeof(IMapper)));
        }
    }
}
