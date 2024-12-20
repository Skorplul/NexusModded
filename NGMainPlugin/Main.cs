﻿namespace NGMainPlugin
{
    using System;
    using HarmonyLib;
    using Exiled.API.Features;
    using NGMainPlugin.Systems;
    using NGMainPlugin.Systems.LobbySystem;
    using NGMainPlugin.Systems.RGBNuke;
    using NGMainPlugin.Systems.RespawnTimer;
    using NGMainPlugin.Systems.EventHandlers;
    using NGMainPlugin.Systems.EventsSystem;
    using NGMainPlugin.Systems.CustomItems;
    using NGMainPlugin.Systems.Notifications;

    public class NGMainPlguin : Plugin<Config>
    {
        public override string Author => "Skorp 1.0 and LastPenguin";
        public override string Name => "NGMainPlugin";
        public override string Prefix => "NGM";
        public override Version Version => new Version(2, 4, 0);
        public override Version RequiredExiledVersion => new Version(8, 9, 11);

        public static NGMainPlguin Instance { get; private set; }

        private Harmony Harmony { get; } = new Harmony($"com.NGMainPlugin-{DateTime.Now.Ticks}");

        public override void OnEnabled()
        {
            Instance = this;

            Log.Info("                                                                                                                                                                         \r\n                                                                                                                                                                         \r\n          `7MN.   `7MF`7MM\"\"\"YMM  `YMM'   `MP`7MMF'   `7MF'.M\"\"\"bgd                       .g8\"\"\"bgd       db     `7MMM.     ,MMF`7MMF`7MN.   `7MF' .g8\"\"\"bgd             \r\n            MMN.    M   MM    `7    VMb.  ,P   MM       M ,MI    \"Y                     .dP'     `M      ;MM:      MMMb    dPMM   MM   MMN.    M .dP'     `M             \r\n            M YMb   M   MM   d       `MM.M'    MM       M `MMb.                         dM'       `     ,V^MM.     M YM   ,M MM   MM   M YMb   M dM'       `             \r\n            M  `MN. M   MMmmMM         MMb     MM       M   `YMMNq.                     MM             ,M  `MM     M  Mb  M' MM   MM   M  `MN. M MM                      \r\nmmmmm mmmmm M   `MM.M   MM   Y  ,    ,M'`Mb.   MM       M .     `MM                     MM.    `7MMF'  AbmmmqMA    M  YM.P'  MM   MM   M   `MM.M MM.    `7MMFmmmmm mmmmm \r\n            M     YMM   MM     ,M   ,P   `MM.  YM.     ,M Mb     dM                     `Mb.     MM   A'     VML   M  `YM'   MM   MM   M     YMM `Mb.     MM             \r\n          .JML.    YM .JMMmmmmMMM .MM:.  .:MMa. `bmmmmd\"' P\"Ybmmd\"                        `\"bmmmdPY .AMA.   .AMMA.JML. `'  .JMML.JMML.JML.    YM   `\"bmmmdPY             \r\n                                                                                                                                                                         \r\n                                                                                                                                                                         \r\n\r\n");

            // Load all configs
            Log.Info("Loading Configs...");
            Config.LoadConfigs();

            // All patches
            Log.Info("Harmony Patching...");
            Harmony.PatchAll();

            // Enable all the custom systems
            Log.Info("-----[Systems]-----");

            Log.Info("Enabling Custom Items..");
            CustomItems.Enable();

            Log.Info("Enabling Event Handlers...");
            EventHandlers.Enable();

            Log.Info("Enabling Random Painkillers...");
            RandomPainkillers.Enable();

            Log.Info("Enabling Lobby System...");
            LobbySystem.Enable();

            Log.Info("Enabling RGBNuke System...");
            RGBNuke.Enable();

            Log.Info("Enabling Respawn Timer System...");
            RespawnTimer.Enable();

            Log.Info("Enabling Notification System...");
            Notifications.Enable();

            Log.Info("Events System...");
            EventsSystemHandler.Enable();

            Log.Info("-----[NGMainPlugin Initialized]-----");
            
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Log.Info("-----[NGMainPlugin Disable]-----");

            // Unpatch everything
            Log.Info("Harmony Unpatching...");
            Harmony.UnpatchAll();

            // Disable all the custom systems
            Log.Info("-----[Systems]-----");

            Log.Info("Disabling Custom Items..");
            CustomItems.Disable();

            Log.Info("Disabling Event Handlers...");
            EventHandlers.Disable();

            Log.Info("Disabling Random Painkillers...");
            RandomPainkillers.Disable();

            Log.Info("Disabling Lobby System...");
            LobbySystem.Disable();

            Log.Info("Disabling RGBNuke System...");
            RGBNuke.Disable();

            Log.Info("Disabling Respawn Timer System...");
            RespawnTimer.Disable();

            Log.Info("Disabling Notification System...");
            Notifications.Disable();

            Log.Info("Disableing Events System...");
            EventsSystemHandler.Disable();

            Log.Info("-----[NGMainPlugin Disabled]-----");
            
            base.OnDisabled();
        }
    }
}
