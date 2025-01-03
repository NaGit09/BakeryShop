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

        ResponseServices<String> CheckMail(ForgotPasswordValidation email);

        ResponseServices<String> ValidToken(String token);

        ResponseServices<String> ResetPassword(ResetPassword resetPassword);


        // Khai báo những chức năng cơ bản của User

    }
}
