using RPG.Core.Entities.Characters;
using RPG.Core.Entities.Monsters;
using RPG.Core.Interfaces;

namespace RPG.Core.Services;

public class CombatService
{
    public void ExecuteTurn(ICombatant player, ICombatant monster)
    {
        Random dice = new Random();
        int roll = dice.Next(7);
        if (roll > 3)
        {
            monster.TakeDamage(player.DealDamage());
        }
        else
        {
            player.TakeDamage(monster.DealDamage());
        }
    }

}
