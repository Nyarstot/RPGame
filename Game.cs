/*
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Media;

namespace RPGame
{
	/// <summary>
	/// Main class of game
	/// </summary>
	public class Game
	{
		public Player player;
		Dictionary < string,Quest > QuestBase;
		Dictionary < string,Item > ItemBase;
		public Quest CurrentQuest;
		
		#region Save n Load
		
		public void Save()
		{
            /// <summary>
            /// Save game function
            /// </summary>
			string path = @"Saves\\Save.dat";

			List <string> save = new List<string>();
			save.Add("CurrentQuest_id="+CurrentQuest.ID);
			save.Add("Health="+player.Health.ToString());
			save.Add("Coins="+player.Coins.ToString());
			save.Add("Inv="+player.SaveInventory());
			File.WriteAllLines(path,save);
			
		}
		
		public void Load()
		{
            /// <summary>
            /// Load game function
            /// </summary>
			string path = @"Saves\\Save.dat";

			string [] load = File.ReadAllLines(path);
			foreach (string line in load)
			{
				string [] info = line.Split('=');
				
				switch (info [0])
				{
					case "CurrentQuest_id":
						CurrentQuest = QuestBase[info[1]];
						break;
						
					case "Health":
						player.Health = Convert.ToInt32(info[1]);
						break;
						
					case "Coins":
						player.Coins = Convert.ToInt32(info[1]);
						break;
						
					case "Inv":
						player.LoadInventory(info[1]);
						break;
				}
			}
			
		}

		#endregion

		#region PolarisScript

		public void LoadPlot(string Lang)
		{
			string path = "Story\\"+Lang+"_.story";
            QuestAction action = new QuestAction();
			Quest quest = new Quest();
			QuestBase = new Dictionary<string, Quest>();
			string[] loadPlot = File.ReadAllLines(path);
			foreach (string line in loadPlot)
			{
				string line2 = line.Trim();
				
				
				
				if (line2 == "")
				{
					continue;
				}
				
				if (line2.Substring(0,2)=="//")
				{
					continue;
				}
				
				switch(line2)
				{
					case "# QUEST BEGIN":
						quest = new Quest();
						break;
					case "# QUEST END":
						QuestBase.Add(quest.ID,quest);
						break;
					case "# ACTION BEGIN":
						action = new QuestAction();
						break;
					case "# ACTION END":
						quest.Actions.Add(action);
						break;
						
				}
				
				string [] info = line2.Split('=');
				
				
				switch(info[0])
				{
					case "Quest_ID":
						quest.ID = info[1];
						break;
					case "QuestText":
						quest.Text = info[1];
						break;
					case "NextQuest":
						action.NextQuest = info[1];
						break;
					case "ActionText":
						action.Text = info[1];
						break;
                    case "PlaySound":
                        quest.PlaySound = info[1];
                        break;
					case "ActHealth":
						action.Health=Convert.ToInt32(info[1]);
						break;
					case "ActCoins":
						action.Coins=Convert.ToInt32(info[1]);
						break;
				}
			}
		}

		#endregion
		
		#region Inventary init
		
		public void InvInit()
		{
			string file = "ItemBase.inv";
			ItemBase = new Dictionary<string, Item>();
			string[]ItemLoad = File.ReadAllLines(file);
			foreach(string line in ItemLoad)
			{
				string[]str = line.Split('	');
				Item item = new Item();
				item.name = str[1];
				item.image = str[2];
				item.type = str[5];
				item.quality = int.Parse(str[3]);
				item.stack = bool.Parse(str[4]);
				for (int i = 6; i < str.Length;i++)
				{
					item.Params.Add(str[i]);
				}
				ItemBase.Add(str[0],item);
			}

		}

        #endregion

        #region HistoryAppend

        public void Append()
        {

            string path = @"Saves\\History.dat";

            List<string> HistoryList = new List<string>();
            HistoryList.Add(CurrentQuest.Text);
            File.WriteAllLines(path, HistoryList);
            
        }

        #endregion

        public void PlayerAction(QuestAction QuestAct) //Form for adding of configs from QuestAction
		{
			player.Health += QuestAct.Health;
			player.Coins += QuestAct.Coins;
			
			CurrentQuest = QuestBase[QuestAct.NextQuest];

            if (CurrentQuest.PlaySound != null)
            {
                new SoundPlayer("Sound\\" + CurrentQuest.PlaySound).Play();
            }
            else
            {
                new SoundPlayer().Stop();
            }
		}
		
		public void Start(){
			LoadPlot("Rus");
			CurrentQuest = QuestBase["First_q"];
		}
		
		void initQuestList()
		{
			QuestAction action;
			Quest quest;
			string quest_id;
			QuestBase = new Dictionary<string, Quest>();
			
		}
		
		public Game()
		{
			player = new Player();
			initQuestList();
        }

	}
}
