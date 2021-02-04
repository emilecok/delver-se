using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using Terminal.Gui;

class Program
{
	static void Main()
	{
		Application.Init();
		Colors.Base = Colors.Dialog; // WTF?!
		var top = Application.Top;

		var mainWindow = new Window("Delver Save Editor")
			{ X = 0, Y = 0, Width = Dim.Fill(), Height = Dim.Fill() };

		var menuWindow = new MenuBar (new MenuBarItem [] {
			new MenuBarItem ("_File", new MenuItem [] {
				new MenuItem ("_Refresh", "Refresh Delver saves", null),
				new MenuItem ("_About", "About this program", null),
				new MenuItem ("_Quit", "", () => { if (Quit()) top.Running = false; })
			})
		});

		var delverPath = loadGamePath();
		var delverPathLabel = new Label("Delver path:")
			{ X = 1, Y = 1, Width = 13, Height = 1 };
		var delverPathField = new TextField(delverPath)
			{ X = 14, Y = 1, Width = Dim.Fill() - 1, Height = 1 };

		var savesListData = new List<string>() { "Save 0", "Save 1", "Save 3" };
		var savesList = new ListView(savesListData) {
			X = 1,
			Y = 0,
			Width = Dim.Fill() - 1,
			Height = Dim.Fill() - 1,
			AllowsMarking = false
		};

		var savesWindow = new Window("Saves slot")
			{ X = 0, Y = 3, Width = 20, Height = Dim.Fill() };

		var dataWindow = new Window("Data Editor")
			{ X = 21, Y = 3, Width = Dim.Fill(), Height = Dim.Fill() };
		var playerHpLabel = new Label("HP:")
			{ X = 0, Y = 1, Width = 10, Height = 1, TextAlignment = Terminal.Gui.TextAlignment.Right };
		var playerHp = new TextField()
			{ X = 11, Y = 1, Width = Dim.Fill() - 2, Height = 1 };
		var playerMaxHpLabel = new Label("Max HP:")
			{ X = 0, Y = 3, Width = 10, Height = 1, TextAlignment = Terminal.Gui.TextAlignment.Right };
		var playerMaxHp = new TextField()
			{ X = 11, Y = 3, Width = Dim.Fill() - 2, Height = 1 };
		var playerGoldLabel = new Label("Gold:")
			{ X = 0, Y = 5, Width = 10, Height = 1, TextAlignment = Terminal.Gui.TextAlignment.Right };
		var playerGold = new TextField()
			{ X = 11, Y = 5, Width = Dim.Fill() - 2, Height = 1 };
		var playerXpLabel = new Label("XP:")
			{ X = 0, Y = 7, Width = 10, Height = 1, TextAlignment = Terminal.Gui.TextAlignment.Right };
		var playerXp = new TextField()
			{ X = 11, Y = 7, Width = Dim.Fill() - 2, Height = 1 };

		var updateButton = new Button ("Update", is_default: false)
			{ X = 11, Y = 9, Height = 1 };
		updateButton.Clicked += () => {  };

		savesWindow.Add(savesList);
		dataWindow.Add
		(
			playerHpLabel,playerHp,
			playerMaxHpLabel, playerMaxHp,
			playerGoldLabel, playerGold,
			playerXpLabel, playerXp,
			updateButton
		);
		mainWindow.Add(delverPathLabel, delverPathField, savesWindow, dataWindow);
		top.Add(menuWindow, mainWindow);
		Application.Run();
	}

	static bool Quit()
	{
		var n = MessageBox.Query (20, 5, "Quit", "Вы лох?", "Yes", "No");
		return n == 0;
	}

	// return Delver path
	static string loadGamePath()
	{
		// check config.json file exist
		if (File.Exists("./config.json"))
		{
			string jsonString = System.IO.File.ReadAllText("./config.json");
			var data = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonString);

			return(data["delver_path"]);
		}
		else
		{
			// create file with "default" path
			StreamWriter configFile = System.IO.File.CreateText("./config.json");
			configFile.WriteLine("{\n    \"delver_path\": \"C:\\\\\"\n}");
			configFile.Close();

			return("C:\\");
		}
	}

	static void saveReadFile()
	{
		// string text = System.IO.File.ReadAllText(@"C:\Users\Public\TestFolder\WriteText.txt");
	}

	static void loadSavesSlot()
	{
		// try
  //       {
  //           string[] savesSlots = Directory.GetDirectories(@"c:\", "p*", SearchOption.TopDirectoryOnly);
  //           Console.WriteLine("The number of directories starting with p is {0}.", dirs.Length);
  //           foreach (string dir in dirs)
  //           {
  //               Console.WriteLine(dir);
  //           }
  //       }
  //       catch (Exception e)
  //       {
  //           Console.WriteLine("The process failed: {0}", e.ToString());
  //       }
	}
}
