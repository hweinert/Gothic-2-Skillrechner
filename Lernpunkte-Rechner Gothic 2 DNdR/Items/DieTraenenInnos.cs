using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lernpunkte_Rechner_Gothic_2_DNdR.Items;

[Serializable]
public class DieTraenenInnos : Item
{
    public DieTraenenInnos(Player player)
    : base(player, "Die_Tränen_Innos", "Stärke und Geschick + 5")
    {
    }

    public override void Impact()
    {
        Player.GetSkillByName("Stärke").TrainWithoutCosts(5);
        Player.GetSkillByName("Geschick").TrainWithoutCosts(5);
    }
}