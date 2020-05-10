// <copyright file="ISession.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-02-28</date>

namespace TreasureHunt.Common
{
	/// <summary>
	/// Defines the <see cref="ISession" />
	/// </summary>
	public interface ISession
	{
		/// <summary>
		/// Gets the UserID
		/// </summary>
		int? UserID { get; }
	}
}
