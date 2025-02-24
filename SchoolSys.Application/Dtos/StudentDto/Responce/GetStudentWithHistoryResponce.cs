namespace SchoolSys.Application.Dtos.StudentDto.Responce;

public class GetStudentWithHistoryResponce : BaseStudentDto
{
    public Guid Id { get; set; }
    public List<BaseStudentHistoryDto> History { get; set; }
}