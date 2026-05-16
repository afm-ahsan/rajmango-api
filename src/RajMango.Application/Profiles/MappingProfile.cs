using AutoMapper;
using RajMango.Application.DTOs;
using RajMango.Application.Features.Commands;
using RajMango.Application.Features.Queries;
using RajMango.Domain.Entities;

namespace RajMango.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //App User
            CreateMap<AppUser, CreateUserCommand>();
            CreateMap<CreateUserCommand, AppUser>();
            CreateMap<AppUser, UpdateUserCommand>();
            CreateMap<UpdateUserCommand, AppUser>();

            //CreateMap<User, UserDto>();
            //CreateMap<UserDto, User>();
            //CreateMap<HrtofficeDto, Hrtoffice>();
            ////If need extra mapping
            //CreateMap<Hrtoffice, HrtofficeDto>()
            //    .ForMember(
            //        dest => dest.Active,
            //        opt => opt.MapFrom(src => src.IsActive.HasValue && src.IsActive.Value == true ? "Yes" : "No")
            //    )
            //    .ForMember(
            //        dest => dest.Show,
            //        opt => opt.MapFrom(src => src.IsShow.HasValue && src.IsShow.Value == true ? "Yes" : "No")
            //    );

            //Category
            CreateMap<MangoType, CreateMangoTypeCommand>();
            CreateMap<CreateMangoTypeCommand, MangoType>();
            CreateMap<MangoType, UpdateMangoTypeCommand>();
            CreateMap<UpdateMangoTypeCommand, MangoType>();
            CreateMap<MangoType, GetAllMangoTypeDto>();
            CreateMap<MangoType, GetMangoTypeWithPaginationDto>();
            CreateMap<GetMangoTypeByIdDto, MangoType>();
            CreateMap<MangoType, GetMangoTypeByIdDto>();

            //ExpenseType
            CreateMap<ExpenseType, CreateExpenseTypeCommand>();
            CreateMap<CreateExpenseTypeCommand, ExpenseType>();
            CreateMap<ExpenseType, UpdateExpenseTypeCommand>();
            CreateMap<UpdateExpenseTypeCommand, ExpenseType>();
            CreateMap<ExpenseType, GetAllExpenseTypeDto>();
            CreateMap<ExpenseType, GetExpenseTypeWithPaginationDto>();
            CreateMap<GetExpenseTypeByIdDto, ExpenseType>();
            CreateMap<ExpenseType, GetExpenseTypeByIdDto>();

            //Expense
            CreateMap<Expense, CreateExpenseCommand>();
            CreateMap<CreateExpenseCommand, Expense>();
            CreateMap<Expense, UpdateExpenseCommand>();
            CreateMap<UpdateExpenseCommand, Expense>();
            CreateMap<Expense, GetAllExpenseDto>();
            CreateMap<Expense, GetExpenseWithPaginationDto>();
            CreateMap<GetExpenseByIdDto, Expense>();
            CreateMap<Expense, GetExpenseByIdDto>();

            //Customer
            CreateMap<Customer, CreateCustomerCommand>();
            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<Customer, UpdateCustomerCommand>();
            CreateMap<UpdateCustomerCommand, Customer>();
            CreateMap<Customer, GetAllCustomerDto>();
            CreateMap<Customer, GetCustomerWithPaginationDto>()
                .ForMember(d => d.Name,        opt => opt.MapFrom(s => s.FullName))
                .ForMember(d => d.PhoneNumber, opt => opt.MapFrom(s => s.PhoneNumber1))
                .ForMember(d => d.Address,     opt => opt.MapFrom(s => s.AddressLine1));
            CreateMap<GetCustomerByIdDto, Customer>();
            CreateMap<Customer, GetCustomerByIdDto>();

            //Role
            CreateMap<Role, CreateRoleCommand>();
            CreateMap<CreateRoleCommand, Role>();
            CreateMap<Role, UpdateRoleCommand>();
            CreateMap<UpdateRoleCommand, Role>();
            CreateMap<Role, GetAllRoleDto>();
            CreateMap<Role, GetRoleWithPaginationDto>();
            CreateMap<GetRoleByIdDto, Role>();
            CreateMap<Role, GetRoleByIdDto>();

            //Payment
            CreateMap<Payment, CreatePaymentCommand>();
            CreateMap<CreatePaymentCommand, Payment>();
            CreateMap<Payment, UpdatePaymentCommand>();
            CreateMap<UpdatePaymentCommand, Payment>();
            CreateMap<Payment, GetAllPaymentDto>();
            CreateMap<Payment, GetPaymentWithPaginationDto>();
            CreateMap<GetPaymentByIdDto, Payment>();
            CreateMap<Payment, GetPaymentByIdDto>();
        }
    }
}
