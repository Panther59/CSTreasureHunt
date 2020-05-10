// <copyright file="Result.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-05-10</date>

namespace TreasureHunt.Models
{
	/// <summary>
	/// Defines the <see cref="Result" />.
	/// </summary>
	public class Result
	{
		/// <summary>
		/// Gets or sets the Answered.
		/// </summary>
		public int Answered { get; set; }

		/// <summary>
		/// Gets or sets the Rank.
		/// </summary>
		public int Rank { get; set; }

		/// <summary>
		/// Gets or sets the Total.
		/// </summary>
		public int Total { get; set; }

		/// <summary>
		/// Gets or sets the User.
		/// </summary>
		public User User { get; set; }
	}
}
