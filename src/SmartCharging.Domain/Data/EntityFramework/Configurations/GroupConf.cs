﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCharging.Domain.Data.EntityFramework.Entities;
using SmartCharging.Domain.Data.EntityFramework.Configurations.Base;

namespace SmartCharging.Domain.Data.EntityFramework.Configurations;

internal class GroupConf : BaseConf<Group, Guid>
{
    public override void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(250);
    }
}
