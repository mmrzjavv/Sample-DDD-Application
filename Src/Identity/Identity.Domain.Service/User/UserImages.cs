using Identity.Domain.Core.Bases.SeedWork;

namespace Identity.Domain.Service.User;

public class UserImages : ValueObject<UserImages>
{
    public string FilePath { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public string Extension { get; set; } = string.Empty;
    public int Size { get; set; }

    protected override bool EqualsCore(UserImages other)
    {
        if (other == null)
            return false;

        return FilePath == other.FilePath &&
               FileName == other.FileName &&
               Extension == other.Extension &&
               Size == other.Size;
    }

    protected override int GetHashCodeCore()
    {
        return HashCode.Combine(FilePath, FileName, Extension, Size);
    }
}
