using AutoMapper;
using SchoolSys.Application.Dtos.FacultyDto.Request;
using SchoolSys.Application.Dtos.FacultyDto.Response;
using SchoolSys.Application.Dtos.TeacherDto.Response;
using SchoolSys.Application.interfaces.Repositories;
using SchoolSys.Application.interfaces.Services;
using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.Services;

public class FacultyService : IFacultyService
{
    private readonly IFacultyRepository _facultyRepository;
    private readonly IMapper _mapper;

    public FacultyService(IFacultyRepository facultyRepository, IMapper mapper)
    {
        _facultyRepository = facultyRepository;
        _mapper = mapper;
    }

    public async Task<Guid> AddAsync(CreateFacultyRequest createFacultyRequest)
    {
        var faculty = _mapper.Map<Faculty>(createFacultyRequest);
        await _facultyRepository.AddAsync(faculty);
        return faculty.Id;
    }

    public async Task<bool> UpdateAsync(UpdateFacultyRequest updateFacultyRequest)
    {
        var faculty = await _facultyRepository.GetByIdAsync(updateFacultyRequest.Id);
        if (faculty == null)
            return false;

        _mapper.Map(updateFacultyRequest, faculty);
        return await _facultyRepository.UpdateAsync(faculty);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var faculty = await _facultyRepository.GetByIdAsync(id);
        if (faculty == null)
            return false;

        return await _facultyRepository.DeleteAsync(faculty);
    }

    public async Task<GetFacultyResponse> GetByIdAsync(Guid id)
    {
        var faculty = await _facultyRepository.GetByIdAsync(id);
        return _mapper.Map<GetFacultyResponse>(faculty);
    }

    public async Task<IEnumerable<GetFacultyResponse>> GetAllAsync()
    {
        var faculties = await _facultyRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<GetFacultyResponse>>(faculties);
    }

    public async Task<ICollection<GetTeacherResponse>> GetTeachersByFacultyIdAsync(Guid facultyId)
    {
        var result = await _facultyRepository.GetTeachersByFacultyIdAsync(facultyId); 
        return _mapper.Map<ICollection<GetTeacherResponse>>(result);
    }
}