using AutoMapper;
using AutoMapper.Configuration;
using DYApp.DataObject;
using DYApp.Domain.Model;
using DYApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYApp.Application.AutoMap
{
    public static class DyMapper
    {
        static DyMapper()
        {
            MapperConfigurationExpression cfg = new MapperConfigurationExpression();

            cfg.CreateMap<UserInfo, UserInfoDataObject>();
            cfg.CreateMap<UserInfoDataObject, UserInfo>();
            cfg.CreateMap<Function, FunctionDataObject>();
            cfg.CreateMap<FunctionDataObject, Function>();
            cfg.CreateMap<Role, RoleDataObject>();
            cfg.CreateMap<RoleDataObject, Role>();
            cfg.CreateMap<Involved, InvolvedDataObject>();
            cfg.CreateMap<InvolvedDataObject, Involved>()
                .ForMember(dest => dest.ID, src => src.Ignore());
            cfg.CreateMap<SceneRecord, SceneRecordDataObject>();
            cfg.CreateMap<SceneRecordDataObject, SceneRecord>()
                .ForMember(dest => dest.ID, src => src.Ignore())
                .ForMember(dest => dest.Time, src => src.MapFrom(p => p.Time == DateTime.MinValue ? DateTime.Now : p.Time))
                .ForMember(dest => dest.InvolvedSignTime, src => src.MapFrom(p => p.InvolvedSignTime==DateTime.MinValue?DateTime.Now:p.InvolvedSignTime))
                .ForMember(dest => dest.EnforcerSignTime, src => src.MapFrom(p => p.EnforcerSignTime == DateTime.MinValue ? DateTime.Now : p.EnforcerSignTime));

            cfg.CreateMap<Filing, FilingDataObject>();
            cfg.CreateMap<FilingDataObject, Filing>()
                .ForMember(dest => dest.ID, src => src.Ignore())
                .ForMember(dest => dest.AcceptTime, src => src.MapFrom(p => p.AcceptTime == DateTime.MinValue ? DateTime.Now : p.AcceptTime))
                .ForMember(dest => dest.AcceptSignTime, src => src.MapFrom(p => p.AcceptSignTime == DateTime.MinValue ? DateTime.Now : p.AcceptSignTime))
                .ForMember(dest => dest.ManageSignTime, src => src.MapFrom(p => p.ManageSignTime == DateTime.MinValue ? DateTime.Now : p.ManageSignTime));

            cfg.CreateMap<AskRecord, AskRecordDataObject>();
            cfg.CreateMap<AskRecordDataObject, AskRecord>()
                .ForMember(dest => dest.ID, src => src.Ignore())
                .ForMember(dest => dest.BetweenBegin, src => src.MapFrom(p => p.BetweenBegin == DateTime.MinValue ? DateTime.Now : p.BetweenBegin))
                .ForMember(dest => dest.BetweenEnd, src => src.MapFrom(p => p.BetweenEnd == DateTime.MinValue ? DateTime.Now : p.BetweenEnd));

            cfg.CreateMap<CaseHandling, CaseHandlingDataObject>();
            cfg.CreateMap<CaseHandlingDataObject, CaseHandling>()
                .ForMember(dest => dest.ID, src => src.Ignore())
                .ForMember(dest => dest.WorkSuggestionTime, src => src.MapFrom(p => p.WorkSuggestionTime == DateTime.MinValue ? DateTime.Now : p.WorkSuggestionTime))
                .ForMember(dest => dest.ExecuteSuggestionTime, src => src.MapFrom(p => p.ExecuteSuggestionTime == DateTime.MinValue ? DateTime.Now : p.ExecuteSuggestionTime));

            cfg.CreateMap<Evidence, EvidenceDataObject>();
            cfg.CreateMap<EvidenceDataObject, Evidence>()
                .ForMember(dest => dest.ID, src => src.Ignore())
                .ForMember(dest => dest.HandlingTime, src => src.MapFrom(p => p.HandlingTime == DateTime.MinValue ? DateTime.Now : p.HandlingTime))
                .ForMember(dest => dest.InvolvedSignTime, src => src.MapFrom(p => p.InvolvedSignTime == DateTime.MinValue ? DateTime.Now : p.InvolvedSignTime))
                .ForMember(dest => dest.Time, src => src.MapFrom(p => p.Time == DateTime.MinValue ? DateTime.Now : p.Time));

            cfg.CreateMap<EvidenceDetailDataObject, EvidenceDetail>();
            cfg.CreateMap<EvidenceDetail, EvidenceDetailDataObject>();

            cfg.CreateMap<WorkFlow, WorkFlowDataObject>()
                .ForMember(dest => dest.UserInfoIDList, src => src.MapFrom(p => p.UserInfoList.Select(k => k.ID).ToArray()));
            cfg.CreateMap<WorkFlowDataObject, WorkFlow>();
            Mapper.Initialize(cfg);
        }

        public static Target Map<Source, Target>(Source source)
        {
            return source == null ? default(Target) : Mapper.Map<Source, Target>(source);
        }
        public static Target Map<Source, Target>(Source source, Target target)
        {
            return source == null ? target : Mapper.Map(source, target);
        }

    }
}
