namespace School.Api.Services;

public class InvalidStudentIdException : Exception
{
    public InvalidStudentIdException(string message) : base(message) { }
}
