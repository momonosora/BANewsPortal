using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class NewsConfigurations : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            // Configuring entities --> Scalability Purpose
            builder.Property(p => p.Id).IsRequired();
            // builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Title).IsRequired().HasMaxLength(100);
            // builder.Property(p => p.Date).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Text).IsRequired();
            builder.Property(p => p.PictureUrl).IsRequired();
            // Unnecessary to add a foreign key, as it is configured by ef
            builder.HasOne(b => b.NewsCat).WithMany()
                .HasForeignKey(p => p.NewsCatId); 
            // Decimals go another way around ==> .HasColumnType("decimal(18,2)");
            //                                                                    <== 

        }
    }
}