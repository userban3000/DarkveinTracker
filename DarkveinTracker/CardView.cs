using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using HearthDb;
using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.Controls;
using Card = Hearthstone_Deck_Tracker.Hearthstone.Card;

namespace DarkveinTracker {
	public class CardView : StackPanel {
		public List<Card> cards;
		public AnimatedCardList view;
		public HearthstoneTextBlock label;

		public CardView() {
			Orientation = Orientation.Vertical;
			
			//Label
			label = new HearthstoneTextBlock();
			label.FontSize = 16;
			label.TextAlignment = TextAlignment.Center;
			var labelMargin = label.Margin;
			labelMargin.Top = 18;
			label.Margin = labelMargin;
			Children.Add(label);
			label.Visibility = Visibility.Hidden;

			//Card
			view = new AnimatedCardList();
			Children.Add(view);
			cards = new List<Card>();
		}

		public void Update(Card card) {
			cards.Clear();
			if ( card != null )
				cards.Add(card.Clone() as Card);
			view.Update(cards, true);
			if ( cards.Count > 0 )
				label.Visibility = Visibility.Visible;
		}
	}
}