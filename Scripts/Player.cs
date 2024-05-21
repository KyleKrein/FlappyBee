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
		public float TimeOfGoingUp = 0;
		public event Action<TransformComponent> OnGoingRight;
		private float m_TimeInGoingUp = 0;
		private bool m_IsGoingUp = false;
		void OnCreate()
		{
			m_Transform = GetComponent<TransformComponent>();
		}
		void OnUpdate()
		{
			if (m_IsGoingUp)
			{
                m_Transform.Translation.Y += SpeedInGoingUp * Time.DeltaTime;
				m_TimeInGoingUp += Time.DeltaTime;
				if(m_TimeInGoingUp >= TimeOfGoingUp)
				{
					m_IsGoingUp = false;
				}
            }
			else
			{
                m_Transform.Translation.Y -= SpeedY * Time.DeltaTime;
            }
			m_Transform.Translation.X += SpeedX * Time.DeltaTime;
			if(Input.IsKeyDown(Key.Space))
			{
				m_IsGoingUp = true;
				m_TimeInGoingUp = 0;
			}
			OnGoingRight?.Invoke(m_Transform);
        }
	}
}
