using AutoMapper;
using Common.Data.Entities.Audio;
using Core.Application.DTOs.Request.Audio;

namespace Core.Application.Services.Audio.Mapper;

public class AudioResponseMapper : Profile
{
    public AudioResponseMapper()
    {
        CreateMap<AudioRequestDto, AudioResponse>().ReverseMap();
        CreateMap<AudioRequestDto, AudioResponse>().ReverseMap();
    }
}
