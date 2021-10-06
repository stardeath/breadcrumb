using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace BreadcrumbLib.Demo.Infrastructure
{
	public class League
	{
		public League(string name)
		{
			_name = name;
			_divisions = new List<Division>();

			Image = new Image {Width = 16, Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Folder_Open.png", UriKind.RelativeOrAbsolute))};
		}

		public Image Image { get; private set; }

		string _name;

		public string Name { get { return _name; } }

		List<Division> _divisions;
		public List<Division> Divisions { get { return _divisions; } }

		public override string ToString()
		{
			return Name;
		}

	}
	public class Division
	{
		public Division(string name)
		{
			_name = name;
			_teams = new List<Team>();

			Image = new Image { Width = 16, Source = new BitmapImage(new Uri("pack://application:,,,/Resources/foldergreen.png", UriKind.RelativeOrAbsolute)) };
		}

		public Image Image { get; private set; }

		string _name;

		public string Name { get { return _name; } }

		List<Team> _teams;

		public List<Team> Teams { get { return _teams; } }
		public override string ToString()
		{
			return Name;
		}

	}

	public class Team
	{
		public Team(string name)
		{
			_name = name;
			Image = new Image { Width = 16, Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Folder_Open.png", UriKind.RelativeOrAbsolute)) };
		}

		public Image Image { get; private set; }

		string _name;

		public string Name { get { return _name; } }
		public override string ToString()
		{
			return Name;
		}

	}

	public class ListLeagueList : List<League>
	{
		public ListLeagueList()
		{
			League l;
			Division d;

			Add(l = new League("League A"));
			l.Divisions.Add((d = new Division("Division A")));
			d.Teams.Add(new Team("Team I"));
			d.Teams.Add(new Team("Team II"));
			d.Teams.Add(new Team("Team III"));
			d.Teams.Add(new Team("Team IV"));
			d.Teams.Add(new Team("Team V"));
			l.Divisions.Add((d = new Division("Division B")));
			d.Teams.Add(new Team("Team Blue"));
			d.Teams.Add(new Team("Team Red"));
			d.Teams.Add(new Team("Team Yellow"));
			d.Teams.Add(new Team("Team Green"));
			d.Teams.Add(new Team("Team Orange"));
			l.Divisions.Add((d = new Division("Division C")));
			d.Teams.Add(new Team("Team East"));
			d.Teams.Add(new Team("Team West"));
			d.Teams.Add(new Team("Team North"));
			d.Teams.Add(new Team("Team South"));
			Add(l = new League("League B"));
			l.Divisions.Add((d = new Division("Division A")));
			d.Teams.Add(new Team("Team 1"));
			d.Teams.Add(new Team("Team 2"));
			d.Teams.Add(new Team("Team 3"));
			d.Teams.Add(new Team("Team 4"));
			d.Teams.Add(new Team("Team 5"));
			l.Divisions.Add((d = new Division("Division B")));
			d.Teams.Add(new Team("Team Diamond"));
			d.Teams.Add(new Team("Team Heart"));
			d.Teams.Add(new Team("Team Club"));
			d.Teams.Add(new Team("Team Spade"));
			l.Divisions.Add((d = new Division("Division C")));
			d.Teams.Add(new Team("Team Alpha"));
			d.Teams.Add(new Team("Team Beta"));
			d.Teams.Add(new Team("Team Gamma"));
			d.Teams.Add(new Team("Team Delta"));
			d.Teams.Add(new Team("Team Epsilon"));
		}

		public League this[string name]
		{
			get
			{
				foreach (League l in this)
					if (l.Name == name)
						return l;

				return null;
			}
		}


	}
}