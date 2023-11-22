using UnityEngine;
using System.Threading.Tasks;

namespace Patterns.Composite.Command
{
    public class Command1 : Patterns.Command.Command
    {
        public async Task Execute()
        {
            await Task.Delay(200);
            Debug.Log("1");
        }
    }
}