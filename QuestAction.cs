/*
 */
using System;
using System.Media;

namespace RPGame
{
	//<summary></symmary>
	public class QuestAction
	{
		public string Text;
		public string NextQuest;
		public int Health;
		public int Coins;
        public string AddItem;
		
		public QuestAction()
		{
			Health = 0;
            Coins = 0;
     
        }
	}
}
