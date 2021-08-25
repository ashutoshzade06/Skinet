using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {

        /*
        This interface ,is created tto overcome the disadvantages of Generic classes and give them a aility to use some 
        functionality like '.Include'
        */



         Expression<Func<T,bool>> Criteria{get;}
         List<Expression<Func<T,object>>> Includes{get;}

        Expression<Func<T,object>> OrderBy{get;}
        Expression<Func<T,object>> OrderByDescending{get;}


        int Take{get;}
        int Skip{get;}
        bool IsPaginEnabled{get;}


    }
}