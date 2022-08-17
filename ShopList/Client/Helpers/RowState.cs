namespace ShopList.Client.Helpers
{
  public class RowState<TItem>
  {
    public TItem Item { get; set; }
    public bool IsSelected { get; set; }
  }
}
