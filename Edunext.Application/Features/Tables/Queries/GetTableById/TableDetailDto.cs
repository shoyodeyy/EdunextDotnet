namespace Edunext.Application.Features.Tables.Queries.GetTableById;

public record TableDetailDto(Guid TableId, string Code, bool IsActive);