using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns.Command
{
    public class Consumer : MonoBehaviour
    {
        private List<Command> _commandsKey1;
        private List<Command> _commandsKey2;

        public void Configure(List<Command> commandsKey1, List<Command> commandsKey2)
        {
            _commandsKey1 = commandsKey1;
            _commandsKey2 = commandsKey2;
        }

        void Update()
        {
            var commandQueue = CommandQueue.Instance;
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                foreach (var command in _commandsKey1)
                {
                    commandQueue.AddCommand(command);
                }
            }else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                foreach (var command in _commandsKey2)
                {
                    commandQueue.AddCommand(command);
                }
            }
        }
    }
}


