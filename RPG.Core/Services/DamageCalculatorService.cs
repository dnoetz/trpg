using RPG.Core.Entities.Characters;

namespace RPG.Core.Services;

public class DamageCalculatorService
{
    private readonly DiceRollerService _roller;

    public DamageCalculatorService()
    {
        _roller = new DiceRollerService();
    }

    public int CalculateCriticalDamage(Character player)
    {
        return player.DealDamage() + (player.MainStat * 2);
    }

    public int CalculateDamage(Character player, int rollValue)
    {
        return player.DealDamage() + (rollValue * 2);
    }


}
