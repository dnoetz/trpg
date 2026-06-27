namespace RPG.Core.Entities.Monsters;

public class Goblin : Monster
{
    public Goblin(string name) : base(name)
    {
        MaxHitpoints = 150;
        CurrentHitpoints = MaxHitpoints;
        ExperienceAwarded = 13;
    }

}
