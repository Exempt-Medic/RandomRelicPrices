using Modding;
using System;
using Satchel.BetterMenus;

namespace RandomRelicPrices
{
    #region Menu
    public static class ModMenu
    {
        private static Menu? MenuRef;
        public static MenuScreen CreateModMenu(MenuScreen modlistmenu)
        {
            MenuRef ??= new Menu("Relic Price Options", new Element[]
            {
                new CustomSlider
                (
                    "Wanderer's Journal Min",
                    f =>
                    {
                        RandomRelicPricesMod.LS.relic1Min = (int)f;
                        RandomRelicPricesMod.LS.relic1Max = (f > RandomRelicPricesMod.LS.relic1Max) ? (int)f : RandomRelicPricesMod.LS.relic1Max;
                        MenuRef?.Update();
                    },
                    () => RandomRelicPricesMod.LS.relic1Min,
                    0f,
                    3000f,
                    true
                ),

                new CustomSlider
                (
                    "Wanderer's Journal Max",
                    f =>
                    {
                        RandomRelicPricesMod.LS.relic1Max = (int)f;
                        RandomRelicPricesMod.LS.relic1Min = (f < RandomRelicPricesMod.LS.relic1Min) ? (int)f : RandomRelicPricesMod.LS.relic1Min;
                        MenuRef?.Update();
                    },
                    () => RandomRelicPricesMod.LS.relic1Max,
                    0f,
                    3000f,
                    true
                ),

                new CustomSlider
                (
                    "Hallownest Seal Min",
                    f =>
                    {
                        RandomRelicPricesMod.LS.relic2Min = (int)f;
                        RandomRelicPricesMod.LS.relic2Max = (f > RandomRelicPricesMod.LS.relic2Max) ? (int)f : RandomRelicPricesMod.LS.relic2Max;
                        MenuRef?.Update();
                    },
                    () => RandomRelicPricesMod.LS.relic2Min,
                    0f,
                    3000f,
                    true
                ),

                new CustomSlider
                (
                    "Hallownest Seal Max",
                    f =>
                    {
                        RandomRelicPricesMod.LS.relic2Max = (int)f;
                        RandomRelicPricesMod.LS.relic2Min = (f < RandomRelicPricesMod.LS.relic2Min) ? (int)f : RandomRelicPricesMod.LS.relic2Min;
                        MenuRef?.Update();
                    },
                    () => RandomRelicPricesMod.LS.relic2Max,
                    0f,
                    3000f,
                    true
                ),

                new CustomSlider
                (
                    "King's Idol Min",
                    f =>
                    {
                        RandomRelicPricesMod.LS.relic3Min = (int)f;
                        RandomRelicPricesMod.LS.relic3Max = (f > RandomRelicPricesMod.LS.relic3Max) ? (int)f : RandomRelicPricesMod.LS.relic3Max;
                        MenuRef?.Update();
                    },
                    () => RandomRelicPricesMod.LS.relic3Min,
                    0f,
                    3000f,
                    true
                ),

                new CustomSlider
                (
                    "King's Idol Max",
                    f =>
                    {
                        RandomRelicPricesMod.LS.relic3Max = (int)f;
                        RandomRelicPricesMod.LS.relic3Min = (f < RandomRelicPricesMod.LS.relic3Min) ? (int)f : RandomRelicPricesMod.LS.relic3Min;
                        MenuRef?.Update();
                    },
                    () => RandomRelicPricesMod.LS.relic3Max,
                    0f,
                    3000f,
                    true
                ),

                new CustomSlider
                (
                    "Arcane Egg Min",
                    f =>
                    {
                        RandomRelicPricesMod.LS.relic4Min = (int)f;
                        RandomRelicPricesMod.LS.relic4Max = (f > RandomRelicPricesMod.LS.relic4Max) ? (int)f : RandomRelicPricesMod.LS.relic4Max;
                        MenuRef?.Update();
                    },
                    () => RandomRelicPricesMod.LS.relic4Min,
                    0f,
                    3000f,
                    true
                ),

                new CustomSlider
                (
                    "Arcane Egg Max",
                    f =>
                    {
                        RandomRelicPricesMod.LS.relic4Max = (int)f;
                        RandomRelicPricesMod.LS.relic4Min = (f < RandomRelicPricesMod.LS.relic4Min) ? (int)f : RandomRelicPricesMod.LS.relic4Min;
                        MenuRef?.Update();
                    },
                    () => RandomRelicPricesMod.LS.relic4Max,
                    0f,
                    3000f,
                    true
                ),

                new MenuButton
                (
                    "Reset Defaults",
                    "",
                    a =>
                    {
                        RandomRelicPricesMod.LS.relic1Min = 100;
                        RandomRelicPricesMod.LS.relic1Max = 300;
                        RandomRelicPricesMod.LS.relic2Min = 225;
                        RandomRelicPricesMod.LS.relic2Max = 675;
                        RandomRelicPricesMod.LS.relic3Min = 400;
                        RandomRelicPricesMod.LS.relic3Max = 1200;
                        RandomRelicPricesMod.LS.relic4Min = 600;
                        RandomRelicPricesMod.LS.relic4Max = 1800;
                        MenuRef?.Update();
                    }
                )
            });
            return MenuRef.GetMenuScreen(modlistmenu);
        }
    }
    #endregion

