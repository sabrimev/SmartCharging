using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCharging.Domain.Data.EntityFramework.Entities;

namespace SmartCharging.Domain.Data.EntityFramework.Entities;

internal class GroupConf : BaseConf<Group>
{
    public override void Configure(EntityTypeBuilder<Group> builder)
    {
        
    }
}
