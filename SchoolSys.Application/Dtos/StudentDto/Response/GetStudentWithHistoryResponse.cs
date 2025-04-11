namespace SchoolSys.Application.Dtos.StudentDto.Response;

public class GetStudentWithHistoryResponse : BaseStudentDto
{
    public Guid Id { get; set; }
    public List<BaseStudentHistoryDto> History { get; set; }
}