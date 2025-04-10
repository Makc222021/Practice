using System;
using System.Collections.Generic;

namespace CommandPatternExample
{
    // Интерфейс команды
    public interface ICommand
    {
        void Execute();
    }

    // Получатель (Receiver): GameCharacter
    public class GameCharacter
    {
        public void Jump()
        {
            Console.WriteLine("Персонаж совершает прыжок!");
        }

        public void Attack()
        {
            Console.WriteLine("Персонаж атакует врага!");
        }

        public void Defend()
        {
            Console.WriteLine("Персонаж защищается!");
        }
    }

    // Конкретная команда: JumpCommand
    public class JumpCommand : ICommand
    {
        private readonly GameCharacter _character;

        public JumpCommand(GameCharacter character)
        {
            _character = character;
        }

        public void Execute()
        {
            _character.Jump();
        }
    }

    // Конкретная команда: AttackCommand
    public class AttackCommand : ICommand
    {
        private readonly GameCharacter _character;

        public AttackCommand(GameCharacter character)
        {
            _character = character;
        }

        public void Execute()
        {
            _character.Attack();
        }
    }

    // Конкретная команда: DefendCommand
    public class DefendCommand : ICommand
    {
        private readonly GameCharacter _character;

        public DefendCommand(GameCharacter character)
        {
            _character = character;
        }

        public void Execute()
        {
            _character.Defend();
        }
    }

    // Инициатор (Invoker): GameController
    public class GameController
    {
        private readonly List<ICommand> _commands = new List<ICommand>();

        // Добавление команды в очередь
        public void AddCommand(ICommand command)
        {
            _commands.Add(command);
        }

        // Выполнение всех команд
        public void ExecuteCommands()
        {
            Console.WriteLine("Выполнение команд...");
            foreach (var command in _commands)
            {
                command.Execute();
            }
            _commands.Clear(); // Очистка очереди после выполнения
        }
    }

    // Клиент (Client)
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем получателя (персонаж)
            GameCharacter character = new GameCharacter();

            // Создаем команды
            ICommand jumpCommand = new JumpCommand(character);
            ICommand attackCommand = new AttackCommand(character);
            ICommand defendCommand = new DefendCommand(character);

            // Создаем инициатора (контроллер)
            GameController controller = new GameController();

            // Добавляем команды в очередь
            controller.AddCommand(jumpCommand);
            controller.AddCommand(attackCommand);
            controller.AddCommand(defendCommand);

            // Выполняем команды
            controller.ExecuteCommands();

            // Повторная очередь действий
            controller.AddCommand(defendCommand);
            controller.AddCommand(jumpCommand);
            controller.ExecuteCommands();
        }
    }
}