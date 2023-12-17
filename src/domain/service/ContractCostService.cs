using AnimalsService.Config;
using AnimalsService.Dictionary;
using AnimalsService.Infrastructure;
using AnimalsService.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Sieve.Models;
using Sieve.Services;

namespace AnimalsService.Service
{
  public class ContractCostService(
    ApplicationContext context,
    ISieveProcessor sieve
  ) : BaseService<ContractCost>(context, sieve)
  {
    public override ContractCost Create(ContractCost entity)
    {
      if (entity.Municipalities != null && entity.Municipalities.Id != 0)
      {
        Municipality? municipalities = context
          .Municipalities
          .Find(entity.Municipalities.Id);
        if (municipalities != null)
        {
          entity.Municipalities = municipalities;
        }
      }

      context.ContractCosts.Add(entity);
      context.SaveChanges();
      return entity;
    }

    public override void Delete(long id)
    {
      ContractCost entity =
        GetOne(id) ?? throw new InvalidOperationException("Запись не найдена");
      context.ContractCosts.Remove(entity);
      context.SaveChanges();
    }

    public override bool Exists(long id)
    {
      return context.ContractCosts.FirstOrDefault(e => e.Id == id) != null;
    }

    public override Pagination<ContractCost> GetList(SieveModel param)
    {
      IIncludableQueryable<ContractCost, object> model = context
        .ContractCosts
        .Include(e => e.Municipalities)
        .Include(e => e.Contract);

      IEnumerable<ContractCost> data = sieve.Apply(param, model);
      int Total = sieve
        .Apply(new SieveModel { Filters = param.Filters }, model)
        .Count();
      return new Pagination<ContractCost> { Data = data, Total = Total };
    }

    public override ContractCost? GetOne(long id)
    {
      ContractCost? organization = context
        .ContractCosts
        .Include(e => e.Municipalities)
        .Include(e => e.Contract)
        .FirstOrDefault(e => e.Id == id);

      return organization;
    }

    public override ContractCost Update(long id, ContractCost entity)
    {
      ContractCost? contactCost = GetOne(id);
      if (id != entity.Id || contactCost == null)
      {
        throw new InvalidOperationException("Запись не найдена");
      }
      if (entity.Municipalities != null && entity.Municipalities.Id != 0)
      {
        Municipality? municipalities = context
          .Municipalities
          .Find(entity.Municipalities.Id);
        if (municipalities != null)
        {
          contactCost.Municipalities = municipalities;
        }
      }

      context.Entry(contactCost).CurrentValues.SetValues(entity);
      context.SaveChanges();
      return contactCost;
    }
  }
}
