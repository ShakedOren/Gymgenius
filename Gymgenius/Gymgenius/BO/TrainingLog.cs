using System;
using System.Collections.Generic;

namespace GymGenius.BO
{
	public class TrainingLog
	{
		public int Id { get; set; }
		public DateTime DateCreated { get; set; }
		public string ProgramName { get; set; }
		public string UserName { get; set; }
		public List<ExerciseLog> ExerciseLogs { get; set; } 

		public TrainingLog()
		{
			ExerciseLogs = new List<ExerciseLog>();
		}
	}
}