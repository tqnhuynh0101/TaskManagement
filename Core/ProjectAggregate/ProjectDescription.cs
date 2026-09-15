using Vogen;

namespace Core.ProjectAggregate;

[ValueObject<string>(conversions: Conversions.SystemTextJson)]
public partial struct ProjectDescription
{
    public const int MaxLength = 500;
    public static Validation Validate(in string value)
        => !string.IsNullOrWhiteSpace(value)
            ? value.Length > MaxLength
                ? Validation.Invalid($"ProjectDescription cannot be longer than {MaxLength} characters")
                : Validation.Ok
            : Validation.Invalid("ProjectDescription cannot be null or whitespace");
}
