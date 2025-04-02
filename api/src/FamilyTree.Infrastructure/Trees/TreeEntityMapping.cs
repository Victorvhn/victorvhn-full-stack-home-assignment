using FamilyTree.Domain.Trees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyTree.Infrastructure.Trees;

internal sealed class TreeEntityMapping : IEntityTypeConfiguration<Tree>
{
    public void Configure(EntityTypeBuilder<Tree> builder)
    {
        builder
            .HasKey(tree => tree.Id);
    }
}
