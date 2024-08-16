using Application.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public interface IAuthenticationCommands
    {
        /// <summary>
        /// Verify user//
        /// </summary>
        /// <param name="email"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        Task Verify(string email, string code);

        /// <summary>
        /// Create code save code and send mail
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task ResetPassword(ResetPasswordRequest request);


        //tạo code => lưu csld => gửi mail
        Task RequestVerifyCode(string email);

        /// <summary>
        /// Create code save code and send mail
        /// </summary>
        /// <param name="email">User Id</param>
        /// <returns>Void</returns>
        Task RequestResetPasswordCode(string email);

        /// <summary>
        /// Register new user with Role User <see cref="UserRole"/>
        /// </summary>
        /// <param name="register"><see cref="RegisterRequest"/></param>
        /// <returns></returns>
        Task<Guid> Register(RegisterRequest register);

        Task<AuthResponse> Authenticate(AuthRequest request);
    }
}
