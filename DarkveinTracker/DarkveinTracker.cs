using System.Collections;
using System.Windows;
using System.Windows.Controls;
using HearthDb.Enums;
using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.Hearthstone;
using Hearthstone_Deck_Tracker.Enums;
using Core = Hearthstone_Deck_Tracker.API.Core;

namespace DarkveinTracker {
	
	internal class DarkveinTracker {
		private const bool DEBUG = false;
		private Settings settings;
		
		private CardView player;
		private CardView opponent;

		private StackPanel playerPanel;
		private StackPanel opponentPanel;

		public DarkveinTracker() {
			settings = new Settings();
		}
		
		internal void GameStart() {
			//var debugString = settings.readSettings();
			
			Reset();
			
			if (DEBUG) {
				player.label.Text = //debugString + " " +
									settings.UseLabels.ToString() + " " +
				                    settings.TrackForOpponent.ToString() + " " +
				                    settings.TrackForWarlockOpponent.ToString() + " " +
				                    settings.HideNotDeck.ToString() + " " +
				                    settings.HideNotHand.ToString();
			}
		}

		internal void GameEnd() {
			Reset();
		}

		private void Reset() {
			Core.OverlayCanvas.Children.Remove(playerPanel);
			Core.OverlayCanvas.Children.Remove(opponentPanel);
			
			//create player card view
			player = new CardView();
			player.Update(null);
			player.label.Text = "Player Lady Darkvein";

			//create opponent card view
			opponent = new CardView();
			opponent.Update(null);
			opponent.label.Text = "Opponent Lady Darkvein";

			//create container for player
			playerPanel = new StackPanel();
			playerPanel.Orientation = Orientation.Vertical;
			Canvas.SetTop(playerPanel, Core.OverlayWindow.Height * 5 / 100);
			Canvas.SetRight(playerPanel, Core.OverlayWindow.Width * 20 / 100);
			Core.OverlayCanvas.Children.Add(playerPanel);
			Core.OverlayCanvas.Children.Add(player);
			Canvas.SetTop(player, Core.OverlayWindow.Height * 5 / 100);
			Canvas.SetRight(player, Core.OverlayWindow.Width * 20 / 100);
			
			//create container for opponent
			opponentPanel = new StackPanel();
			opponentPanel.Orientation = Orientation.Vertical;
			Canvas.SetTop(opponentPanel, Core.OverlayWindow.Height * 5 / 100);
			Canvas.SetLeft(opponentPanel, Core.OverlayWindow.Width * 20 / 100);
			Core.OverlayCanvas.Children.Add(opponentPanel);
			Core.OverlayCanvas.Children.Add(opponent);
			Canvas.SetTop(opponent, Core.OverlayWindow.Height * 5 / 100);
			Canvas.SetLeft(opponent, Core.OverlayWindow.Width * 20 / 100);
		}
		
		internal void OnPlayerPlay(Card card) {
			if ( card.SpellSchool.Equals(SpellSchool.SHADOW)) {
				player.Update(card);
			}
		}
		
		internal void OnOpponentPlay(Card card) {
			if ( card.SpellSchool.Equals(SpellSchool.SHADOW)) {
				opponent.Update(card);
			}
		}
		
		//hiding in menu
		internal void InMenu() {
			if (Config.Instance.HideInMenu) {
				playerPanel.Visibility = Visibility.Hidden;
				opponentPanel.Visibility = Visibility.Hidden;
			}
		}
	}
}