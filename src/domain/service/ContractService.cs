using AnimalsService.Config;
using AnimalsService.Infrastructure;
using AnimalsService.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Sieve.Models;
using Sieve.Services;

namespace AnimalsService.Service
{
  public class ContractService(ApplicationContext context, ISieveProcessor sieve)
    : BaseService<Contract>(context, sieve)
  {
    public override Contract Create(Contract entity)
    {
      if (entity.Contractor != null && entity.Contractor.Id != 0)
      {
        Organization? organization = context.Organizations.Find(entity.Contractor.Id);
        if (organization != null)
        {
          entity.Contractor = organization;
        }
      }
      if (entity.Customer != null && entity.Customer.Id != 0)
      {
        Organization? organization = context.Organizations.Find(entity.Customer.Id);
        if (organization != null)
        {
          entity.Customer = organization;
        }
      }

      context.Contracts.Add(entity);
      context.SaveChanges();
      return entity;
    }

    public override void Delete(long id)
    {
      Contract entity = GetOne(id) ?? throw new InvalidOperationException("Запись не найдена");
      context.Contracts.Remove(entity);
      context.SaveChanges();
    }

    public override bool Exists(long id)
    {
      return context.Contracts.FirstOrDefault(e => e.Id == id) != null;
    }

    public override Pagination<Contract> GetList(SieveModel param)
    {
      IIncludableQueryable<Contract, object?> model = context
        .Contracts
        .Include(e => e.Contractor)
        .Include(e => e.Customer)
        .Include(e => e.Contractor.Name)
        .Include(e => e.Customer.Name);

      IEnumerable<Contract> data = sieve.Apply(param, model);
      int Total = sieve.Apply(new SieveModel { Filters = param.Filters }, model).Count();
      return new Pagination<Contract> { Data = data, Total = Total };
    }

    public override Contract? GetOne(long id)
    {
      Contract? contract = context
        .Contracts
        .Include(e => e.Contractor)
        .Include(e => e.Customer)
        .Include(e => e.Contractor.LegalType)
        .Include(e => e.Contractor.OrganizationType)
        .Include(e => e.Customer.LegalType)
        .Include(e => e.Customer.OrganizationType)
        .Include(e => e.ContractCosts)
        .FirstOrDefault(e => e.Id == id);

      return contract;
    }

    public override Contract Update(long id, Contract entity)
    {
      Contract? contract = GetOne(id);
      if (id != entity.Id || contract == null)
      {
        throw new InvalidOperationException("Запись не найдена");
      }

      if (entity.Contractor != null && entity.Contractor.Id != 0)
      {
        Organization? organization = context.Organizations.Find(entity.Contractor.Id);
        if (organization != null)
        {
          contract.Contractor = organization;
        }
      }
      if (entity.Customer != null && entity.Customer.Id != 0)
      {
        Organization? organization = context.Organizations.Find(entity.Customer.Id);
        if (organization != null)
        {
          contract.Customer = organization;
        }
      }

      context.Entry(contract).CurrentValues.SetValues(entity);
      context.SaveChanges();
      return contract;
    }
  }
}
