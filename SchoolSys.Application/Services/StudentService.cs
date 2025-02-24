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

    public async Task<GetStudentResponce> GetByIdAsync(Guid id)
    {
        var student = await _studentRepository.GetByIdAsync(id);
        return _mapper.Map<GetStudentResponce>(student);
    }

    public  async Task<GetStudentWithHistoryResponce> GetByIdWithHistoryAsync(Guid id)
    {
        var student = await _studentRepository.GetStudentHistoryByIdAsync(id);
        return _mapper.Map<GetStudentWithHistoryResponce>(student);
    }

    public async  Task<IEnumerable<GetStudentResponce>> GetAllAsync()
    {
        var students = await _studentRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<GetStudentResponce>>(students);
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
        student = _mapper.Map<Student>(updateStudentRequest);
        
        var result= await _studentRepository.UpdateAsync(student);
        
        if (OldStatus != student.Status)
            await _studentHistoryService.RecordStatusChangeAsync(student.Id, OldStatus, student.Status);
        
        
        return result;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var student = await _studentRepository.GetByIdAsync(id);
        return await _studentRepository.DeleteAsync(student);
    }
}