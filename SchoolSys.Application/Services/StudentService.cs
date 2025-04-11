using System.Collections;
using AutoMapper;
using SchoolSys.Application.Dtos.StudentDto.Request;
using SchoolSys.Application.Dtos.StudentDto.Response;
using SchoolSys.Application.interfaces.Repositories;
using SchoolSys.Application.interfaces.Services;
using SchoolSys.Domain.Entities;
using SchoolSys.Domain.enums;

namespace SchoolSys.Application.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly StudentHistoryService _studentHistoryService;
    private readonly IMapper _mapper;

    public StudentService(IStudentRepository studentRepository, IMapper mapper, StudentHistoryService studentHistoryService)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
        _studentHistoryService = studentHistoryService;
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
    
    public async Task<ICollection<GetStudentResponse>> GetStudentsByYearAndFacultyAsync(int year, Guid facultyId)
    {
        var student = await _studentRepository.GetStudentsByFacultyAndByYearAsync(year, facultyId);
        return _mapper.Map<ICollection<GetStudentResponse>>(student);
    }

    public async Task<GetStudentResponse> GetStudentByGetStudentHistoryByIdAsyncIdAsync(Guid studentId)
    {
        var student = await _studentRepository.GetStudentHistoryByIdAsync(studentId);
        if(student == null)
            throw new Exception("Student not found");
        return _mapper.Map<GetStudentResponse>(student);
    }

    public async Task<ICollection<GetStudentResponse>> GetStudentsByGroupIdAsync(string groupName)
    {
        var student = await _studentRepository.GetStudentsByGroupNameAsync(groupName);
        if(student == null)
            throw new Exception("Students not found");
        return _mapper.Map<ICollection<GetStudentResponse>>(student);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var student = await _studentRepository.GetByIdAsync(id);
        if (student == null)
            return false;
        return await _studentRepository.DeleteAsync(student);
    }
}