﻿namespace Basis.Domain.Interfaces
{
    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
