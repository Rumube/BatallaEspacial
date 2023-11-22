using Patterns.Command;
using System.Threading.Tasks;

namespace Common.Commands
{
    public class LoadGameSceneCommand : Command
    {
        public async Task Execute()
        {
            await new LoadSceneCommand("Game").Execute();
            await new StartBattleCommand().Execute();
        }
    }
}