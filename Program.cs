using System;
using System.Collections.Generic;
using Terminal.Gui;

class Program
{
	static void Main()
	{
		Application.Init();
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

		// var statusBar = new StatusBar (new Label("Delver path: "));
		var delverPathLabel = new Label("Delver path:")
			{ X = 1, Y = 1, Width = 13, Height = 1 };
		var delverPathField = new TextField("null")
			{ X = 14, Y = 1, Width = Dim.Fill(), Height = 1 };

		var savesListData = new List<string>() { "Save 0", "Save 1", "Save 3" };
		var savesList = new ListView(savesListData) {
			X = 0,
			Y = 0,
			Width = Dim.Fill(),
			Height = Dim.Fill(),
			AllowsMarking = false
		};

		var savesWindow = new Window("Saves slot")
			{ X = 0, Y = 3, Width = 20, Height = Dim.Fill() };

		var dataWindow = new Window("Data Editor")
			{ X = 21, Y = 3, Width = Dim.Fill(), Height = Dim.Fill() };
		var playerHpLabel = new Label("HP:")
			{ X = 0, Y = 0, Width = 10, Height = 1, TextAlignment = Terminal.Gui.TextAlignment.Right };
		var playerHp = new TextField()
			{ X = 11, Y = 0, Width = Dim.Fill() - 1, Height = 1 };
		var playerMaxHpLabel = new Label("Max HP:")
			{ X = 0, Y = 2, Width = 10, Height = 1, TextAlignment = Terminal.Gui.TextAlignment.Right };
		var playerMaxHp = new TextField()
			{ X = 11, Y = 2, Width = Dim.Fill() - 1, Height = 1 };
		var playerGoldLabel = new Label("Gold:")
			{ X = 0, Y = 4, Width = 10, Height = 1, TextAlignment = Terminal.Gui.TextAlignment.Right };
		var playerGold = new TextField()
			{ X = 11, Y = 4, Width = Dim.Fill() - 1, Height = 1 };
		var playerXpLabel = new Label("XP:")
			{ X = 0, Y = 6, Width = 10, Height = 1, TextAlignment = Terminal.Gui.TextAlignment.Right };
		var playerXp = new TextField()
			{ X = 11, Y = 6, Width = Dim.Fill() - 1, Height = 1 };

		savesWindow.Add(savesList);
		dataWindow.Add
		(
			playerHpLabel,playerHp,
			playerMaxHpLabel, playerMaxHp,
			playerGoldLabel, playerGold,
			playerXpLabel, playerXp
		);
		mainWindow.Add(delverPathLabel, delverPathField, savesWindow, dataWindow);
		top.Add(mainWindow, menuWindow);
		Application.Run();
	}

	static bool Quit()
	{
		var n = MessageBox.Query (50, 7, "Quit", "Вы лох?", "Yes", "No");
		return n == 0;
	}
}
