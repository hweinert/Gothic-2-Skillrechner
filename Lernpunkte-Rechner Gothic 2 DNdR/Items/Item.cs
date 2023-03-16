using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lernpunkte_Rechner_Gothic_2_DNdR.Items;

[Serializable]
public abstract class Item
{
    public Player Player { get; set; }
    public String Name { get; private set; }
    public String Description { get; private set; }
    public int Consumed { get; private set; }

    public Item(Player player, String name, String description)
    {
        Player = player;
        Name = name;
        Description = description;
    }

    public void Consume()
    {
        Impact();
        Consumed++;
    }

    public abstract void Impact();

    public override string ToString() => "[" + Consumed + "]     " + Name.Replace("_", " ") + "  (" + Description + ")";
}
