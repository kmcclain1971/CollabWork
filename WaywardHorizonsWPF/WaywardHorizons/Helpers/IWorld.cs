
namespace WaywardHorizons.Environment
{
    internal interface IWorld
    {
        List<Location> Locations { get; set; }

        string GetLocationList();
    }
}