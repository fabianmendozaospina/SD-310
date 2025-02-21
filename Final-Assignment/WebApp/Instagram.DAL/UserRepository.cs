﻿using Instagram.Models;

namespace Instagram.DAL
{
    public class UserRepository
    {
        private readonly InstagramContext _context;

        public UserRepository(InstagramContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
    }
}
