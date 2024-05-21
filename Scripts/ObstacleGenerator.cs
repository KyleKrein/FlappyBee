using BeeEngine;
using System;

namespace FlappyBee
{
	public sealed class ObstacleGenerator: Behaviour
	{
		public Prefab ObstaclePrefab;
		public Prefab Floor;
		public float TimeBeforeSpawn = 1f;
		private float m_PassedTime = 1;
		private float lastObstacle = 0;
		private Random m_Random = new Random();
		void OnCreate()
		{

		}
		void OnUpdate()
		{
			if(m_PassedTime >= TimeBeforeSpawn)
			{
				m_PassedTime = 0;
				int obstaclesUp = m_Random.Next(1, 5);
				for(int i = 0; i  < obstaclesUp; i++)
				{
					SpawnObstacle(m_Random.Next(-10, -2));   
                }
                int obstaclesDown = m_Random.Next(1, 5);
                for (int i = 0; i < obstaclesDown; i++)
                {
                    SpawnObstacle(m_Random.Next(2, 8));
                }
            }
			m_PassedTime += Time.DeltaTime;
		}

		void SpawnObstacle(float Y)
		{
            Entity obstacle = Instantiate(ObstaclePrefab, ThisEntity);
            var transform = obstacle.GetComponent<TransformComponent>();
            lastObstacle += m_Random.Next(1, 3);
            transform.Translation.X = lastObstacle;
            transform.Translation.Y += Y;
        }
	}
}
