using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lernpunkte_Rechner_Gothic_2_DNdR.Items;
using Lernpunkte_Rechner_Gothic_2_DNdR.Skills;

namespace Lernpunkte_Rechner_Gothic_2_DNdR;

[Serializable]
public class Player
{
    public String Name { get; private set; }
    public int LearnPointsSpent { get; set; }

    // gets increased for example by drinking a perma-boni-potion
    public int LifePointsBonus { get; set; }

    private List<Skill> Skills { get; set; }
    private List<Ability> Abilities { get; set; }

    private List<Item> Items { get; set; }

    public Player(String name)
    {
        Name = name;
        LearnPointsSpent = 0;
        LifePointsBonus = 0;

        /* Fähigkeiten und Kampffähigkeiten */

        Skills = new List<Skill>();
        Skills.Add(new Skill(this, "Mana", 10, 200));
        Skills.Add(new Skill(this, "Stärke", 10, 200));
        Skills.Add(new Skill(this, "Geschick", 10, 200));

        FightingSkill einhand = new FightingSkill(this, "Einhand", 10, 100, null);
        FightingSkill zweihand = new FightingSkill(this, "Zweihand", 10, 100, einhand);
        einhand.Counterpart = zweihand;
        FightingSkill bogen = new FightingSkill(this, "Bogen", 10, 100, null);
        FightingSkill armbrust = new FightingSkill(this, "Armbrust", 10, 100, bogen);
        bogen.Counterpart = armbrust;

        Skills.Add(einhand);
        Skills.Add(zweihand);
        Skills.Add(bogen);
        Skills.Add(armbrust);

        /* Talente */
        Abilities = new List<Ability>();

        // Jagdtalente
        Abilities.Add(new Ability(this, "Felle_nehmen", 5, null));
        Abilities.Add(new Ability(this, "Blutfliegenstachel", 1, "Felle_nehmen"));
        Abilities.Add(new Ability(this, "Blutfliegenflügel", 1, null));
        Abilities.Add(new Ability(this, "Sekret_aus_Stachel_entnehmen", 1, null));
        Abilities.Add(new Ability(this, "Zähne_reißen", 3, null));
        Abilities.Add(new Ability(this, "Klauen_hacken", 3, null));
        Abilities.Add(new Ability(this, "Zangen_nehmen", 1, null));
        Abilities.Add(new Ability(this, "Horn_des_Drachensnappers", 1, null));
        Abilities.Add(new Ability(this, "Crawlerplatten_nehmen", 3, null));
        Abilities.Add(new Ability(this, "Horn_des_Schattenläufers", 3, null));
        Abilities.Add(new Ability(this, "Herz_nehmen", 3, null));
        Abilities.Add(new Ability(this, "Drachenschuppen_nehmen", 3, null));
        Abilities.Add(new Ability(this, "Drachenblut_zapfen", 3, null));
        Abilities.Add(new Ability(this, "Feuerzunge", 1, null));
        Abilities.Add(new Ability(this, "Häute_von_Reptilien_nehmen", 3, null));

        // Diebestalente
        Abilities.Add(new Ability(this, "Schleichen", 5, null));
        Abilities.Add(new Ability(this, "Schlösser_knacken", 10, null));
        Abilities.Add(new Ability(this, "Taschendiebstahl", 10, null));

        // Alchemie
        Abilities.Add(new Ability(this, "Essenz_der_Heilung", 1, null));
        Abilities.Add(new Ability(this, "Extrakt_der_Heilung", 3, "Essenz_der_Heilung"));
        Abilities.Add(new Ability(this, "Elixier_der_Heilung", 5, "Extrakt_der_Heilung"));
        Abilities.Add(new Ability(this, "Elixier_des_Lebens", 10, "Elixier_der_Heilung"));
        Abilities.Add(new Ability(this, "Mana_Essenz", 1, null));
        Abilities.Add(new Ability(this, "Mana_Extrakt", 3, "Mana_Essenz"));
        Abilities.Add(new Ability(this, "Mana_Elixier", 5, "Mana_Extrakt"));
        Abilities.Add(new Ability(this, "Elixier_des_Geistes", 10, "Mana_Elixier"));
        Abilities.Add(new Ability(this, "Elixier_der_Stärke", 20, null));
        Abilities.Add(new Ability(this, "Elixier_der_Geschicklichkeit", 20, null));
        Abilities.Add(new Ability(this, "Trank_der_Geschwindigkeit", 5, null));

        // Sprache der Erbauer
        Abilities.Add(new Ability(this, "Sprache_der_Bauern", 5, null));
        Abilities.Add(new Ability(this, "Sprache_der_Krieger", 10, "Sprache_der_Bauern"));
        Abilities.Add(new Ability(this, "Sprache_der_Priester", 15, "Sprache_der_Krieger"));

        // Irrlicht-Talente
        Abilities.Add(new Ability(this, "Fernkampfwaffen_und_Munition", 1, null));
        Abilities.Add(new Ability(this, "Runen_und_Spruchrollen", 3, null));
        Abilities.Add(new Ability(this, "Ringe_und_Amulette", 4, null));
        Abilities.Add(new Ability(this, "Pflanzen_und_Nahrung", 5, null));
        Abilities.Add(new Ability(this, "Tränke", 5, null));
        Abilities.Add(new Ability(this, "Sonstiges", 2, null));

        // Sonstige Talente
        Abilities.Add(new Ability(this, "Goldhacken_lernen", 2, null));

        /* Magie-Talente */

        // Runenkreise
        Abilities.Add(new Ability(this, "Kreis_1", 5, null));
        Abilities.Add(new Ability(this, "Kreis_2", 5, "Kreis_1"));
        Abilities.Add(new Ability(this, "Kreis_3", 5, "Kreis_2"));
        Abilities.Add(new Ability(this, "Kreis_4", 5, "Kreis_3"));
        Abilities.Add(new Ability(this, "Kreis_5", 5, "Kreis_4"));
        Abilities.Add(new Ability(this, "Kreis_6", 5, "Kreis_5"));

        // Kreis 1
        Abilities.Add(new Ability(this, "Blitz", 3, "Kreis_1"));
        Abilities.Add(new Ability(this, "Feuerpfeil", 5, "Kreis_1"));
        Abilities.Add(new Ability(this, "Goblin_Skelett_erschaffen", 3, "Kreis_1"));
        Abilities.Add(new Ability(this, "Leichte_Wunden_heilen", 3, "Kreis_1"));
        Abilities.Add(new Ability(this, "Licht", 1, "Kreis_1"));

        // Kreis 2
        Abilities.Add(new Ability(this, "Eislanze", 5, "Kreis_2"));
        Abilities.Add(new Ability(this, "Eispfeil", 5, "Kreis_2"));
        Abilities.Add(new Ability(this, "Feuerball", 10, "Kreis_2"));
        Abilities.Add(new Ability(this, "Schlaf", 5, "Kreis_2"));
        Abilities.Add(new Ability(this, "Windfaust", 5, "Kreis_2"));
        Abilities.Add(new Ability(this, "Windhose", 5, "Kreis_2"));
        Abilities.Add(new Ability(this, "Wolf_rufen", 5, "Kreis_2"));

        // Kreis 3
        Abilities.Add(new Ability(this, "Angst", 5, "Kreis_3"));
        Abilities.Add(new Ability(this, "Eisblock", 10, "Kreis_3"));
        Abilities.Add(new Ability(this, "Geysir", 10, "Kreis_3"));
        Abilities.Add(new Ability(this, "Kleiner_Feuersturm", 15, "Kreis_3"));
        Abilities.Add(new Ability(this, "Kugelblitz", 10, "Kreis_3"));
        Abilities.Add(new Ability(this, "Mittlere_Wunden_heilen", 5, "Kreis_3"));
        Abilities.Add(new Ability(this, "Skelett_erschaffen", 10, "Kreis_3"));
        Abilities.Add(new Ability(this, "Unwetter", 5, "Kreis_3"));

        // Kreis 4
        Abilities.Add(new Ability(this, "Blitzschlag", 5, "Kreis_4"));
        Abilities.Add(new Ability(this, "Golem_erwecken", 15, "Kreis_4"));
        Abilities.Add(new Ability(this, "Großer_Feuerball", 10, "Kreis_4"));
        Abilities.Add(new Ability(this, "Untote_vernichten", 10, "Kreis_4"));
        Abilities.Add(new Ability(this, "Wasserfaust", 10, "Kreis_4"));

        // Kreis 5
        Abilities.Add(new Ability(this, "Dämon_beschwören", 20, "Kreis_5"));
        Abilities.Add(new Ability(this, "Eiswelle", 20, "Kreis_5"));
        Abilities.Add(new Ability(this, "Großer_Feuersturm", 10, "Kreis_5"));
        Abilities.Add(new Ability(this, "Schwere_Wunden_heilen", 10, "Kreis_5"));

        // Kreis 6
        Abilities.Add(new Ability(this, "Armee_der_Finsternis", 20, "Kreis_6"));
        Abilities.Add(new Ability(this, "Feuerregen", 20, "Kreis_6"));
        Abilities.Add(new Ability(this, "Monster_schrumpfen", 20, "Kreis_6"));
        Abilities.Add(new Ability(this, "Todeshauch", 20, "Kreis_6"));
        Abilities.Add(new Ability(this, "Todeswelle", 20, "Kreis_6"));

        // Paladin-Runen
        Abilities.Add(new Ability(this, "Böses_vertreiben", 20, null));
        Abilities.Add(new Ability(this, "Heiliger_Pfeil", 20, null));
        Abilities.Add(new Ability(this, "Heiliges_Licht", 0, null));
        Abilities.Add(new Ability(this, "Große_Wundheilung", 20, null));
        Abilities.Add(new Ability(this, "Mittlere_Wundheilung", 20, null));
        Abilities.Add(new Ability(this, "Kleine_Wundheilung", 20, null));

        /* Schwerter */

        Abilities.Add(new Ability(this, "Schwert", 2, null));
        Abilities.Add(new Ability(this, "Edles_Schwert", 2, "Schwert"));
        Abilities.Add(new Ability(this, "Edles_Langschwert", 6, "Edles_Schwert"));
        Abilities.Add(new Ability(this, "Rubinklinge", 8, "Edles_Langschwert"));
        Abilities.Add(new Ability(this, "El_Bastardo", 10, "Rubinklinge"));

        Abilities.Add(new Ability(this, "Erz-Langschwert", 4, "Schwert"));
        Abilities.Add(new Ability(this, "Erz-Bastardschwert", 6, "Schwert"));
        Abilities.Add(new Ability(this, "Erz-Schlachtklinge", 8, "Schwert"));
        Abilities.Add(new Ability(this, "Erz-Drachentöter", 10, null));

        Abilities.Add(new Ability(this, "Erz-Zweihänder", 4, "Schwert"));
        Abilities.Add(new Ability(this, "Schwerer_Erz-Zweihänder", 6, "Schwert"));
        Abilities.Add(new Ability(this, "Schwere_Erz-Schlachtklinge", 8, "Schwert"));
        Abilities.Add(new Ability(this, "Großer_Erz-Drachentöter", 10, null));

        /* Gegenstände */

        Items = new List<Item>();

        // Tränke
        Items.Add(new SkillBonusItem(this, "Elixier_der_Stärke", "Stärke + 5", "Stärke", 5));
        Items.Add(new SkillBonusItem(this, "Elixier_des_Geschicks", "Geschick + 5", "Geschick", 5));
        Items.Add(new SkillBonusItem(this, "Elixier_des_Geistes", "Mana + 5", "Mana", 5));

        Items.Add(new SkillBonusItem(this, "Essenz_des_Geistes", "Mana + 3", "Mana", 3));
        Items.Add(new SkillBonusItem(this, "Trank_aus_Drachenei-Sekret", "Stärke + 3", "Stärke", 3));
        Items.Add(new DieTraenenInnos(this));
        Items.Add(new EmbarlaFigasto(this));

        // Pflanzen
        Items.Add(new SkillBonusItem(this, "25_Äpfel", "Stärke + 1", "Stärke", 1));
        Items.Add(new SkillBonusItem(this, "50_Dunkelpilze", "Mana + 5", "Mana", 5));
        Items.Add(new SkillBonusItem(this, "Drachenwurzel", "Stärke + 1", "Stärke", 1));
        Items.Add(new SkillBonusItem(this, "Goblinbeere", "Geschick + 1", "Geschick", 1));

        // Essen
        Items.Add(new SkillBonusItem(this, "dampfende_Fleischsuppe", "Stärke + 1", "Stärke", 1));

        // Beten (wird behandelt als Item)
        Items.Add(new SkillBonusItem(this, "Beten_für_Stärke", "Stärke + 1", "Stärke", 1));
        Items.Add(new SkillBonusItem(this, "Beten_für_Geschick", "Geschick + 1", "Geschick", 1));
        Items.Add(new SkillBonusItem(this, "Beten_für_Mana", "Mana + 1", "Mana", 1));
    }

