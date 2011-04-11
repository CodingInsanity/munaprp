using System;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class CriteriaBuilder<ItemToMatch, PropertyType>
    {
        PropertyAccessor<ItemToMatch, PropertyType> accessor;

        public CriteriaBuilder(PropertyAccessor<ItemToMatch, PropertyType> accessor)
        {
            this.accessor = accessor;
        }


        public Criteria<ItemToMatch> equal_to(PropertyType value)
        {
            return new AnonymousCriteria<ItemToMatch>(x => accessor(x).Equals(value));
        }

        public Criteria<ItemToMatch> equal_to_any(params PropertyType[] values)
        {
            return new AnonymousCriteria<ItemToMatch>(x =>
                                                          {
                                                              foreach (var value in values)
                                                              {
                                                                  if (accessor(x).Equals(value))
                                                                  {
                                                                      return true;
                                                                  }
                                                              }
                                                              return false;
                                                          });
        }
    }
}