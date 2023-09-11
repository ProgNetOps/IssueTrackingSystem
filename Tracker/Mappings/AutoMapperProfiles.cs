using AutoMapper;
using Tracker.Entity;
using Tracker.Models.DTOs;

namespace Tracker.Mappings
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<BTS,BTSDTO>().ReverseMap();
        }
    }
}
