using Bakery_API.DTO;
using Bakery_API.Models;
using Bakery_API.Services;

namespace Bakery_API.Interfaces
{
    public interface IUser
    {
        ResponseServices<String> SignIn(UserSignInRequest request);
        ResponseServices<User> SignUp(UserSignUpRequest request);

        ResponseServices<User> CheckNumberOTP(CheckOTPRequest checkOTPRequest);


        // Khai báo những chức năng cơ bản của User

    }
}
