// <copyright file="Answer.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-05-09</date>

namespace TreasureHunt.Models
{
	/// <summary>
	/// Defines the <see cref="Answer" />.
	/// </summary>
	public class Answer
	{
		/// <summary>
		/// Gets or sets the Question.
		/// </summary>
		public Question Question { get; set; }

		/// <summary>
		/// Gets or sets the Skipped.
		/// </summary>
		public bool? Skipped { get; set; }

		/// <summary>
		/// Gets or sets the Title.
		/// </summary>
		public string Title { get; set; }
	}
}
