/*
 */
using System;
using System.Collections.Generic;

namespace RPGame
{
	/// <summary>
	/// Description of game player
	/// </summary>
	public class Player
	{
		public int Health;
		public int Coins;
        public int Stamina;
        string[] Inv = new string[16];

        public Dictionary < string,int > Inventory;
        
		#region Skills
		public int Lucky;
		public int Charisma;
		public int Power;
		public int Breaking;
		public int Guns;
		public int Medicinic;
		public int MeleeWeapons;
		public int Science;
		public int Curie;
		public int Collector;
		#endregion
		
		public Player()
		{
			Health = 100;
			Coins = 0;
            Stamina = 100;

            Inventory = new Dictionary< string,int >();

            #region SkillsPlayer
            Lucky = 0;
			Charisma = 0;
			Power = 0;
			Breaking = 0;
			Guns = 0;
			Medicinic = 0;
			MeleeWeapons = 0;
			Science = 0;
			Curie = 0;
			Collector = 0;
			#endregion

		}
		
		public string SaveInventory()
		{
			
			string result = "";
			foreach(var item in Inventory)
			{
				if (result != "")
				{
					result+=";";
				}
				result += item.Key+":"+item.Value;
			}
			return result;
			
		}
		
		public void LoadInventory(string data)
		{
		
			foreach(var item in data.Split(';'))
			{
			
				string[]info = item.Split(':');
				Inventory.Add(info[0],int.Parse(info[1]));
			
			}
		
		}
			
	}
}
