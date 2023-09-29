using Microsoft.Playwright;

namespace Playwright_Specflow.Drivers
{
    public class PlaywrightDriver : IDisposable
    {
        private IPlaywright? _playwright;
        private readonly IAPIRequestContext? _requestContext;

        public async Task<IAPIRequestContext> GetAPIContext()
        {            
            if (_requestContext != null)
                return _requestContext;

            _playwright ??= await Playwright.CreateAsync();

            return await _playwright.APIRequest.NewContextAsync(
                new APIRequestNewContextOptions
                {
                    BaseURL = "https://rickandmortyapi.com/api/",
                    IgnoreHTTPSErrors=true
                });
        }

        public void Dispose()
        {
            _playwright?.Dispose();

            if (_requestContext != null)
                _requestContext.DisposeAsync();
        }
    }
}
