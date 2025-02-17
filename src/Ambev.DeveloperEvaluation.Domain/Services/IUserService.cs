// Placeholder for IInventoryService.cs file

namespace Ambev.DeveloperEvaluation.Domain.Services;
public interface IUserService
{
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string Role { get; set; }
}