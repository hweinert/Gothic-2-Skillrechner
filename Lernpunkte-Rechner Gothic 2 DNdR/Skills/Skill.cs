using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lernpunkte_Rechner_Gothic_2_DNdR.Skills;

[Serializable]
public class Skill
{
    public Player Player { get; private set; }
    public string Name { get; private set; }
    public int Level { get; set; }
    public int MaxLevel { get; private set; }

    public Skill(Player player, string name, int level, int maxLevel)
    {
        Player = player;
        Name = name;
        Level = level;
        MaxLevel = maxLevel;
    }

    public int CalculateLpCosts(int levelGain)
    {
        return (1 + Level / 30) * levelGain;
    }

    public String MakeLpCostsString()
    {
        int for1Lp = CalculateLpCosts(1);
        int for5Lp = CalculateLpCosts(5);
        return $"Kosten: {for1Lp} bzw. {for5Lp} Lernpunkte";
    }

    public virtual void Train(int levelGain)
    {
        if (Level < MaxLevel)
        {
            int lpCosts = CalculateLpCosts(levelGain);
            Player.LearnPointsSpent += lpCosts;
            Level += levelGain;
            Global.Logger.Log($"{Name} wurde um {levelGain} gesteigert auf {Level} für {lpCosts} LP");
        }
        else
        {
            Global.Logger.Log($"Es gibt keinen Lehrer, der {Name} auf mehr als {MaxLevel} erhöhen kann.");
        }
    }

    public void TrainWithoutCosts(int levelGain)
    {
        Level += levelGain;
        Global.Logger.Log($"{Name} wurde um {levelGain} gesteigert auf {Level} (kostenlos).");
    }
}
