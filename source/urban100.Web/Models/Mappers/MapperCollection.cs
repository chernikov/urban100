using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using urban100.Model;
using urban100.Web.Models.ViewModels;
using urban100.Web.Models.ViewModels.User;

namespace urban100.Web.Models.Mappers
{
    public static class MapperCollection
    {
        public static class LoginUserMapper
        {
            public static void Init()
            {
                Mapper.CreateMap<User, LoginView>();
                Mapper.CreateMap<LoginView, User>();
            }
        }

        public static class UserMapper
        {
            public static void Init()
            {
                Mapper.CreateMap<User, RegisterUserView>();
                Mapper.CreateMap<RegisterUserView, User>();

                Mapper.CreateMap<User, UserView>();
                Mapper.CreateMap<UserView, User>();
            }
        }

        
        public static class OwnerMapper
        {
        	public static void Init()
        	{
        		Mapper.CreateMap<Owner, OwnerView>();
        		Mapper.CreateMap<OwnerView, Owner>();
        	}
        }
    }
}