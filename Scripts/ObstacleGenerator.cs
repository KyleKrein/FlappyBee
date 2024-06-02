using BeeEngine;
using System;

namespace FlappyBee
{
	public sealed class ObstacleGenerator: Behaviour
	{
		public Prefab ObstaclePrefab;
		public Prefab Floor;
		public float TimeBeforeSpawn = 1f;
		public float WaitOnStartSeconds = 1f;
		private float m_PassedTime = 0;
		private float lastObstacle = 0;
		private Random m_Random = new Random();
		const int MAX_OBSTACLES = 20;
		private Entity[] m_Obstacles = new Entity[MAX_OBSTACLES];

		private int m_CurrentObstacle = 0;
		void OnCreate()
		{
			for(int i = 0; i < MAX_OBSTACLES; i++)
			{
				Entity obstacle = Instantiate(ObstaclePrefab, ThisEntity);
				var transform = obstacle.GetComponent<TransformComponent>();
            	lastObstacle += m_Random.Next(1, 3);
            	transform.Translation.X = lastObstacle;
				bool isUp = m_Random.Next(0, 2) == 0;
				var y = isUp ? m_Random.Next(-10, -2) : m_Random.Next(2, 8);
            	transform.Translation.Y += y;
				m_Obstacles[i] = obstacle;
			}
			m_PassedTime = -WaitOnStartSeconds;
		}
		void OnUpdate()
		{
			if(m_PassedTime >= TimeBeforeSpawn)
			{
				m_PassedTime = 0;
				bool isUp = m_Random.Next(0, 2) == 0;
				var y = isUp ? m_Random.Next(-10, -2) : m_Random.Next(2, 8);
				SpawnObstacle(y);
            }
			m_PassedTime += Time.DeltaTime;
		}

		void SpawnObstacle(float Y)
		{
            Entity obstacle = m_Obstacles[m_CurrentObstacle];
            var transform = obstacle.GetComponent<TransformComponent>();
            lastObstacle += m_Random.Next(1, 3);
            transform.Translation.X = lastObstacle;
            transform.Translation.Y += Y;
			m_CurrentObstacle = (m_CurrentObstacle + 1) % 10;
        }
	}
}
