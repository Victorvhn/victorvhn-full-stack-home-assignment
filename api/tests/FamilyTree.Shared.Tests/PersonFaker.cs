using Bogus;
using FamilyTree.Domain.Persons.Enums;
using FamilyTree.Domain.Trees;
using Person = FamilyTree.Domain.Persons.Person;

namespace FamilyTree.Shared.Tests;

public static class PersonFaker
{
    public static Faker<Person> GetFaker()
    {
        var tree = Tree.CreateInstance();
        return new Faker<Person>()
            .CustomInstantiator(f => (Person)Activator.CreateInstance(typeof(Person), true)!)
            .RuleFor(person => person.GivenName, faker => faker.Name.FirstName())
            .RuleFor(person => person.Surname, faker => faker.Name.LastName())
            .RuleFor(person => person.Gender, faker => faker.PickRandom<PersonGender>())
            .RuleFor(person => person.FamilyTree, tree)
            .RuleFor(person => person.FamilyTreeId, tree.Id)
            .RuleFor(person => person.BirthDate,
                faker => faker.Random.Bool(0.7f)
                    ? faker.Date.Past(100, DateTime.UtcNow)
                    : null
            )
            .RuleFor(person => person.BirthLocation,
                (faker, person) => person.BirthDate.HasValue && faker.Random.Bool()
                    ? faker.Address.City()
                    : null
            )
            .RuleFor(person => person.DeathDate, (faker, person) =>
            {
                if (faker.Random.Bool())
                {
                    return person.BirthDate.HasValue
                        ? faker.Date.Between(person.BirthDate.Value.AddYears(1), DateTime.UtcNow)
                        : faker.Date.Past(30, DateTime.UtcNow);
                }

                return null;
            })
            .RuleFor(person => person.DeathLocation,
                (faker, person) => person.DeathDate.HasValue && faker.Random.Bool()
                    ? faker.Address.City()
                    : null
            );
    }
}
