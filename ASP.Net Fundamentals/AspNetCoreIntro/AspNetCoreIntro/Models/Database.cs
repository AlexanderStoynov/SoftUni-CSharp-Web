namespace AspNetCoreIntro.Models
{
	static class Database
	{
		private static List<Student> students = new List<Student>
		{
			new Student
			{
				Id = 1,
				Name = "John",
				Email = "john@abv.bg"
			},

			new Student
			{
				Id = 2,
				Name = "Jane",
				Email = "jane@abv.bg"
			}
		};

		public static Student GetStudent(int id)
		{
			return students.FirstOrDefault(s => s.Id == id);
		}

		public static bool UpdateStudent(Student student)
		{
			var existingStudent = students.FirstOrDefault(s => s.Id == student.Id);
			bool result = false;

            if (existingStudent !=null)
            {
				existingStudent.Name = student.Name;
				existingStudent.Email = student.Email;

				result = true;
            }

			return result;
        }
	}
}
