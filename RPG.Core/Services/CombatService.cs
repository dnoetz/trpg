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
        if (roll > 3)
        {
            enemy.TakeDamage(player.DealDamage());
        }
        else
        {
            player.TakeDamage(enemy.DealDamage());
        }
        if (enemy.IsDead && player is Character character && enemy is Monster monster)
        {
            character.EarnExp(monster.ExperienceAwarded);
            if (character.ExperienceToLevel <= 0)
            {
                character.LevelUp();
            }
        }
    }

}
