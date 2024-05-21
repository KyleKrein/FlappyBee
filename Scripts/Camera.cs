using BeeEngine;
using System;

namespace FlappyBee
{
	public class Camera: Behaviour
	{
		TransformComponent m_Transform;
		void OnCreate()
		{
			m_Transform = GetComponent<TransformComponent>();
			Entity player = FindEntityByName("Player");
            player.GetBehaviour<Player>().OnGoingRight += Camera_OnGoingRight; ;
		}

        private void Camera_OnGoingRight(TransformComponent obj)
        {
			m_Transform.Translation.X = obj.Translation.X;
        }

        void OnUpdate()
		{
			// TODO: Add your code here
		}
	}
}
