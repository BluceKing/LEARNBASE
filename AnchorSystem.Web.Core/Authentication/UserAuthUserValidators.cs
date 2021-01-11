using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnchorSystem.Core.AnchorSystemAuthDb.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AnchorSystem.Web.Core.Authentication
{
    public class UserAuthUserValidators : UserValidator<AdminUser>
    {
        public override async Task<IdentityResult> ValidateAsync(UserManager<AdminUser> manager, AdminUser user)
        {
            if (manager == null)
                throw new ArgumentNullException(nameof(manager));
            if ((object)user == null)
                throw new ArgumentNullException(nameof(user));
            var errors = new List<IdentityError>();
            await this.ValidateUserName(manager, user, (ICollection<IdentityError>)errors);
            if (manager.Options.User.RequireUniqueEmail)
                await this.ValidateEmail(manager, user, errors);
            return errors.Count > 0 ? IdentityResult.Failed(errors.ToArray()) : IdentityResult.Success;
        }

        private async Task ValidateUserName(
            UserManager<AdminUser> manager,
            AdminUser user,
            ICollection<IdentityError> errors)
        {
            var userName = await manager.GetUserNameAsync(user);
            if (string.IsNullOrWhiteSpace(userName))
                errors.Add(this.Describer.InvalidUserName(userName));
            else if (!string.IsNullOrEmpty(manager.Options.User.AllowedUserNameCharacters)
                     && userName.Any<char>((Func<char, bool>)(c => !manager.Options.User.AllowedUserNameCharacters.Contains<char>(c))))
            {
                errors.Add(this.Describer.InvalidUserName(userName));
            }
            else
            {
                var byNameAsync = await manager.Users.FirstOrDefaultAsync(m => m.UserName == user.UserName);
                var flag = (object)byNameAsync != null;
                if (flag)
                {
                    var a = await manager.GetUserIdAsync(byNameAsync);
                    flag = !string.Equals(a, await manager.GetUserIdAsync(user));
                    a = (string)null;
                }
                if (!flag)
                    return;
                errors.Add(this.Describer.DuplicateUserName(userName));
            }
        }

        private async Task ValidateEmail(
            UserManager<AdminUser> manager,
            AdminUser user,
            ICollection<IdentityError> errors)
        {
            var email = await manager.GetEmailAsync(user);
            if (string.IsNullOrWhiteSpace(email))
                errors.Add(this.Describer.InvalidEmail(email));
            else if (!new EmailAddressAttribute().IsValid((object)email))
            {
                errors.Add(this.Describer.InvalidEmail(email));
            }
            else
            {
                var byEmailAsync = await manager.FindByEmailAsync(email);
                var flag = (object)byEmailAsync != null;
                if (flag)
                {
                    var a = await manager.GetUserIdAsync(byEmailAsync);
                    flag = !string.Equals(a, await manager.GetUserIdAsync(user));
                    a = (string)null;
                }
                if (!flag)
                    return;
                errors.Add(this.Describer.DuplicateEmail(email));
            }
        }
    }
}

