using System.Linq;
using AutoMapper;
using marcore.api.Dtos.Contactmail;
using marcore.api.Dtos.Message;
using marcore.api.Dtos.Photo;
using marcore.api.Dtos.Tb;
using marcore.api.Dtos.User;
using marcore.api.Dtos.VsoftLedgerAccount;
using marcore.api.Dtos.VsoftContract;
using marcore.api.Dtos.VsoftCustomer;
using marcore.api.Dtos.VsoftCustomerInvoice;
using marcore.api.Dtos.VsoftLedger;
using marcore.api.Dtos.VsoftMailform;
using marcore.api.Dtos.VsoftSupplier;
using marcore.api.Dtos.VsoftSupplierInvoice;
using marcore.api.Dtos.VsoftTelebibContract;
using marcore.Entities;

namespace marcore.api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(dest => dest.Age, opt =>
                {
                    opt.MapFrom(d => d.DateOfBirth.CalculateAge());
                });

            CreateMap<User, UserForDetailedDto>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(dest => dest.Age, opt =>
                {
                    opt.MapFrom(d => d.DateOfBirth.CalculateAge());
                });

            CreateMap<Photo, PhotosForDetailedDto>();
            CreateMap<UserForUpdateDto, User>();
            CreateMap<Photo, PhotoForReturnDto>();
            CreateMap<PhotoForCreationDto, Photo>();
            CreateMap<UserForRegisterDto, User>();

            CreateMap<ContactmailForDto, Contactmail>();
            // CreateMap<Contactmail, ContactmailForDto>();

            CreateMap<MessageForCreationDto, Message>().ReverseMap();
            CreateMap<Message, MessageToReturnDto>()
                .ForMember(m => m.SenderPhotoUrl, opt => opt
                    .MapFrom(u => u.Sender.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(m => m.RecipientPhotoUrl, opt => opt
                    .MapFrom(u => u.Recipient.Photos.FirstOrDefault(p => p.IsMain).Url));


            CreateMap<TbValeur, TbValeurForIODto>();
            CreateMap<TbQualifier, TbQualifierForIODto>();

            CreateMap<VsoftLedgerAccount, VsoftLedgerAccountForDetailedDto>();
            CreateMap<VsoftLedgerAccount, VsoftLedgerAccountForListDto>();
            CreateMap<VsoftLedgerAccountForNewDto, VsoftLedgerAccount>();
            CreateMap<VsoftLedgerAccountForUpdateDto, VsoftLedgerAccount>();

            CreateMap<VsoftLedger, VsoftLedgerForDetailedDto>();

            CreateMap<VsoftCustomer, VsoftCustomerForDetailedDto>();
            CreateMap<VsoftCustomer, VsoftCustomerForListDto>();
            CreateMap<CustomerForNewDto, VsoftCustomer>();
            CreateMap<CustomerForUpdateDto, VsoftCustomer>();

            CreateMap<VsoftSupplier, VsoftSupplierForDetailedDto>();
            CreateMap<VsoftSupplier, VsoftSupplierForListDto>();
            CreateMap<SupplierForNewDto, VsoftSupplier>();
            CreateMap<SupplierForUpdateDto, VsoftSupplier>();

            CreateMap<VsoftSupplierInvoice, VsoftSupplierInvoiceForDetailedDto>();
            CreateMap<VsoftSupplierInvoice, VsoftSupplierInvoiceForListDto>();

            CreateMap<VsoftContract, VsoftContractForDetailedDto>();
            CreateMap<VsoftContract, VsoftContractForListDto>();
            CreateMap<VsoftTelebibContract, VsoftTelebibContractForDetailedDto>();
            CreateMap<VsoftTelebibContract, VsoftTelebibContractForListDto>();
            CreateMap<VsoftCustomerInvoice, VsoftCustomerInvoiceForDetailedDto>();
            CreateMap<VsoftCustomerInvoice, VsoftCustomerInvoiceForListDto>();

            CreateMap<VsoftMailform, VsoftMailformForDetailedDto>();
            CreateMap<VsoftMailform, VsoftMailformForListDto>();
            CreateMap<MailformForNewDto, VsoftMailform>();
            CreateMap<MailformForUpdateDto, VsoftMailform>();
        }
    }
}
