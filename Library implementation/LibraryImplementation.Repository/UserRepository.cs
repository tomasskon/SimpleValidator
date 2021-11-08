using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LibraryImplementation.Domain.Models;
using LibraryImplementation.Repository.Entities;
using LibraryImplementation.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryImplementation.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbSet<UserEntity> _userSet;
        private LibraryImplementationDbContext _context;
        private readonly IMapper _mapper;
        
        public UserRepository(LibraryImplementationDbContext context, IMapper mapper)
        {
            _userSet = context.Users;
            _context = context;
            _mapper = mapper;
        }

        public IList<User> GetAll()
        {
            var userEntityList = _userSet.ToList();
            
            return _mapper.Map<List<User>>(userEntityList);
        }
        
        public User Get(Guid userId)
        {
            var userEntity =  _userSet.SingleOrDefault(x => x.Id == userId);

            return userEntity == null ? null : _mapper.Map<User>(userEntity);
        }

        public Guid Create(User user)
        {
            var userEntity = _mapper.Map<UserEntity>(user);
            
            _userSet.Add(userEntity);
            _context.SaveChanges();
            _context.Entry(userEntity).State = EntityState.Detached;

            return userEntity.Id;
        }

        public void Update(User user)
        {
            var userEntity = _mapper.Map<UserEntity>(user);
            
            _userSet.Update(userEntity);
            _context.SaveChanges();
            
            _context.Entry(userEntity).State = EntityState.Modified;
        }

        public void Delete(Guid userId)
        {
            var userEntity = _userSet.Single(x => x.Id == userId);
            
            _userSet.Remove(userEntity);
            _context.SaveChanges();
        }

        public bool CheckIfUserExists(Guid userId)
        {
            return _userSet.Any(x => x.Id == userId);
        }
    }
}