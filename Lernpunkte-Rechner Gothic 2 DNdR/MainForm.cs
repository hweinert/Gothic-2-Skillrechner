using Lernpunkte_Rechner_Gothic_2_DNdR.Skills;
using System.CodeDom;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lernpunkte_Rechner_Gothic_2_DNdR
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void ZurücksetzenButton_Click(object sender, EventArgs e)
        {
            Global.Player = new Player("standard");
            Global.Logger = new Logger();
            RefreshAll();
            ProtokollTextBox.Text = "";
        }

        private void SpeichernButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog d = new SaveFileDialog())
            {
                if (d.ShowDialog() == DialogResult.OK)
                {
                    Stream fileStream = d.OpenFile();
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fileStream, new Save(Global.Player, Global.Logger));
                    fileStream.Close();
                    MessageBox.Show("Die Datei wurde gespeichert.");
                }
            }
        }

        private void LadenButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog d = new OpenFileDialog())
            {
                if (d.ShowDialog() == DialogResult.OK)
                {
                    Stream fileStream = d.OpenFile();
                    BinaryFormatter formatter = new BinaryFormatter();
                    Save save = (Save)formatter.Deserialize(fileStream);
                    Global.Player = save.Player;
                    Global.Logger = save.Logger;
                    fileStream.Close();
                }
            }

            ProtokollTextBox.Text = Global.Logger.FetchOldMessages();
            ProtokollTextBox.ScrollToCaret();
            RefreshAll();
        }

        #region skills

        private void Staerke1Button_Click(object sender, EventArgs e)
        {
            Global.Player.TrainSkill("Stärke", 1);
            RefreshTopSkillLog();
        }

        private void Stärke5Button_Click(object sender, EventArgs e)
        {
            Global.Player.TrainSkill("Stärke", 5);
            RefreshTopSkillLog();
        }

        private void Geschick1Button_Click(object sender, EventArgs e)
        {
            Global.Player.TrainSkill("Geschick", 1);
            RefreshTopSkillLog();
        }

        private void Geschick5Button_Click(object sender, EventArgs e)
        {
            Global.Player.TrainSkill("Geschick", 5);
            RefreshTopSkillLog();
        }

        private void Mana1Button_Click(object sender, EventArgs e)
        {
            Global.Player.TrainSkill("Mana", 1);
            RefreshTopSkillLog();
        }

        private void Mana5Button_Click(object sender, EventArgs e)
        {
            Global.Player.TrainSkill("Mana", 5);
            RefreshTopSkillLog();
        }

        private void Einhand1Button_Click(object sender, EventArgs e)
        {
            Global.Player.TrainSkill("Einhand", 1);
            RefreshTopSkillLog();
        }

        private void Einhand5Button_Click(object sender, EventArgs e)
        {
            Global.Player.TrainSkill("Einhand", 5);
            RefreshTopSkillLog();
        }

        private void Zweihand1Button_Click(object sender, EventArgs e)
        {
            Global.Player.TrainSkill("Zweihand", 1);
            RefreshTopSkillLog();
        }

        private void Zweihand5Button_Click(object sender, EventArgs e)
        {
            Global.Player.TrainSkill("Zweihand", 5);
            RefreshTopSkillLog();
        }

        private void Bogen1Button_Click(object sender, EventArgs e)
        {
            Global.Player.TrainSkill("Bogen", 1);
            RefreshTopSkillLog();
        }

        private void Bogen5Button_Click(object sender, EventArgs e)
        {
            Global.Player.TrainSkill("Bogen", 5);
            RefreshTopSkillLog();
        }

        private void Armbrust1Button_Click(object sender, EventArgs e)
        {
            Global.Player.TrainSkill("Armbrust", 1);
            RefreshTopSkillLog();
        }

        private void Armbrust5Button_Click(object sender, EventArgs e)
        {
            Global.Player.TrainSkill("Armbrust", 5);
            RefreshTopSkillLog();
        }

        #endregion

        #region abilities

        private void ReactOnAbilityClick(CheckBox cb, Ability ability)
        {
            if (ability.Learned) return;
            ability.Train();
            if (ability.Learned)
            {
                cb.Checked = true;
                cb.Enabled = false;
            }
            RefreshAllAbilities();
        }

        private void ReactOnAbilityClick(CheckBox cb, String abilityString)
        {
            Ability ability = Global.Player.GetAbilityByName(abilityString);

            if (ability.Learned) return;
            ability.Train();
            if (ability.Learned)
            {
                cb.Checked = true;
                cb.Enabled = false;
            }
            RefreshAllAbilities();
        }

        private void FellAbziehenCheckBox_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(FellAbziehenCheckBox, Global.Player.GetAbilityByName("Felle_nehmen"));

        private void StachelCheckBox_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(StachelCheckBox, Global.Player.GetAbilityByName("Blutfliegenstachel"));

        private void FlügelCheckBox_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(FlügelCheckBox, Global.Player.GetAbilityByName("Blutfliegenflügel"));

        private void SekretEntnehmenCheckBox_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(SekretEntnehmenCheckBox, Global.Player.GetAbilityByName("Sekret_aus_Stachel_entnehmen"));

        private void ZähneReissenCheckBox_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(ZähneReissenCheckBox, Global.Player.GetAbilityByName("Zähne_reißen"));

        private void KlauenHackenCheckBox_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(KlauenHackenCheckBox, Global.Player.GetAbilityByName("Klauen_hacken"));

        private void ZangenNehmenCheckBox_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(ZangenNehmenCheckBox, Global.Player.GetAbilityByName("Zangen_nehmen"));

        private void DrachenSnapperHornCheckBox_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(DrachenSnapperHornCheckBox, Global.Player.GetAbilityByName("Horn_des_Drachensnappers"));

        private void FeuerzungeCheckBox_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(FeuerzungeCheckBox, Global.Player.GetAbilityByName("Feuerzunge"));

        private void CrawlerplattenCheckBox_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(CrawlerplattenCheckBox, Global.Player.GetAbilityByName("Crawlerplatten_nehmen"));

        private void SchattenläuferHornCheckBox_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(SchattenläuferHornCheckBox, Global.Player.GetAbilityByName("Horn_des_Schattenläufers"));

        private void HerzNehmenCheckBox_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(HerzNehmenCheckBox, Global.Player.GetAbilityByName("Herz_nehmen"));

        private void DrachenschuppenCheckBox_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(DrachenschuppenCheckBox, Global.Player.GetAbilityByName("Drachenschuppen_nehmen"));

        private void DrachenblutCheckBox_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(DrachenblutCheckBox, Global.Player.GetAbilityByName("Drachenblut_zapfen"));

        private void ReptilienhäuteCheckBox_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(ReptilienhäuteCheckBox, Global.Player.GetAbilityByName("Häute_von_Reptilien_nehmen"));

        private void SchleichenCheckBox_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(SchleichenCheckBox, Global.Player.GetAbilityByName("Schleichen"));

        private void SchlösserKnackenCheckBox_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(SchlösserKnackenCheckBox, Global.Player.GetAbilityByName("Schlösser_knacken"));

        private void DiebstahlCheckBox_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(DiebstahlCheckBox, Global.Player.GetAbilityByName("Taschendiebstahl"));

        private void BauernCheckBox_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(BauernCheckBox, "Sprache_der_Bauern");

        private void KriegerCheckBox_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(KriegerCheckBox, "Sprache_der_Krieger");

        private void PriesterCheckBox_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(PriesterCheckBox, "Sprache_der_Priester");

        private void FernkampfwaffenCheckBox_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(FernkampfwaffenCheckBox, "Fernkampfwaffen_und_Munition");

        private void RunenCheckBox_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(RunenCheckBox, "Runen_und_Spruchrollen");

        private void TränkeCheckBox_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(TränkeCheckBox, "Tränke");

        private void RingeCheckBox_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(RingeCheckBox, "Ringe_und_Amulette");

        private void PflanzenCheckBox_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(PflanzenCheckBox, "Pflanzen_und_Nahrung");

        private void SonstigesCheckBox_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(SonstigesCheckBox, "Sonstiges");

        private void GoldhackenCheckBox_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(GoldhackenCheckBox, "Goldhacken_lernen");

        #endregion

        #region schwerter

        private void SchmiedenCheckBox_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(SchmiedenCheckBox, "Schwert");

        private void EdlesSchwertCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(EdlesSchwertCb, "Edles_Schwert");

        private void EdlesLangschwertCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(EdlesLangschwertCb, "Edles_Langschwert");

        private void RubinklingeCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(RubinklingeCb, "Rubinklinge");

        private void ElBastardoCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(ElBastardoCb, "El_Bastardo");

        private void ErzLangschwertCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(ErzLangschwertCb, "Erz-Langschwert");

        private void ErzBastardschwertCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(ErzBastardschwertCb, "Erz-Bastardschwert");

        private void ErzSchlachtklingeCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(ErzSchlachtklingeCb, "Erz-Schlachtklinge");

        private void ErzDrachentöterCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(ErzDrachentöterCb, "Erz-Drachentöter");

        private void ErzZweihänderCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(ErzZweihänderCb, "Erz-Zweihänder");

        private void SchwererErzZweihänderCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(SchwererErzZweihänderCb, "Schwerer_Erz-Zweihänder");

        private void SchwereErzSchlachtklingeCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(SchwereErzSchlachtklingeCb, "Schwere_Erz-Schlachtklinge");

        private void GroßerErzDrachentöterCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(GroßerErzDrachentöterCb, "Großer_Erz-Drachentöter");

        #endregion

        #region alchemie

        private void EssenzHeilungCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(EssenzHeilungCb, "Essenz_der_Heilung");

        private void ExtraktHeilungCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(ExtraktHeilungCb, "Extrakt_der_Heilung");

        private void ElixierHeilungCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(ElixierHeilungCb, "Elixier_der_Heilung");

        private void ManaEssenzCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(ManaEssenzCb, "Mana_Essenz");

        private void ManaExtraktCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(ManaExtraktCb, "Mana_Extrakt");

        private void ManaElixierCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(ManaElixierCb, "Mana_Elixier");

        private void TrankGeschwindCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(TrankGeschwindCb, "Trank_der_Geschwindigkeit");

        private void ElixierDesLebensCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(ElixierDesLebensCb, "Elixier_des_Lebens");

        private void ElixierDesGeistesCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(ElixierDesGeistesCb, "Elixier_des_Geistes");

        private void StärkeElixierCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(StärkeElixierCb, "Elixier_der_Stärke");

        private void ElixierGeschickCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(ElixierGeschickCb, "Elixier_der_Geschicklichkeit");

        #endregion

        #region magie

        private void Runenkreis1CheckBox_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(Runenkreis1CheckBox, "Kreis_1");

        private void Runenkreis2CheckBox_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(Runenkreis2CheckBox, "Kreis_2");

        private void Runkenkreis3CheckBox_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(Runenkreis3CheckBox, "Kreis_3");

        private void Runenkreis4CheckBox_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(Runenkreis4CheckBox, "Kreis_4");

        private void Runenkreis5CheckBox_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(Runenkreis5CheckBox, "Kreis_5");

        private void Runenkreis6CheckBox_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(Runenkreis6CheckBox, "Kreis_6");

        private void BlitzCb_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(BlitzCb, "Blitz");

        private void FeuerpfeilCb_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(FeuerpfeilCb, "Feuerpfeil");

        private void GoblinSkelettCb_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(GoblinSkelettCb, "Goblin_Skelett_erschaffen");

        private void LichtCb_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(LichtCb, "Licht");

        private void LeichteWundenCb_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(LeichteWundenCb, "Leichte_Wunden_heilen");

        private void EislanzeCb_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(EislanzeCb, "Eislanze");

        private void EispfeilCb_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(EispfeilCb, "Eispfeil");

        private void FeuerballCb_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(FeuerballCb, "Feuerball");

        private void SchlafCb_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(SchlafCb, "Schlaf");

        private void WindfaustCb_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(WindfaustCb, "Windfaust");

        private void WindhoseCb_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(WindhoseCb, "Windhose");

        private void WolfRufenCb_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(WolfRufenCb, "Wolf_rufen");

        private void AngstCb_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(AngstCb, "Angst");

        private void EisblockCb_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(EisblockCb, "Eisblock");

        private void GeysirCb_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(GeysirCb, "Geysir");

        private void UnwetterCb_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(UnwetterCb, "Unwetter");

        private void KleinerFeuersturmCb_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(KleinerFeuersturmCb, "Kleiner_Feuersturm");

        private void KugelblitzCb_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(KugelblitzCb, "Kugelblitz");

        private void SkelettErschaffenCb_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(SkelettErschaffenCb, "Skelett_erschaffen");

        private void MittlereHeilungCb_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(MittlereHeilungCb, "Mittlere_Wunden_heilen");

        private void BlitzschlagCb_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(BlitzschlagCb, "Blitzschlag");

        private void GolemErweckenCb_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(GolemErweckenCb, "Golem_erwecken");

        private void GroßerFeuerballCb_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(GroßerFeuerballCb, "Großer_Feuerball");

        private void UntoteVernichtenCb_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(UntoteVernichtenCb, "Untote_vernichten");

        private void WasserfaustCb_MouseUp(object sender, MouseEventArgs e) =>
            ReactOnAbilityClick(WasserfaustCb, "Wasserfaust");

        private void EiswelleCb_MouseUp(object sender, MouseEventArgs e)
    => ReactOnAbilityClick(EiswelleCb, "Eiswelle");

        private void DämonCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(DämonCb, "Dämon_beschwören");

        private void GroßerFeuersturmCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(GroßerFeuersturmCb, "Großer_Feuersturm");

        private void SchwereWundenCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(SchwereWundenCb, "Schwere_Wunden_heilen");

        private void ArmeeFinsternisCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(ArmeeFinsternisCb, "Armee_der_Finsternis");

        private void FeuerregenCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(FeuerregenCb, "Feuerregen");

        private void TodeshauchCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(TodeshauchCb, "Todeshauch");

        private void TodeswelleCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(TodeswelleCb, "Todeswelle");

        private void BösesVertreibenCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(BösesVertreibenCb, "Böses_vertreiben");

        private void HeiligerPfeilCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(HeiligerPfeilCb, "Heiliger_Pfeil");

        private void KleineWundheilungCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(KleineWundheilungCb, "Kleine_Wundheilung");

        private void MittlereWundheilungCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(MittlereWundheilungCb, "Mittlere_Wundheilung");

        private void GroßeWundheilungCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(GroßeWundheilungCb, "Große_Wundheilung");

        private void MonsterSchrumpfenCb_MouseUp(object sender, MouseEventArgs e)
            => ReactOnAbilityClick(MonsterSchrumpfenCb, "Monster_schrumpfen");

        #endregion

        #region items

        private void ElixierStärkeButton_Click(object sender, EventArgs e)
        {
            Global.Player.ConsumeItem("Elixier_der_Stärke");
            RefreshTopSkillItemsLog();
        }

        private void ElixierGeschickButton_Click(object sender, EventArgs e)
        {
            Global.Player.ConsumeItem("Elixier_des_Geschicks");
            RefreshTopSkillItemsLog();
        }

        private void ElixierGeistButton_Click(object sender, EventArgs e)
        {
            Global.Player.ConsumeItem("Elixier_des_Geistes");
            RefreshTopSkillItemsLog();
        }

        private void EssenzGeistButton_Click(object sender, EventArgs e)
        {
            Global.Player.ConsumeItem("Essenz_des_Geistes");
            RefreshTopSkillItemsLog();
        }

        private void TrankDracheneiButton_Click(object sender, EventArgs e)
        {
            Global.Player.ConsumeItem("Trank_aus_Drachenei-Sekret");
            RefreshTopSkillItemsLog();
        }

        private void TränenInnosButton_Click(object sender, EventArgs e)
        {
            Global.Player.ConsumeItem("Die_Tränen_Innos");
            RefreshTopSkillItemsLog();
        }

        private void EmbarlaFigastoButton_Click(object sender, EventArgs e)
        {
            Global.Player.ConsumeItem("Embarla_Figasto");
            RefreshTopSkillItemsLog();
        }

        private void Äpfel25Button_Click(object sender, EventArgs e)
        {
            Global.Player.ConsumeItem("25_Äpfel");
            RefreshTopSkillItemsLog();
        }

        private void Dunkelpilze50Button_Click(object sender, EventArgs e)
        {
            Global.Player.ConsumeItem("50_Dunkelpilze");
            RefreshTopSkillItemsLog();
        }

        private void DrachenwurzelButton_Click(object sender, EventArgs e)
        {
            Global.Player.ConsumeItem("Drachenwurzel");
            RefreshTopSkillItemsLog();
        }

        private void GoblinbeereButton_Click(object sender, EventArgs e)
        {
            Global.Player.ConsumeItem("Goblinbeere");
            RefreshTopSkillItemsLog();
        }

        private void FleischsuppeButton_Click(object sender, EventArgs e)
        {
            Global.Player.ConsumeItem("dampfende_Fleischsuppe");
            RefreshTopSkillItemsLog();
        }

        // Gebete

        private void BetenStärkeButton_Click(object sender, EventArgs e)
        {
            Global.Player.ConsumeItem("Beten_für_Stärke");
            RefreshTopSkillItemsLog();
        }

        private void BetenGeschickButton_Click(object sender, EventArgs e)
        {
            Global.Player.ConsumeItem("Beten_für_Geschick");
            RefreshTopSkillItemsLog();
        }

        private void BetenManaButton_Click(object sender, EventArgs e)
        {
            Global.Player.ConsumeItem("Beten_für_Mana");
            RefreshTopSkillItemsLog();
        }

        #endregion

        #region area_refresh

        private void RefreshAll()
        {
            RefreshTopArea();
            RefreshSkillArea();
            RefreshAllAbilities();
            RefreshItemsArea();
            RefreshLog();
        }

        private void RefreshAllAbilities()
        {
            RefreshTopArea();
            RefreshAbilitiesArea();
            RefreshAlchemyArea();
            RefreshMagicArea();
            RefreshMagic2Area();
            RefreshSwordsArea();
            RefreshLog();
        }

        private void RefreshTopSkillLog()
        {
            RefreshTopArea();
            RefreshSkillArea();
            RefreshLog();
        }

        private void RefreshTopSkillItemsLog()
        {
            RefreshTopArea();
            RefreshSkillArea();
            RefreshItemsArea();
            RefreshLog();
        }

        private void RefreshTopArea()
        {
            StufeTextBox.Text = Global.Player.CalcLevel().ToString();
            ErfahrungTextBox.Text = Global.Player.CalcExperienceNeeded().ToString();
            LernpunkteTextBox.Text = Global.Player.LearnPointsSpent.ToString();
        }

        private void RefreshSkillArea()
        {
            StaerkeTextBox.Text = Global.Player.GetSkillByName("Stärke").Level.ToString();
            GeschickTextBox.Text = Global.Player.GetSkillByName("Geschick").Level.ToString();
            ManaTextBox.Text = Global.Player.GetSkillByName("Mana").Level.ToString();

            StaerkeLpLabel.Text = Global.Player.GetSkillByName("Stärke").MakeLpCostsString();
            GeschickLpLabel.Text = Global.Player.GetSkillByName("Geschick").MakeLpCostsString();
            ManaLpLabel.Text = Global.Player.GetSkillByName("Mana").MakeLpCostsString();

            EinhandTextBox.Text = Global.Player.GetSkillByName("Einhand").Level.ToString();
            ZweihandTextBox.Text = Global.Player.GetSkillByName("Zweihand").Level.ToString();
            BogenTextBox.Text = Global.Player.GetSkillByName("Bogen").Level.ToString();
            ArmbrustTextBox.Text = Global.Player.GetSkillByName("Armbrust").Level.ToString();

            EinhandLpLabel.Text = Global.Player.GetSkillByName("Einhand").MakeLpCostsString();
            ZweihandLpLabel.Text = Global.Player.GetSkillByName("Zweihand").MakeLpCostsString();
            BogenLpLabel.Text = Global.Player.GetSkillByName("Bogen").MakeLpCostsString();
            ArmbrustLpLabel.Text = Global.Player.GetSkillByName("Armbrust").MakeLpCostsString();

            Application.DoEvents();
        }

        private void RefreshAbilitiesArea()
        {
            // Jagdtalente

            RefreshCheckBox(FellAbziehenCheckBox, "Felle_nehmen");
            RefreshCheckBox(StachelCheckBox, "Blutfliegenstachel");
            RefreshCheckBox(FlügelCheckBox, "Blutfliegenflügel");
            RefreshCheckBox(SekretEntnehmenCheckBox, "Sekret_aus_Stachel_entnehmen");
            RefreshCheckBox(ZähneReissenCheckBox, "Zähne_reißen");
            RefreshCheckBox(KlauenHackenCheckBox, "Klauen_hacken");
            RefreshCheckBox(ZangenNehmenCheckBox, "Zangen_nehmen");
            RefreshCheckBox(DrachenSnapperHornCheckBox, "Horn_des_Drachensnappers");
            RefreshCheckBox(SchattenläuferHornCheckBox, "Horn_des_Schattenläufers");
            RefreshCheckBox(CrawlerplattenCheckBox, "Crawlerplatten_nehmen");
            RefreshCheckBox(HerzNehmenCheckBox, "Herz_nehmen");
            RefreshCheckBox(DrachenschuppenCheckBox, "Drachenschuppen_nehmen");
            RefreshCheckBox(DrachenblutCheckBox, "Drachenblut_zapfen");
            RefreshCheckBox(FeuerzungeCheckBox, "Feuerzunge");
            RefreshCheckBox(ReptilienhäuteCheckBox, "Häute_von_Reptilien_nehmen");

            // Diebestalente

            RefreshCheckBox(SchleichenCheckBox, "Schleichen");
            RefreshCheckBox(SchlösserKnackenCheckBox, "Schlösser_knacken");
            RefreshCheckBox(DiebstahlCheckBox, "Taschendiebstahl");

            // Sprache der Erbauer

            RefreshCheckBox(BauernCheckBox, "Sprache_der_Bauern");
            RefreshCheckBox(KriegerCheckBox, "Sprache_der_Krieger");
            RefreshCheckBox(PriesterCheckBox, "Sprache_der_Priester");

            // Irrlicht-Talente

            RefreshCheckBox(FernkampfwaffenCheckBox, "Fernkampfwaffen_und_Munition");
            RefreshCheckBox(RunenCheckBox, "Runen_und_Spruchrollen");
            RefreshCheckBox(RingeCheckBox, "Ringe_und_Amulette");
            RefreshCheckBox(PflanzenCheckBox, "Pflanzen_und_Nahrung");
            RefreshCheckBox(TränkeCheckBox, "Tränke");
            RefreshCheckBox(SonstigesCheckBox, "Sonstiges");

            // Sonstige Talente

            RefreshCheckBox(GoldhackenCheckBox, "Goldhacken_lernen");
        }

        private void RefreshAlchemyArea()
        {
            RefreshCheckBox(EssenzHeilungCb, "Essenz_der_Heilung");
            RefreshCheckBox(ExtraktHeilungCb, "Extrakt_der_Heilung");
            RefreshCheckBox(ElixierHeilungCb, "Elixier_der_Heilung");
            RefreshCheckBox(ElixierDesLebensCb, "Elixier_des_Lebens");
            RefreshCheckBox(ManaEssenzCb, "Mana_Essenz");
            RefreshCheckBox(ManaExtraktCb, "Mana_Extrakt");
            RefreshCheckBox(ManaElixierCb, "Mana_Elixier");
            RefreshCheckBox(ElixierDesGeistesCb, "Elixier_des_Geistes");
            RefreshCheckBox(StärkeElixierCb, "Elixier_der_Stärke");
            RefreshCheckBox(ElixierGeschickCb, "Elixier_der_Geschicklichkeit");
            RefreshCheckBox(TrankGeschwindCb, "Trank_der_Geschwindigkeit");
        }

        private void RefreshMagicArea()
        {
            RefreshCheckBox(Runenkreis1CheckBox, "Kreis_1");
            RefreshCheckBox(Runenkreis2CheckBox, "Kreis_2");
            RefreshCheckBox(Runenkreis3CheckBox, "Kreis_3");
            RefreshCheckBox(Runenkreis4CheckBox, "Kreis_4");
            RefreshCheckBox(Runenkreis5CheckBox, "Kreis_5");
            RefreshCheckBox(Runenkreis6CheckBox, "Kreis_6");

            RefreshCheckBox(BlitzCb, "Blitz");
            RefreshCheckBox(FeuerpfeilCb, "Feuerpfeil");
            RefreshCheckBox(GoblinSkelettCb, "Goblin_Skelett_erschaffen");
            RefreshCheckBox(LeichteWundenCb, "Leichte_Wunden_heilen");
            RefreshCheckBox(LichtCb, "Licht");

            RefreshCheckBox(EislanzeCb, "Eislanze");
            RefreshCheckBox(EispfeilCb, "Eispfeil");
            RefreshCheckBox(FeuerballCb, "Feuerball");
            RefreshCheckBox(SchlafCb, "Schlaf");
            RefreshCheckBox(WindfaustCb, "Windfaust");
            RefreshCheckBox(WindhoseCb, "Windhose");
            RefreshCheckBox(WolfRufenCb, "Wolf_rufen");

            RefreshCheckBox(AngstCb, "Angst");
            RefreshCheckBox(EisblockCb, "Eisblock");
            RefreshCheckBox(GeysirCb, "Geysir");
            RefreshCheckBox(KleinerFeuersturmCb, "Kleiner_Feuersturm");
            RefreshCheckBox(KugelblitzCb, "Kugelblitz");
            RefreshCheckBox(MittlereHeilungCb, "Mittlere_Wunden_heilen");
            RefreshCheckBox(SkelettErschaffenCb, "Skelett_erschaffen");
            RefreshCheckBox(UnwetterCb, "Unwetter");

            RefreshCheckBox(BlitzschlagCb, "Blitzschlag");
            RefreshCheckBox(GolemErweckenCb, "Golem_erwecken");
            RefreshCheckBox(GroßerFeuerballCb, "Großer_Feuerball");
            RefreshCheckBox(UntoteVernichtenCb, "Untote_vernichten");
            RefreshCheckBox(WasserfaustCb, "Wasserfaust");
        }

        private void RefreshMagic2Area()
        {
            RefreshCheckBox(EiswelleCb, "Eiswelle");
            RefreshCheckBox(DämonCb, "Dämon_beschwören");
            RefreshCheckBox(GroßerFeuersturmCb, "Großer_Feuersturm");
            RefreshCheckBox(SchwereWundenCb, "Schwere_Wunden_heilen");

            RefreshCheckBox(ArmeeFinsternisCb, "Armee_der_Finsternis");
            RefreshCheckBox(FeuerregenCb, "Feuerregen");
            RefreshCheckBox(MonsterSchrumpfenCb, "Monster_schrumpfen");
            RefreshCheckBox(TodeshauchCb, "Todeshauch");
            RefreshCheckBox(TodeswelleCb, "Todeswelle");

            RefreshCheckBox(BösesVertreibenCb, "Böses_vertreiben");
            RefreshCheckBox(HeiligerPfeilCb, "Heiliger_Pfeil");
            RefreshCheckBox(KleineWundheilungCb, "Kleine_Wundheilung");
            RefreshCheckBox(MittlereWundheilungCb, "Mittlere_Wundheilung");
            RefreshCheckBox(GroßeWundheilungCb, "Große_Wundheilung");
        }

        private void RefreshSwordsArea()
        {
            RefreshCheckBox(SchmiedenCheckBox, "Schwert");
            RefreshCheckBox(EdlesSchwertCb, "Edles_Schwert");
            RefreshCheckBox(EdlesLangschwertCb, "Edles_Langschwert");
            RefreshCheckBox(RubinklingeCb, "Rubinklinge");
            RefreshCheckBox(ElBastardoCb, "El_Bastardo");

            RefreshCheckBox(ErzLangschwertCb, "Erz-Langschwert");
            RefreshCheckBox(ErzBastardschwertCb, "Erz-Bastardschwert");
            RefreshCheckBox(ErzSchlachtklingeCb, "Erz-Schlachtklinge");
            RefreshCheckBox(ErzDrachentöterCb, "Erz-Drachentöter");

            RefreshCheckBox(ErzZweihänderCb, "Erz-Zweihänder");
            RefreshCheckBox(SchwererErzZweihänderCb, "Schwerer_Erz-Zweihänder");
            RefreshCheckBox(SchwereErzSchlachtklingeCb, "Schwere_Erz-Schlachtklinge");
            RefreshCheckBox(GroßerErzDrachentöterCb, "Großer_Erz-Drachentöter");
        }

        private void RefreshItemsArea()
        {
            ElixierStärkeLabel.Text = Global.Player.GetItemByName("Elixier_der_Stärke").ToString();
            ElixierGeschickLabel.Text = Global.Player.GetItemByName("Elixier_des_Geschicks").ToString();
            ElixierGeistLabel.Text = Global.Player.GetItemByName("Elixier_des_Geistes").ToString();
            EssenzGeistLabel.Text = Global.Player.GetItemByName("Essenz_des_Geistes").ToString();
            TrankDracheneiLabel.Text = Global.Player.GetItemByName("Trank_aus_Drachenei-Sekret").ToString();
            TränenInnosLabel.Text = Global.Player.GetItemByName("Die_Tränen_Innos").ToString();
            EmbarlaFigastoLabel.Text = Global.Player.GetItemByName("Embarla_Figasto").ToString();
            Äpfel25Label.Text = Global.Player.GetItemByName("25_Äpfel").ToString();
            Dunkelpilze50Label.Text = Global.Player.GetItemByName("50_Dunkelpilze").ToString();
            DrachenwurzelLabel.Text = Global.Player.GetItemByName("Drachenwurzel").ToString();
            GoblinbeereLabel.Text = Global.Player.GetItemByName("Goblinbeere").ToString();
            FleischsuppeLabel.Text = Global.Player.GetItemByName("dampfende_Fleischsuppe").ToString();

            // Gebete (werden wie Items behandelt)

            BetenStärkeLabel.Text = Global.Player.GetItemByName("Beten_für_Stärke").ToString();
            BetenGeschickLabel.Text = Global.Player.GetItemByName("Beten_für_Geschick").ToString();
            BetenManaLabel.Text = Global.Player.GetItemByName("Beten_für_Mana").ToString();
        }

        private void RefreshCheckBox(CheckBox cb, String abilityName)
        {
            cb.Checked = Global.Player.GetAbilityByName(abilityName).Learned;
            if (!cb.Checked) cb.Enabled = true;
        }

        private void RefreshLog()
        {
            ProtokollTextBox.AppendText(Global.Logger.FetchNewMessages());
            ProtokollTextBox.ScrollToCaret();
        }

        #endregion
    }
}