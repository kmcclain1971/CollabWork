using WaywardHorizons.Characters;
using WaywardHorizons.Environment;

namespace WaywardHorizons.Helpers
{
    internal interface IUtility
    {
        void Clear();
        List<Location> GenerateLocations();
        string[] GetArrayTextFromExternalFile(string path);
        string GetNextStep(int locationId);
        void GetNextStep(object locationId);
        int GetRandomNumber(int max);
        int GetRandomNumber(int min, int max);
        string GetStepText(string textType);
        string GetTextFromExternalFile(string path);
        void Pause();
        void Print(string message);

        void WriteTitle();
        void WriteHeader(Person adventurer);
        void WriteFooter();
    }
}