namespace Hackathon.Models;

public class UserPageAndCoursesAndLectures
{
    public UserLogin UserLogin { get; set; }
    public UserData? UserData { get; set; }
    public List<Course> allCourses { get; set; }
    public List<Lecture> allLectures { get; set; }
}