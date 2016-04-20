namespace PortfolioWebApi.Services
{
    public interface IPortfolioIdentityService
    {
        string CurrentUser { get; }
        string CurrentUserId { get; }
    }
}