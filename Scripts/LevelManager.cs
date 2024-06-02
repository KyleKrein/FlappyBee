using BeeEngine;
using System;

namespace FlappyBee
{
	public class LevelManager: Behaviour
	{
		private Scene m_ActiveScene;
		public Scene GameOverScene;
		void OnCreate()
		{
			m_ActiveScene = Scene.ActiveScene;
		}
		void OnUpdate()
		{
			if(Input.IsKeyDown(Key.R))
			{
				m_ActiveScene.Reset();
			}
		}

		public void GameOver()
		{
			GameOverScene.SetActive();
		}
	}
}
