using System;
using System.Windows.Controls;
using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Plugins;

namespace DarkveinTracker {
	public class DarkveinPlugin : IPlugin {

		public void OnLoad() {
			DarkveinTracker dkvt = new DarkveinTracker();
			
			GameEvents.OnGameStart.Add(dkvt.GameStart);
			GameEvents.OnGameEnd.Add(dkvt.GameEnd);
			GameEvents.OnInMenu.Add(dkvt.InMenu);
			GameEvents.OnPlayerPlay.Add(dkvt.OnPlayerPlay);
			GameEvents.OnOpponentPlay.Add(dkvt.OnOpponentPlay);
		}

		public void OnUnload() {
		}

		public void OnButtonPress() {
			// Triggered when the user clicks your button in the plugin list
		}

		public void OnUpdate() {
		}

		public string Name => "Lady Darkvein Tracker";

		public string Description => "A simple plugin tracking the last Shadow spell each player cast, for Lady Darkvein.";

		public string ButtonText => "Settings";

		public string Author => "GHIDRA";

		public Version Version => new Version(1, 0, 1);

		public MenuItem MenuItem => null;
	}
}