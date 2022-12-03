using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scorilenos
{
        public interface WatchingFilms

        {
            IEnumerable<WatchingItem> GetAllElements();
            WatchingItem GetElementById(Guid id);
           
        }
    
}


public enum day
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday,
}


public enum genrefilm
{
    Romance,
    Comedy,
    Drama,
    Fantasy,
    Adventure,
    
}

public enum dayTimeviewing
{
    ten = 10,
    twelve = 12,
    fourteen = 14,
}


public enum eveningTimeviewing
{
    sixteen = 16,
    eighteen = 18,
    twenty = 20,
    twentytwo = 22,
}

public class WatchingItem
{
    public Guid Id { get; set; }
    public timeOfDay TimeOfDay { get; set; }    
    public day Day { get; set; }
    public dayTimeviewing dayTimeviewing { get; set; }
    public eveningTimeviewing eveningTimeviewing { get; set; }
    public int Romance { get; set; }
    public int Comedy { get; set; } 
    public int Drama { get; set; }
    public int Fantasy { get; set; }
    public int Adventure { get; set; }
    public int viewingDayTime => 3 + (int)(viewingDayTime / 0.8889);
    public int viewingEveningTime => 4 + (int)(viewingEveningTime / 0.8889);
    public string viewingChance { get; set; }

}


public WatchingItem GetElementById(Guid id, int viewingDayTime)
{
    var rng = new Random();
    WatchingItem r = new WatchingItem
    {
        Id = id,
        TimeOfDay = TimeOfDayRandom(),
        Day = DayRandom(),
        dayTimeviewing = dayTimeviewingRandom(),
        eveningTimeviewing = eveningTimeviewingRandom(),
        Romance = RomanceRandom(),
        Comedy = ComedyRandom(),
        Drama = DramaRandom(),
        Fantasy = FantasyRandom(),
        Adventure = AdventureRandom(),
        viewingDayTime = rng.Next(1, 3),
        viewingEveningTime = rng.Next(1, 4),
        viewingChance = ViewingChanceRandom()
    };

    return r;
}

public string CombineIntegers(int a, int b) => a + "." + b;

int AdventureRandom()
{
    throw new NotImplementedException();
}

string ViewingChanceRandom()
{
    throw new NotImplementedException();
}

int FantasyRandom()
{
    throw new NotImplementedException();
}

timeOfDay TimeOfDayRandom()
{
    throw new NotImplementedException();
}

day DayRandom()
{
    throw new NotImplementedException();
}

dayTimeviewing dayTimeviewingRandom()
{
    throw new NotImplementedException();
}

eveningTimeviewing eveningTimeviewingRandom()
{
    throw new NotImplementedException();
}

int RomanceRandom()
{
    throw new NotImplementedException();
}

int ComedyRandom()
{
    throw new NotImplementedException();
}

int DramaRandom()
{
    throw new NotImplementedException();
}


