using System;
using System.Linq;
using System.Threading.Tasks;

namespace Q2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException($"{nameof(input)}={input}");
            }

            var splited = input.Split(' ');
            if (splited.Length == 0)
            {
                throw new ArgumentException($"{nameof(input)}={input}");
            }

            var monsters = splited.Select(x => new Monster(x)).ToArray();
            var arena = new BattleArena(monsters);
            await arena.Battle();

            var ranking = string.Join(" ", monsters.OrderByDescending(x => x.Score).Select(x => x.Name));
            Console.WriteLine(ranking);
        }
    }
}
