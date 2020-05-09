// <copyright file="User.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-05-09</date>

namespace TreasureHunt.Models
{
	/// <summary>
	/// Defines the <see cref="User" />.
	/// </summary>
	public class User
	{
		/// <summary>
		/// Gets or sets the ID.
		/// </summary>
		public int? ID { get; set; }

		/// <summary>
		/// Gets or sets the LoginName.
		/// </summary>
		public string LoginName { get; set; }

		/// <summary>
		/// Gets or sets the Name.
		/// </summary>
		public string Name { get; set; }
	}
}
