using Patterns.Command;
using System.Threading.Tasks;
using UnityEngine;

namespace Common.Commands
{
    public class PauseGameCommand : Command
    {
        public Task Execute()
        {
            Time.timeScale = 0;
            return Task.CompletedTask;
        }
    }
}