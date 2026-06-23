namespace RPG.Core.Entities.Monsters;

public abstract class Monster
{
    public int Id { get; protected set; }
    public string Name { get; protected set; }
    public int MaxHitpoints { get; protected set; }
    public int CurrentHitpoints { get; protected set; }
    public int ExperienceAwarded { get; protected set; }
    public bool IsBoss { get; protected set; } = false;

    public Monster(string name)
    {
        Name = name;
    }

    public void TakeDamage(int damage)
    {
        CurrentHitpoints -= damage;
        if (CurrentHitpoints < 0)
        {
            CurrentHitpoints = 0;
        }
    }
}
