using WaywardHorizons.Characters;

namespace WaywardHorizons.Interfaces
{
    public interface IUtilityService
    {
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