using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley.GameData.Buildings;
namespace RealisticSiloCapacity
{
    public class ModEntry : Mod
    {
        public override void Entry(IModHelper? helper)
        {
            if (helper == null)
            {
                return;
            }
            helper.Events.Content.AssetRequested += this.OnAssetRequested;
        }

        private void OnAssetRequested(object? sender, AssetRequestedEventArgs e)
        {
            if (!e.NameWithoutLocale.IsEquivalentTo("Data/Buildings"))
            {
                return;
            }

            e.Edit(asset =>
            {
                IDictionary<string, BuildingData> data = asset.AsDictionary<string, BuildingData>().Data;
                if (data.TryGetValue("Silo", out BuildingData? silodata))
                {
                    if (silodata != null)
                    {
                        silodata.HayCapacity = 325000;
                    }
                }
            });
        }
    }
}
