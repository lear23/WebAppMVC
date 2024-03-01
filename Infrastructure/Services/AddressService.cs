

using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class AddressService(AddressRepo repo)
{
    private readonly AddressRepo _repo = repo;

    public async Task<ResponseResult> GetOrCreateAddresAsync(string streetName, string postalCode, string city)
    {
        try
        {
            var result = await GetAddresAsync(streetName, postalCode, city);
            if(result.StatusCode == StatusCodes.NOTFOUND)
            {
                result = await GetAddresAsync(streetName,postalCode, city);
            }

           return result;

        }
        catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
    }


    public async Task<ResponseResult> CreateAddresAsync(string streetName, string postalCode, string city)
    {
        try
        {
            var exists = await _repo.ExistsAsync(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            if (exists == null)
            {
                var result = await _repo.CreateOneAsync(AddressFactory.Create(streetName, postalCode, city));
                if (result.StatusCode == StatusCodes.OK)
                {
                    return ResponseFactory.Ok(AddressFactory.Create((AddressEntity)result.ContentResult!));
                  
                }

                return result;
                
            }
            return exists;

        }
        catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
    }
    public async Task<ResponseResult> GetAddresAsync(string streetName, string postalCode, string city)
    {
        try
        {

            var result = await _repo.GetOneAsync(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            return result;

        }
        catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
    }


}
