using RPG.Core.Interfaces;

namespace RPG.Core.Entities.Characters.Necromancer;

public class AbilityReapersMark : ICombatAbility
{
    public string Name { get; }
    public string Description { get; }
    public string DamageType { get; }
    public int BaseDamage { get; }

    public AbilityReapersMark()
    {
        Name = "Reaper's Mark";
        Description = "Mark a target for your undead summons, dealing damage for each undead under your command";
        DamageType = "Physical";
        BaseDamage = 7;
    }

    public int Execute(Character player)
    {
        if (player is PlayerNecromancer necromancer)
        {
            return BaseDamage * necromancer.UndeadRaised;
        }

        return 0;
    }
}