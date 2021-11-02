namespace MentorMate.Web.Factories
{
    public interface IFactory<out T>
    {
        T Create();
    }
}
