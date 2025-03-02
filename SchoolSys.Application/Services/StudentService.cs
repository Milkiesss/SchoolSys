using AutoMapper;
using SchoolSys.Application.Dtos.StudentDto.Request;
using SchoolSys.Application.Dtos.StudentDto.Responce;
using SchoolSys.Application.interfaces.Repositories;
using SchoolSys.Application.interfaces.Services;
using SchoolSys.Domain.Entities;
using SchoolSys.Domain.enums;

namespace SchoolSys.Application.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly IStudentHistoryService _studentHistoryService;
    private readonly IMapper _mapper;

    public StudentService(IStudentRepository studentRepository, IMapper mapper, IStudentHistoryService studentHistoryService)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
        _studentHistoryService = studentHistoryService;
    }

    public async Task<GetStudentResponse> GetByIdAsync(Guid id)
    {
        var student = await _studentRepository.GetByIdAsync(id);
        return _mapper.Map<GetStudentResponse>(student);
    }

    public  async Task<GetStudentWithHistoryResponse> GetByIdWithHistoryAsync(Guid id)
    {
        var student = await _studentRepository.GetStudentHistoryByIdAsync(id);
        return _mapper.Map<GetStudentWithHistoryResponse>(student);
    }

    public async  Task<IEnumerable<GetStudentResponse>> GetAllAsync()
    {
        var students = await _studentRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<GetStudentResponse>>(students);
    }

    public async Task<Guid> AddAsync(CreateStudentRequest createStudentRequest)
    {
        var student = _mapper.Map<Student>(createStudentRequest); 
        await _studentRepository.AddAsync(student);
        await _studentHistoryService.RecordCreationAsync(student.Id);
        return student.Id;
    }

    public async  Task<bool> UpdateAsync(UpdateStudentRequest updateStudentRequest)
    {
        var student = await _studentRepository.GetByIdAsync(updateStudentRequest.Id);
        
        var OldStatus = student.Status;
        student = _mapper.Map(updateStudentRequest, student);
        
        var result= await _studentRepository.UpdateAsync(student);
        
        if (OldStatus != student.Status)
            await _studentHistoryService.RecordStatusChangeAsync(student.Id, OldStatus, student.Status);
        
        
        return result;
    }

    public Task<ICollection<GetStudentResponse>> GetStudentsByYearAsync(int year)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<GetStudentResponse>> GetStudentByIdAsync(Guid studentId)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<GetStudentResponse>> GetStudentsByGroupIdAsync(Guid groupId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var student = await _studentRepository.GetByIdAsync(id);
        if (student == null)
            return false;
        return await _studentRepository.DeleteAsync(student);
    }
}