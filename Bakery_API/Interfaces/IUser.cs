using Bakery_API.DTO;
using Bakery_API.Models;
using Bakery_API.Services;

namespace Bakery_API.Interfaces
{
    public interface IUser
    {
        ResponseServices<User> SignIn (UserRequest request);
        ResponseServices<User> SignUp(UserRequest request);


        // Khai báo những chức năng cơ bản của User

    }
}
