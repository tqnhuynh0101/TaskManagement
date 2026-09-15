using Vogen;

namespace Core.ProjectAggregate;

[ValueObject<string>(conversions: Conversions.SystemTextJson)]
public partial struct ProjectName
{
    public const int MaxLeght = 100;
    public static Validation Validate(in string value)
        => !string.IsNullOrWhiteSpace(value)
            ? value.Length > MaxLeght
                ? Validation.Invalid($"ProjectName cannot be longer than {MaxLeght} characters")
                : Validation.Ok
            : Validation.Invalid("ProjectName cannot be null or whitespace");
}
