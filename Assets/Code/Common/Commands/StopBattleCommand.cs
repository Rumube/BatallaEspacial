using Patterns.Command;
using Patterns.ServiceLocator;
using Ships.Enemies;
using System.Threading.Tasks;

namespace Common.Commands
{
    public class StopBattleCommand : Command
    {
        public Task Execute()
        {
            var serviceLocator = ServiceLocator.Instance;
            serviceLocator.GetService<EnemySpawner>().StopAndReset();
            return Task.CompletedTask;
        }
    }
}