using System;
using AutoMapper;
using Magazine011.Models;
using Magazine011.ViewModel;

namespace Magazine011.Settings
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<User, UserForListViewModel>();
            CreateMap<User, UserDetailViewModel>();
        }
    }
}
