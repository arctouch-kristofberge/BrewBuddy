﻿using System;
using PropertyChanged;

namespace BrewBuddy.Model
{
	[ImplementPropertyChanged]
	public class Glass : IBaseModel
	{
		public string Id { get; set; }
		public string Name { get; set; }
	}
}

