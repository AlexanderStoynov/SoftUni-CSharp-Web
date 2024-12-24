using AspNetCoreIntro.Models;

namespace AspNetCoreIntro.Contracts
{
	public interface IStudentService
	{
		Student GetStudent(int id);

		bool UpdateStudent(Student student);
	}
}
