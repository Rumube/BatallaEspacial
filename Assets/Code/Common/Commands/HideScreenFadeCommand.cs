using Patterns.Command;
using Patterns.ServiceLocator;
using System.Threading.Tasks;
using UI;

namespace Common.Commands
{
    public class HideScreenFadeCommand : Command
    {
        public async Task Execute()
        {
            var serviceLocator = ServiceLocator.Instance;
            serviceLocator.GetService<ScreenFade>().Hide();

            await Task.Delay(200);
        }
    }
}