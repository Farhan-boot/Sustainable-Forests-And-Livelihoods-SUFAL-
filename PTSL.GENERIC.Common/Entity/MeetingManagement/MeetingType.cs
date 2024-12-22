﻿using PTSL.GENERIC.Common.Entity.CommonEntity;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Entity.MeetingManagement
{
	public class MeetingType : BaseEntity
	{
		public string? Name { get; set; }
		public string? NameBn { get; set; }

		public List<Meeting>? Meetings { get; set; }
	}
}