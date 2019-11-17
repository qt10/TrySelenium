namespace SeleniumDemoBasic.PageObjectModelApproach.Pages
{
    public interface INavigatable<T> where T: Page
    {
        T Navigate();
    }
}
