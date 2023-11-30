using Patterns.Command;
using System.Threading.Tasks;
using UnityEngine;

namespace Common.Commands
{
    public class ResumeGameCommand : Command
    {
        public Task Execute()
        {
            Time.timeScale = 1;
            return Task.CompletedTask;
        }
    }
}