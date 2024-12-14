using Bakery_API.DTO;
using Bakery_API.Interfaces;
using Bakery_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Diagnostics.Eventing.Reader;
using BCrypt.Net;

namespace Bakery_API.Services
{
    public class UserServices : IUser // Kế thừa từ interdace IUser
    {

        private readonly BakeryShopContext _bakerySqlContext;
        private readonly ISession _session;
        private readonly TokenServices _tokenServices;


        public UserServices(BakeryShopContext bakerySqlContext, IHttpContextAccessor httpContextAccessor, TokenServices tokenServices)
        {

            _bakerySqlContext = bakerySqlContext;
            _session = httpContextAccessor.HttpContext.Session;
            _tokenServices = tokenServices;
        }

        public ResponseServices<String> SignIn(UserSignInRequest request) // Hiện thực 
        {
            var user = _bakerySqlContext.Users.SingleOrDefault
                 (us => us.Gmail == request.Gmail);
            if (user != null)
            {
                if (VerifyPassword(request.Password, user.Password))
                {
                    return new ResponseServices<String>
                    {
                        Data = _tokenServices.GenerateToken(user),
                        Success = true,
                        Message = "Đăng nhập thành công",

                    };
                }
                else
                {
                    return new ResponseServices<String>
                    {
                        Data = "",
                        Success = false,
                        Message = "Sai mật khẩu",

                    };

                }

            }

            else
            {
                return new ResponseServices<String>
                {
                    Data = "",
                    Success = false,
                    Message = "Sai mật khẩu và email",

                };

            }


        }



        public ResponseServices<User> SignUp(UserSignUpRequest request)
        {
            var userInDb = _bakerySqlContext.Users.SingleOrDefault(uib => uib.Gmail == request.Email);
            if (userInDb == null)
            {
                _session.SetString("OTP", GetNumberOTP(request.Email));
                _session.SetString("Email", request.Email);
                _session.SetString("Password", HashPassword(request.Password));
                _session.SetString("Gender", request.Gender.ToString());
                _session.SetString("Name", request.Name);


                return new ResponseServices<User>
                {
                    Success = true,
                    Message = "Chờ xác nhận OTP",
                };
            }


            else
            {
                return new ResponseServices<User>
                {
                    Success = false,
                    Message = "Email đã tồn tại trong hệ thống"

                };
            }


        }


        // Mã hóa BCrypt
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool VerifyPassword(string password, string hashPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashPassword);
        }


        // Lấy mã xác thực và gửi mail
        public String GetNumberOTP(String email)
        {
            Random random = new Random();
            int NumberOTP = random.Next(10000, 99999);

            // Gửi OTP qua email
            EmailServices emailServices = new EmailServices();
            emailServices.SendOTPEmail(email, NumberOTP);

            return NumberOTP.ToString();
        }


        // Xác thực OTP, đúng thì lưu thông tin user xuống db
        public ResponseServices<User> CheckNumberOTP(CheckOTPRequest checkOTPRequest)
        {

            if (checkOTPRequest.OTP == int.Parse(_session.GetString("OTP")))
            {
                try
                {
                    _bakerySqlContext.Add(new User
                    {
                        Gmail = _session.GetString("Email"),
                        Password = _session.GetString("Password"),
                        Gender = byte.Parse(_session.GetString("Gender")),
                        Name = _session.GetString("Name"),
                        CreatedAt = DateOnly.FromDateTime(DateTime.Now)
                    });

                    _bakerySqlContext.SaveChanges();

                    return new ResponseServices<User>
                    {

                        Success = true,
                        Message = "Đăng kí thành công"

                    };
                }
                catch
                {

                    return new ResponseServices<User>
                    {

                        Success = false,
                        Message = "Đăng kí thất bại"


                    };

                }


            }
            else
            {
                return new ResponseServices<User>
                {
                    Success = false,
                    Message = "Sai mã OTP"


                };

            }
        }
    }
}

