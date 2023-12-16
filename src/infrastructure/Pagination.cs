namespace AnimalsService.Infrastructure
{
  public class Pagination<T>
  {
    public IEnumerable<T> Data = [];
    public int Total;
  }
}
