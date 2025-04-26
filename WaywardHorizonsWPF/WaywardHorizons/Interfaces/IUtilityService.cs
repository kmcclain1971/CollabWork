using WaywardHorizons.Characters;
using WaywardHorizons.Helpers;

namespace WaywardHorizons.Interfaces
{
    public interface IUtilityService
    {
        List<Event> GenerateEvents(int locationId);
        string[] GetArrayTextFromExternalFile(string path);
        string GetNextStep(int locationId);
        void GetNextStep(object locationId);
        int GetRandomNumber(int max);
        int GetRandomNumber(int min, int max);
        string GetStepText(string textType);
        string GetTextFromExternalFile(string path);
        void WriteHeader(Person adventurer);

    }
}