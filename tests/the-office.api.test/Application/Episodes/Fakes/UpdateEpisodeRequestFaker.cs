using Bogus;
using the_office.api.application.Episodes.Messaging.Requests;

namespace the_office.api.test.Application.Episodes.Fakes;

internal sealed class UpdateEpisodeRequestFaker : Faker<UpdateEpisodeRequest>
{
    private UpdateEpisodeRequestFaker()
    {
        RuleFor(request => request.Name, faker => faker.Name.FullName());
        RuleFor(request => request.Description, faker => faker.Lorem.Paragraphs());
        RuleFor(request => request.AirDate, faker => faker.Date.Past());
        RuleFor(request => request.SeasonCode, faker => faker.Random.Guid());
        RuleFor(request => request.Characters, Enumerable.Range(0,10).Select(_ => Guid.NewGuid()).ToList());
    }
    
    internal static UpdateEpisodeRequestFaker Create() => new();
    
    internal UpdateEpisodeRequest WithManyCharacters(int count = 10)
    {
        var request = Generate();
        
        request.Characters = Enumerable.Range(0,count).Select(_ => Guid.NewGuid()).ToList();

        return request;
    } 
    
    internal UpdateEpisodeRequest WithNoCharacters()
    {
        var request = Generate();
        
        request.Characters = null;

        return request;
    } 
}