using AutoMapper;
using SchoolSys.Application.Dtos.TeacherDto.Request;
using SchoolSys.Application.Dtos.TeacherDto.Response;
using SchoolSys.Application.interfaces.Repositories;
using SchoolSys.Application.interfaces.Services;
using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.Services;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _teacherRepository;
    private readonly IMapper _mapper;
    public TeacherService(ITeacherRepository teacherRepository, IMapper mapper)
    {
        _teacherRepository = teacherRepository;
        _mapper = mapper;
    }

    public async Task<Guid> AddAsync(CreateTeacherRequest createTeacherRequest)
    {
        var teacher = _mapper.Map<Teacher>(createTeacherRequest);
        await _teacherRepository.AddAsync(teacher);
        return teacher.Id;
    }

    public async Task<bool> UpdateAsync(UpdateTeacherRequest updateTeacherRequest)
    {
        var teacher = await _teacherRepository.GetByIdAsync(updateTeacherRequest.Id);
        if (teacher == null)
            return false;

        _mapper.Map(updateTeacherRequest, teacher);
        return await _teacherRepository.UpdateAsync(teacher);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var teacher = await _teacherRepository.GetByIdAsync(id);
        if (teacher == null)
            return false;

        return await _teacherRepository.DeleteAsync(teacher);
    }

    public async Task<GetTeacherResponse> GetByIdAsync(Guid id)
    {
        var teacher = await _teacherRepository.GetByIdAsync(id);
        return _mapper.Map<GetTeacherResponse>(teacher);
    }

    public async Task<ICollection<GetTeacherResponse>> GetAllAsync()
    {
        var teachers = await _teacherRepository.GetAllAsync();
        return _mapper.Map<ICollection<GetTeacherResponse>>(teachers);
    }

    public async Task<ICollection<GetTeacherResponse>> GetTeachersByFacultyIdAsync(Guid facultyId)
    {
        var teachers = await _teacherRepository.GetTeachersByFacultyIdAsync(facultyId);
        return _mapper.Map<ICollection<GetTeacherResponse>>(teachers);
    }
    

    public async Task<bool> AddTeacherSubjectAsync(Guid teacherId, Guid subjectId)
    {
        return await _teacherRepository.AddTeacherSubjectAsync(teacherId, subjectId);
    }

    public async Task<bool> DeleteTeacherSubjectAsync(Guid teacherId, Guid subjectId)
    {
        return await _teacherRepository.DeleteTeacherSubjectAsync(teacherId, subjectId);
    }
}