﻿using Lecoati.LeBlender.Extension.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace Lecoati.LeBlender.Extension
{
    public class Helper
    {

        private static UmbracoHelper GetUmbracoHelper()
        {
            return new UmbracoHelper(UmbracoContext.Current);
        }

        public static bool IsFrontEnd()
        {
            return UmbracoContext.Current.IsFrontEndUmbracoRequest;
        }

        public static IPublishedContent GetCurrentContent()
        {
            if (UmbracoContext.Current.IsFrontEndUmbracoRequest)
            {
                return GetUmbracoHelper().AssignedContentItem;
            }
            else
            {
                return GetUmbracoHelper().TypedContent(HttpContext.Current.Request["id"].ToString());
            }
        }

        public static BlenderModel DeserializeBlenderModel(dynamic model) {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<BlenderModel>(model.ToString());
        }

        public static string GetInnerMessage(Exception ex)
        {
            if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
                return ex.InnerException.Message;

            return ex.Message;
        }

    }
}