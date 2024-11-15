using System.Security.AccessControl;
using System.Security.Principal;
using Identity.Domain.Core.Bases.SeedWork;
using Identity.Domain.Service.Role;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Domain.Service.User;

public class Users : AggregateRoot<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public string Mobile { get; set; } = string.Empty;
    public UserImages UserImage { get; set; }

    public Guid RoleId { get; set; }
    public Role.Roles Roles { get; set; } = null!;


    private Users(Guid id, string name, string lastname, string mobile
        , string filePath, string fileName, string fileExtension, int fileSize)
    {
        //validation
        Id = id;
        Name = name;
        Lastname = lastname;
        Mobile = mobile;
        BuildUserImages(filePath, fileName, fileExtension, fileSize);
    }

    private void BuildUserImages(string filePath, string fileName, string fileExtension, int fileSize)
    {
        if (string.IsNullOrEmpty(filePath)) return;
        UserImage = new UserImages();
        UserImage.FilePath = filePath;
        UserImage.FileName = fileName;
        UserImage.Extension = fileExtension;
        UserImage.Size = fileSize;
    }

    public static Users CreateUsers(string name, string lastname, string mobile
        , string filePath, string fileName, string fileExtension, int fileSize)
    {
        var userId = Guid.NewGuid();
        return new Users(userId, name, lastname, mobile, filePath, fileName, fileExtension, fileSize);
    }

    public static Users UpdateUsers(Guid id, string name, string lastname, string mobile
        , string filePath, string fileName, string fileExtension, int fileSize)
    {
        return new Users(id, name, lastname, mobile, filePath, fileName, fileExtension, fileSize);
    }

    public static Users DeleteUser(Guid id)
    {
        return new Users(id);
    }

    private Users(Guid id)
    {
        Id = id;
    }

    private Users()
    {
    }
    
    public class  UserConfiguration : IEntityTypeConfiguration<User.Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasOne(x => x.Roles)
                .WithMany()  
                .HasForeignKey(x => x.RoleId);
            builder.OwnsOne(x => x.UserImage, u =>
            {
                u.Property(p => p.FilePath).HasMaxLength(500);
                u.Property(p => p.FileName).HasMaxLength(250);
                u.Property(p => p.Extension).HasMaxLength(10);
                u.Property(p => p.Size);
            });
            
        }
    }
}