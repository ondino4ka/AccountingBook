using System.Collections.Generic;

namespace AccountingBookCommon
{
  public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SubCategory> SubCategories { get; set; }
    }
}
