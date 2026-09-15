
using Vogen;

[assembly: VogenDefaults(
    staticAbstractsGeneration: StaticAbstractsGeneration.MostCommon | StaticAbstractsGeneration.InstanceMethodsAndProperties)]
namespace Core.ProjectAggregate;

[ValueObject<int>]
public readonly partial struct ProjectId
{
    private static Validation Validate(int value)
    => value > 0
        ? Validation.Ok
        : Validation.Invalid("ProjectId must be greater than 0");
}
