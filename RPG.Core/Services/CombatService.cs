using RPG.Core.Entities.Characters;
using RPG.Core.Entities.Monsters;
using RPG.Core.Interfaces;

namespace RPG.Core.Services;

public class CombatService
{
    private readonly DiceRollerService _roller;
    private readonly DamageCalculatorService _damage;
    public CombatService()
    {
        _roller = new DiceRollerService();
        _damage = new DamageCalculatorService();
    }

    public void ExecuteTurn(ICombatant player, ICombatant enemy)
    {
        int roll = _roller.Roll6();
        if (player is Character character && enemy is Monster monster)
        {
            if (roll > 3)
            {
                if (roll == 6)
                {
                    //crit var for testing, remove and place logic into TakeDamage() later
                    int crit = _damage.CalculateCriticalDamage(character);
                    monster.TakeDamage(crit);
                    //console.writeline below for testing, remove later
                    Console.WriteLine($"Critical hit for {crit} damage!");
                }
                else
                {
                    int damage = _damage.CalculateDamage(character, roll);
                    monster.TakeDamage(damage);
                    Console.WriteLine($"Hit for {damage} damage!");
                }
            }
            else
            {
                character.TakeDamage(monster.DealDamage());
            }
            if (monster.IsDead)
            {
                character.EarnExp(monster.ExperienceAwarded);
                if (character.ExperienceToLevel <= 0)
                {
                    character.LevelUp(30, 2, 2, 2, 2, 2);
                }
            }
        }
    }
}
