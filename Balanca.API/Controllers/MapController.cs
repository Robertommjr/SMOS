using AutoMapper;
using System.Web.Http;

namespace Balanca.API.Controllers
{
    public class MapController : ApiController
    {
        public MapperConfiguration AutomMapperConfig { get; set; }
        public IMapper Mapper { get; set; }
    }
}