using System.Threading.Tasks;

namespace Patterns.Command
{
    public interface Command
    {
        Task Execute();
    }
}
