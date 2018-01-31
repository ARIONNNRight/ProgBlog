using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgrammersBlog.CommonHelpers
{
    public static class ImageHelper
    {
        public static MvcHtmlString CustomImage(this HtmlHelper htmlHelper,
                                                                 string src, string alt, int width, int height)
        {
            var imageTag = new TagBuilder("image");
            imageTag.MergeAttribute("src", src);
            imageTag.MergeAttribute("alt", alt);
            imageTag.MergeAttribute("width", width.ToString());
            imageTag.MergeAttribute("height", height.ToString());
            imageTag.MergeAttribute("class", "img-thumbnail");
            imageTag.GenerateId("idCustomImage");
            return MvcHtmlString.Create(imageTag.ToString(TagRenderMode.SelfClosing));
        }
    }
}