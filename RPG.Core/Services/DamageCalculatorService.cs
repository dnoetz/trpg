using RPG.Core.Entities.Characters;

namespace RPG.Core.Services;

public class DamageCalculatorService
{
    private readonly DiceRollerService _roller;

    public DamageCalculatorService(DiceRollerService roller)
    {
        _roller = roller;
    }

    public int CalculateCriticalDamage(Character player, string abilityName)
    {
        return Convert.ToInt32(player.DealDamage(abilityName) * 1.5);
    }

    public int CalculateDamage(Character player, int rollValue, string abilityName)
    {
        return player.DealDamage(abilityName) + (rollValue);
    }


}
