﻿using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.DAL.Repositories.Interface.Capacity;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.Capacity
{
    public class DepartmentalTrainingMemberRepository : BaseRepository<DepartmentalTrainingMember>, IDepartmentalTrainingMemberRepository
    {
        public DepartmentalTrainingMemberRepository(
            GENERICWriteOnlyCtx ecommarceWriteOnlyCtx,
            GENERICReadOnlyCtx ecommarceReadOnlyCtx)
            : base(ecommarceWriteOnlyCtx, ecommarceReadOnlyCtx) { }
    }
}

