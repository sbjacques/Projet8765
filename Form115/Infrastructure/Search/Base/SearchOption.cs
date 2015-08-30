namespace Form115.Infrastructure.Search.Base
{
    internal abstract class SearchOption : SearchBase {
        protected SearchBase SearchBase;

        protected SearchOption(SearchBase sb) {
            SearchBase = sb;
        }


    }
}