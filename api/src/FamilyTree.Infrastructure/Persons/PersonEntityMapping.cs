using FamilyTree.Domain.Persons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyTree.Infrastructure.Persons;

internal sealed class PersonEntityMapping : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder
            .HasKey(person => person.Id);

        builder
            .Property(person => person.GivenName)
            .HasMaxLength(Person.Constraints.GivenNameMaxLength)
            .IsRequired();

        builder
            .Property(person => person.Surname)
            .HasMaxLength(Person.Constraints.SurnameMaxLength)
            .IsRequired();

        builder
            .Property(person => person.Gender)
            .IsRequired();

        builder
            .Property(person => person.BirthDate)
            .IsRequired(false);

        builder
            .Property(person => person.BirthLocation)
            .HasMaxLength(Person.Constraints.BirthLocationMaxLength)
            .IsRequired(false);

        builder
            .Property(person => person.DeathDate)
            .IsRequired(false);

        builder
            .Property(person => person.DeathLocation)
            .HasMaxLength(Person.Constraints.DeathLocationMaxLength)
            .IsRequired(false);

        builder
            .Ignore(person => person.DisplayName);

        builder
            .HasOne(person => person.FamilyTree)
            .WithMany(tree => tree.FamilyMembers)
            .HasForeignKey(person => person.FamilyTreeId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