    public int CalcLevel()
    {
        int level = LearnPointsSpent / 10;
        if (LearnPointsSpent % 10 != 0) level++;
        return level;
    }

    public int CalcExperienceNeeded() => CalcLevel() * CalcLevel() * 250 + CalcLevel() * 250;

    public int CalcLifePoints() => 40 + CalcLevel() * 12 + LifePointsBonus;

    public void TrainSkill(String name, int levelGain) => GetSkillByName(name).Train(levelGain);

    public void TrainAbility(String name) => GetAbilityByName(name).Train();

    public void ConsumeItem(String name) => GetItemByName(name).Consume();

    public Skill GetSkillByName(String name) => Skills.SingleOrDefault(s => s.Name.Equals(name));

    public Ability GetAbilityByName(String name) => Abilities.SingleOrDefault(a => a.Name.Equals(name));

    public Item GetItemByName(String name) => Items.SingleOrDefault(i => i.Name.Equals(name));

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"Ausgegebene Lernpunkte : {LearnPointsSpent}\n");
        sb.Append($"Benötigte Stufe        : {CalcLevel()}\n");
        sb.Append($"Benötigte Erfahrung    : {CalcExperienceNeeded()}\n");
        sb.Append($"Basis-Lebensenergie    : {CalcLifePoints()}\n\n");

        sb.Append($"Stärke   : {GetSkillByName("Stärke").Level}\n");
        sb.Append($"Geschick : {GetSkillByName("Geschick").Level}\n");
        sb.Append($"Mana     : {GetSkillByName("Mana").Level}\n\n");

        sb.Append("Erlernte Fähigkeiten:\n");
        foreach (Ability ability in Abilities) if (ability.Learned) sb.Append(ability + "\n");

        return sb.ToString();
    }
}

