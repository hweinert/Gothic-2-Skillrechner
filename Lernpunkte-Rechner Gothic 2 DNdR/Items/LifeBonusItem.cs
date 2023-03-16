using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lernpunkte_Rechner_Gothic_2_DNdR.Items;

[Serializable]
public class LifeBonusItem : Item
{
    public int Bonus;

    public LifeBonusItem(Player player, String name, String description, int bonus) : base(player, name, description)
    {
        Bonus = bonus;
    }

    override public void Impact()
    {
        Player.LifePointsBonus += Bonus;
    }
}
