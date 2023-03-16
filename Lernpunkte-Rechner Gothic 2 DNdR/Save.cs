using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lernpunkte_Rechner_Gothic_2_DNdR;

[Serializable]
internal class Save
{
    public Player Player { get; private set; }
    public Logger Logger { get; private set; }

    public Save(Player player, Logger logger)
    {
        Player = player;
        Logger = logger;
    }
}

