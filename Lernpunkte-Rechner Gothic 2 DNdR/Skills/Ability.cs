using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lernpunkte_Rechner_Gothic_2_DNdR;

namespace Lernpunkte_Rechner_Gothic_2_DNdR.Skills;

[Serializable]
public class Ability
{
    public Player Player { get; private set; }
    public String Name { get; private set; }
    public int LearnPointsNeeded { get; private set; }
    public String? NameOfPrecedingAbility { get; private set; }
    public Boolean Learned { get; private set; }

    public Ability(Player player, String name, int learnPointsNeeded, String? nameOfPrecedingAbility)
    {
        Player = player;
        Name = name;
        LearnPointsNeeded = learnPointsNeeded;
        NameOfPrecedingAbility = nameOfPrecedingAbility;
    }

    public void Train()
    {
        if (Learned)
        {
            Global.Logger.Log($"{Name.Replace("_", " ")} wurde bereits erlernt.");
            return;
        }

        if (NameOfPrecedingAbility != null && !Player.GetAbilityByName(NameOfPrecedingAbility).Learned)
        {
            Global.Logger.Log($"{NameOfPrecedingAbility.Replace("_", " ")} muss hierzu erst erlernt werden.");
            return;
        }

        Player.LearnPointsSpent += LearnPointsNeeded;
        Learned = true;
        Global.Logger.Log($"{Name.Replace("_", " ")} wurde erlernt für {LearnPointsNeeded} LP.");
    }

    public override string ToString()
    {
        return Name;
    }
}

