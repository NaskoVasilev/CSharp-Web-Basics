using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Chronometer
{
	public class Chronometer : IChronometer
	{
		private long miliseconds;
		private bool isRunning;

		public Chronometer()
		{
			this.Reset();
		}

		public string GetTime
		{
			get
			{
				long minutes = miliseconds / 60000;
				long seconds = miliseconds / 1000;
				long timeMiliseconds = miliseconds % 1000;
				return $"{minutes:D2}:{seconds:D2}:{timeMiliseconds:D4}";
			}
		}

		public List<string> Laps { get; private set; }

		public string Lap()
		{
			string time = this.GetTime;
			this.Laps.Add(time);
			return time;
		}

		public void Reset()
		{
			this.isRunning = false;
			this.miliseconds = 0;
			this.Laps = new List<string>();
		}

		public void Start()
		{
			this.isRunning = true;
			Task task = Task.Run(() =>
			{
				while (isRunning)
				{
					Thread.Sleep(1);
					miliseconds++;
				}
			});
		}

		public void Stop()
		{
			this.isRunning = false;
		}
	}
}
