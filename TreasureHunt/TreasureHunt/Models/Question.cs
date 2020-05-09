// <copyright file="Question.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-05-09</date>

namespace TreasureHunt.Models
{
	/// <summary>
	/// Defines the <see cref="Question" />.
	/// </summary>
	public class Question
	{
		/// <summary>
		/// Gets or sets the ID.
		/// </summary>
		public int? ID { get; set; }

		/// <summary>
		/// Gets or sets the Sequance.
		/// </summary>
		public int? Sequance { get; set; }

		/// <summary>
		/// Gets or sets the SkippedDurationSeconds.
		/// </summary>
		public int? SkippedDurationSeconds { get; set; }

		/// <summary>
		/// Gets or sets the Title.
		/// </summary>
		public string Title { get; set; }
	}
}
