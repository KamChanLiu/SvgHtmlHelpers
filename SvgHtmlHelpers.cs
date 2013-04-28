using System;
using System.Linq;
using System.Web.Mvc;

namespace SvgHtmlHelpers
{
    public static class SvgHtmlHelpers
    {
        private const float DefaultFontSize = 12;
        private const string DefaultFontFamily = "Arial";
        private const double DefaultStrokeWidth = 1;

        public static MvcHtmlString SvgLine(
            this HtmlHelper htmlHelper,
            float x1,
            float y1,
            float x2,
            float y2,
            string id = null,
            string cssClass = null,
            string stroke = null,
            double strokeWidth = DefaultStrokeWidth,
            string fill = null)
        {
            var tagBuilder = new TagBuilder("line");

            tagBuilder.Attributes.Add("x1", x1.ToString());
            tagBuilder.Attributes.Add("x2", x2.ToString());
            tagBuilder.Attributes.Add("y1", y1.ToString());
            tagBuilder.Attributes.Add("y2", y2.ToString());

            if (!string.IsNullOrWhiteSpace(id))
            {
                tagBuilder.Attributes.Add("id", htmlHelper.Encode(id));
            }

            if (!string.IsNullOrWhiteSpace(cssClass))
            {
                tagBuilder.Attributes.Add("class", htmlHelper.Encode(cssClass));
            }

            string style = string.Empty;
            style += !string.IsNullOrWhiteSpace(stroke) ? string.Format("stroke: {0};", stroke) : string.Empty;
            style += string.Format("stroke-width: {0};", strokeWidth);
            style += !string.IsNullOrWhiteSpace(fill) ? string.Format("fill: {0};", fill) : string.Empty;

            if (!string.IsNullOrWhiteSpace(style))
            {
                tagBuilder.Attributes.Add("style", htmlHelper.Encode(style));
            }

            return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString SvgPolyLine(
            this HtmlHelper htmlHelper,
            Tuple<float, float>[] points,
            string id = null,
            string cssClass = null,
            string stroke = null,
            double strokeWidth = DefaultStrokeWidth,
            string fill = null,
            string styles = null)
        {
            var tagBuilder = new TagBuilder("polyline");

            string pointValues = points.Aggregate(string.Empty,
                                                  (x, p) =>
                                                  x + string.Format("{0}, {1} ", p.Item1.ToString(), p.Item2.ToString()));

            if (!string.IsNullOrWhiteSpace(pointValues))
            {
                tagBuilder.Attributes.Add("points", pointValues);
            }

            if (!string.IsNullOrWhiteSpace(id))
            {
                tagBuilder.Attributes.Add("id", htmlHelper.Encode(id));
            }

            if (!string.IsNullOrWhiteSpace(cssClass))
            {
                tagBuilder.Attributes.Add("class", htmlHelper.Encode(cssClass));
            }

            string style = string.Empty;
            style += !string.IsNullOrWhiteSpace(stroke) ? string.Format("stroke: {0};", stroke) : string.Empty;
            style += string.Format("stroke-width: {0};", strokeWidth);
            style += !string.IsNullOrWhiteSpace(fill) ? string.Format("fill: {0};", fill) : string.Empty;
            style += !string.IsNullOrWhiteSpace(styles) ? styles : string.Empty;

            if (!string.IsNullOrWhiteSpace(style))
            {
                tagBuilder.Attributes.Add("style", htmlHelper.Encode(style));
            }

            return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString SvgText(
            this HtmlHelper htmlHelper,
            float x,
            float y,
            string text,
            string id = null,
            string cssClass = null,
            float fontSize = DefaultFontSize,
            string colour = null,
            string fontFamily = DefaultFontFamily,
            string fontWeight = null,
            string textAnchor = null,
            string title = null)
        {
            var tagBuilder = new TagBuilder("text");

            tagBuilder.Attributes.Add("x", x.ToString());
            tagBuilder.Attributes.Add("y", y.ToString());
            tagBuilder.SetInnerText(text);

            if (!string.IsNullOrWhiteSpace(id))
            {
                tagBuilder.Attributes.Add("id", htmlHelper.Encode(id));
            }

            if (!string.IsNullOrWhiteSpace(title))
            {
                var titleTag = new TagBuilder("title") {InnerHtml = htmlHelper.Encode(title)};
                tagBuilder.InnerHtml += titleTag.ToString();
            }

            if (!string.IsNullOrWhiteSpace(cssClass))
            {
                tagBuilder.Attributes.Add("class", htmlHelper.Encode(cssClass));
            }

            string style = string.Empty;
            style += string.Format("font-size: {0};", fontSize);
            style += !string.IsNullOrWhiteSpace(colour) ? string.Format("colour: {0};", colour) : string.Empty;
            style += !string.IsNullOrWhiteSpace(fontFamily)
                         ? string.Format("font-family: {0};", fontFamily)
                         : string.Empty;
            style += !string.IsNullOrWhiteSpace(fontWeight)
                         ? string.Format("font-weight: {0};", fontWeight)
                         : string.Empty;
            style += !string.IsNullOrWhiteSpace(textAnchor)
                         ? string.Format("text-anchor: {0}", textAnchor)
                         : string.Empty;

            if (!string.IsNullOrWhiteSpace(style))
            {
                tagBuilder.Attributes.Add("style", htmlHelper.Encode(style));
            }

            return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString SvgCircle(
            this HtmlHelper htmlHelper,
            float x,
            float y,
            float radius,
            string id = null,
            string cssClass = null,
            string stroke = null,
            double strokeWidth = DefaultStrokeWidth,
            string fill = null,
            string styles = null)
        {
            var tagBuilder = new TagBuilder("circle");

            tagBuilder.Attributes.Add("cx", x.ToString());
            tagBuilder.Attributes.Add("cy", y.ToString());
            tagBuilder.Attributes.Add("r", radius.ToString());

            if (!string.IsNullOrWhiteSpace(id))
            {
                tagBuilder.Attributes.Add("id", htmlHelper.Encode(id));
            }

            if (!string.IsNullOrWhiteSpace(cssClass))
            {
                tagBuilder.Attributes.Add("class", htmlHelper.Encode(cssClass));
            }

            string style = string.Empty;
            style += !string.IsNullOrWhiteSpace(stroke) ? string.Format("stroke: {0};", stroke) : string.Empty;
            style += string.Format("stroke-width: {0};", strokeWidth);
            style += !string.IsNullOrWhiteSpace(fill) ? string.Format("fill: {0};", fill) : string.Empty;
            style += !string.IsNullOrWhiteSpace(styles) ? styles : string.Empty;

            if (!string.IsNullOrWhiteSpace(style))
            {
                tagBuilder.Attributes.Add("style", htmlHelper.Encode(style));
            }

            return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.Normal));
        }
    }
}