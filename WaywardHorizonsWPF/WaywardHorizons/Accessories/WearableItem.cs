namespace WaywardHorizons.Accessories
{
    internal class WearableItem : Item
    {
        public string WearableLocation = "neck";
        public WearableItem()
        {
            ItemName = "Amulet";
        }

        public virtual string DescribeItem()
        {
            return $"{ItemName} can be worn at location: {WearableLocation}";
        }

    }
}
