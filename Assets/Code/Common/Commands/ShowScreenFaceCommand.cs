using Patterns.Command;
using Patterns.ServiceLocator;
using System.Threading.Tasks;
using UI;

namespace Common.Commands
{
    public class ShowScreenFadeCommand : Command
    {
        public async Task Execute()
        {
            var serviceLocator = ServiceLocator.Instance;
            serviceLocator.GetService<ScreenFade>().Show();

            await Task.Delay(200);
        } 
    }
}
