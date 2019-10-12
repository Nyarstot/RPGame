/*
 * Created by SharpDevelop.
 * User: курсы
 * Date: 27.04.2018
 * Time: 16:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace RPGame
{
	/// <summary>
	/// Description of Item.
	/// </summary>
	public class Item
	{
			public string name;
			public string image;
			public int quality;
			public bool stack { get; set; }
			
			public string type;
			public List < string > Params;
		
		public Item()
		{	
			Params = new List< string >();	
		}

        public class Healing : Item
        {
            public int Power { get; set; }
        }
	}
}
