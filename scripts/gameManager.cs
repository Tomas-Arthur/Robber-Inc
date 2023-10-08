using Godot;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

public partial class gameManager : Node
{
	//tableau contenant tout les items du fichier json  
	public static string[,] scenesArray;

	//dictionaire contenant tout les irems du fichier json
	public static Dictionary<string, string[]> scenesDictionary;

	public static int nbItemInBuilder;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		scenesDictionary = new Dictionary<string, string[]>();
		readAndStoreDataForLevelBuilder();

	}

	

// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

		/*GD.Print(scenesArray[0, 0]);
		GD.Print(scenesArray[0, 1]);
		GD.Print(scenesArray[0, 2]);*/
		
	}

	// lis scenes.json et stock les valeurs parser dans scenesArray
	public void readAndStoreDataForLevelBuilder()
	{
		string jsonFilePath = "assets/scenes.json"; // Remplacez ceci par le chemin de votre fichier JSON


		if (File.Exists(jsonFilePath))
		{
			try
			{
				using (StreamReader reader = new StreamReader(jsonFilePath))
				{
					string jsonContents = reader.ReadToEnd();
					var jsonData = JsonConvert.DeserializeObject<Dictionary<string, JObject>>(jsonContents);

					if (jsonData != null)
					{
						// Créez un tableau multidimensionnel pour stocker les valeurs de "name", "icon" et "scene"
						scenesArray = new string[jsonData.Count, 3];
                        nbItemInBuilder = jsonData.Count;
                        //GD.Print(jsonData.Count);
                        int rowIndex = 0;

						foreach (var kvp in jsonData)
						{
							var itemData = kvp.Value;

							if (itemData != null)
							{
								scenesArray[rowIndex, 0] = itemData["name"].ToString();
								scenesArray[rowIndex, 1] = itemData["icon"].ToString();
								scenesArray[rowIndex, 2] = itemData["scene"].ToString();
								rowIndex++;
								scenesDictionary.Add(itemData["name"].ToString(), new string[] { itemData["icon"].ToString(), itemData["scene"].ToString() });
							}
						}

						// Vous pouvez maintenant utiliser le tableau "valuesArray" comme nécessaire.
						/*for (int i = 0; i < jsonData.Count; i++)
						{
							GD.Print("Name: " + scenesArray[i, 0]);
							GD.Print("Icon: " + scenesArray[i, 1]);
							GD.Print("Scene: " + scenesArray[i, 2]);
						}*/
					}
					else
					{
						GD.PrintErr("Failed to parse JSON data.");
					}
				}
			}
			catch (Exception e)
			{
				GD.PrintErr("An error occurred while reading the JSON file: " + e.Message);
			}
		}
		else
		{
			GD.PrintErr("JSON file not found: " + jsonFilePath);
		}
	}

	
}

