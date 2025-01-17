﻿using System;
using System.Threading;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
namespace EmprendeUCR.Infrastructure.Core
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        private readonly ILogger<ApplicationDbContext> _logger;
        private IDbContextTransaction? _currentTransaction;
        public IDbContextTransaction? GetCurrentTransaction() => _currentTransaction;
        public bool HasActiveTransaction => _currentTransaction != null;
        public async Task BeginTransactionAsync()
        {
            if (_currentTransaction != null) return;
            _currentTransaction = await Database.BeginTransactionAsync();
        }
        public ApplicationDbContext(DbContextOptions options, ILogger<ApplicationDbContext> logger) : base(options)
        {
            _logger = logger;
        }
        public async Task CommitTransactionAsync()
        {
            if (_currentTransaction == null) throw new InvalidOperationException($"There is no current transaction.");
            try
            {
                await SaveChangesAsync();
                await _currentTransaction.CommitAsync();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public async Task SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            // After executing this line all the changes
            // performed through the DbContext will be committed
            await base.SaveChangesAsync(cancellationToken);
        }
    }
}