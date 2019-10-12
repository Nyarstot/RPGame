/*
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace RPGame
{
	
	public partial class MainForm : Form
	{
		Game GameControler;
        List<Button> Buttons = new List<Button>();

        public void MainMenu ()
		{
			
		}
		
		public void MainGame()
		{
			
		}
		
		public MainForm()
		{
			InitializeComponent();
			GameControler = new Game();
			GameControler.Start();
			LoadQuestData();
		}
		
		public void LoadQuestData()
		{
			label2.Enabled = label3.Enabled = label4.Enabled = label5.Enabled = false;
			label2.Text = label3.Text = label4.Text = label5.Text = "";
			
			if (GameControler.CurrentQuest.Actions.Count > 0)
			{
				label2.Enabled = true;
				label2.Text = GameControler.CurrentQuest.Actions[0].Text;

			}
			
			if (GameControler.CurrentQuest.Actions.Count > 1)
			{
				label3.Enabled = true;
				label3.Text = GameControler.CurrentQuest.Actions[1].Text;
			}
			
			if (GameControler.CurrentQuest.Actions.Count > 2)
			{
				label4.Enabled = true;
				label4.Text = GameControler.CurrentQuest.Actions[2].Text;
			}
			
			if (GameControler.CurrentQuest.Actions.Count > 3)
			{
				label5.Enabled = true;
				label5.Text = GameControler.CurrentQuest.Actions[3].Text;
			}
				
			
			label1.Text = GameControler.CurrentQuest.Text;
			Text = GameControler.player.Health.ToString();
		}
		void Label2Click(object sender, EventArgs e)
		{
			GameControler.PlayerAction(GameControler.CurrentQuest.Actions[0]);
			LoadQuestData();
		}
		void Button1Click(object sender, EventArgs e)
		{
			GameControler.PlayerAction(GameControler.CurrentQuest.Actions[1]);
			LoadQuestData();
		}
		void Button2Click(object sender, EventArgs e)
		{
			GameControler.PlayerAction(GameControler.CurrentQuest.Actions[2]);
			LoadQuestData();
		}
		void Button3Click(object sender, EventArgs e)
		{
			GameControler.PlayerAction(GameControler.CurrentQuest.Actions[3]);
			LoadQuestData();
		}
		void Button7Click(object sender, EventArgs e)
		{
			Close();
		}
		void Button5Click(object sender, EventArgs e)
		{
			GameControler.Save();

            //AddSound sound = new AddSound("two.wav");

            pictureBox1.ImageLocation = "images\\UI\\ButtonS_Push.png";
        }
		void Button8Click(object sender, EventArgs e)
		{
			GameControler.Load();
			LoadQuestData();
		}

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            History StoryShow = new History();
            StoryShow.Show();
        }
    }
}
