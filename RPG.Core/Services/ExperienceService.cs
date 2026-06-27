using RPG.Core.Entities.Characters;
using RPG.Core.Entities.Monsters;

namespace RPG.Core.Services;

public class ExperienceService
{
    public void AwardExp(Character player, Monster monster)
    {
        player.EarnExp(monster.ExperienceAwarded);
    }

    public void IncreaseLevel(Character player)
    {
        player.LevelUp(30, 2, 2, 2, 2, 2);
    }

}
