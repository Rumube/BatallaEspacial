using Common.Commands;
using Patterns.Command;
using Patterns.ServiceLocator;

namespace Core.Installers
{
    public class GlobalInstaller : GeneralInstaller
    {
        protected override async void DoStart()
        {
            ServiceLocator.Instance.GetService<CommandQueue>().AddCommand(new LoadSceneCommand("Menu"));
        }

        protected override void DoInstallDependencies()
        {
            ServiceLocator.Instance.RegisterService(CommandQueue.Instance);
        }
    }
}


