using RPG.Core.Entities.Characters;
using RPG.Core.Entities.Monsters;

namespace RPG.Core.Services;

public class CombatService
{
    private readonly DiceRollerService _roller;
    private readonly DamageCalculatorService _damage;
    private readonly ExperienceService _exp;
    public CombatService()
    {
        _roller = new DiceRollerService();
        _damage = new DamageCalculatorService(_roller);
        _exp = new ExperienceService();
    }

    public void ExecuteCombatTurn(Character player, Monster enemy)
    {
        int initiative = _roller.Roll20();
        int roll = _roller.Roll6();
            if (initiative > 5)
            {
                if (roll == 6)
                {
                    //crit var for testing, remove and place logic into TakeDamage() later
                    int crit = _damage.CalculateCriticalDamage(player);
                    enemy.TakeDamage(crit);
                    //console.WriteLine below for testing, remove later
                    Console.WriteLine($"Critical hit for {crit} damage!");
                }
                else
                {
                    int damage = _damage.CalculateDamage(player, roll);
                    enemy.TakeDamage(damage);
                    Console.WriteLine($"Hit for {damage} damage!");
                }
            }
            else
            {
                player.TakeDamage(enemy.DealDamage());
            }
            if (enemy.IsDead)
            {
                _exp.AwardExp(player, enemy);
                if (player.ExperienceToLevel <= 0)
                {
                    player.LevelUp(30, 2, 2, 2, 2, 2);
                }
            }
    }
}
