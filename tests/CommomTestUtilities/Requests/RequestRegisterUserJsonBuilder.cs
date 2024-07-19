using Bogus;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;

namespace CommomTestUtilities.Requests;
public class RequestRegisterUserJsonBuilder
{
    public static RequestRegisterUserJson Build()
    {
        return new Faker<RequestRegisterUserJson>()
            .RuleFor(rule => rule.UserName, faker => faker.Internet.UserName())
            .RuleFor(rule => rule.Email, faker => faker.Internet.Email())
            .RuleFor(rule => rule.Password, faker => faker.Internet.Password())
            .RuleFor(rule => rule.Type, faker => faker.PickRandom<UserType>());
    }
}
