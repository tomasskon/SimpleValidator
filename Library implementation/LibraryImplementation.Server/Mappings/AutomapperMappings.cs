using System;
using AutoMapper;
using LibraryImplementation.Contracts.User;
using LibraryImplementation.Domain.Models;
using LibraryImplementation.Repository.Entities;

namespace LibraryImplementation.Server.Mappings
{
    public class AutomapperMappings : Profile
    {
        public AutomapperMappings()
        {
            MapDomainModelsAndEntities();
            MapDataContractsAndDomainModels();
        }

        private void MapDomainModelsAndEntities()
        {
            CreateMap<User, UserEntity>().ReverseMap();
        }

        private void MapDataContractsAndDomainModels()
        {
            CreateMap<UserContract, User>().ReverseMap();
            CreateMap<CreateUserContract, User>().ReverseMap();
        }
    }
}