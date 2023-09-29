using Newtonsoft.Json;
using Playwright_Specflow.Drivers;
using Playwright_Specflow.Models;

namespace Playwright_Specflow.StepDefinition
{
    [Binding]
    public class API_RickAndMorty
    {
        private readonly PlaywrightDriver _playwrightDriver;
        private readonly ScenarioContext scenarioContext;

        public API_RickAndMorty(PlaywrightDriver playwrightDriver, ScenarioContext scenarioContext)
        {
            _playwrightDriver = playwrightDriver;
            this.scenarioContext = scenarioContext;
        }
       
        [StepDefinition(@"We make a GET request for character (.*)")]
        public async Task GivenWeMakeAGETRequestForCharacter(string id)
        {
            Console.WriteLine("ID="+id);

            var requestContext = await _playwrightDriver.GetAPIContext()
                ?? throw new Exception("Could not create API context");

            var response = await requestContext.GetAsync("character/" + id);
            var content = await response.TextAsync();
            Console.WriteLine($"API Response: {content}");

            var character = JsonConvert.DeserializeObject<Character>(content)
                ?? throw new Exception($"Could not retrieve character data");

            scenarioContext["character"] = character;
        }

        [StepDefinition(@"We receive a response")]
        public void WhenWeReceiveAResponse()
        {
            if (scenarioContext["character"] is not Character)
                throw new Exception("Invalid character state");
        }

        [StepDefinition(@"The associated values for the character match the following '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public void ThenTheAssociatedValuesForTheCharacterMatchTheFollowing(int id, string name, string status, string species, string gender)
        {
            if (scenarioContext["character"] is not Character character)
                throw new Exception("Invalid character state");

            character.Id.Should().Be(id);
            character.Name.Should().Be(name);
            character.Status.Should().Be(status);
            character.Species.Should().Be(species);
            character.Gender.Should().Be(gender);
        }
    }
}