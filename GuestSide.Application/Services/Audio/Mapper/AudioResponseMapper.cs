using AutoMapper;
using Core.Application.DTOs.Request.Audio;
using GuestSide.Core.Entities.Audio;

namespace Core.Application.Services.Audio.Mapper;

public class AudioResponseMapper : Profile
{
    public AudioResponseMapper()
    {
        CreateMap<AudioRequestDto, AudioResponse>().ReverseMap();
        CreateMap<AudioRequestDto, AudioResponse>().ReverseMap();
    }
}
