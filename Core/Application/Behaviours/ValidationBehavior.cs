using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Behaviours
{


    //public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    //{
    //    private readonly IEnumerable<IValidator<TRequest>> _validators;

    //    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    //    {
    //        _validators = validators;
    //    }




    //    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    //    {
    //        if (_validators.Any())
    //        {


    //            var validationContext = new ValidationContext<TRequest>(request);

    //            var validationResult = await Task.WhenAll(_validators.Select(x => x.ValidateAsync(validationContext, cancellationToken)));
    //            var errors = validationResult.SelectMany(x => x.Errors).Where(x => x != null).ToList();
    //            if (errors.Count != 0)
    //            {

    //                throw new System.ComponentModel.DataAnnotations.ValidationException(errors.ToString());
    //            }


    //        }

    //        return await next();
    //    }
    //}


    public class ValidationBehavior<TRequest, TRespone> : IPipelineBehavior<TRequest, TRespone>
        where TRequest : IRequest<TRespone>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }
        public async Task<TRespone> Handle(TRequest request, RequestHandlerDelegate<TRespone> next, CancellationToken cancellationToken)
        {
            if (validators.Any())
            {
                var validationContext = new ValidationContext<TRequest>(request);

                var validationResult = await Task.WhenAll(validators.Select(x => x.ValidateAsync(validationContext, cancellationToken)));
                var errors = validationResult.SelectMany(x => x.Errors).Where(x => x != null).ToList();
                if (errors.Count != 0)
                {
                    foreach (var item in errors)
                    {
                        throw new ValidationException(item.ErrorMessage);
                    }
                  
                }
            }
            return await next();
        }
        //public async Task<TRespone> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TRespone> next)
        //{
        //    if (validators.Any())
        //    {
        //        var validationContext = new ValidationContext<TRequest>(request);

        //        var validationResult = await Task.WhenAll(validators.Select(x => x.ValidateAsync(validationContext, cancellationToken)));
        //        var errors = validationResult.SelectMany(x => x.Errors).Where(x => x != null).ToList();
        //        if (errors.Count != 0)
        //        {
        //            //string error = "";
        //            //foreach (var item in errors)
        //            //    error += item.ErrorMessage + "\n";
        //            throw new ValidationException(errors);
        //        }
        //    }
        //    return await next();
        //}
    }

}
