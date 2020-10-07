using System.Linq;
using System.Threading.Tasks;

namespace Q2
{
    public class BattleArena
    {
        readonly Monster[] monsters;

        public BattleArena(Monster[] monsters)
        {
            this.monsters = monsters;
        }

        public async Task Battle()
        {
            foreach (var group in monsters.GroupBy(x => x.Score))
            {
                if (group.Count() == 1)
                {
                    continue;
                }

                await BattleCore(group.ToArray());
            }

            if (monsters.GroupBy(x => x.Score).Any(x => x.Count() >= 2))
            {
                await Battle();
            }
        }

        static async Task BattleCore(Monster[] targets)
        {
            for (var i = 1; i < targets.Length; i++)
            {
                var monster1 = targets[i - 1];
                var monster2 = targets[i];

                var result = await BattleApiClient.Get(monster1, monster2);

                if (result.Winner == monster1.Name)
                {
                    monster1.Score = monster2.Score + 1;
                }
                else if (result.Winner == monster2.Name)
                {
                    monster2.Score = monster1.Score + 1;
                }
            }
        }

    }
}