    public class RandomRelicPricesMod : Mod, ICustomMenuMod, ILocalSettings<LocalSettings>
    {
        #region Boilerplate
        private static RandomRelicPricesMod? _instance;

        internal static RandomRelicPricesMod Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException($"An instance of {nameof(RandomRelicPricesMod)} was never constructed");
                }
                return _instance;
            }
        }

        public MenuScreen GetMenuScreen(MenuScreen modListMenu, ModToggleDelegates? toggleDelegates) => ModMenu.CreateModMenu(modListMenu);
        public bool ToggleButtonInsideMenu => false;
        public static LocalSettings LS { get; private set; } = new();
        public void OnLoadLocal(LocalSettings s) => LS = s;
        public LocalSettings OnSaveLocal() => LS;
        public override string GetVersion() => GetType().Assembly.GetName().Version.ToString();

        public RandomRelicPricesMod() : base("RandomRelicPrices")
        {
            _instance = this;
        }
        #endregion

        #region Custom Variables
        public int relic1 = 200;
        public int relic2 = 450;
        public int relic3 = 800;
        public int relic4 = 1200;
        #endregion

        #region Init
        public override void Initialize()
        {
            Log("Initializing");

            ModHooks.LanguageGetHook += OnLanguageGet;
            On.UIManager.StartNewGame += SetPrices;

            Log("Initialized");
        }
        #endregion

        #region Changes
        private void SetPrices(On.UIManager.orig_StartNewGame orig, UIManager self, bool permaDeath, bool bossRush)
        {
            orig(self, permaDeath, bossRush);

            relic1 = UnityEngine.Random.Range(LS.relic1Min, LS.relic1Max);
            relic2 = UnityEngine.Random.Range(LS.relic2Min, LS.relic2Max);
            relic3 = UnityEngine.Random.Range(LS.relic3Min, LS.relic3Max);
            relic4 = UnityEngine.Random.Range(LS.relic4Min, LS.relic4Max);
        }
        private string OnLanguageGet(string key, string sheetTitle, string orig)
        {
            if (sheetTitle == "Prices" && key.StartsWith("RELIC_"))
            {
                if (key.EndsWith("1"))
                {
                    return relic1.ToString();
                }
                else if (key.EndsWith("2"))
                {
                    return relic2.ToString();
                }
                else if (key.EndsWith("3"))
                {
                    return relic3.ToString();
                }
                else if (key.EndsWith("4"))
                {
                    return relic4.ToString();
                }
                return orig;
            }
            return orig;
        }
        #endregion
    }
    #region Settings
    public class LocalSettings
    {
        public int relic1Min = 100;
        public int relic1Max = 300;
        public int relic2Min = 225;
        public int relic2Max = 675;
        public int relic3Min = 400;
        public int relic3Max = 1200;
        public int relic4Min = 600;
        public int relic4Max = 1800;
    }
    #endregion
}
