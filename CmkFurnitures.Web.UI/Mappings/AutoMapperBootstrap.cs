using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using CmkFurnitures.Web.UI.Areas.Admin.Models;
using CmkFurnitures.Domain;

namespace CmkFurnitures.Web.UI.Mappings
{
    public class AutoMapperBootstrap
    {
        public static void ConfigureMappings()
        {
            Mapper.CreateMap<FurnitureFormViewModel, Furniture>()
                .ForMember(x => x.PartNumber, x => x.MapFrom(y => y.PartNumber))
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Name))
                .ForMember(x => x.Text, x => x.MapFrom(y => y.Text))
                .ForMember(x => x.Price, x => x.MapFrom(y => y.Price))
                .ForMember(x => x.FurnitureTypeId, x => x.MapFrom(y => y.FurnitureTypeId))
                .ForMember(x => x.DesignerId, x => x.MapFrom(y => y.DesignerId))
                .ForMember(x => x.DesignYear, x => x.MapFrom(y => y.DesignYear));

            Mapper.CreateMap<Furniture, FurnitureFormViewModel>()
                .ForMember(x => x.PartNumber, x => x.MapFrom(y => y.PartNumber))
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Name))
                .ForMember(x => x.Text, x => x.MapFrom(y => y.Text))
                .ForMember(x => x.Price, x => x.MapFrom(y => y.Price))
                .ForMember(x => x.FurnitureTypeId, x => x.MapFrom(y => y.FurnitureTypeId))
                .ForMember(x => x.DesignerId, x => x.MapFrom(y => y.DesignerId))
                .ForMember(x => x.DesignYear, x => x.MapFrom(y => y.DesignYear));

            Mapper.CreateMap<Designer, DesignerFormViewModel>()
                .ForMember(x => x.FirstName, x => x.MapFrom(y => y.FirstName))
                .ForMember(x => x.LastName, x => x.MapFrom(y => y.LastName));
        }
    }
}