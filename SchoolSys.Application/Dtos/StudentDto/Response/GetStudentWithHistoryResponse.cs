namespace SchoolSys.Application.Dtos.StudentDto.Responce;

public class GetStudentWithHistoryResponse : BaseStudentDto
{
    public Guid Id { get; set; }
    public List<BaseStudentHistoryDto> History { get; set; }
}