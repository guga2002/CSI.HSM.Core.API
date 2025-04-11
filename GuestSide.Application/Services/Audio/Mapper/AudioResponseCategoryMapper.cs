using AutoMapper;
using Core.Application.DTOs.Request.Audio;
using Core.Application.DTOs.Response.Audio;
using Domain.Core.Entities.Audio;

namespace Core.Application.Services.Audio.Mapper;

public class AudioResponseCategoryMapper : Profile
{
    public AudioResponseCategoryMapper()
    {
        CreateMap<AudioResponseCategoryRequestDto, AudioResponseCategory>().ReverseMap();
        CreateMap<AudioResponseCategoryResponseDto, AudioResponseCategory>().ReverseMap();
    }
}
