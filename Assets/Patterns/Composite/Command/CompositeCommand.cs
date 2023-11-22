using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patterns.Composite.Command
{
    public class CompositeCommand : Patterns.Command.Command
    {
        private readonly List<Patterns.Command.Command> _commands;

        public CompositeCommand()
        {
            _commands = new List<Patterns.Command.Command>();
        }

        public void AddCommand(Patterns.Command.Command command)
        {
            _commands.Add(command);
        }

        public async Task Execute()
        {
            var tasks = new List<Task>(_commands.Count);

            foreach (var command in _commands)
            {
                var task = command.Execute();
                tasks.Add(task);
            }

            await Task.WhenAll(tasks);
        }
    }
}