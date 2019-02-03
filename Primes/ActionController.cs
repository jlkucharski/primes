using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Primes
{
	class ActionController
	{
		private readonly IDictionary<string, Action> _choices;

		public ActionController(IDictionary<string, Action> choices)
		{
			_choices = choices;
		}

		public void ProcessInput()
		{
			while (true)
			{
				DisplayOptions();

				int choice = -1;
				string choiceText;
				do
				{
					choiceText = Console.ReadLine();

					if (choiceText == "q")
					{
						return;
					}

				} while (!int.TryParse(choiceText, out choice) || choice < 0 || choice >= _choices.Count);

				var action = _choices.Values.ElementAt(choice);
				action.Invoke();
			}
		}

		private void DisplayOptions()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine("");
			sb.AppendLine("Choose action");

			for (int i = 0; i < _choices.Keys.Count; i++)
			{
				string actionDescription = _choices.Keys.ElementAt(i);
				sb.AppendLine($"{i}. {actionDescription}.");
			}

			sb.AppendLine("Choose an action number or press q to exit.");

			Console.Write(sb.ToString());
		}
	}
}
