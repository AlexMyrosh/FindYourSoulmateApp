﻿using DAL.Repositories.Interfaces;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }

        public IInterestRepository InterestRepository { get; }

        public void ClearTracking();

        public Task SaveChangesAsync();
    }
}