/*
 */
using System;
using System.Collections.Generic;

namespace RPGame
{
	/// <summary>
	/// Description of Quest.
	/// </summary>
	public class Quest
	{
		public string Text = "";
		public List < QuestAction > Actions;
		public string ID = "";
		public string PlaySound;
		
		public Quest()
		{
			Actions = new List<QuestAction>();
		}
	}
}
