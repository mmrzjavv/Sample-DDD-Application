using System.Security.AccessControl;
using System.Security.Principal;
using Identity.Domain.Core.Bases.SeedWork;
using Identity.Domain.Service.Role;

namespace Identity.Domain.Service.User;

public class Users : AggregateRoot<UserId>
{
    public string Name { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public string Mobile { get; set; } = string.Empty;
    public UserImages UserImage { get; set; }

    public RoleId RoleId { get; set; }
    public Role.RoleId Roles { get; set; } = null!;


    private Users(UserId id, string name, string lastname, string mobile
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
        var userId = new UserId(Guid.NewGuid());
        return new Users(userId, name, lastname, mobile, filePath, fileName, fileExtension, fileSize);
    }

    public static Users UpdateUsers(Guid id, string name, string lastname, string mobile
        , string filePath, string fileName, string fileExtension, int fileSize)
    {
        var userId = new UserId(id);
        return new Users(userId, name, lastname, mobile, filePath, fileName, fileExtension, fileSize);
    }

    public static Users DeleteUser(UserId id)
    {
        return new Users(id);
    }

    private Users(UserId id)
    {
        Id = id;
    }

    private Users()
    {
    }
}