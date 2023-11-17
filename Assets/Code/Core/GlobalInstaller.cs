using Patterns.ServiceLocator;
using System.Threading.Tasks;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class GlobalInstaller : GeneralInstaller
    {
        private async Task LoadNextScene()
        {
            await LoadScene("Game");
            ServiceLocator.Instance.GetService<LoadingScreen>().Hide();
        }

        private async Task LoadScene(string sceneName)
        {
            var loadSceneAsync = SceneManager.LoadSceneAsync(sceneName);

            while (loadSceneAsync.isDone)
            {
                await Task.Yield();
            }
            await Task.Yield();
        }

        protected override async void DoStart()
        {
            await LoadNextScene();
        }

        protected override void DoInstallDependencies()
        {
        }
    }
}


