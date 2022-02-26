using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCharging.Domain.Data.EntityFramework.Entities;
using SmartCharging.Domain.Data.EntityFramework.Configurations.Base;

namespace SmartCharging.Domain.Data.EntityFramework.Configurations;

internal class ConnectorCong : BaseConf<Connector, int>
{
    public override void Configure(EntityTypeBuilder<Connector> builder)
    {
        
    }
}
