using RPG.Core.Entities.Characters;
using RPG.Core.Entities.Monsters;
using RPG.Core.Interfaces;

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

    public void ExecuteCombatTurn(ICombatant player, ICombatant enemy)
    {
        int initiative = _roller.Roll20();
        int roll = _roller.Roll6();
        if (player is Character character && enemy is Monster monster)
        {
            if (initiative > 5)
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
                _exp.AwardExp(character, monster);
                if (character.ExperienceToLevel <= 0)
                {
                    character.LevelUp(30, 2, 2, 2, 2, 2);
                }
            }
        }
    }
}
