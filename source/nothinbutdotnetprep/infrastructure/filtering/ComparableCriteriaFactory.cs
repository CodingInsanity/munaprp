using System;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class ComparableCriteriaFactory<ItemToMatch,PropertyType> where PropertyType : IComparable<PropertyType>
    {
        PropertyAccessor<ItemToMatch, PropertyType> accessor;

        public ComparableCriteriaFactory(PropertyAccessor<ItemToMatch, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public Criteria<ItemToMatch> between(PropertyType start, PropertyType end)
        {
            return new AnonymousCriteria<ItemToMatch>(x => accessor(x).CompareTo(start) >= 0 && accessor(x).CompareTo(end) <= 0);
        }
    }
}