using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lernpunkte_Rechner_Gothic_2_DNdR.Items;

[Serializable]
public class AbilityBonusItem : Item
{
    public String AbilityName;
    public int Bonus;

    public AbilityBonusItem(Player player, String name, String description, String abilityName, int bonus) : base(player, name, description)
    {
        AbilityName = abilityName;
        Bonus = bonus;
    }

    public override void Impact()
    {
        Player.GetAbilityByName(AbilityName).Train();
    }
}
