namespace APC.Application.Common.JWT
{
    public interface ITokenService
    {
        Task<string> GenerateToken(Guid userId, string userName);
    }
}