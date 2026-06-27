namespace RPG.Core.Interfaces;

public interface ICombatant
{
    string Name { get; }
    int CurrentHitpoints { get; }
    int MaxHitpoints { get; }
    bool IsDead { get; }

    void TakeDamage(int damage);
    int DealDamage();
}
