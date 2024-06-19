using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace UniversityApp.Service.Dtos.GroupDtos
{
    public class GroupCreateDto
    {
   
        public string No { get; set; }
   
        public byte Limit { get; set; }
    }

    public class GroupCreateDtoValidator:AbstractValidator<GroupCreateDto>
    {
        public GroupCreateDtoValidator()
        {
            RuleFor(x => x.No).NotEmpty().MaximumLength(5).MinimumLength(4);
            RuleFor(x => (int)x.Limit).NotNull().InclusiveBetween(5,18);
        }
    }
}
