namespace RPG.Core.Entities;

public class PlayerWarrior : Character
{
    public PlayerWarrior(string name) : base(name)
    {
        MaxHitpoints = 200;
        CurrentHitpoints = MaxHitpoints;
        Agility = 4;
        Intelligence = 1;
        Strength = 8;
        Vitality = 5;
        Charisma = 2;
    }

}
