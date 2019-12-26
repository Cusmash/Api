using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MonApiGuate.Models;

namespace MonApiGuate.DTOs
{
    public class AutoMapperConfiguration
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<Clientes, ClientesDTO>()
                   .ForMember(x => x.CuentasTelepeajes, o => o.Ignore())
                   .ReverseMap();

                CreateMap<CortesCajeroes, CortesCajeroesDTO>()
                   .ForMember(x => x.OperacionesCajeroes, o => o.Ignore())
                   .ReverseMap();

                CreateMap<CuentasTelepeajes, CuentasTelepeajesDTO>()
                   .ForMember(x => x.Cliente, o => o.Ignore())
                   .ForMember(x => x.Tags, o => o.Ignore())
                   .ReverseMap();

                CreateMap<Historico, HistoricoDTO>()
                   .ReverseMap();

                CreateMap<HistoricoListas, HistoricoListasDTO>()
                   .ReverseMap();

                CreateMap<ListaNegra, ListaNegraDTO>()
                   .ReverseMap();

                CreateMap<MontosRecargables, MontosRecargablesDTO>()
                   .ReverseMap();

                CreateMap<OperacionesCajeroes, OperacionesCajeroesDTO>()
                   .ForMember(x => x.Corte, o => o.Ignore())
                   .ReverseMap();

                CreateMap<OperacionesSerBipagos, OperacionesSerBipagosDTO>()
                   .ReverseMap();

                CreateMap<Parametrizables, ParametrizablesDTO>()
                   .ReverseMap();

                CreateMap<Tags, TagsDTO>()
                   .ForMember(x => x.Cuenta, o => o.Ignore())
                   .ReverseMap();

                CreateMap<AspNetRoles, AspNetRolesDTO>()
                   .ForMember(x => x.AspNetUserRoles, o => o.Ignore())
                   .ReverseMap();

                CreateMap<AspNetUserClaims, AspNetUserClaimsDTO>()
                   .ForMember(x => x.User, o => o.Ignore())
                   .ReverseMap();

                CreateMap<AspNetUserLogins, AspNetUserLoginsDTO>()
                   .ForMember(x => x.User, o => o.Ignore())
                   .ReverseMap();

                CreateMap<AspNetUserRoles, AspNetUserRolesDTO>()
                   .ForMember(x => x.Role, o => o.Ignore())
                   .ForMember(x => x.User, o => o.Ignore())
                   .ReverseMap();

                CreateMap<AspNetUsers, AspNetUsersDTO>()
                   .ForMember(x => x.AspNetUserRoles, o => o.Ignore())
                   .ForMember(x => x.AspNetUserLogins, o => o.Ignore())
                   .ForMember(x => x.AspNetUserClaims, o => o.Ignore())
                   .ReverseMap();

                CreateMap<AmountConfigurations, AmountConfigurationsDTO>()
                   .ReverseMap();
            }
        }
    }
}
