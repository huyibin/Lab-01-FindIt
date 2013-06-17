
namespace FindIt.Web.Extensions {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc.Html;
    using System.Web.Mvc;
    using System.Text;
    using FindIt.Web.Framework.UI.Paging;
    using FindIt.Web.Models.Common;


    public static class PagerHtmlExtension {
        //we have two pagers:
        //The first one can have custom routes
        //The second one just adds query string parameter
        public static MvcHtmlString Pager<TModel>(this HtmlHelper<TModel> html, PagerModel model) {

            var links = new StringBuilder();

            if (model.ShowTotalSummary && (model.TotalPages > 0)) {
                links.Append(string.Format(model.CurrentPageText, model.PageIndex + 1, model.TotalPages, model.TotalRecords));
                links.Append("&nbsp;");
            }
            if (model.ShowPagerItems && (model.TotalPages > 1)) {
                if (model.ShowFirst) {
                    if ((model.PageIndex >= 3) && (model.TotalPages > model.IndividualPagesDisplayedCount)) {
                        if (model.ShowIndividualPages) {
                            links.Append("&nbsp;");
                        }

                        model.RouteValues.page = 1;

                        if (model.UseRouteLinks) {
                            links.Append(html.RouteLink(model.FirstButtonText, model.RouteActionName, (object)model.RouteValues, new { title = "首页" }));
                        }
                        else {
                            links.Append(html.ActionLink(model.FirstButtonText, model.RouteActionName, (object)model.RouteValues, new { title = "首页" }));
                        }

                        if ((model.ShowIndividualPages || (model.ShowPrevious && (model.PageIndex > 0))) || model.ShowLast) {
                            links.Append("&nbsp;...&nbsp;");
                        }
                    }
                }
                if (model.ShowPrevious) {
                    if (model.PageIndex > 0) {
                        model.RouteValues.page = (model.PageIndex);

                        if (model.UseRouteLinks) {
                            links.Append(html.RouteLink(model.PreviousButtonText, model.RouteActionName, (object)model.RouteValues, new { title = "上一页" }));
                        }
                        else {
                            links.Append(html.ActionLink(model.PreviousButtonText, model.RouteActionName, (object)model.RouteValues, new { title = "上一页" }));
                        }

                        if ((model.ShowIndividualPages || model.ShowLast) || (model.ShowNext && ((model.PageIndex + 1) < model.TotalPages))) {
                            links.Append("&nbsp;");
                        }
                    }
                }
                if (model.ShowIndividualPages) {
                    int firstIndividualPageIndex = model.GetFirstIndividualPageIndex();
                    int lastIndividualPageIndex = model.GetLastIndividualPageIndex();
                    for (int i = firstIndividualPageIndex; i <= lastIndividualPageIndex; i++) {
                        if (model.PageIndex == i) {
                            links.AppendFormat("<span>{0}</span>", (i + 1).ToString());
                        }
                        else {
                            model.RouteValues.page = (i + 1);

                            if (model.UseRouteLinks) {
                                links.Append(html.RouteLink((i + 1).ToString(), model.RouteActionName, (object)model.RouteValues, new { title = String.Format("{0}页", (i + 1).ToString()) }));
                            }
                            else {
                                links.Append(html.ActionLink((i + 1).ToString(), model.RouteActionName, (object)model.RouteValues, new { title = String.Format("{0}页", (i + 1).ToString()) }));
                            }
                        }
                        if (i < lastIndividualPageIndex) {
                            links.Append("&nbsp;");
                        }
                    }
                }
                if (model.ShowNext) {
                    if ((model.PageIndex + 1) < model.TotalPages) {
                        if (model.ShowIndividualPages) {
                            links.Append("&nbsp;");
                        }

                        model.RouteValues.page = (model.PageIndex + 2);

                        if (model.UseRouteLinks) {
                            links.Append(html.RouteLink(model.NextButtonText, model.RouteActionName, (object)model.RouteValues, new { title = "上一页" }));
                        }
                        else {
                            links.Append(html.ActionLink(model.NextButtonText, model.RouteActionName, (object)model.RouteValues, new { title = "上一页" }));
                        }
                    }
                }
                if (model.ShowLast) {
                    if (((model.PageIndex + 3) < model.TotalPages) && (model.TotalPages > model.IndividualPagesDisplayedCount)) {
                        if (model.ShowIndividualPages || (model.ShowNext && ((model.PageIndex + 1) < model.TotalPages))) {
                            links.Append("&nbsp;...&nbsp;");
                        }

                        model.RouteValues.page = model.TotalPages;

                        if (model.UseRouteLinks) {
                            links.Append(html.RouteLink(model.LastButtonText, model.RouteActionName, (object)model.RouteValues, new { title = "尾页" }));
                        }
                        else {
                            links.Append(html.ActionLink(model.LastButtonText, model.RouteActionName, (object)model.RouteValues, new { title = "尾页" }));
                        }
                    }
                }
            }
            return MvcHtmlString.Create(links.ToString());
        }

        public static Pager Pager(this HtmlHelper helper, IPageableModel pagination) {
            return new Pager(pagination, helper.ViewContext);
        }
        public static Pager Pager(this HtmlHelper helper, string viewDataKey) {
            var dataSource = helper.ViewContext.ViewData.Eval(viewDataKey) as IPageableModel;

            if (dataSource == null) {
                throw new InvalidOperationException(string.Format("Item in ViewData with key '{0}' is not an IPagination.",
                                                                  viewDataKey));
            }

            return helper.Pager(dataSource);
        }
    }
}