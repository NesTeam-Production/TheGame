using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TheGame;
using TheGame.OpenAI;
using TheGame.Races;

internal class OpenAIHandler
{
    internal static async Task GenerateFullCharacter(int level, Class choosenClass, Race choosenRace)
    {
        string filePath = "C:/Users/GTAgi/Desktop/Characters";
        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }
        HttpClient client = new HttpClient();
        try
        {
            string apiKeyFilePath = Path.Combine(Common.GetWorkingDirectory(), "api.key");
            if (!File.Exists(apiKeyFilePath))
            {
                Logger.LogRed("api.key file doesn't exist.");
                Logger.LogDarkYellow($"Please navigate to {Common.GetWorkingDirectory()} and create your api.key file, containing your OpenAI API key.");
                return;
            }
            string apiKey = File.ReadAllText(apiKeyFilePath);

            // Set the base URL
            client.BaseAddress = new Uri("https://api.openai.com");

            // Create the request content
            var requestData = new
            {
                model = "gpt-4",
                messages = new[]
                {
                    new
                    {
                        role = "system",
                        content = "You are a helpful assistant who has all the knowledge about the world and mechanics of Dungeons and Dragons 5E. When you respond, you only respond in an intended, prettified json format you are requested in."
                    },
                    new
                    {
                        role = "user",
                        content =
                        @$"Create a Dungeons and Dragons 5E NPC's character sheet.
                        This character should be a level {level} {choosenRace} {choosenClass}.
                        Respond in this json format:
                            {{
                              ""Name"": string,
                              ""Level"": int,
                              ""Race"": string,
                              ""Class"": string,
                              ""MaxHP"": int,
                              ""ArmorClass"": int,
                              ""ProficiencyBonus"": int,
                              ""Strength"": int,
                              ""Dexterity"": int,
                              ""Constitution"": int,
                              ""Intelligence"": int,
                              ""Wisdom"": int,
                              ""Charisma"": int,
                              ""SkillsProficiencies"": {{string, int}},
                              ""ToolsProficiencies"": string[],
                              ""Weapons"": string[],
                              ""Armor"": string,
                              ""Inventory"": string[],
                              ""Spells"": string[],
                              ""Backstory"": string
                            }}
                            Backstory should be max 120 words."
                    }
                }
            };

            string jsonRequest = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            // Set the authorization header
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            Console.WriteLine("Sending request");
            // Send the POST request
            HttpResponseMessage response = await client.PostAsync("/v1/chat/completions", content);
            Console.WriteLine("Response arrived!");

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                OpenAiChatResponse openAiChatResponse = JsonConvert.DeserializeObject<OpenAiChatResponse>(responseContent);
                string newCharacterJson = openAiChatResponse.choices[0].message.content;
                Console.WriteLine("Response:");
                Console.WriteLine(newCharacterJson);

                NewCharacterTemplate newCharacter = JsonConvert.DeserializeObject<NewCharacterTemplate>(newCharacterJson.Replace("\\r\\n", ""));

                File.WriteAllText($"{filePath}/{newCharacter.Name}.json", newCharacterJson);
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}\n{response.Headers}\n{response.Content}");
            }
        }
        catch (Exception ex)
        {
            throw;
        }
        finally { client.Dispose(); }
    }
}