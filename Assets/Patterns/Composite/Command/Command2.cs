using UnityEngine;
using System.Threading.Tasks;

namespace Patterns.Composite.Command
{
    public class Command2 : Patterns.Command.Command
    {
        public async Task Execute()
        {
            await Task.Delay(300);
            Debug.Log("2");
        }
    }
}