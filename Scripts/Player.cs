using BeeEngine;
using System;

namespace FlappyBee
{
	public sealed class Player: Behaviour
	{
		private TransformComponent m_Transform;
		public float SpeedY = 0;
		public float SpeedX = 0;
		public float SpeedInGoingUp = 0;
		public event Action<TransformComponent> OnGoingRight;
		void OnCreate()
		{
			m_Transform = GetComponent<TransformComponent>();
			ThisEntity.OnCollisionStart += (sender, other) =>
			{
				var LevelManager = FindEntityByName("LevelManager")!.GetBehaviour<LevelManager>();
				LevelManager!.GameOver();
			};
		}
		void OnUpdate()
		{
			m_Transform.Translation.X += SpeedX * Time.DeltaTime;
			if(Input.IsKeyDown(Key.Space))
			{
				m_Transform.Translation.Y += SpeedInGoingUp * Time.DeltaTime;
			}
			OnGoingRight?.Invoke(m_Transform);
        }
	}
}
