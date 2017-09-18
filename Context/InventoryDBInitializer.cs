using System.Data.Entity;

namespace InventoryManagement.Context
{
    internal class InventoryDBInitializer : CreateDatabaseIfNotExists<InventoryDBContext>
    {
        protected override void Seed(InventoryDBContext  context)
        {
            base.Seed(context);
        }
    }
}