using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lernpunkte_Rechner_Gothic_2_DNdR.Skills;

[Serializable]
public class FightingSkill : Skill
{
    public Skill Counterpart { get; set; }

    public FightingSkill(Player player, String name, int level, int maxLevel, Skill counterpart)
    : base(player, name, level, maxLevel)
    {
        Counterpart = counterpart;
    }

    public override void Train(int levelGain)
    {
        if (Level >= MaxLevel)
        {
            Global.Logger.Log($"Es gibt keinen Lehrer, der {Name} um mehr als {MaxLevel} erhöhen kann.");
            return;
        }

        int lpCosts = CalculateLpCosts(levelGain);
        Player.LearnPointsSpent += lpCosts;
        Level += levelGain;
        Global.Logger.Log($"{Name} wurde um {levelGain} auf {Level} erhöht für {lpCosts} Lernpunkte.");

        if (Level - levelGain >= 30 && Level - levelGain - 30 >= Counterpart.Level)
        {
            Counterpart.Level += levelGain;
            Global.Logger.Log($"{Counterpart.Name} wurde um {levelGain} mitverbessert.");
        }
    }
}
