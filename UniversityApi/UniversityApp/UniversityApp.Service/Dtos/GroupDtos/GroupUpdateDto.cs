using FluentValidation;

namespace UniversityApp.Service.Dtos.GroupDtos
{
    public class GroupUpdateDto
    {
        public string No { get; set; }
        public byte Limit { get; set; }
    }

    public class GroupUpdateDtoValidator : AbstractValidator<GroupUpdateDto>
    {
        public GroupUpdateDtoValidator()
        {
            RuleFor(x => x.No).NotEmpty().MaximumLength(5).MinimumLength(4);
            RuleFor(x => (int)x.Limit).NotNull().InclusiveBetween(5, 18);
        }
    }
}
