﻿
using Infrastructure.Entities;
using Infrastructure.Helpers;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class UserFactory
{
    public static UserEntity create()
    {
        try
        {
            var date = DateTime.Now;

            return new UserEntity() {
                Id = Guid.NewGuid().ToString(),
                Created =date,
                Updated =date
            };
            
        }
        catch { }
        return null!;
    }


    public static UserEntity create(SignUpModel model)
    {
        try
        {
            var date = DateTime.Now;

            var (password, securityKey) = PasswordHasher.GenerateSecurePassword(model.Password);    


            return new UserEntity()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
                SecurityKey = securityKey,
                Created = date,
                Updated = date

            };

        }
        catch { }
        return null!;
    }

}
