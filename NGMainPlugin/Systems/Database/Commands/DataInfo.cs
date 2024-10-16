﻿namespace NGMainPlugin.Systems.Database.Commands
{
    using CommandSystem;
    using System;
    using Exiled.API.Features;
    using Exiled.Permissions.Extensions;
    using NGMainPlugin.Systems.Database;

    [CommandHandler(typeof(ClientCommandHandler))]
    public class DataInfoClient : ICommand
    {
        public string Command { get; } = "pt";

        public string[] Aliases { get; } = new string[] { };

        public string Description { get; } = Config.Translations.DBPTDescriptionClient;

        public bool SanitizeResponse => true;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var info = Database.GetPlayerInfo(Player.Get(sender));

            if (info != null)
            {
                response = String.Format(Config.Translations.DBClientPlaytime, $"{TimeSpan.FromSeconds(info.Playtime):hh\\:mm\\:ss}");
                return true;
            }

            response = Config.Translations.DBDataNotStored;
            return false;
        }
    }

    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class DataInfoServer : ICommand
    {
        public string Command { get; } = "pt";

        public string[] Aliases { get; } = new string[] { };

        public string Description { get; } = Config.Translations.DBPTDescriptionServer;

        public bool SanitizeResponse => true;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!Player.Get(sender).CheckPermission("NG.PtMng"))
            {
                response = "You dont have a permission to use that command!";
                return false;
            }

            if (arguments.Count == 0)
            {
                response = Config.Translations.DBServerEveryonePlaytime;
                foreach (Player p in Player.List)
                {
                    PlayerInfo info = Database.GetPlayerInfo(p);
                    if (info == null)
                        continue;

                    response += $"<color=yellow>[{p.CanStoreCustomData()}] {p.Nickname}</color> - {TimeSpan.FromSeconds(info.Playtime):hh\\:mm\\:ss}\n";
                }

                return true;
            }
            else if (arguments.Count == 1)
            {
                /*if (arguments.At(0) == "all")
                {
                    response = Database.DebugInfo();

                    return true;
                }*/

                Player p = Player.Get(arguments.At(0));
                PlayerInfo info;
                if (p == null)
                {
                    info = Database.GetPlayerInfo(arguments.At(0)+"@steam");

                    if (info == null)
                    {
                        response = Config.Translations.DBServerWrongID;
                        return false;
                    }

                    response = String.Format(Config.Translations.DBServerPlayerPlaytime, arguments.At(0), $"{TimeSpan.FromSeconds(info.Playtime):hh\\:mm\\:ss}");
                    return true;

                }

                info = Database.GetPlayerInfo(p);
                if (info == null)
                {
                    response = Config.Translations.DBServerDataNotStored;
                    return false;
                }

                response = String.Format(Config.Translations.DBServerPlayerPlaytime, p.Nickname, $"{TimeSpan.FromSeconds(info.Playtime):hh\\:mm\\:ss}");
                return true;
            }

            response = "";
            return false;
        }
    }
}