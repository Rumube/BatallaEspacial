using UnityEngine;
using System.Threading.Tasks;

namespace Patterns.Composite.Command
{
    public class Command3 : Patterns.Command.Command
    {
        public async Task Execute()
        {
            await Task.Delay(100);
            Debug.Log("3");
        }
    }
}