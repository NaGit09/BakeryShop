using System.Net.Mail;
using System.Net;

namespace Bakery_API.Services
{
    public class EmailServices
    {
        public void SendOTPEmail(string recipientEmail, int otp)
        {
            // Cấu hình SMTP
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587, // Sử dụng TLS
                Credentials = new NetworkCredential("22130320@st.hcmuaf.edu.vn", "cftg ruws ntgw yjrz"),
                EnableSsl = true,
            };

            // Tạo email
            var mailMessage = new MailMessage
            {
                From = new MailAddress("22130320@st.hcmuaf.edu.vn"),
                Subject = "Mã OTP của bạn",
                Body = $"Mã OTP của bạn là: {otp}",
                IsBodyHtml = false, // Đặt `true` nếu muốn gửi HTML
            };

            // Thêm người nhận
            mailMessage.To.Add(recipientEmail);

            try
            {
                // Gửi email
                smtpClient.Send(mailMessage);
                Console.WriteLine("Email đã được gửi thành công.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gửi email thất bại: {ex.Message}");
            }
        }
    }
}


//cftg ruws ntgw yjrz
