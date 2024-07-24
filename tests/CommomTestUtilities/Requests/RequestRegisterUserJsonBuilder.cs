using Bogus;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;

namespace CommomTestUtilities.Requests;
public class RequestRegisterUserJsonBuilder
{
    public static RequestUserJson Build()
    {
        return new Faker<RequestUserJson>()
            .RuleFor(rule => rule.UserName, faker => faker.Internet.UserName())
            .RuleFor(rule => rule.Email, faker => faker.Internet.Email())
            .RuleFor(rule => rule.Password, faker => faker.Internet.Password())
            .RuleFor(rule => rule.UserType, faker => faker.PickRandom<UserType>());
    }
}
