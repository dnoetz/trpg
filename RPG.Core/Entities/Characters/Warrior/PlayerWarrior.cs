namespace RPG.Core.Entities.Characters.Warrior;

public class PlayerWarrior : Character
{
    public PlayerWarrior(string name) : base(name)
    {
        MaxHitpoints = 200;
        CurrentHitpoints = MaxHitpoints;
        Agility = 3;
        Intelligence = 1;
        Strength = 8;
        Vitality = 6;
        Charisma = 2;
    }

    override public int DealDamage()
    {
        return 40;
    }
}
