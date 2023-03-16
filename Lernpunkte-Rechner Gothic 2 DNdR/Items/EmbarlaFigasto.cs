using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lernpunkte_Rechner_Gothic_2_DNdR.Items;

[Serializable]
public class EmbarlaFigasto : Item
{
    public EmbarlaFigasto(Player player)
    : base(player, "Embarla_Figasto", "Stärke oder Geschick + 15")
    {
    }

    public override void Impact()
    {
        if (Player.GetSkillByName("Stärke").Level >= Player.GetSkillByName("Geschick").Level)
            Player.GetSkillByName("Stärke").TrainWithoutCosts(15);
        else Player.GetSkillByName("Geschick").TrainWithoutCosts(15);
    }
}
