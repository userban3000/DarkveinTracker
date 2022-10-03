using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Xml;
using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.Properties;
using Hearthstone_Deck_Tracker.Utility.Logging;
using Hearthstone_Deck_Tracker.Windows;

namespace DarkveinTracker {
	public class Settings {

		public bool UseLabels => useLabels;

		public bool TrackForOpponent => trackForOpponent;

		public bool TrackForWarlockOpponent => trackForWarlockOpponent;

		public bool HideNotDeck => hideNotDeck;

		public bool HideNotHand => hideNotHand;

		private bool useLabels, trackForOpponent, trackForWarlockOpponent, hideNotDeck, hideNotHand;
		
		private const string Filename = "DarkveinSettings.xml";
		
		private String generateFilepath() {
			String fp = Assembly.GetExecutingAssembly().Location;
			String[] tokens = fp.Split('\\');
			String res = "";
			for (int i = 0; i < tokens.Length - 1; i++) {
				res += tokens[i] + "\\";
			}
			res += Filename;
			return res;
		}
		
		public String readSettings() {
			String Filepath = generateFilepath();
			//return Filepath + "    " + Assembly.GetExecutingAssembly().Location;
			if (File.Exists(Filepath)) {
				XmlDocument xmldoc = new XmlDocument();
				xmldoc.Load(Filepath);

				XmlNodeList booleans = xmldoc.GetElementsByTagName("Settings");
				if (booleans.Count > 0) {
					useLabels = booleans[0].Value == "True";
					trackForOpponent = booleans[1].Value == "True";
					trackForWarlockOpponent = booleans[2].Value == "True";
					hideNotDeck = booleans[3].Value == "True";
					hideNotHand = booleans[4].Value == "True";
				}
				else {
					return "Bools not found.";
				}

				return "See booleans: ";
			}
			else {
				return "File not found. Path: " + Filepath;
			}
		}
	}
}