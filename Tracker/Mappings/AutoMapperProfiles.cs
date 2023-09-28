using AutoMapper;
using Tracker.Entity;
using Tracker.Models.DTOs;

namespace Tracker.Mappings
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<State, StateDTO>().ReverseMap();
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<BTS, BTSDTO>().ReverseMap();
            CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<Circuit, CircuitDTO>().ReverseMap();
            CreateMap<MPLSPoP, MPLSPoPDTO>().ReverseMap();
            CreateMap<IPPoP, IPPoPDTO>().ReverseMap();
            CreateMap<NetworkSwitch, NetworkSwitchDTO>().ReverseMap();
            CreateMap<BTS, BTSCreateDTO>().ReverseMap();
        }
    }
}
