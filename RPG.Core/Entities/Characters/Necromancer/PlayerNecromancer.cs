using RPG.Core.Interfaces;

namespace RPG.Core.Entities.Characters.Necromancer;

public class PlayerNecromancer : Character
{
    public List<ICombatAbility> Abilities { get; } = 
        [
            new AbilityNecrosis(),
            new AbilityReapersMark()
        ];
    public override int MainStat => Intelligence;
    
    
    public PlayerNecromancer(string name) : base(name)
    {
        MaxHitpoints = 100;
        CurrentHitpoints = MaxHitpoints;
        Agility = 2;
        Intelligence = 11;
        Strength = 1;
        Vitality = 3;
        Charisma = 3;
    }

    public override int DealDamage()
    {
        return Abilities[0].BaseDamage;
    }

}
