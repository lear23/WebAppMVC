using WebApp.Models;

namespace WebApp.ViewModels;

public class AccountDetailsViewModel
{
    public string Title { get; set; } = "Account Details";

    public AccountBasicInfoModel BasicInfoModel { get; set; } = new AccountBasicInfoModel();
    public AccountDetailsAddressModel AddressModel { get; set; } = new AccountDetailsAddressModel();

}
