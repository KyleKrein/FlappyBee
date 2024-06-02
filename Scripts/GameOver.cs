using BeeEngine;
using System;

namespace FlappyBee
{
	public class GameOver: Behaviour
	{
		public Scene LevelScene;
		void OnCreate()
		{
			GetComponent<TextRendererComponent>().Text = Localization.Translate("gameOver");
		}
		void OnUpdate()
		{
			if(Input.IsKeyDown(Key.R) || Input.IsKeyDown(Key.Enter) || Input.IsKeyDown(Key.Space))
			{
				LevelScene.SetActive();
			}
		}
	}
}
