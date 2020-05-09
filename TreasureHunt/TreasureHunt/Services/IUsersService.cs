// <copyright file="IUsersService.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-05-09</date>

namespace TreasureHunt.Services
{
	using System.Threading.Tasks;
	using TreasureHunt.Models;

	/// <summary>
	/// Defines the <see cref="IUsersService" />.
	/// </summary>
	public interface IUsersService
	{
		/// <summary>
		/// The CreateUser.
		/// </summary>
		/// <param name="user">The user<see cref="User"/>.</param>
		/// <returns>The <see cref="Task{User}"/>.</returns>
		Task<User> CreateUser(User user);
	}
}
