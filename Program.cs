using System;
using System.Collections.Generic;
using Terminal.Gui;

class Program
{
	static void Main()
	{
		Application.Init();
		var top = Application.Top;

		var win = new Window("Delver Save Editor")
			{ X = 0, Y = 0, Width = Dim.Fill(), Height = Dim.Fill() };

		var menu = new MenuBar (new MenuBarItem [] {
			new MenuBarItem ("_File", new MenuItem [] {
				new MenuItem ("_Refresh", "Refresh Delver saves", null),
				new MenuItem ("_About", "About this program", null),
				new MenuItem ("_Quit", "", () => { if (Quit ()) top.Running = false; })
			})
		});

		// var statusBar = new StatusBar (new Label("Delver path: "));
		var delverPathLabel = new Label("Delver path: ")
			{ X = 1, Y = 1, Width = Dim.Fill (), Height = 1 };

		var savesListData = new List<string> () { "Save 0", "Save 1", "Save 3" };
		var savesList = new ListView (savesListData) {
			X = 0,
			Y = 0,
			Width = Dim.Fill(),
			Height = Dim.Fill(),
			AllowsMarking = false
		};

		var savesWindow = new Window("Saves slot")
			{ X = 0, Y = 3, Width = 20, Height = Dim.Fill() };

		savesWindow.Add(savesList);

		var dataWindow = new Window("Data Editor")
		{
			X = 21, Y = 3, Width = Dim.Fill(), Height = Dim.Fill()
		};

		top.Add(win, menu);
		win.Add(delverPathLabel, savesWindow, dataWindow);
		Application.Run ();
	}

	static bool Quit ()
	{
		var n = MessageBox.Query (50, 7, "Quit", "Вы лох?", "Yes", "No");
		return n == 0;
	}
}
