using Common.Commands;

namespace Core.Installers
{
    public class GlobalInstaller : GeneralInstaller
    {
        protected override async void DoStart()
        {
            new LoadSceneCommand("Menu").Execute();
        }

        protected override void DoInstallDependencies()
        {
        }
    }
}


