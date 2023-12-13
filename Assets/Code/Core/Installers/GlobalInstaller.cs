using Common.Commands;
using Common.Score;
using Patterns.Command;
using Patterns.ServiceLocator;
using Core.Serializers;
using ScoreSystem = Common.Score.ScoreSystem;
using Core.DataStorage;

namespace Core.Installers
{
    public class GlobalInstaller : GeneralInstaller
    {
        protected override void DoStart()
        {
            ServiceLocator.Instance.GetService<CommandQueue>()
                          .AddCommand(new LoadSceneCommand("Menu"));
        }

        protected override void DoInstallDependencies()
        {
            ServiceLocator.Instance.RegisterService(CommandQueue.Instance);

            var serializer = new JsonUtilityAdapter();
            var dataStore = new PlayerPrefsDataStorageAdapter(serializer);
            var scoreSystemImpl = new ScoreSystemImpl(dataStore);
            ServiceLocator.Instance.RegisterService<ScoreSystem>(scoreSystemImpl);
        }
    }
}


