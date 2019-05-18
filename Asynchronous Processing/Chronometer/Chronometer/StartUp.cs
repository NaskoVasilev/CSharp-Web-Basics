using System;
using System.Linq;

namespace Chronometer
{
	class StartUp
	{
		static void Main(string[] args)
		{
			IChronometer chronometer = new Chronometer();
			string command = string.Empty;

			while ((command = Console.ReadLine()) != "exit")
			{
				switch (command)
				{
					case "start":
						{
							chronometer.Start();
							break;
						}
					case "stop":
						{
							chronometer.Stop();
							break;
						}
					case "lap":
						{
							Console.WriteLine(chronometer.Lap());
							break;
						}
					case "laps":
						{
							if (chronometer.Laps.Count == 0)
							{
								Console.WriteLine("Lasp: no laps.");
							}
							else
							{
								string result = $"Laps: {Environment.NewLine}" + string.Join(Environment.NewLine,
									chronometer.Laps.Select((lap, index) => $"{index}. {lap}"));
								Console.WriteLine(result);
							}
							break;
						}
					case "time":
						{
							Console.WriteLine(chronometer.GetTime);
							break;
						}
					case "reset":
						{
							chronometer.Reset();
							break;
						}
				}
			}
		}
	}
}
