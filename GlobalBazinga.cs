using Microsoft.Xna.Framework.Audio;
using Terraria;
using Terraria.ModLoader;

namespace Bazinga {
	public class BazingaItem : GlobalItem {
		public override void SetDefaults(Item item) {
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/Bazinga");
		}
	}

	public class BazingaNPC : GlobalNPC {
		public override void SetDefaults(NPC npc) {
			npc.HitSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/Bazinga");
			npc.DeathSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/Bazinga");
		}
	}
}
