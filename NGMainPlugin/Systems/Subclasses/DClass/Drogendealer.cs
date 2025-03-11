using Exiled.API.Features;
using UnityEngine;

namespace NGMainPlugin.Systems.Subclasses;

public static class Drogendealer
{
    public static void SetRole(Player ply)
    {
        ply.Role.Set(PlayerRoles.RoleTypeId.ClassD);
        ply.ShowHint("[<color=#180D76>P</color><color=#190D7F>r</color><color=#1A0D88>o</color><color=#1B0D91>j</color><color=#1C0D9A>e</color><color=#1D0DA3>c</color><color=#1E0DAC>t</color> <color=#200DBE>R</color><color=#210DC7>e</color><color=#220DD0>l</color><color=#230DD9>o</color><color=#240DE2>a</color><color=#250DEB>d</color>] Du Bist nun der Drogendealer!");
        ply.AddItem(ItemType.Painkillers, 2);
        ply.Scale = new Vector3(1f, 1f, 1f);
    }
}
