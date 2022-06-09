using System.Text.Json;
using Microsoft.AspNetCore.Http;
#pragma warning disable CS8618

namespace dojodachi.Models
{
    public class Dojodachi
    {
        public int Happiness {get; set;}
        public int Fullness {get; set;}
        public int Energy {get; set;}
        public int Meals {get; set;}
        public string Mood {get; set;}
        public Dojodachi()
        {
            Happiness = 20;
            Fullness = 20;
            Energy = 50;
            Meals = 3;
            Mood = "neutral";
        }

        Random rand = new Random();

        public string feed()
        {
            if(Meals == 0)
            {
                Mood = "angry";
                return "You don't have any meals left!";
            }
            
            if(rand.Next(4) == 0){
                Mood = "angry";
                Meals--;
                return "Dojodachi did not want to eat so they threw it on the ground!";
            }
            else
            {
                Mood = "eat";
                int fullModifier = rand.Next(5,11);
                Fullness += fullModifier;
                Meals--;
                return $"Dojodachi ate it all up gladly! Gained {fullModifier} Fullness!";
            }
        }

        public string play()
        {
            if(Energy == 0)
            {
                Mood = "tired";
                return "Can't you see that Dojodachi is too tired to play...";
            }
            if(rand.Next(4) == 0)
            {
                Mood = "angry";
                Energy -= 5;
                return "Dojodachi did not want to play and instead just banged its head against a wall and lost 5 Energy!";
            }
            else
            {
                Mood = "happy";
                int happinessModifier = rand.Next(5,11);
                Energy -= 5;
                Happiness += happinessModifier;
                return $"Dojodachi was happy to play! Gained {happinessModifier} Happiness!";
            }
        }

        public string work()
        {
            if(Energy == 0)
            {
                Mood = "tired";
                return "Whoah there, slavedriver! Dojodachi is pooped and can no longer work!";
            }
            int mealModifier = rand.Next(1,4);
            Meals += mealModifier;
            Energy -= 5;
            Mood = "work";
            return $"Dojodachi works like a dog, expending 5 Energy. But we gain {mealModifier} meal(s)!";
        }

        public string sleep()
        {
            Energy += 15;
            Fullness -= 5;
            Happiness -= 5;
            return "Dojodachi gets some good sleep! Gained 15 Energy but lost 5 Fullness and 5 Happiness.";
        }

        public bool checkDead()
        {
            if(Fullness <= 0 || Happiness <= 0)
            {
                Mood = "dead";
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkWin()
        {
            if (Fullness >= 100 && Happiness >= 100 && Energy >= 100)
            {
                Mood = "win";
                return true;
            }
            else
            {
                return false;
            }
        }

        public Dictionary<string,object> toDict()
        {
            Dictionary<string,object> dojodachiDict = new Dictionary<string,object>()
            {
                {"Happiness", this.Happiness},
                {"Fullness", this.Fullness},
                {"Energy", this.Energy},
                {"Meals", this.Meals},
                {"Mood", this.Mood}
            };
            
            return dojodachiDict;
        }
    }

    public static class SessionExtensions
    {
        // We can call ".SetObjectAsJson" just like our other session set methods, by passing a key and a value
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            // This helper function simply serializes the object to JSON and stores it as a string in session
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        // generic type T is a stand-in indicating that we need to specify the type on retrieval
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            string value = session.GetString(key);
            // Upon retrieval the object is deserialized based on the type we specified
            return value == null ? default(T) : JsonSerializer.Deserialize<T>(value);
        }
    }

}