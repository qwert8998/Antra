﻿using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterface;
using ApplicationCore.ServiceInterface;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel registerRequest)
        {
            var dbUser = await _userRepository.GetUserByEmail(registerRequest.Email);

            // if   user exists
            if (dbUser != null)
            {
                throw new Exception("User Already exists, please try to login");
            }

            // generate a unique salt
            var salt = CreateSalt();

            // hash the password with salt generated in the above step
            var hashedPassword = CreateHashedPassword(registerRequest.Password, salt);

            // then create User Object and save it to database with UserRepository 
            var user = new User()
            {
                FirstName = registerRequest.FirstName,
                LastName = registerRequest.LastName,
                Email = registerRequest.Email,
                Salt = salt,
                HashedPassword = hashedPassword,
                DateOfBirth = registerRequest.DateTime,
            };

            // call repository to save User info that included salt and hashed password
            var createdUser = await _userRepository.AddAsync(user);

            // map user object to UserRegisterResponseModel object
            var createdUserResponse = new UserRegisterResponseModel
            {
                Id = createdUser.Id,
                Email = createdUser.Email,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName
            };

            return createdUserResponse;
        }

        public async Task<UserLoginResponseModel> ValidateUser(string email, string password)
        {
            var dbuser = await _userRepository.GetUserByEmail(email);
            if(dbuser == null)
                return null;

            var hashedPassword = CreateHashedPassword(password, dbuser.Salt);
            if(hashedPassword == dbuser.HashedPassword)
            {
                var response = new UserLoginResponseModel() {
                    Id = dbuser.Id,
                    Email = dbuser.Email,
                    FirstName = dbuser.FirstName,
                    LastName = dbuser.LastName
                };
                return response;
            }
            return null;
        }

        private string CreateSalt()
        {
            byte[] randomBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);
        }

        private string CreateHashedPassword(string password, string salt)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Convert.FromBase64String(salt),
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hashed;
        }
    }
}