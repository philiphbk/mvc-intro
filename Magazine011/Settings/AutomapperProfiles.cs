using System;
using AutoMapper;
using Magazine011.Models;
using Magazine011.ViewModels;

namespace Magazine011.Settings
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<User, UserForListViewModel>();
            CreateMap<UserForDB, UserForListViewModel>()
                .ForMember(dest=>dest.Id,x=>x.MapFrom(x=>x.Id))
                .ForMember(dest=>dest.Name,x=>x.MapFrom(x=> $"{x.FirstName} {x.LastName}"));
            CreateMap<User, UserDetailViewModel>();
            CreateMap<User, EditProfileViewModel>(); // getting
            CreateMap<AddUserViewModel, User>(); // posting
            CreateMap<AddUserViewModel, UserForDB>()
                .ForMember(dest => dest.FirstName, 
                    x => x.MapFrom(x => x.Name)); // posting
            CreateMap<User, ProfilePixViewModel>(); // posting
        }
    }
}
