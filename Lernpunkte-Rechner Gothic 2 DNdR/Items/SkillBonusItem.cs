using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lernpunkte_Rechner_Gothic_2_DNdR.Items;

[Serializable]
public class SkillBonusItem : Item
{
    public String SkillName;
    public int Bonus;

    public SkillBonusItem(Player player, String name, String description, String skillName, int bonus) : base(player, name, description)
    {
        SkillName = skillName;
        Bonus = bonus;
    }

    public override void Impact()
    {
        Player.GetSkillByName(SkillName).TrainWithoutCosts(Bonus);
    }
}
