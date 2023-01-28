namespace ProjectEBusinessMVC.Core.Interfaces;

public interface IEntity
{
    int Id { get; set; }
    bool IsDeleted { get; set; }
    DateTime UpdatedTime { get; set; }
}
