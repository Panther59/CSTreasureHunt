// <copyright file="Quiz.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-05-09</date>

namespace TreasureHunt.Models
{
	using System;

	/// <summary>
	/// Defines the <see cref="Quiz" />.
	/// </summary>
	public class Quiz
	{
		/// <summary>
		/// Gets or sets the Active.
		/// </summary>
		public bool? Active { get; set; }

		/// <summary>
		/// Gets or sets the EndTime.
		/// </summary>
		public DateTime? EndTime { get; set; }

		/// <summary>
		/// Gets or sets the ID.
		/// </summary>
		public int? ID { get; set; }

		/// <summary>
		/// Gets or sets the StartTime.
		/// </summary>
		public DateTime? StartTime { get; set; }

		/// <summary>
		/// Gets or sets the Title.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets the Type.
		/// </summary>
		public int? Type { get; set; }
	}
}
