using RPG.Core.Interfaces;

namespace RPG.Core.Entities.Characters.Necromancer;

public class AbilitySummonDead : IUtilityAbility
{
    public string Name { get; }
    public string Description { get; }

    public AbilitySummonDead()
    {
        Name = "Raise Undead";
        Description =
            "Use dark magic to bind the bones of the fallen, raising an undead ally to serve you until the end of combat.";
    }
}