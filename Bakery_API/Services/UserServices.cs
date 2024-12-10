using Bakery_API.DTO;
using Bakery_API.Interfaces;
using Bakery_API.Models;
using System.Diagnostics.Eventing.Reader;

namespace Bakery_API.Services
{
    public class UserServices : IUser // Kế thừa từ interdace IUser
    {
        private readonly BakerySqlContext _bakerySqlContext;

        public UserServices(BakerySqlContext bakerySqlContext) {

            _bakerySqlContext = bakerySqlContext;
        }

        public ResponseServices<User> SignIn(UserRequest request) // Hiện thực 
        {
           var user = _bakerySqlContext.Users.SingleOrDefault
                (us => us.Gmail == request.Gmail && us.Password == request.Password);

            if (user != null)
            {
                return new ResponseServices<User>
                {
                    Data = user,
                    Success = true,
                    Message = "Sign In Success",

                };
                }

            else
            {
                return new ResponseServices<User>
                {
                    Success = false,
                    Message = "Sign In False",

                };

            }


            }

        public ResponseServices<User> SignUp(UserRequest request) // Hiện thực
        {
            throw new NotImplementedException();
        }
    }



        
    }

