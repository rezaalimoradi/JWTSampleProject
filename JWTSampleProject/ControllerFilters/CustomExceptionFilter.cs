﻿using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;

namespace JWTSampleProject.ControllerFilters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly IModelMetadataProvider _modelMetadataProvider;

        public CustomExceptionFilter(
            IModelMetadataProvider modelMetadataProvider)
        {
            _modelMetadataProvider = modelMetadataProvider;
        }

        public void OnException(ExceptionContext context)
        {
            var result = new ViewResult { ViewName = "خطای بومی سازی شده" };
            result.ViewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState);
            result.ViewData.Add("Exception", context.Exception);

            // Here we can pass additional detailed data via ViewData
            context.ExceptionHandled = true; // mark exception as handled
            context.Result = result;
        }
    }
}
