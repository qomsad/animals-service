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
  public class OrganizationService(
    ApplicationContext context,
    ISieveProcessor sieve
  ) : BaseService<Organization>(context, sieve)
  {
    public override Organization Create(Organization entity)
    {
      if (entity.LegalType != null && entity.LegalType.Id != 0)
      {
        DicLegalType? legalType = context.LegalTypes.Find(entity.LegalType.Id);
        if (legalType != null)
        {
          entity.LegalType = legalType;
        }
      }
      if (entity.OrganizationType != null && entity.OrganizationType.Id != 0)
      {
        DicOrganizationType? organizationType = context
          .OrganizationTypes
          .Find(entity.OrganizationType.Id);
        if (organizationType != null)
        {
          entity.OrganizationType = organizationType;
        }
      }

      context.Organizations.Add(entity);
      context.SaveChanges();
      return entity;
    }

    public override void Delete(long id)
    {
      Organization entity =
        GetOne(id) ?? throw new InvalidOperationException("Запись не найдена");
      context.Organizations.Remove(entity);
      context.SaveChanges();
    }

    public override bool Exists(long id)
    {
      return context.Organizations.FirstOrDefault(e => e.Id == id) != null;
    }

    public override Pagination<Organization> GetList(SieveModel param)
    {
      IIncludableQueryable<Organization, object> model = context
        .Organizations
        .Include(e => e.LegalType)
        .Include(e => e.OrganizationType);

      IEnumerable<Organization> data = sieve.Apply(param, model);
      int Total = sieve
        .Apply(new SieveModel { Filters = param.Filters }, model)
        .Count();
      return new Pagination<Organization> { Data = data, Total = Total };
    }

    public override Organization? GetOne(long id)
    {
      Organization? organization = context
        .Organizations
        .Include(e => e.LegalType)
        .Include(e => e.OrganizationType)
        .FirstOrDefault(e => e.Id == id);

      return organization;
    }

    public override Organization Update(long id, Organization entity)
    {
      Organization? organization = GetOne(id);
      if (id != entity.Id || organization == null)
      {
        throw new InvalidOperationException("Запись не найдена");
      }

      if (entity.LegalType != null && entity.LegalType.Id != 0)
      {
        DicLegalType? legalType = context.LegalTypes.Find(entity.LegalType.Id);
        if (legalType != null)
        {
          organization.LegalType = legalType;
        }
      }
      if (entity.OrganizationType != null && entity.OrganizationType.Id != 0)
      {
        DicOrganizationType? organizationType = context
          .OrganizationTypes
          .Find(entity.OrganizationType.Id);
        if (organizationType != null)
        {
          organization.OrganizationType = organizationType;
        }
      }

      context.Entry(organization).CurrentValues.SetValues(entity);
      context.SaveChanges();
      return organization;
    }
  }
}
