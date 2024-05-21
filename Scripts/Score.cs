using BeeEngine;
using System;

namespace FlappyBee
{
	public class Score: Behaviour
	{
		public int ScoreNumber = 0;
		TextRendererComponent m_Text;
		void OnCreate()
		{
			m_Text = GetComponent<TextRendererComponent>();
		}
		void OnUpdate()
		{
			m_Text.Text = Localization.Translate("score", "score", ScoreNumber);
		}
	}
}
