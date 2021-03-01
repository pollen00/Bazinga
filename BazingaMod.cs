using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Mono.Cecil;
using MonoMod.Cil;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Bazinga {
	public class BazingaMod : Mod {
		public static Texture2D oldLogo;
		public static Texture2D old2Logo;
		public static Texture2D sheldonCooper;
		public override void Load() {
			sheldonCooper = ModContent.GetTexture("Bazinga/Sheldon");
			oldLogo = Main.logoTexture;
			old2Logo = Main.logoTexture;
			Main.logoTexture = sheldonCooper;
			Main.logo2Texture = sheldonCooper;

			ILCursor c;
			IL.Terraria.Main.UpdateAudio += il => {

				c = il.At(0);
				if (c.TryGotoNext(i =>
					i.MatchLdarg(out int empty),
					i => i.MatchLdfld(out FieldReference reference),
					i => i.MatchStsfld(out FieldReference reference2),
					i => i.MatchLdcR4(out float anotherUseless),
					i => i.MatchStloc(out int empty2))) {
					c.Index += 5;
					c.EmitDelegate<Action>(() => {
						if (Main.gameMenu) {
							Main.curMusic = GetSoundSlot(SoundType.Music, "Sounds/Music/The Big Bang Theory Intro Full Version");
						}
					});
				}
			};
		}

		public override void Unload() {
			Main.logoTexture = oldLogo;
			Main.logo2Texture = old2Logo;
		}

		public override void UpdateMusic(ref int music, ref MusicPriority priority) {
			music = GetSoundSlot(SoundType.Music, "Sounds/Music/The Big Bang Theory Intro Full Version");
			priority = MusicPriority.BossHigh;
		}
	}
}