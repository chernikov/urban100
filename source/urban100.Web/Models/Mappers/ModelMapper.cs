using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace urban100.Web.Models.Mappers
{
    public class ModelMapper
    {
        static ModelMapper()
        {
            MapperCollection.LoginUserMapper.Init();
            MapperCollection.UserMapper.Init();
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }
    }
}
