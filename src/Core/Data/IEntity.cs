namespace WebApiReferenceImpl.Core.Data
{

    public interface IEntity
    {
    }

    public interface IDetachedEntity : IEntity
    {
        EntityState EntityState { get; set; }
    }
}