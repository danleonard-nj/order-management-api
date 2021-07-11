using Common.Models.UserManagement.Abstractions;
using Services.DesertMusic.Api.Components.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.DesertMusic.Api.Components
{
		public interface IUserProvider
		{
				Task<IEnumerable<IUserModel>> GetUsers();
		}

		public class UserProvider : IUserProvider
		{
				public UserProvider(IUserComponent userComponent)
				{
						_userComponent = userComponent ?? throw new ArgumentNullException(nameof(userComponent));
				}

				public async Task<IEnumerable<IUserModel>> GetUsers()
				{
						var users = await _userComponent.GetUsers();

						return users;
				}


				private readonly IUserComponent _userComponent;
		}
}
