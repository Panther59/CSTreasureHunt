// <copyright file="LoginAuthorizeAttribute.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-05-10</date>

namespace TreasureHunt.Filters
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.Filters;
	using TreasureHunt.Common;

	/// <summary>
	/// Defines the <see cref="LoginAuthorizeAttribute" />.
	/// </summary>
	public class LoginAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
	{
		/// <inheritdoc />
		public void OnAuthorization(AuthorizationFilterContext context)
		{
			var session = context.HttpContext.RequestServices.GetService(typeof(ISession)) as ISession;

			if (session == null || session.UserID.HasValue == false)
			{
				context.Result = new UnauthorizedResult();
			}
		}
	}
}
