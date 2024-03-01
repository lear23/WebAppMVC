

using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Helpers;
using Infrastructure.Models;
using Infrastructure.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services;

public class UserService(UserRepo repo, AddressService addressService)
{

    private readonly UserRepo _repo = repo; 
    private readonly AddressService _addressService = addressService;


    public async Task<ResponseResult> CreateUserAsync(SignUpModel model)
    {
        try
        {

            var exists = await _repo.ExistsAsync(x => x.Email == model.Email);
            if(exists.StatusCode == StatusCodes.EXISTS)
            {
                return exists;
            }           
            
            var result = await _repo.CreateOneAsync(UserFactory.create(model));

            if (result.StatusCode != StatusCodes.OK) 
                return result;

            return ResponseFactory.Ok("User Was Created Successfully");            
                

        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }

    public async Task<ResponseResult> SignInUserAsync(SignInModel model)
    {
        try
        {

            var result = await _repo.GetOneAsync(x => x.Email == model.Email);
            if (result.StatusCode == StatusCodes.OK && result.ContentResult != null!)
            {
                
                var userEntity = (UserEntity)result.ContentResult;

                if (PasswordHasher.ValidatePassword(model.Password, userEntity.Password, userEntity.SecurityKey))
                    return ResponseFactory.Ok();


            }

            return ResponseFactory.Error("Incorret Email or Password");


        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }




}
