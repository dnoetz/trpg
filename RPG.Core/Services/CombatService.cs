using RPG.Core.Entities.Characters;
using RPG.Core.Entities.Monsters;
using RPG.Core.Interfaces;

namespace RPG.Core.Services;

public class CombatService
{
    private readonly DiceRollerService _roller;
    public CombatService()
    {
        _roller = new DiceRollerService();
    }

    public void ExecuteTurn(ICombatant player, ICombatant enemy)
    {
        int roll = _roller.Roll6();
        if (player is Character character && enemy is Monster monster)
        {
            if (roll > 3)
            {
                if (roll > 4)
                {
                    //move damage calculation into separate DamageCalculatorService to keep logic thin
                    //crit var for testing, remove and place logic into TakeDamage() later
                    int crit = character.MainStat + character.DealDamage();
                    monster.TakeDamage(crit);
                    //console.writeline below for testing, remove later
                    Console.WriteLine($"Critical hit for {crit} damage!");
                }
                else{
                    monster.TakeDamage(character.DealDamage());
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
                    character.LevelUp();
                }
            }
        }
    }
}
